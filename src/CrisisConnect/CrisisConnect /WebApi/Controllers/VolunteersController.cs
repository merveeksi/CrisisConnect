using Application.Features.Volunteers.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateVolunteerCommand createVolunteerCommand)
        {
            CreatedVolunteerResponse response = await Mediator.Send(createVolunteerCommand);
            return Ok(response);
        }
    }
}
