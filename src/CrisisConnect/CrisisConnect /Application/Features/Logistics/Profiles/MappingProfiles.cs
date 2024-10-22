using Application.Features.Logistics.Commands.Create;
using AutoMapper;

namespace Application.Features.Logistics.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Logistic, CreateLogisticCommand>().ReverseMap();
        CreateMap<Domain.Entities.Logistic, CreatedLogisticResponse>().ReverseMap();
    }
}