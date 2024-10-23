using Application.Features.Teames.Commands.Create;
using Application.Features.Teames.Queries;
using Application.Features.Teames.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Teames.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Team, CreateTeamCommand>().ReverseMap();
        CreateMap<Team, CreatedTeamResponse>().ReverseMap();
        
        CreateMap<Team, GetListTeamListItemDto>().ReverseMap();
        CreateMap<Team, GetByIdTeamResponse>().ReverseMap();
        CreateMap<Paginate<Team>, GetListResponse<GetListTeamListItemDto>>().ReverseMap();
    }
}