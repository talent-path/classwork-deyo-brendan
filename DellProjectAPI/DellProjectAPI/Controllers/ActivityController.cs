using DellProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellProjectAPI.Controllers
{
    [ApiController]
    public class ActivityController : Controller
    {
        ProjectService _service;

        public ActivityController(ProjectService service)
        {
            _service = service;
        }
    }
}
