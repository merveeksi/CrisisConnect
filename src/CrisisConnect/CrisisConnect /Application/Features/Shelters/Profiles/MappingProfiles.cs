using Application.Features.Disasters.Queries.GetListByDynamic;
using Application.Features.Shelters.Commands.Create;
using Application.Features.Shelters.Commands.Delete;
using Application.Features.Shelters.Commands.Update;
using Application.Features.Shelters.Queries;
using Application.Features.Shelters.Queries.GetList;
using Application.Features.Shelters.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Shelters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Shelter, CreateShelterCommand>().ReverseMap();
        CreateMap<Shelter, CreatedShelterResponse>().ReverseMap();

        CreateMap<Shelter, UpdateShelterCommand>().ReverseMap();
        CreateMap<Shelter, UpdatedShelterResponse>().ReverseMap();

        CreateMap<Shelter, DeleteShelterCommand>().ReverseMap();
        CreateMap<Shelter, DeletedShelterResponse>().ReverseMap();
        
        CreateMap<Shelter, GetListShelterListItemDto>().ReverseMap();
        CreateMap<Paginate<Shelter>, GetListResponse<GetListShelterListItemDto>>().ReverseMap();
        CreateMap<Paginate<Shelter>, GetListResponse<GetListByDynamicShelterListItemDto>>().ReverseMap();
    }
}