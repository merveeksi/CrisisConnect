using Application.Features.Alerts.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Alerts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Alert, CreateAlertCommand>().ReverseMap();
        CreateMap<Alert, CreatedAlertResponse>().ReverseMap();
    }
}