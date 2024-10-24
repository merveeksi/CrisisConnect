using Application.Features.Donors.Commands.Create;
using Application.Features.Donors.Commands.Delete;
using Application.Features.Donors.Commands.Update;
using Application.Features.Donors.Queries;
using Application.Features.Donors.Queries.GetById;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDonorCommand createDonorCommand)
        {
            CreatedDonorResponse response = await Mediator.Send(createDonorCommand);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListDonorQuery getListDonorQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListDonorListItemDto> response = await Mediator.Send(getListDonorQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdDonorQuery getByIdDonorQuery = new() { Id = id };
            GetByIdDonorResponse response = await Mediator.Send(getByIdDonorQuery);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDonorCommand updateDonorCommand)
        {
            UpdatedDonorResponse response = await Mediator.Send(updateDonorCommand);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedDonorResponse response = await Mediator.Send(new DeleteDonorCommand { Id = id });
        
            return Ok(response);
        }
    }

