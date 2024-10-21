using MediatR;

namespace Application.Features.Requests.Commands.Create;

public class CreateRequestCommand : IRequest<CreatedRequestResponse>
{
    public string PriorityLevel { get; set; }

    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, CreatedRequestResponse>
    {
        public Task<CreatedRequestResponse> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            CreatedRequestResponse createdRequestResponse = new CreatedRequestResponse();
            createdRequestResponse.Id = new Guid();
            createdRequestResponse.DateRequested = DateTime.Now;
            createdRequestResponse.PriorityLevel = request.PriorityLevel;
            return Task.FromResult(createdRequestResponse);
        }
    }
}