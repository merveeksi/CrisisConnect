using Application.Features.Shelters.Commands.Create;
using AutoMapper;

namespace Application.Features.Shelters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Shelter, CreateShelterCommand>().ReverseMap();
        CreateMap<Domain.Entities.Shelter, CreatedShelterResponse>().ReverseMap();
    }
}