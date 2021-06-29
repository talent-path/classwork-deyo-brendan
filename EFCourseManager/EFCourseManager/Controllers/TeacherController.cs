using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCourseManager.Models;
using EFCourseManager.Repos;
using Microsoft.EntityFrameworkCore;

namespace EFCourseManager.Controllers
{
    [ApiController]
    public class TeacherController : Controller
    {
        CourseManagerDbContext _context;

        public TeacherController(CourseManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("/Teacher")]
        public IActionResult AddStudent(Teacher toAdd)
        {
            _context.Teachers.Add(toAdd);
            _context.SaveChanges();
            return this.Accepted(toAdd.TeacherId);
        }

        [HttpGet("/Teacher/{id}")]
        public IActionResult GetTeacher(int id)
        {
            Teacher toRetrieve = _context.Teachers.Find(id);
            return this.Accepted(toRetrieve);
        }

        [HttpGet("/Teacher")]
        public IActionResult GetAll()
        {
            return this.Accepted(_context.Teachers.ToList());
        }

        [HttpPut("/Teacher")]
        public IActionResult EditTeacher(Teacher edited)
        {
            _context.Attach(edited);
            _context.Entry(edited).State = EntityState.Modified;
            _context.SaveChanges();
            return this.Accepted();
        }

        [HttpDelete("/Teacher/{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            Teacher toDelete = new Teacher
            {
                TeacherId = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return this.Accepted();
        }
    }
}
