using Application.Features.Volunteers.Commands.Create;
using Application.Features.Volunteers.Commands.Delete;
using Application.Features.Volunteers.Commands.Update;
using Application.Features.Volunteers.Queries;
using Application.Features.Volunteers.Queries.GetById;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Volunteers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Volunteer, CreateVolunteerCommand>().ReverseMap();
        CreateMap<Volunteer, CreatedVolunteerResponse>().ReverseMap();

        CreateMap<Volunteer, UpdateVolunteerCommand>().ReverseMap();
        CreateMap<Volunteer, UpdatedVolunteerResponse>().ReverseMap();

        CreateMap<Volunteer, DeleteVolunteerCommand>().ReverseMap();
        CreateMap<Volunteer, DeletedVolunteerResponse>().ReverseMap();
        
        CreateMap<Volunteer, GetListVolunteerListItemDto>().ReverseMap();
        CreateMap<Volunteer, GetByIdVolunteerResponse>().ReverseMap();
        CreateMap<Paginate<Volunteer>, GetListResponse<GetListVolunteerListItemDto>>().ReverseMap();
    }
}
