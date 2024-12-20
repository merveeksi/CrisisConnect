using Application.Features.Centers.Commands.Create;
using Application.Features.Centers.Commands.Delete;
using Application.Features.Centers.Commands.Update;
using Application.Features.Centers.Queries.GetList;
using Application.Features.Centers.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
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
        
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicCenterQuery getListByDynamicCenterQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicCenterListItemDto> response = await Mediator.Send(getListByDynamicCenterQuery);
            return Ok(response);
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCenterCommand updateCenterCommand)
        {
            UpdatedCenterResponse response = await Mediator.Send(updateCenterCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedCenterResponse response = await Mediator.Send(new DeleteCenterCommand { Id = id });
        
            return Ok(response);
        }
    }

