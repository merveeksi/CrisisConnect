using Application.Features.Donors.Commands.Create;
using Application.Features.Donors.Commands.Delete;
using Application.Features.Donors.Commands.Update;
using Application.Features.Donors.Queries;
using Application.Features.Donors.Queries.GetListByDynamic;
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
        
        CreateMap<Disaster, GetListDonorListItemDto>()
            .ForMember(destinationMember: c => c.AlertName, memberOptions: opt => opt.MapFrom(c => c.Alert.Name))
            .ForMember(destinationMember: c => c.DisasterName, memberOptions: opt => opt.MapFrom(c => c.Name))
            .ForMember(destinationMember: c => c.TeamName, memberOptions: opt => opt.MapFrom(c => c.Team.Name))
            .ReverseMap();
        
        CreateMap<Disaster, GetListByDynamicDonorListItemDto>()
            .ForMember(destinationMember: c => c.AlertName, memberOptions: opt => opt.MapFrom(c => c.Alert.Name))
            .ForMember(destinationMember: c => c.DisasterName, memberOptions: opt => opt.MapFrom(c => c.Name))
            .ForMember(destinationMember: c => c.TeamName, memberOptions: opt => opt.MapFrom(c => c.Team.Name))
            .ReverseMap();
        
       
        CreateMap<Paginate<Donor>, GetListResponse<GetListDonorListItemDto>>().ReverseMap();
        CreateMap<Paginate<Donor>, GetListResponse<GetListByDynamicDonorListItemDto>>().ReverseMap();
    }
}