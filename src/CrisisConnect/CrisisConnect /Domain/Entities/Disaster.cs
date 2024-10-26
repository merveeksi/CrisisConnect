using Core.Persistence.Repositories;
using Humanizer.Localisation;

namespace Domain.Entities;

public class Disaster:Entity<Guid> //afet
{
    public Guid TeamId { get; set; }
    public Guid AlertId { get; set; }
    public Guid ResourceId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // e.g. Earthquake, Flood, etc. türü
    public string Location { get; set; }
    public int Severity { get; set; } //şiddeti ve büyüklüğü
    public DateTime DateOccurred { get; set; } //ne zaman meydana geldi
    public int Casualties { get; set; } //yaralananlar, ölenler
    public string? Description { get; set; } //afetin kısa açıklaması
    public List<Resource>? ReliefEfforts { get; set; } //afete müdahale eden kaynaklar
    
    //Nesnel ilişkilendirmeleri
    public virtual Team? Team { get; set; }
    public virtual Alert? Alert { get; set; }
    
    //ICollection kullanarak ilişkileri (one-to-many veya many-to-one) modelleyebilirim
    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<Volunteer> Volunteers { get; set; } 
    public virtual ICollection<Request> Requests { get; set; } 
    public virtual ICollection<Shelter> Shelters { get; set; }
    public virtual ICollection<Logistic> Logistics { get; set; } //withMany için

    public virtual ICollection<Team> Teams { get; set; }
    
    public Disaster()
    { 
        Resources = new HashSet<Resource>(); 
        Volunteers = new HashSet<Volunteer>(); 
        Requests = new HashSet<Request>(); 
        Shelters = new HashSet<Shelter>();
        Logistics = new HashSet<Logistic>();
        Teams = new HashSet<Team>();
       
       
    }
    
    public Disaster(Guid id, Guid teamId, Guid alertId, Guid resourceId, string name, string type, string location, int severity, DateTime dateOccurred, int casualties, string description, List<Resource> reliefEfforts):this()
    {
        Id = id;
        TeamId = teamId;
        AlertId = alertId;
        ResourceId = resourceId;
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