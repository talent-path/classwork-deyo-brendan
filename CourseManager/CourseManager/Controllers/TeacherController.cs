using System;
using System.Collections.Generic;
using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Services;

namespace CourseManager.Controllers
{
    public class TeacherController : Controller
    {
        CourseService _service = new CourseService();

        public TeacherController()
        {
        }

        public IActionResult Index()
        {
            List<Teacher> teachers = _service.GetAllTeachers();
            return View(teachers);
        }






    }
}
