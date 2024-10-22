namespace Application.Features.Donors.Commands.Create;

public class CreatedDonorResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    
}