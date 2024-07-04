using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_hareem.Models;

namespace WebApp_hareem.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("role") == "user")
            {
return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

      
        public IActionResult AboutUs()
        {
            return View();
        }

		public IActionResult Products()
		{
			return View();
		}
		public IActionResult ContactUs()
		{
			return View();
		}

	}
}