using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Alerts.Commands.Create;

public class CreateAlertCommand:IRequest<CreatedAlertResponse>
{
    public string Title { get; set; } 
    
}

public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, CreatedAlertResponse>
{
    private readonly IAlertRepository _alertRepository;

    public CreateAlertCommandHandler(IAlertRepository alertRepository)
    {
        _alertRepository = alertRepository;
    }

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