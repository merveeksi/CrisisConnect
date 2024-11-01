using Application.Features.Disasters.Queries.GetListByDynamic;
using Application.Features.Teames.Commands.Create;
using Application.Features.Teames.Commands.Delete;
using Application.Features.Teames.Commands.Update;
using Application.Features.Teames.Queries;
using Application.Features.Teams.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
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
        
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicTeamQuery getListByDynamicTeamQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicTeamListItemDto> response = await Mediator.Send(getListByDynamicTeamQuery);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTeamQuery getListTeamQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListTeamListItemDto> response = await Mediator.Send(getListTeamQuery);
            return Ok(response);
        }
        
       
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTeamCommand updateTeamCommand)
        {
            UpdatedTeamResponse response = await Mediator.Send(updateTeamCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedTeamResponse response = await Mediator.Send(new DeleteTeamCommand { Id = id });
        
            return Ok(response);
        }
    }
}
