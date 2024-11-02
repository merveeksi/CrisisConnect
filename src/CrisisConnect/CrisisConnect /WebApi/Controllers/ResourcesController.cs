using Application.Features.Resources.Commands.Create;
using Application.Features.Resources.Commands.Delete;
using Application.Features.Resources.Commands.Update;
using Application.Features.Resources.Queries;
using Application.Features.Resources.Queries.GetById;
using Application.Features.Resources.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateResourceCommand createResourceCommand)
        {
            CreatedResourceResponse response = await Mediator.Send(createResourceCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListResourceQuery getListResourceQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListResourceListItemDto> response = await Mediator.Send(getListResourceQuery);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdResourceQuery getByIdResourceQuery = new() { Id = id };
            GetByIdResourceResponse response = await Mediator.Send(getByIdResourceQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateResourceCommand updateResourceCommand)
        {
            UpdatedResourceResponse response = await Mediator.Send(updateResourceCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedResourceResponse response = await Mediator.Send(new DeleteResourceCommand { Id = id });
        
            return Ok(response);
        }
    }

