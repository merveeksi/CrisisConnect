using Application.Features.Logistics.Commands.Create;
using Application.Features.Logistics.Commands.Delete;
using Application.Features.Logistics.Commands.Update;
using Application.Features.Logistics.Queries;
using Application.Features.Logistics.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Logistics.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Logistic, CreateLogisticCommand>().ReverseMap();
        CreateMap<Logistic, CreatedLogisticResponse>().ReverseMap();

        CreateMap<Logistic, UpdateLogisticCommand>().ReverseMap();
        CreateMap<Logistic, UpdatedLogisticResponse>().ReverseMap();

        CreateMap<Logistic, DeleteLogisticCommand>().ReverseMap();
        CreateMap<Logistic, DeletedLogisticResponse>().ReverseMap();
        
        CreateMap<Logistic, GetListLogisticListItemDto>().ReverseMap();
        CreateMap<Logistic, GetByIdLogisticResponse>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.Logistic>, GetListResponse<GetListLogisticListItemDto>>().ReverseMap();
    }
}