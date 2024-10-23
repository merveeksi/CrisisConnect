using Application.Features.Shelters.Commands.Create;
using Application.Features.Shelters.Commands.Update;
using Application.Features.Shelters.Queries;
using Application.Features.Shelters.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheltersContoller : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateShelterCommand createShelterCommand)
        {
            CreatedShelterResponse response = await Mediator.Send(createShelterCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListShelterQuery getListShelterQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListShelterListItemDto> response = await Mediator.Send(getListShelterQuery);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdShelterQuery getByIdShelterQuery = new() { Id = id };
            GetByIdShelterResponse response = await Mediator.Send(getByIdShelterQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateShelterCommand updateShelterCommand)
        {
            UpdatedShelterResponse response = await Mediator.Send(updateShelterCommand);
            return Ok(response);
        }
    }
}
