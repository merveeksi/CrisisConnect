using Application.Features.Centers.Commands.Create;
using Application.Features.Centers.Commands.Update;
using Application.Features.Centers.Queries;
using Application.Features.Centers.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class CentersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCenterCommand createCenterCommand)
        {
            CreatedCenterResponse response = await Mediator.Send(createCenterCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCenterQuery getListCenterQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCenterListItemDto> response = await Mediator.Send(getListCenterQuery);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdCenterQuery getByIdCenterQuery = new() { Id = id };
            GetByIdCenterResponse response = await Mediator.Send(getByIdCenterQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCenterCommand updateCenterCommand)
        {
            UpdatedCenterResponse response = await Mediator.Send(updateCenterCommand);
            return Ok(response);
        }
    }

