using Microsoft.AspNetCore.Mvc;

namespace WebApp_hareem.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email=="hareem@gmail.com" && password == "123")
            {
                HttpContext.Session.SetString("adminemail", email);
                HttpContext.Session.SetString("role", "admin");
                return RedirectToAction("Index");
            }
            else if (email == "user@gmail.com" && password == "123")
            {
                HttpContext.Session.SetString("useremail", email);
                HttpContext.Session.SetString("role", "user");
                return RedirectToAction("Index","Home");
            }
            else
            {
             return View();
            }
           
        }
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("adminemail");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Login");
        }
        public IActionResult UserLogout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("useremail");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Login");
        }
    }
}
