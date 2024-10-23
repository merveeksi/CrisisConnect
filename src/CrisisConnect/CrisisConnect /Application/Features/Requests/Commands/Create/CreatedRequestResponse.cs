namespace Application.Features.Requests.Commands.Create;

public class CreatedRequestResponse
{
    public Guid Id { get; set; }
    
    public DateTime DateRequested { get; set; } 

    public string PriorityLevel { get; set; }
    
    public DateTime CreateDate { get; set; }
}