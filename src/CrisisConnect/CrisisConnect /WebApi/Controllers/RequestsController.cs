using Application.Features.Requests.Commands.Create;
using Application.Features.Requests.Commands.Delete;
using Application.Features.Requests.Commands.Update;
using Application.Features.Requests.Queries;
using Application.Features.Requests.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRequestCommand createRequestCommand)
        {
            CreatedRequestResponse response = await Mediator.Send(createRequestCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListRequestQuery getListRequestQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListRequestListItemDto> response = await Mediator.Send(getListRequestQuery);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdRequestQuery getByIdRequestQuery = new() { Id = id };
            GetByIdRequestResponse response = await Mediator.Send(getByIdRequestQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRequestCommand updateRequestCommand)
        {
            UpdatedRequestResponse response = await Mediator.Send(updateRequestCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedRequestResponse response = await Mediator.Send(new DeleteRequestCommand { Id = id });
        
            return Ok(response);
        }
    }

