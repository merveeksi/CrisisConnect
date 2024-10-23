using Application.Features.Centers.Commands.Create;
using Application.Features.Centers.Queries;
using Application.Features.Centers.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Centers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Center, CreateCenterCommand>().ReverseMap();
        CreateMap<Center, CreatedCenterResponse>().ReverseMap();
        
        CreateMap<Center, GetListCenterListItemDto>().ReverseMap();
        CreateMap<Center, GetByIdCenterResponse>().ReverseMap();
        CreateMap<Paginate<Center>, GetListResponse<GetListCenterListItemDto>>().ReverseMap();
    }
}