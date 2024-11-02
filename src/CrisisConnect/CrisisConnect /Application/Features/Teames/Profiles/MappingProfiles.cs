using Application.Features.Teames.Commands.Create;
using Application.Features.Teames.Commands.Delete;
using Application.Features.Teames.Commands.Update;
using Application.Features.Teames.Queries;
using Application.Features.Teames.Queries.GetList;
using Application.Features.Teames.Queries.GetListByDynamic;
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

        CreateMap<Team, UpdateTeamCommand>().ReverseMap();
        CreateMap<Team, UpdatedTeamResponse>().ReverseMap();

        CreateMap<Team, DeleteTeamCommand>().ReverseMap();
        CreateMap<Team, DeletedTeamResponse>().ReverseMap();
        
        CreateMap<Team, GetListTeamListItemDto>().ReverseMap();
        CreateMap<Paginate<Team>, GetListResponse<GetListTeamListItemDto>>().ReverseMap();
        CreateMap<Paginate<Team>, GetListResponse<GetListByDynamicTeamListItemDto>>().ReverseMap();
        
    }
}