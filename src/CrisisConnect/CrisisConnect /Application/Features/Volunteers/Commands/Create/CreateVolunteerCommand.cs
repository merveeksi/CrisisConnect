using MediatR;

namespace Application.Features.Volunteers.Commands.Create;

public class CreateVolunteerCommand : IRequest<CreatedVolunteerResponse>
{
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public List<string> Skills { get; set; } 
    public string Location { get; set; }
    public decimal PhoneNumber { get; set; }
    
    
    public class CreateVolunteerCommandHandler : IRequestHandler<CreateVolunteerCommand, CreatedVolunteerResponse>
    {
        public Task<CreatedVolunteerResponse> Handle(CreateVolunteerCommand request, CancellationToken cancellationToken)
        {
            CreatedVolunteerResponse createdVolunteerResponse = new CreatedVolunteerResponse();
            createdVolunteerResponse.FirstName = request.FirstName;
            createdVolunteerResponse.Lastname = request.Lastname;
            createdVolunteerResponse.Skills = request.Skills;
            createdVolunteerResponse.Location = request.Location;
            createdVolunteerResponse.PhoneNumber = request.PhoneNumber;
            return Task.FromResult(createdVolunteerResponse);
        }
    }
}