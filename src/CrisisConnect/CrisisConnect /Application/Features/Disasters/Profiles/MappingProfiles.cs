using Application.Features.Disasters.Commands.Create;
using Application.Features.Disasters.Commands.Delete;
using Application.Features.Disasters.Commands.Update;
using Application.Features.Disasters.Queries.GetList;
using Application.Features.Disasters.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Disasters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Disaster, CreateDisasterCommand>().ReverseMap();
        CreateMap<Disaster, CreatedDisasterResponse>().ReverseMap();
        
        CreateMap<Disaster, UpdateDisasterCommand>().ReverseMap();
        CreateMap<Disaster, UpdatedDisasterResponse>().ReverseMap();

        CreateMap<Disaster, DeleteDisasterCommand>().ReverseMap();
        CreateMap<Disaster, DeletedDisasterResponse>().ReverseMap();
        
        
        CreateMap<Disaster, GetListDisasterListItemDto>().ReverseMap();    // Disaster sınıfını GetListDisasterListItemDto'ya ve tersine dönüştür
        CreateMap<Paginate<Disaster>, GetListResponse<GetListDisasterListItemDto>>().ReverseMap();
        CreateMap<Paginate<Disaster>, GetListResponse<GetListByDynamicDisasterListItemDto>>().ReverseMap();
    }
}