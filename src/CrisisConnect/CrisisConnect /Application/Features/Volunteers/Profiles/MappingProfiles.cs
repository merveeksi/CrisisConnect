using Application.Features.Volunteers.Commands.Create;
using AutoMapper;

namespace Application.Features.Volunteers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Volunteer, CreateVolunteerCommand>().ReverseMap();
        CreateMap<Domain.Entities.Volunteer, CreatedVolunteerResponse>().ReverseMap();
    }
}
