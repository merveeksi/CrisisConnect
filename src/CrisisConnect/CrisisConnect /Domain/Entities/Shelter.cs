using Core.Persistence.Repositories;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Shelter:Entity<ShelterId> //barınak
{
    public Guid? VolunteerId { get; set; }
    public Guid? DisasterId { get; set; }
    public Guid? RequestId { get; set; }
    
    // Basic Information
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
    public ShelterStatus Status { get; set; } 

    // Capacity Management
    public int TotalCapacity { get; set; }
    public bool HasAccessibility { get; set; }  // Engelli erişimi var mı?
    public bool HasMedicalSupport { get; set; } 
    public bool HasKitchen { get; set; } 
    
    // Tracking
    public DateTime OpenedAt { get; set; } 
    public DateTime ClosedAt { get; set; }

    // Navigation Properties
    public virtual Request? Request { get; set; }
    public virtual Disaster? Disaster { get; set; }
    public virtual Volunteer? Volunteer { get; set; }
    public virtual ICollection<Resource> Resources { get; set; }
    
    
    public Shelter()
    {
        Resources = new HashSet<Resource>();
    }
    
    public Shelter(ShelterId id, Guid volunteerId, Guid disasterId, Guid requestId, string name, string phoneNumber, 
        Address address, ShelterStatus status, int totalCapacity, bool hasAccessibility, bool hasMedicalSupport, 
        bool hasKitchen, DateTime openedAt, DateTime closedAt):this()
    {
        Id = id;
        VolunteerId = volunteerId;
        DisasterId = disasterId;
        RequestId = requestId;
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Status = status;
        TotalCapacity = totalCapacity;
        HasAccessibility = hasAccessibility;
        HasMedicalSupport = hasMedicalSupport;
        HasKitchen = hasKitchen;
        OpenedAt = openedAt;
        ClosedAt = closedAt;
    }
}