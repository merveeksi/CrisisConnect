using Application.Features.Centers.Commands.Create;
using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Centers.Commands.Create;

public class CreateCenterCommand:IRequest<CreatedCenterResponse>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
}

public class CreateCenterCommandHandler : IRequestHandler<CreateCenterCommand, CreatedCenterResponse>
{
    private readonly ICenterRepository _centerRepository;

    public CreateCenterCommandHandler(ICenterRepository centerRepository)
    {
        _centerRepository = centerRepository;
    }

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