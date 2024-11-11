using Application.Features.Disasters.Commands.Create;
using Application.Features.Disasters.Commands.Delete;
using Application.Features.Disasters.Commands.Update;
using Application.Features.Disasters.Queries.GetList;
using Application.Features.Disasters.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DisastersController : BaseController
{
   
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDisasterCommand createDisasterCommand)
    {
        CreatedDisasterResponse response = await Mediator.Send(createDisasterCommand); // Mediator'e komutu gönderiyoruz
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDisasterQuery getListDisasterQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDisasterListItemDto> response = await Mediator.Send(getListDisasterQuery);
        return Ok(response);
    }
    
    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
    {
        GetListByDynamicDisasterQuery getListByDynamicDisasterQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicDisasterListItemDto> response = await Mediator.Send(getListByDynamicDisasterQuery);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDisasterCommand updateDisasterCommand)
    {
        UpdatedDisasterResponse response = await Mediator.Send(updateDisasterCommand);
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] DisasterId id)
    {
        DeletedDisasterResponse response = await Mediator.Send(new DeleteDisasterCommand { Id = id });
        
        return Ok(response);
    }
}