using Application.Features.Alerts.Commands.Create;
using Application.Features.Alerts.Queries;
using Application.Features.Alerts.Queries.GetById;
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
        
        CreateMap<Alert, GetListAlertListItemDto>().ReverseMap();
        CreateMap<Alert, GetByIdAlertResponse>().ReverseMap();
        CreateMap<Paginate<Alert>, GetListResponse<GetListAlertListItemDto>>().ReverseMap();
    }
}