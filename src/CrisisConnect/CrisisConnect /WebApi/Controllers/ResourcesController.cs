using Application.Features.Resources.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateResourceCommand createResourceCommand)
        {
            CreatedResourceResponse response = await Mediator.Send(createResourceCommand);
            return Ok(response);
        }
    }

