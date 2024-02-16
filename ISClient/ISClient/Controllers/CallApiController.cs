using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ISClient.Controllers
{
    [Authorize]
    public class CallApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var weather = new List<WeatherForecast>();
            using (var client = new HttpClient())
            {
                client.SetBearerToken(accessToken);
                var result = await client.GetAsync("https://localhost:6001/WeatherForecast");
                if (result.IsSuccessStatusCode)
                {
                    var model = await result.Content.ReadAsStringAsync();
                    weather = JsonConvert.DeserializeObject<List<WeatherForecast>>(model);
                }
                else
                {
                    throw new Exception("Failed");
                }
            }
            return View(weather);
        }
    }
}
