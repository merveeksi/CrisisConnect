using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Alert:Entity<Guid> //acil durum uyarısı
{
    public Guid? DisasterId { get; set; }
    public string Name { get; set; } //title gibi kullan
    
    // Core alert information
    public string Description { get; set; }
    public AlertType Type { get; set; }
    public SeverityLevel Severity { get; set; }
    
    // Temporal information
    public DateTime IssuedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    
    // Geographical information
    public GeoLocation Location { get; set; }
    
    // Status tracking
    public AlertStatus Status { get; set; }
    public string Instructions { get; set; }
    
    // Audit information
    public Guid IssuedBy { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    
    
    // Navigation Properties
    public virtual Disaster? Disaster { get; set; } 
    
    public Alert()
    {
    }

    public Alert(Guid id, Guid disasterId, string name, string description, AlertType type, SeverityLevel severity, DateTime issuedAt, DateTime? resolvedAt, GeoLocation location, AlertStatus status, string instructions, Guid issuedBy, DateTime lastUpdatedAt):this()
    {
        Id = id;
        DisasterId = disasterId;
        Name = name;
        Description = description;
        Type = type;
        Severity = severity;
        IssuedAt = issuedAt;
        ResolvedAt = resolvedAt;
        Location = location;
        Status = status;
        Instructions = instructions;
        IssuedBy = issuedBy;
        LastUpdatedAt = lastUpdatedAt;
    }
    
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
