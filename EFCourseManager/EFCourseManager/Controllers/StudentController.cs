using EFCourseManager.Models;
using EFCourseManager.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCourseManager.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        CourseManagerDbContext _context;

        public StudentController(CourseManagerDbContext context)
        {
            _context = context;
        }

        [HttpPost("/Student")]
        public IActionResult AddStudent(Student toAdd)
        {
            _context.Students.Add(toAdd);
            _context.SaveChanges();
            return this.Accepted(toAdd.StudentId);
        }

        [HttpGet("/Student/{id}")]
        public IActionResult GetStudent(int id)
        {
            Student toRetrieve =_context.Students.Find(id);
            return this.Accepted(toRetrieve);
        }

        [HttpGet("/Student")]
        public IActionResult GetAll()
        {
            return this.Accepted(_context.Students.ToList());
        }

        [HttpPut("/Student")]
        public IActionResult EditStudent(Student edited)
        {
            _context.Attach(edited);
            _context.Entry(edited).State = EntityState.Modified;
            _context.SaveChanges();
            return this.Accepted();
        }

        [HttpDelete("/Student/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student toDelete = new Student
            {
                StudentId = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return this.Accepted();
        }

    }
}
