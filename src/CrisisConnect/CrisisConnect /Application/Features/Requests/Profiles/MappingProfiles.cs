using Application.Features.Requests.Commands.Create;
using Application.Features.Requests.Queries;
using Application.Features.Requests.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Requests.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Request, CreateRequestCommand>().ReverseMap();
        CreateMap<Request, CreatedRequestResponse>().ReverseMap();
        
        CreateMap<Request, GetListRequestListItemDto>().ReverseMap();
        CreateMap<Request, GetByIdRequestResponse>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.Request>, GetListResponse<GetListRequestListItemDto>>().ReverseMap();
    }
}