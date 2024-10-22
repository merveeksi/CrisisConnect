using Application.Features.Requests.Commands.Create;
using AutoMapper;

namespace Application.Features.Requests.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Request, CreateRequestCommand>().ReverseMap();
        CreateMap<Domain.Entities.Request, CreatedRequestResponse>().ReverseMap();
    }
}