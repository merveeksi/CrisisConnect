using Application.Features.Disasters.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Disasters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Disaster, CreateDisasterCommand>().ReverseMap();
        CreateMap<Disaster, CreatedDisasterResponse>().ReverseMap();
    }
}