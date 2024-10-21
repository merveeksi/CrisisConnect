namespace Application.Features.Volunteers.Commands.Create;

public class CreatedVolunteerResponse
{
    public string FirstName { get; set; } 
    
    public string Lastname { get; set; } 
    
    public List<string> Skills { get; set; } 
    
    public string Location { get; set; } 
    
    public decimal PhoneNumber { get; set; }
}