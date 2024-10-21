using MediatR;

namespace Application.Features.Center.Commands.Create;

public class CreateCenterCommand:IRequest<CreatedCenterResponse>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
}

public class CreateCenterCommandHandler : IRequestHandler<CreateCenterCommand, CreatedCenterResponse>
{
    public Task<CreatedCenterResponse>? Handle(CreateCenterCommand request, CancellationToken cancellationToken)
    {
        CreatedCenterResponse createdCenterResponse = new CreatedCenterResponse();
        createdCenterResponse.Name = request.Name;
        createdCenterResponse.Location = request.Location;
        createdCenterResponse.Capacity = request.Capacity;
        createdCenterResponse.Id = new Guid();
        return Task.FromResult(createdCenterResponse);
    }
}