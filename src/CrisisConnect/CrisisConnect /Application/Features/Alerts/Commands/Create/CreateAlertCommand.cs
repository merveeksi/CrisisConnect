using MediatR;

namespace Application.Features.Alerts.Commands.Create;

public class CreateAlertCommand:IRequest<CreatedAlertResponse>
{
    public string Title { get; set; } 
    
}

public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, CreatedAlertResponse>
{
    public Task<CreatedAlertResponse>? Handle(CreateAlertCommand request, CancellationToken cancellationToken)
    {
        CreatedAlertResponse createdAlertResponse = new CreatedAlertResponse();
        createdAlertResponse.Id = new Guid();
        createdAlertResponse.Message = request.Title;
        createdAlertResponse.Location = "Location";
        createdAlertResponse.AlertType = "AlertType";
        return Task.FromResult(createdAlertResponse);

    }
}