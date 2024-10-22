using Application.Features.Donors.Commands.Create;
using AutoMapper;

namespace Application.Features.Donor.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Donor, CreateDonorCommand>().ReverseMap();
        CreateMap<Domain.Entities.Donor, CreatedDonorResponse>().ReverseMap();
    }
}