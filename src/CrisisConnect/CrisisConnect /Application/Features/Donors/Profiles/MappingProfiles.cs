using Application.Features.Centers.Queries;
using Application.Features.Centers.Queries.GetById;
using Application.Features.Donors.Commands.Create;
using Application.Features.Donors.Commands.Delete;
using Application.Features.Donors.Commands.Update;
using Application.Features.Donors.Queries;
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
       
        CreateMap<Paginate<Donor>, GetListResponse<GetListDonorListItemDto>>().ReverseMap();
        CreateMap<Center, GetByIdDonorResponse>().ReverseMap();
        CreateMap<Paginate<Donor>, GetListResponse<GetListDonorListItemDto>>().ReverseMap();
    }
}