using PlannerAPI.Exceptions;
using PlannerAPI.Models;
using PlannerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerAPI.Persistence;
using Microsoft.AspNetCore.Cors;

namespace PlannerAPI.Controllers
{
    [ApiController]
    [Route("/api/Event")]
    public class EventController : ControllerBase
    {
        PlannerService _service;

        public EventController(PlannerDbContext context)
        {
            _service = new PlannerService(context);
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            try
            {
                return this.Accepted(_service.GetAllEvents());
            }
            catch(EmptyListException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            try
            {
                return this.Accepted(_service.GetEventById(id));
            }
            catch(InvalidIdException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddEvent(Event toAdd)
        {
            try
            {
                _service.AddEvent(toAdd);
                return this.Accepted();
            }
            catch(InvalidEventException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("Activities/{id}")]
        public IActionResult GetEventActivities(int id)
        {
            try
            {
                _service.GetEventActivities(id);
                return this.Accepted();
            }
            catch(NoActivitiesForGivenEventException e) { return this.BadRequest(e.Message); }
            catch(InvalidIdException e) { return this.BadRequest(e.Message);  }
        }

        [HttpGet("Attendees/{id}")]
        public IActionResult GetEventAttendees(int id)
        {
            try
            {
                _service.GetEventAttendees(id);
                return this.Accepted();
            }
            catch(NoAttendeesForGivenEventException e) { return this.BadRequest(e.Message); }
            catch(InvalidIdException e) { return this.BadRequest(e.Message); }
        }

        [HttpGet("Organizer/{id}")]
        public IActionResult GetEventOrganizer(int id)
        {
            try
            {
                _service.GetEventOrganizer(id);
                return this.Accepted();
            }
            catch(NoOrganizerForGivenEventException e) { return this.BadRequest(e.Message); }
            catch(InvalidIdException e) { return this.BadRequest(e.Message); }
        }

        [HttpPut]
        public IActionResult EditEvent(Event updated)
        {
            try
            {
                _service.EditEvent(updated);
                return this.Accepted();
            }
            catch(InvalidEventException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                _service.RemoveEvent(id);
                return this.Accepted();
            }
            catch (InvalidEventException e)
            {
                return this.BadRequest(e.Message);
            }
            catch (InvalidIdException e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
