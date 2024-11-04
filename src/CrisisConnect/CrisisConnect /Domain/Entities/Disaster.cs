using Core.Persistence.Repositories;
using Domain.Enums;
using Humanizer.Localisation;

namespace Domain.Entities;

public class Disaster:Entity<Guid> //afet
{
    // Primary relationships
    public Guid? CenterId { get; set; }
    
    // Basic Information
    public string Name { get; set; }
    public DisasterType Type { get; set; }
    public DisasterStatus Status { get; set; }
    
    // Location Information
    public string City { get; set; }
    public string District { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    
    // Timing Information
    public DateTime DateOccurred { get; set; } 
    public DateTime? DateResolved { get; set; } 
    
    // Impact Assessment
    public int Magnitude { get; set; }
    public DisasterSeverity Severity { get; set; }
    public int EstimatedAffectedPopulation { get; set; }
    public int InjuredCount { get; set; }
    public int ConfirmedCasualties { get; set; }
    
    // Additional Details
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string EmergencyContactInfo { get; set; }

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

    public Disaster(Guid Id, Guid CenterId, string Name, DisasterType Type, DisasterStatus Status, 
        string City, string District, double? Latitude, double? Longitude, DateTime DateOccurred, 
        DateTime? DateResolved, int Magnitude, DisasterSeverity Severity, int EstimatedAffectedPopulation, 
        int InjuredCount, int ConfirmedCasualties, string Description, bool IsActive, string EmergencyContactInfo, 
        DateTime CreatedAt, DateTime? LastUpdatedAt):this()
    {
        this.Id = Id;
        this.CenterId = CenterId;
        this.Name = Name;
        this.Type = Type;
        this.Status = Status;
        this.City = City;
        this.District = District;
        this.Latitude = Latitude;
        this.Longitude = Longitude;
        this.DateOccurred = DateOccurred;
        this.DateResolved = DateResolved;
        this.Magnitude = Magnitude;
        this.Severity = Severity;
        this.EstimatedAffectedPopulation = EstimatedAffectedPopulation;
        this.InjuredCount = InjuredCount;
        this.ConfirmedCasualties = ConfirmedCasualties;
        this.Description = Description;
        this.IsActive = IsActive;
        this.EmergencyContactInfo = EmergencyContactInfo;
        this.CreatedAt = CreatedAt;
        this.LastUpdatedAt = LastUpdatedAt;
    }
}