using EFCourseManager.Models;
using EFCourseManager.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Controllers
{
    [ApiController]
    public class CourseController : Controller
    {
        CourseManagerDbContext _context;

        public CourseController(CourseManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("/Course")]
        public IActionResult AddCourse(Course toAdd)
        {
            _context.Courses.Add(toAdd);
            _context.SaveChanges();
            return this.Accepted(toAdd.CourseId);
        }

        [HttpGet("/Course/{id}")]
        public IActionResult GetCourse(int id)
        {
            Course toRetrieve = _context.Courses.Find(id);
            return this.Accepted(toRetrieve);
        }

        [HttpGet("/Course")]
        public IActionResult GetAll()
        {
            return this.Accepted(_context.Courses.ToList());
        }

        [HttpPut("/Course")]
        public IActionResult EditCourse(Course edited)
        {
            _context.Attach(edited);
            _context.Entry(edited).State = EntityState.Modified;
            _context.SaveChanges();
            return this.Accepted();
        }

        [HttpDelete("/Course/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            Course toDelete = new Course
            {
                CourseId = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return this.Accepted();
        }
    }
}
