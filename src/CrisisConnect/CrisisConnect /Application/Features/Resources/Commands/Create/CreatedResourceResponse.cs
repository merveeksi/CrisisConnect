namespace Application.Features.Resources.Commands.Create;

public class CreatedResourceResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Type { get; set; } 
    
    public int Quantity { get; set; } 
    
    public string Location { get; set; }
}