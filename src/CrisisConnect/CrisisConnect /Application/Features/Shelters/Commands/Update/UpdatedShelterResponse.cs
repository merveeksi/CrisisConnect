namespace Application.Features.Shelters.Commands.Update;

public class UpdatedShelterResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }
}