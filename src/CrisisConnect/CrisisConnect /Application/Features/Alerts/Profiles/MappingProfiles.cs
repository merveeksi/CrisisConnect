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
        
        CreateMap<Alert, GetListAlertListItemDto>().ReverseMap();
        CreateMap<Alert, GetByIdAlertResponse>().ReverseMap();
        CreateMap<Paginate<Alert>, GetListResponse<GetListAlertListItemDto>>().ReverseMap();
    }
}