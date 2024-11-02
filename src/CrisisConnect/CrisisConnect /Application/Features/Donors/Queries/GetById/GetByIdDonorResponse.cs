namespace Application.Features.Donors.Queries.GetById;

public class GetByIdDonorResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}