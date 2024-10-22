using Application.Features.Requests.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRequestCommand createRequestCommand)
        {
            CreatedRequestResponse response = await Mediator.Send(createRequestCommand);
            return Ok(response);
        }
    }

