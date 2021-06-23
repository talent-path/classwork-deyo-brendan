using System;
using System.Collections.Generic;
using CourseManager.Models;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Services;
using CourseManager.Exceptions;

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

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View(_service.GetTeacherById(id.Value));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            _service.DeleteTeacher(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    return View(toDisplay);

                }
                catch (TeacherNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                try
                {
                    Teacher toDisplay = _service.GetTeacherById(id.Value);
                    List<Course> allCourses = _service.GetAll();
                    List<Student> allStudents = _service.GetAllStudents();

                    EditTeacherViewModel vm = new EditTeacherViewModel
                    {
                        ToEdit = toDisplay,
                        AllStudents = allStudents,
                        AllCourses = allCourses
                    };

                    return View(toDisplay);

                }
                catch (CourseNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(Teacher updated)
        {
            _service.EditTeacher(updated);
            return RedirectToAction("Index");
        }
    }
}
