using Application.Features.Disasters.Commands.Create;
using Application.Features.Disasters.Queries.GetById;
using Application.Features.Disasters.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdDisasterQuery getByIdDisasterQuery = new() { Id = id };
        GetByIdDisasterResponse response = await Mediator.Send(getByIdDisasterQuery);
        return Ok(response);
    }
}