using Application.Features.Teames.Commands.Create;
using Application.Features.Teames.Commands.Update;
using Application.Features.Teames.Queries;
using Application.Features.Teames.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTeamCommand createTeamCommand)
        {
            CreatedTeamResponse response = await Mediator.Send(createTeamCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTeamQuery getListTeamQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListTeamListItemDto> response = await Mediator.Send(getListTeamQuery);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdTeamQuery getByIdTeamQuery = new() { Id = id };
            GetByIdTeamResponse response = await Mediator.Send(getByIdTeamQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTeamCommand updateTeamCommand)
        {
            UpdatedTeamResponse response = await Mediator.Send(updateTeamCommand);
            return Ok(response);
        }
    }
}
