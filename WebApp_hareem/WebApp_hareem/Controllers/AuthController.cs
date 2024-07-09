using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace WebApp_hareem.Controllers
{
    public class AuthController : Controller
    {
        public bool IsAuthenticated { get; private set; }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(string email, string password)
        {
            bool IsAuthentication = false;
            bool IsAdmin = false;
            ClaimsIdentity identity = null;
            if (email == "admin@gmail.com" && password == "123")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Hareem"),
                    new Claim(ClaimTypes.Role, "Admin"),
                }
               , CookieAuthenticationDefaults.AuthenticationScheme);
                IsAuthentication = true;
                IsAdmin = true;


                return RedirectToAction("Index");
            }

            else if (email == "user@gmail.com" && password == "123")
            {

                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "User1"),
                    new Claim(ClaimTypes.Role, "User"),
                }
               , CookieAuthenticationDefaults.AuthenticationScheme);
                IsAuthentication = true;
                IsAdmin = false;

                return RedirectToAction("Index", "Home");
            }
            if(IsAuthenticated && IsAdmin)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if(IsAuthenticated && IsAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                IsAuthenticated = false;
            }
            if(IsAuthenticated && IsAdmin)
            {
                var principal = new ClaimsPrincipal(identity);
                var login= HttpContext.SignInAsync
                (CookieAuthenticationDefaults.AuthenticationScheme,principal);
                return RedirectToAction("Index", "Admin");
            }
            else if (IsAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync
                (CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        
        } 
        public IActionResult Logout(){
                var login = HttpContext.SignOutAsync
               (CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Auth");
            }
    }
}
