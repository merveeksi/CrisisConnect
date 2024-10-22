using Application.Features.Resources.Commands.Create;
using AutoMapper;

namespace Application.Features.Resources.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Resource, CreateResourceCommand>().ReverseMap();
        CreateMap<Domain.Entities.Resource, CreatedResourceResponse>().ReverseMap();
    }
}