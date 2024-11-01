using Application.Features.Disasters.Queries.GetListByDynamic;
using Application.Features.Shelters.Commands.Create;
using Application.Features.Shelters.Commands.Delete;
using Application.Features.Shelters.Commands.Update;
using Application.Features.Shelters.Queries;
using Application.Features.Shelters.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheltersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateShelterCommand createShelterCommand)
        {
            CreatedShelterResponse response = await Mediator.Send(createShelterCommand);
            return Ok(response);
        }
        
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicShelterQuery getListByDynamicShelterQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicShelterListItemDto> response = await Mediator.Send(getListByDynamicShelterQuery);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListShelterQuery getListShelterQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListShelterListItemDto> response = await Mediator.Send(getListShelterQuery);
            return Ok(response);
        }
        
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateShelterCommand updateShelterCommand)
        {
            UpdatedShelterResponse response = await Mediator.Send(updateShelterCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedShelterResponse response = await Mediator.Send(new DeleteShelterCommand { Id = id });
        
            return Ok(response);
        }
    }
}
