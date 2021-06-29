using DellProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellProjectAPI.Controllers
{
    [ApiController]
    public class OrganizerController : Controller
    {
        ProjectService _service;
        public OrganizerController(ProjectService service)
        {
            _service = service;
        }
    }
}
