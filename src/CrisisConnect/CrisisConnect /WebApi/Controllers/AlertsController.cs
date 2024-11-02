using Application.Features.Alerts.Commands.Create;
using Application.Features.Alerts.Commands.Delete;
using Application.Features.Alerts.Commands.Update;
using Application.Features.Alerts.Queries;
using Application.Features.Alerts.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
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
        
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicAlertQuery getListByDynamicAlertQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicAlertListItemDto> response = await Mediator.Send(getListByDynamicAlertQuery);
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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedAlertResponse response = await Mediator.Send(new DeleteAlertCommand { Id = id });
        
            return Ok(response);
        }
    }

