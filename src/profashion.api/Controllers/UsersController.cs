using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using profashion.core.Commands;
using RawRabbit;

namespace profashion.api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBusClient _busClient;

        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            command.Id = Guid.NewGuid().ToString();
            await _busClient.PublishAsync(command);
            return Accepted($"Users/{command.Id}");
        }
    }
}