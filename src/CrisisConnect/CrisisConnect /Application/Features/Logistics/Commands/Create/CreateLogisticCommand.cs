using MediatR;

namespace Application.Features.Logistics.Commands.Create;

public class CreateLogisticCommand : IRequest<CreatedLogisticResponse>
{
    public string Destination { get; set; } 


    public class CreateCommandhandler : IRequestHandler<CreateLogisticCommand, CreatedLogisticResponse>
    {
        public Task<CreatedLogisticResponse>? Handle(CreateLogisticCommand request, CancellationToken cancellationToken)
        {
            CreatedLogisticResponse createdLogisticResponse = new CreatedLogisticResponse();
            createdLogisticResponse.Destination = request.Destination;
            createdLogisticResponse.Id = new Guid();
            return Task.FromResult(createdLogisticResponse);
        }
    }
}