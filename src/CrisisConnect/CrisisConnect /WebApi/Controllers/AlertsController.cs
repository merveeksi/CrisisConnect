using Application.Features.Alerts.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAlertCommand createDisasterCommand)
        {
            CreatedAlertResponse
                response = await Mediator.Send(createDisasterCommand); // Mediator'e komutu gönderiyoruz
            return Ok(response);
        }
    }

