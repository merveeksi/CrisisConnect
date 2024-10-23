namespace Application.Features.Requests.Commands.Update;

public class UpdatedRequestResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }
}