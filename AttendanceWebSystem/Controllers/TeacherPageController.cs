using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AttendanceWebSystem.Models;
using Newtonsoft.Json;

namespace AttendanceWebSystem.Controllers
{
    public class TeacherPageController : Controller
    {
        private static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            if (TempData["LoginSuccess"] is bool loginSuccess && loginSuccess)
            {
                ViewBag.LoginSuccess = true;
            }

            if (TempData["SubmittedStudent"] != null)
            {
                var student = JsonConvert.DeserializeObject<Student>(TempData["SubmittedStudent"].ToString());
                students.Add(student);
            }

            ViewBag.Students = students;

            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.StudentNo == student.StudentNo);
            if (existingStudent != null)
            {
                existingStudent.PCNo = student.PCNo;
                existingStudent.StudentName = student.StudentName;
                existingStudent.StudentPassword = student.StudentPassword;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteStudent(string studentNo)
        {
            var student = students.FirstOrDefault(s => s.StudentNo == studentNo);
            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}