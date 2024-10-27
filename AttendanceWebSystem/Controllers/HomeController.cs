using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace AttendanceWebSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            // Validate the username and password
            if (username == "teacher" && password == "123")
            {
                // Redirect to TeacherPage/Index.cshtml with a success flag
                TempData["LoginSuccess"] = true;
                return RedirectToAction("Index", "TeacherPage");
            }

            // If validation fails, return to the login page with an error message
            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }
    }
}