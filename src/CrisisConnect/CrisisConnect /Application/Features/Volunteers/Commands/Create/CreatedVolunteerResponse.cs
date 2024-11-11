using Domain.ValueObjects;

namespace Application.Features.Volunteers.Commands.Create;

public class CreatedVolunteerResponse
{
    public FullName FullName { get; set; }
    
    public int PhoneNumber { get; set; }
    
    public Email? Email { get; set; }
    
    public Address Address { get; set; }
    
    public string Skills { get; set; }
    
    public string? ImageUrl { get; set; }
}