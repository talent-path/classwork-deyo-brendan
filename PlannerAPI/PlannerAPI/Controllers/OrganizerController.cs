using PlannerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerAPI.Exceptions;
using PlannerAPI.Models;

namespace PlannerAPI.Controllers
{
    [ApiController]
    [Route("/api/Organizer")]
    public class OrganizerController : ControllerBase
    {
        ProjectService _service;
        public OrganizerController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllOrganizers()
        {
            try
            {
                return this.Accepted(_service.GetAllOrganizers());
            }
            catch(EmptyListException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrganizerById(int id)
        {
            try
            {
                return this.Accepted(_service.GetOrganizerById(id));
            }
            catch (InvalidIdException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddOrganizer(Organizer toAdd)
        {
            try
            {
                _service.AddOrganizer(toAdd);
                return this.Accepted();
            }
            catch(InvalidOrganizerException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult EditOrganizer(Organizer updated)
        {
            try
            {
                _service.EditOrganizer(updated);
                return this.Accepted();
            }
            catch(InvalidOrganizerException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteOrganizer(Organizer toDelete)
        {
            try
            {
                _service.RemoveOrganizer(toDelete);
                return this.Accepted();
            }
            catch(InvalidOrganizerException e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}

