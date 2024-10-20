using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Disaster:Entity<Guid> //afet
{
    public string Name { get; set; }
    
    public string Type { get; set; } // e.g. Earthquake, Flood, etc. türü
    
    public string Location { get; set; }
    
    public int Severity { get; set; } //şiddeti ve büyüklüğü
    
    public DateTime DateOccurred { get; set; } //ne zaman meydana geldi
    
    public int Casualties { get; set; } //yaralananlar, ölenler
    
    public string Description { get; set; } //afetin kısa açıklaması
    
    public List<Resource> ReliefEfforts { get; set; } //afete müdahale eden kaynaklar

    public Disaster()
    {
        
    }

    public Disaster(Guid id, string name, string type, string location, int severity, DateTime dateOccurred, int casualties, string description, List<Resource> reliefEfforts)
    {
        Id = id;
        Name = name;
        Type = type;
        Location = location;
        Severity = severity;
        DateOccurred = dateOccurred;
        Casualties = casualties;
        Description = description;
        ReliefEfforts = reliefEfforts;
    }
}