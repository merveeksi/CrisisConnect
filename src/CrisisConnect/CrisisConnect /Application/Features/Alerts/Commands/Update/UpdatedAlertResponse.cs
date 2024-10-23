namespace Application.Features.Alerts.Commands.Update;

public class UpdatedAlertResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }
}