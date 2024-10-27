using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AttendanceWebSystem.Controllers
{
    public class TeacherPageController : Controller
    {
        public IActionResult Index()
        {
            if (TempData["LoginSuccess"] is bool loginSuccess && loginSuccess)
            {
                ViewBag.LoginSuccess = true;
            }
            return View();
        }
    }
}