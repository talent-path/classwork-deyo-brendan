using PlannerAPI.Exceptions;
using PlannerAPI.Models.Domain;
using PlannerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PlannerAPI.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace PlannerAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/Activity")]
    public class ActivityController : ControllerBase
    {
        PlannerService _service;

        public ActivityController(PlannerDbContext context)
        {
            _service = new PlannerService(context);
        }

        [HttpGet]
        public IActionResult GetAllActivites()
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
        public IActionResult GetActivityById(int id)
        {
            try
            {
                return this.Accepted(_service.GetActivityById(id));
            }
            catch(InvalidIdException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddActivity(Activity toAdd)
        {
            try
            {
                _service.AddActivity(toAdd);
                return this.Accepted();
            }
            catch(InvalidActivityException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult EditActivity(Activity updated)
        {
            try
            {
                _service.EditActivity(updated);
                return this.Accepted();
            }
            catch(InvalidActivityException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(int id)
        {
            try
            {
                _service.RemoveActivity(id);
                return this.Accepted();
            }
            catch(InvalidActivityException e)
            {
                return this.BadRequest(e.Message);
            }
            catch(InvalidIdException e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}