using Application.Features.Volunteers.Commands.Create;
using Application.Features.Volunteers.Queries;
using Application.Features.Volunteers.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateVolunteerCommand createVolunteerCommand)
        {
            CreatedVolunteerResponse response = await Mediator.Send(createVolunteerCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListVolunteerQuery getListVolunteerQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListVolunteerListItemDto> response = await Mediator.Send(getListVolunteerQuery);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdVolunteerQuery getByIdVolunteerQuery = new() { Id = id };
            GetByIdVolunteerResponse response = await Mediator.Send(getByIdVolunteerQuery);
            return Ok(response);
        }
    }
}
