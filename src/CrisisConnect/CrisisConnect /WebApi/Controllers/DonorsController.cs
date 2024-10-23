using Application.Features.Donors.Commands.Create;
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
    }

