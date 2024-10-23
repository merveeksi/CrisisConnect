namespace Application.Features.Donors.Commands.Update;

public class UpdatedDonorResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }
}