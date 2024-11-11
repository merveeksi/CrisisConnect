using Domain.ValueObjects;

namespace Application.Features.Shelters.Commands.Create;

public class CreatedShelterResponse
{
    public ShelterId Id { get; set; }
    
    public string Name { get; set; }

    
}