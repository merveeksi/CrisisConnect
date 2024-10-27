using Application.Features.Alerts.Commands.Create;
using Application.Features.Alerts.Commands.Delete;
using Application.Features.Alerts.Commands.Update;
using Application.Features.Alerts.Queries;
using Application.Features.Alerts.Queries.GetById;
using Application.Features.Disasters.Commands.Update;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Alerts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Alert, CreateAlertCommand>().ReverseMap();
        CreateMap<Alert, CreatedAlertResponse>().ReverseMap();

        CreateMap<Alert, UpdateAlertCommand>().ReverseMap();
        CreateMap<Alert, UpdatedAlertResponse>().ReverseMap();
        
        CreateMap<Alert, DeleteAlertCommand>().ReverseMap();
        CreateMap<Alert, DeletedAlertResponse>().ReverseMap();
        
        
        //Bu modelin amacı disaster, center ve request tablolarındaki name alanlarını alert tablosundaki ilgili alanlara maplemek
        
        // CreateMap<Alert, GetListAlertListItemDto>()
        //     .ForMember(destinationMember: c => c.DisasterName, memberOptions: opt => opt.MapFrom(c => c.Disaster.Name))
        //     .ForMember(destinationMember: c => c.CenterName, memberOptions: opt => opt.MapFrom(c => c.Center.Name))
        //     .ForMember(destinationMember: c => c.RequestName, memberOptions: opt => opt.MapFrom(c => c.Request.Name))
        //     .ReverseMap();
        // CreateMap<Model, GetListByDynamicAlertListItemDto>()
        //     .ForMember(destinationMember: c => c.DisasterName, memberOptions: opt => opt.MapFrom(c => c.Disaster.Name))
        //     .ForMember(destinationMember: c => c.CenterName, memberOptions: opt => opt.MapFrom(c => c.Center.Name))
        //     .ForMember(destinationMember: c => c.RequestName, memberOptions: opt => opt.MapFrom(c => c.Request.Name))
        //     .ReverseMap();
        
        CreateMap<Alert, GetListAlertListItemDto>().ReverseMap();
        CreateMap<Alert, GetByIdAlertResponse>().ReverseMap();
        CreateMap<Paginate<Alert>, GetListResponse<GetListAlertListItemDto>>().ReverseMap();
    }
}