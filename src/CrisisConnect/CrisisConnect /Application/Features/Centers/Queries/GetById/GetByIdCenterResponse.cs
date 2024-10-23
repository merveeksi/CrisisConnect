namespace Application.Features.Centers.Queries.GetById;

public class GetByIdCenterResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}