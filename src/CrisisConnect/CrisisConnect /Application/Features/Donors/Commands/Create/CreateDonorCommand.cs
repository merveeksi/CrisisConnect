using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Donors.Commands.Create;

public class CreateDonorCommand:IRequest<CreatedDonorResponse>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Location { get; set; }
}

public class CreateDonorCommandHadler : IRequestHandler<CreateDonorCommand, CreatedDonorResponse>
{
    private readonly IDonorRepository _donorRepository;
    private readonly IMapper _mapper;

    public CreateDonorCommandHadler(IDonorRepository donorRepository, IMapper mapper)
    {
        _donorRepository = donorRepository;
        _mapper = mapper;
    }

    public async Task<CreatedDonorResponse>? Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        Donor donor = _mapper.Map<Donor>(request);
        donor.Id = Guid.NewGuid();
        
        await _donorRepository.AddAsync(donor);
        
        CreatedDonorResponse createdDonorResponse = _mapper.Map<CreatedDonorResponse>(donor);
        return createdDonorResponse;
    }
}