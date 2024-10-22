using Application.Features.Donors.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDonorCommand createDonorCommand)
        {
            CreatedDonorResponse response = await Mediator.Send(createDonorCommand);
            return Ok(response);
        }
    }

