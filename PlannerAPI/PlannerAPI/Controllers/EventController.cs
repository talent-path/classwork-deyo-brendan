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
    [Route("/api/Event")]
    public class EventController : ControllerBase
    {
        ProjectService _service;

        public EventController(ProjectService service)
        {
            _service = service;
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

        [HttpDelete]
        public IActionResult DeleteEvent(Event toDelete)
        {
            try
            {
                _service.RemoveEvent(toDelete);
                return this.Accepted();
            }
            catch (InvalidEventException e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
