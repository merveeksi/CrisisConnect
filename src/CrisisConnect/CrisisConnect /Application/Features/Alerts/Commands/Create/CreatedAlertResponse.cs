namespace Application.Features.Alerts.Commands.Create;

public class CreatedAlertResponse
{
    public Guid Id { get; set; }
    
    public string Message { get; set; }
    
    public string Location { get; set; }
    
    public string AlertType { get; set; }
}