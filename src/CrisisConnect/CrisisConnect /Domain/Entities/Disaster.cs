using Core.Persistence.Repositories;
using Domain.Enums;
using Domain.ValueObjects;
using Humanizer.Localisation;
using DateTime = System.DateTime;

namespace Domain.Entities;

public class Disaster:Entity<DisasterId> //afet
{
    // Primary relationships
    public Guid? CenterId { get; set; }
    
    // Basic Information
    public string Name { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public DisasterType Type { get; set; }
    public DisasterStatus Status { get; set; }
    public ImpactAssessment ImpactAssessment { get; set; }
    public DateTimeInfo DateTime { get; set; }
    
    
    //Nesnel ilişkilendirmeleri, bire bir (one-to-many), navigation properties, include edilecekler
    public virtual Center? Center { get; set; }
    public virtual ICollection<Shelter> Shelters { get; set; }
    public virtual ICollection<Alert> Alerts { get; set; }


    public Disaster()
    { 
        Shelters = new HashSet<Shelter>();
        Alerts = new HashSet<Alert>();
    }

    public Disaster(DisasterId id, Guid centerId, string name, ContactInfo contactInfo, DisasterType type, 
        DisasterStatus status, ImpactAssessment impactAssessment, DateTimeInfo dateTime):this()
    {
        Id = id;
        CenterId = centerId;
        Name = name;
        ContactInfo = contactInfo;
        Type = type;
        Status = status;
        ImpactAssessment = impactAssessment;
        DateTime = dateTime;
    }
}