using Application.Features.Resources.Commands.Create;
using Application.Features.Resources.Commands.Delete;
using Application.Features.Resources.Commands.Update;
using Application.Features.Resources.Queries;
using Application.Features.Resources.Queries.GetById;
using Application.Features.Resources.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Resources.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Resource, CreateResourceCommand>().ReverseMap();
        CreateMap<Resource, CreatedResourceResponse>().ReverseMap();

        CreateMap<Resource, UpdateResourceCommand>().ReverseMap();
        CreateMap<Resource, UpdatedResourceResponse>().ReverseMap();

        CreateMap<Resource, DeleteResourceCommand>().ReverseMap();
        CreateMap<Resource, DeletedResourceResponse>().ReverseMap();
        
        CreateMap<Resource, GetListResourceListItemDto>().ReverseMap();
        CreateMap<Resource, GetByIdResourceResponse>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.Resource>, GetListResponse<GetListResourceListItemDto>>().ReverseMap();
    }
}