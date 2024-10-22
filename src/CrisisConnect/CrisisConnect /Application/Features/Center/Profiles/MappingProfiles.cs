using Application.Features.Center.Commands.Create;
using AutoMapper;

namespace Application.Features.Center.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Center, CreateCenterCommand>().ReverseMap();
        CreateMap<Domain.Entities.Center, CreatedCenterResponse>().ReverseMap();
    }
}