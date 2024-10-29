using Application.Features.Disasters.Commands.Create;
using Application.Features.Disasters.Commands.Delete;
using Application.Features.Disasters.Commands.Update;
using Application.Features.Disasters.Queries.GetById;
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
        
        //Bu modelin amacı alert, resource, team tablolarındaki name alanlarını disaster tablosundaki ilgili alanlara maplemek, include işlemi yapmak, join
        
        CreateMap<Disaster, GetListDisasterListItemDto>()
            .ForMember(destinationMember: c => c.AlertName, memberOptions: opt => opt.MapFrom(c => c.Alert.Name))
            .ForMember(destinationMember: c => c.ResourceName, memberOptions: opt => opt.MapFrom(c => c.Resources.FirstOrDefault().Name))
            .ForMember(destinationMember: c => c.TeamName, memberOptions: opt => opt.MapFrom(c => c.Team.Name))
            .ReverseMap();
        
        //dynamic
        CreateMap<Disaster, GetListByDynamicDisasterListItemDto>()
            .ForMember(destinationMember: c => c.AlertName, memberOptions: opt => opt.MapFrom(c => c.Alert.Name))
            .ForMember(destinationMember: c => c.ResourceName, memberOptions: opt => opt.MapFrom(c => c.Resources.FirstOrDefault().Name))
            .ForMember(destinationMember: c => c.TeamName, memberOptions: opt => opt.MapFrom(c => c.Team.Name))
            .ReverseMap();
        
        CreateMap<Disaster, GetListDisasterListItemDto>().ReverseMap();    // Disaster sınıfını GetListDisasterListItemDto'ya ve tersine dönüştür
        CreateMap<Disaster, GetByIdDisasterResponse>().ReverseMap();       // Disaster sınıfını GetByIdDisasterResponse'a ve tersine dönüştür
        CreateMap<Paginate<Disaster>, GetListResponse<GetListDisasterListItemDto>>().ReverseMap();
        CreateMap<Paginate<Disaster>, GetListResponse<GetListByDynamicDisasterListItemDto>>().ReverseMap();
    }
}