using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace profashion.api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content("Hello from Home");
        }
    }
}