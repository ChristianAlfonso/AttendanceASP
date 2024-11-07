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
    
    
    private static string _currentClassCode;

    

    [HttpPost]
    public IActionResult GenerateClassCode()
    {
        var random = new Random();
        var classCode = random.Next(100000, 999999).ToString(); // Generate a 6-digit random code

        // Save the class code to a shared variable
        _currentClassCode = classCode;

        return Json(new { classCode });
    }

    [HttpGet]
    public IActionResult GetClassCode()
    {
        return Json(new { classCode = _currentClassCode });
    }
    
    private void SaveClassCodeToDatabase(string classCode)
    {
        // Implement your database save logic here
    }
    } 
}