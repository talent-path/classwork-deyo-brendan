using PlannerAPI.Exceptions;
using PlannerAPI.Models;
using PlannerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI.Controllers
{
    [ApiController]
    [Route("/api/Attendee")]
    public class AttendeeController : ControllerBase
    {
        ProjectService _service;

        public AttendeeController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllAttendees()
        {
            try
            {
                return this.Accepted(_service.GetAllAttendees());
            }
            catch(EmptyListException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAttendeeById(int id)
        {
            try
            {
                return this.Accepted(_service.GetAttendeeById(id));
            }
            catch(InvalidIdException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAttendee(Attendee toAdd)
        {
            try
            {
                _service.AddAttendee(toAdd);
                return this.Accepted();
            }
            catch(InvalidAttendeeException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult EditAttendee(Attendee updated)
        {
            try
            {
                _service.EditAttendee(updated);
                return this.Accepted();
            }
            catch(InvalidAttendeeException e)
            {
                return this.BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public IActionResult DeleteAttendee(Attendee toDelete)
        {try
            {
                _service.RemoveAttendee(toDelete);
                return this.Accepted();
            }
            catch (InvalidAttendeeException e) { return this.BadRequest(e.Message); } 
        }
    }
}
