using Application.Features.Alerts.Commands.Create;
using Application.Features.Alerts.Commands.Delete;
using Application.Features.Alerts.Commands.Update;
using Application.Features.Alerts.Queries.GetById;
using Application.Features.Alerts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Domain.ValueObjects;
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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] AlertId id)
        {
            GetByIdAlertQuery getByIdCenterQuery = new() { Id = id };
            GetByIdAlertResponse response = await Mediator.Send(getByIdCenterQuery);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListAlertQuery getListAlertQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListAlertListItemDto> response = await Mediator.Send(getListAlertQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAlertCommand updateAlertCommand)
        {
            UpdatedAlertResponse response = await Mediator.Send(updateAlertCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] AlertId id)
        {
            DeletedAlertResponse response = await Mediator.Send(new DeleteAlertCommand { Id = id });
        
            return Ok(response);
        }
    }

