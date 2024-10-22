using Application.Features.Logistics.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLogisticCommand createLogisticCommand)
        {
            CreatedLogisticResponse response = await Mediator.Send(createLogisticCommand);
            return Ok(response);
        }
    }

