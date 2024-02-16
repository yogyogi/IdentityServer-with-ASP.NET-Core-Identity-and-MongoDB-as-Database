using Microsoft.AspNetCore.Mvc;

namespace ISClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
