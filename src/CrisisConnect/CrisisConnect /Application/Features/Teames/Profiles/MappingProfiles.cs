using Application.Features.Teames.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Teames.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Team, CreateTeamCommand>().ReverseMap();
        CreateMap<Team, CreatedTeamResponse>().ReverseMap();
    }
}