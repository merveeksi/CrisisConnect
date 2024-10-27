namespace Application.Features.Disasters.Queries.GetList;

public class GetListDisasterListItemDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string AlertName { get; set; }
    public string ResourceName { get; set; }
    public string TeamName { get; set; }
}