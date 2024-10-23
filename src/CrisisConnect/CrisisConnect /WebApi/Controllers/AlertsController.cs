using Application.Features.Alerts.Commands.Create;
using Application.Features.Alerts.Queries;
using Application.Features.Alerts.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
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
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListAlertQuery getListAlertQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListAlertListItemDto> response = await Mediator.Send(getListAlertQuery);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdAlertQuery getByIdAlertQuery = new() { Id = id };
            GetByIdAlertResponse response = await Mediator.Send(getByIdAlertQuery);
            return Ok(response);
        }
    }

