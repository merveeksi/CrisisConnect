using Application.Features.Teames.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTeamCommand createTeamCommand)
        {
            CreatedTeamResponse response = await Mediator.Send(createTeamCommand);
            return Ok(response);
        }
    }
}
