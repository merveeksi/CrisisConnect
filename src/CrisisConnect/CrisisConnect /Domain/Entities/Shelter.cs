using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Shelter:Entity<Guid> //barınak
{
    public Guid? VolunteerId { get; set; }
    public Guid? DisasterId { get; set; }
    public Guid? RequestId { get; set; }
    
    // Basic Information
    public string Name { get; set; }
    public ShelterStatus Status { get; set; }
    
    // Location
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    // Capacity Management
    public int TotalCapacity { get; set; }
    public int CurrentOccupancy { get; set; }
    public bool HasAccessibility { get; set; }  // Engelli erişimi var mı?
    
    // Contact & Facilities
    public string PhoneNumber { get; set; }
    public string EmergencyPhone { get; set; }
    public bool HasMedicalSupport { get; set; }
    public bool HasKitchen { get; set; }
    
    // Tracking
    public DateTime OpenedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    // Navigation Properties
    public virtual Request? Request { get; set; }
    public virtual Disaster? Disaster { get; set; }
    public virtual Volunteer? Volunteer { get; set; }
    public virtual ICollection<Resource> Resources { get; set; }
    
    
    public Shelter()
    {
        Resources = new HashSet<Resource>();
    }

    public Shelter(Guid id, Guid volunteerId, Guid disasterId, Guid requestId, string name, ShelterStatus status, string city, string district, string address, 
        double? latitude, double? longitude, int totalCapacity, int currentOccupancy, bool hasAccessibility, string phoneNumber, 
        string emergencyPhone, bool hasMedicalSupport, bool hasKitchen, DateTime openedAt, DateTime? closedAt):this()
    {
        Id = id;
        VolunteerId = volunteerId;
        DisasterId = disasterId;
        RequestId = requestId;
        Name = name;
        Status = status;
        City = city;
        District = district;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        TotalCapacity = totalCapacity;
        CurrentOccupancy = currentOccupancy;
        HasAccessibility = hasAccessibility;
        PhoneNumber = phoneNumber;
        EmergencyPhone = emergencyPhone;
        HasMedicalSupport = hasMedicalSupport;
        HasKitchen = hasKitchen;
        OpenedAt = openedAt;
        ClosedAt = closedAt;
    }
}