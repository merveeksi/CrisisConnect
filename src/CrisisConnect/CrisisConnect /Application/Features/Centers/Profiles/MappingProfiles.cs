using Application.Features.Centers.Commands.Create;
using Application.Features.Centers.Commands.Delete;
using Application.Features.Centers.Commands.Update;
using Application.Features.Centers.Queries.GetList;
using Application.Features.Centers.Queries.GetListByDynamic;
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

        CreateMap<Center, UpdateCenterCommand>().ReverseMap();
        CreateMap<Center, UpdatedCenterResponse>().ReverseMap();

        CreateMap<Center, DeleteCenterCommand>().ReverseMap();
        CreateMap<Center, DeletedCenterResponse>().ReverseMap();
        
        CreateMap<Center, GetListCenterListItemDto>().ReverseMap();
        CreateMap<Paginate<Center>, GetListResponse<GetListCenterListItemDto>>().ReverseMap();
        CreateMap<Paginate<Disaster>, GetListResponse<GetListByDynamicCenterListItemDto>>().ReverseMap();
    }
}