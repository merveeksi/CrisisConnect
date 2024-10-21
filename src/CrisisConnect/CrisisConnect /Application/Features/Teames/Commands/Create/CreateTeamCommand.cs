using MediatR;

namespace Application.Features.Teames.Commands.Create;

public class CreateTeamCommand : IRequest<CreatedTeamResponse>
{
    public string Name { get; set; }
    public string Specialty { get; set; }
    
    
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, CreatedTeamResponse>
    {
        public Task<CreatedTeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            CreatedTeamResponse createdTeamResponse = new CreatedTeamResponse();
            createdTeamResponse.Id = new Guid();
            createdTeamResponse.Name = request.Name;
            createdTeamResponse.Specialty = request.Specialty;
            return Task.FromResult(createdTeamResponse);
        }
    }
}