using Application.Features.Logistics.Commands.Create;
using MediatR;

namespace Application.Features.Shelters.Commands.Create;

public class CreateShelterCommand : IRequest<CreatedShelterResponse>
{
    public string Location { get; set; }

    public string ContactInfo { get; set; }

    public int Capacity { get; set; }


    public class CreateShelterCommandHandler : IRequestHandler<CreateShelterCommand, CreatedShelterResponse>
    {
        public Task<CreatedShelterResponse>? Handle(CreateShelterCommand request, CancellationToken cancellationToken)
        {
            CreatedShelterResponse createdShelterResponse = new CreatedShelterResponse();
            createdShelterResponse.Id = new Guid();
            createdShelterResponse.Location = request.Location;
            createdShelterResponse.ContactInfo = request.ContactInfo;
            createdShelterResponse.Capacity = request.Capacity;
            return Task.FromResult(createdShelterResponse);
        }
    }
}