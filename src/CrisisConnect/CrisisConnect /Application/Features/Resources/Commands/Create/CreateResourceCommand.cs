using MediatR;

namespace Application.Features.Resources.Commands.Create;

public class CreateResourceCommand : IRequest<CreatedResourceResponse>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; }

    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, CreatedResourceResponse>
    {
        public Task<CreatedResourceResponse>? Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            CreatedResourceResponse createdResourceResponse = new CreatedResourceResponse();
            createdResourceResponse.Id = new Guid();
            createdResourceResponse.Name = request.Name;
            createdResourceResponse.Type = request.Type;
            createdResourceResponse.Quantity = request.Quantity;
            createdResourceResponse.Location = request.Location;
            return Task.FromResult(createdResourceResponse);
        }
    }
}