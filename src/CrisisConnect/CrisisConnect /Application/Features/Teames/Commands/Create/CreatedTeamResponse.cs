namespace Application.Features.Teames.Commands.Create;

public class CreatedTeamResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string Specialty { get; set; }
    
    public DateTime CreateDate { get; set; }
}