using Core.Persistence.Repositories;
using Domain.Enums;
using Domain.ValueObjects;
using Humanizer.Localisation;

namespace Domain.Entities;

public class Disaster:Entity<Guid> //afet
{
    // Primary relationships
    public Guid? CenterId { get; set; }
    
    // Basic Information
    public string Name { get; set; }
    public DisasterType Type { get; set; }
    public bool IsActive { get; set; }
    public DisasterStatus Status { get; set; }
    public Address Address { get; set; }
    public string EmergencyContactInfo { get; set; }
    public ImpactAssessment ImpactAssessment { get; set; }
    
    // Timing Information
    public DateTime DateOccurred { get; set; } 
    public DateTime? DateResolved { get; set; } 

    // Audit
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
        
    
    
    //Nesnel ilişkilendirmeleri, bire bir (one-to-many), navigation properties, include edilecekler
    public virtual Center? Center { get; set; }
    public virtual ICollection<Shelter> Shelters { get; set; }
    public virtual ICollection<Alert> Alerts { get; set; }
    
    
    public Disaster()
    { 
        Shelters = new HashSet<Shelter>();
        Alerts = new HashSet<Alert>();
    }

    public Disaster(Guid id, Guid? centerId, string name, DisasterType type, bool isActive, DisasterStatus status, Address address, string emergencyContactInfo, ImpactAssessment impactAssessment, DateTime dateOccurred, DateTime? dateResolved, DateTime createdAt, DateTime? lastUpdatedAt) : base(id)
    {
        CenterId = centerId;
        Name = name;
        Type = type;
        IsActive = isActive;
        Status = status;
        Address = address;
        EmergencyContactInfo = emergencyContactInfo;
        ImpactAssessment = impactAssessment;
        DateOccurred = dateOccurred;
        DateResolved = dateResolved;
        CreatedAt = createdAt;
        LastUpdatedAt = lastUpdatedAt;
    }
}