using Application.Features.Disasters.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DisastersController : BaseController
{
   
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDisasterCommand createDisasterCommand)
    {
        CreatedDisasterResponse response = await Mediator.Send(createDisasterCommand); // Mediator'e komutu gönderiyoruz
        return Ok(response);
    }
}