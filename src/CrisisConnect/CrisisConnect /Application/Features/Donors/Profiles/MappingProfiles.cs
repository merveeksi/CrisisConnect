using Application.Features.Donors.Commands.Create;
using Application.Features.Donors.Commands.Delete;
using Application.Features.Donors.Commands.Update;
using Application.Features.Donors.Queries;
using Application.Features.Donors.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Donors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Donor, CreateDonorCommand>().ReverseMap();
        CreateMap<Donor, CreatedDonorResponse>().ReverseMap();

        CreateMap<Donor, UpdateDonorCommand>().ReverseMap();
        CreateMap<Donor, UpdatedDonorResponse>().ReverseMap();

        CreateMap<Donor, DeleteDonorCommand>().ReverseMap();
        CreateMap<Donor, DeletedDonorResponse>().ReverseMap();
        
        CreateMap<Donor, GetListDonorListItemDto>().ReverseMap();
        CreateMap<Donor, GetByIdDonorResponse>().ReverseMap();
        CreateMap<Paginate<Donor>, GetListResponse<GetListDonorListItemDto>>().ReverseMap();
    }
}