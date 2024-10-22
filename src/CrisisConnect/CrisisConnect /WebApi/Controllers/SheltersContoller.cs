using Application.Features.Shelters.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheltersContoller : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateShelterCommand createShelterCommand)
        {
            CreatedShelterResponse response = await Mediator.Send(createShelterCommand);
            return Ok(response);
        }
    }
}
