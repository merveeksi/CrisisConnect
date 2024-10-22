using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Donors.Commands.Create;

public class CreateDonorCommand:IRequest<CreatedDonorResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}

public class CreateDonorCommandHadler : IRequestHandler<CreateDonorCommand, CreatedDonorResponse>
{
    private readonly IDonorRepository _donorRepository;

    public CreateDonorCommandHadler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public Task<CreatedDonorResponse>? Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        CreatedDonorResponse createdDonorResponse = new CreatedDonorResponse();
        createdDonorResponse.FirstName = request.FirstName;
        createdDonorResponse.LastName = request.LastName;
        createdDonorResponse.PhoneNumber = request.PhoneNumber;
        createdDonorResponse.Id = new Guid();
        return Task.FromResult(createdDonorResponse);
    }
}