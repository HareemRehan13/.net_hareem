using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_hareem.Models;

namespace WebApp_hareem.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") == "user")
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
        public IActionResult UserProducts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserProducts(UserProduct upro)
        {
            if (ModelState.IsValid)
            {
                return Content("Data is in correct format.");
            }
            else
            {
                ViewBag.msg = "Data not valid";
                return View();
            }

        }
    }
}