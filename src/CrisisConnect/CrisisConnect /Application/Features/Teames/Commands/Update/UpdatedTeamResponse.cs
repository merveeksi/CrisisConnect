namespace Application.Features.Teames.Commands.Update;

public class UpdatedTeamResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }
}