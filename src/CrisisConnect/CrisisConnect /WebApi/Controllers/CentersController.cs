using Application.Features.Center.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class CentersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCenterCommand createCenterCommand)
        {
            CreatedCenterResponse response = await Mediator.Send(createCenterCommand);
            return Ok(response);
        }
    }

