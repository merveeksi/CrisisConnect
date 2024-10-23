namespace Application.Features.Shelters.Commands.Create;

public class CreatedShelterResponse
{
    public Guid Id { get; set; }
    
    public string Location { get; set; }

    public string ContactInfo { get; set; } 

    public int Capacity { get; set; } 
    
    public DateTime CreateDate { get; set; }
}