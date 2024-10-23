using Application.Features.Shelters.Commands.Create;
using Application.Features.Shelters.Queries;
using Application.Features.Shelters.Queries.GetById;
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
        
        CreateMap<Shelter, GetListShelterListItemDto>().ReverseMap();
        CreateMap<Shelter, GetByIdShelterResponse>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.Shelter>, GetListResponse<GetListShelterListItemDto>>().ReverseMap();
    }
}