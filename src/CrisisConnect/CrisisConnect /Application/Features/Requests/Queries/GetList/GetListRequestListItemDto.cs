namespace Application.Features.Requests.Queries;

public class GetListRequestListItemDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string ShelterName { get; set; }
}