using Application.Features.Logistics.Commands.Create;
using Application.Features.Logistics.Commands.Delete;
using Application.Features.Logistics.Commands.Update;
using Application.Features.Logistics.Queries;
using Application.Features.Logistics.Queries.GetById;
using Application.Features.Logistics.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLogisticCommand createLogisticCommand)
        {
            CreatedLogisticResponse response = await Mediator.Send(createLogisticCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLogisticQuery getListLogisticQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListLogisticListItemDto> response = await Mediator.Send(getListLogisticQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdLogisticQuery getByIdLogisticQuery = new() { Id = id };
            GetByIdLogisticResponse response = await Mediator.Send(getByIdLogisticQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLogisticCommand updateLogisticCommand)
        {
            UpdatedLogisticResponse response = await Mediator.Send(updateLogisticCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedLogisticResponse response = await Mediator.Send(new DeleteLogisticCommand { Id = id });
        
            return Ok(response);
        }
    }

