using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Buoi3.Controllers
{
    public class StudentController : Controller
    {
        // Static list to store registered students
        private static List<StudentRegistration> registeredStudents = new List<StudentRegistration>();

        // GET: /Student/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Student/Index
        [HttpPost]
        public IActionResult Index(StudentRegistration model)
        {
            if (ModelState.IsValid)
            {
                // Add the student to the list
                registeredStudents.Add(model);

                // Redirect to ShowKQ with the submitted data
                return RedirectToAction("ShowKQ", new { model.MSSV, model.HoTen, model.ChuyenNganh });
            }

            return View(model);
        }

        // GET: /Student/ShowKQ
        public IActionResult ShowKQ(string MSSV, string HoTen, string ChuyenNganh)
        {
            // Count students with the same major
            int sameMajorCount = registeredStudents.Count(s => s.ChuyenNganh == ChuyenNganh);

            ViewBag.Message = $"Cảm ơn bạn {MSSV} - {HoTen} đã đăng ký chuyên ngành {ChuyenNganh}";
            ViewBag.SameMajorCount = sameMajorCount;

            return View();
        }
    }

    // Model for student registration
    public class StudentRegistration
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }
        public string ChuyenNganh { get; set; }
    }
}
