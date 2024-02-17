using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:44312";
        options.Audience = "IS4API";
    });*/

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("Cookies")
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:44312";
        options.Audience = "IS4API";
    })
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:44312";
        options.ClientId = "zorro";
        options.ResponseType = "code";
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("fullaccess");
        options.Scope.Add("roles");
        options.ClaimActions.MapUniqueJsonKey("role", "role");
        options.SaveTokens = true;
    });

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("Deactivate", policy =>
    {
        policy.RequireRole("Admin Manager");
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("email");
    });
});

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
