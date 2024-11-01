using Application.Features.Requests.Commands.Create;
using Application.Features.Requests.Commands.Delete;
using Application.Features.Requests.Commands.Update;
using Application.Features.Requests.Queries;
using Application.Features.Requests.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Requests.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Request, CreateRequestCommand>().ReverseMap();
        CreateMap<Request, CreatedRequestResponse>().ReverseMap();

        CreateMap<Request, UpdateRequestCommand>().ReverseMap();
        CreateMap<Request, UpdatedRequestResponse>().ReverseMap();

        CreateMap<Request, DeleteRequestCommand>().ReverseMap();
        CreateMap<Request, DeletedRequestResponse>().ReverseMap();
        
        CreateMap<Request, GetListRequestListItemDto>()
            .ForMember(destinationMember: c => c.ShelterName, memberOptions: opt => opt.MapFrom(c => c.Shelter.Name))
            .ReverseMap();
        
        //dynamic
        CreateMap<Request, GetListByDynamicRequestListItemDto>()
            .ForMember(destinationMember: c => c.ShelterName, memberOptions: opt => opt.MapFrom(c => c.Shelter.Name))
            .ReverseMap();
        CreateMap<Paginate<Request>, GetListResponse<GetListRequestListItemDto>>().ReverseMap();
        CreateMap<Paginate<Request>, GetListResponse<GetListByDynamicRequestListItemDto>>().ReverseMap();
    }
}