using Domain.Enums;

namespace Application.Features.Disasters.Queries.GetListByDynamic;

public class GetListByDynamicDisasterListItemDto
{
    public Guid Id { get; set; }
    public string TeamName { get; set; }
    public string ResourceName { get; set; }
    public string AlertName { get; set; }
    
    public string DisasterType { get; set; }
    public string Location { get; set; }
    public List<string> UrgentNeeds { get; set; } // Acil ihtiyaçlar (örneğin, gıda, su, ilaç)
    public string ResourceNeeds { get; set; } 
    public string Description { get; set; } 

    public SeverityLevel Severity { get; set; } 
    public DisasterStatus Status { get; set; }

    public DateTime DateOccurred { get; set; }
    public int AffectedPopulation { get; set; } // Etkilenen nüfus sayısı
    public string AffectedArea { get; set; } // Etkilenen alanın büyüklüğü veya kapsamı (örneğin, kilometre kare olarak)
    public int CasualtyCount { get; set; } // Yaralı veya ölü sayısı
    public int EstimatedDamageCost { get; set; } // Tahmini hasar maliyeti (örneğin, milyon TL olarak)
    public bool IsInternationalAidRequired { get; set; } // Uluslararası yardıma ihtiyaç olup olmadığı
    
    public int ResponseTeamsCount { get; set; }
    public DateTime LastUpdated { get; set; }
}
