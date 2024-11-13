using Core.Persistence.Repositories;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Alert : Entity<AlertId> //acil durum uyarısı
{
    public DisasterId? DisasterId { get; set; }
    public string Name { get; set; }
    
    // Core alert information
    public string Description { get; set; }
    public AlertType Type { get; set; }
    public SeverityLevel Severity { get; set; }
    
    public Address Address { get; set; }
    
    // Status tracking
    public AlertStatus Status { get; set; }
    public string Instructions { get; set; }
    
    // Navigation Properties
    public virtual Disaster? Disaster { get; set; } 
    
    public Alert()
    {
    }

    public Alert(AlertId id, DisasterId disasterId, string name, string description, AlertType type, 
        SeverityLevel severity, Address address, AlertStatus status, string instructions):this()
    {
        Id = id;
        DisasterId = disasterId;
        Name = name;
        Description = description;
        Type = type;
        Severity = severity;
        Address = address;
        Status = status;
        Instructions = instructions;
    }
}
