namespace Application.Features.Center.Commands.Create;

public class CreatedCenterResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public int Capacity { get; set; }
}