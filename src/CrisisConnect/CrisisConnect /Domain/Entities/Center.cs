using Core.Persistence.Repositories;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Center : Entity<Guid> //yardım merkezi
{
    // Basic Information
    public DisasterId? DisasterId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CenterType Type { get; set; }
    public CenterStatus Status { get; set; }
    public bool IsActive { get; set; }
   


    // Location Information
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }

    // Capacity and Staff
    public int TotalCapacity { get; set; }
    public int CurrentOccupancy { get; set; }
    public int AvailableBeds { get; set; }
    public int TotalStaff { get; set; }
    public int MedicalStaff { get; set; }
    public int SupportStaff { get; set; }
    public int Volunteers { get; set; }

    // Contact Information
    public string PhoneNumber { get; set; }
    public string EmergencyPhone { get; set; }
    public string Email { get; set; }
    public string WebsiteUrl { get; set; }

    // Operating Information
    public bool Is24Hours { get; set; }
    public string OpenTime { get; set; }
    public string CloseTime { get; set; }
    public bool IsTemporaryClosed { get; set; }

    // Resources
    public string MainImageUrl { get; set; }
    public string AdditionalImageUrls { get; set; } // Comma-separated URLs
    public string AvailableServices { get; set; } // Comma-separated services

    // Audit
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }


    // Primary relationships
    public virtual Disaster? Disaster { get; set; }
    public virtual ICollection<Team> Teams { get; set; }
    public virtual ICollection<Resource> Resources { get; set; }

    public Center()
    {
        Teams = new HashSet<Team>();
        Resources = new HashSet<Resource>();
    }

    public Center(Guid id, DisasterId disasterId, string name, bool isActive, string description, CenterType type, CenterStatus status, double latitude, 
        double longitude, string address, string city, string region, string country, int totalCapacity, int currentOccupancy, int availableBeds, 
        int totalStaff, int medicalStaff, int supportStaff, int volunteers, string phoneNumber, string emergencyPhone, string email, string websiteUrl, 
        bool is24Hours, string openTime, string closeTime, bool isTemporaryClosed, string mainImageUrl, string additionalImageUrls, string availableServices, 
        DateTime createdAt, DateTime lastUpdatedAt):this()
    {
        Id = id;
        DisasterId = disasterId;
        Name = name;
        IsActive = isActive;
        Description = description;
        Type = type;
        Status = status;
        Latitude = latitude;
        Longitude = longitude;
        Address = address;
        City = city;
        Region = region;
        Country = country;
        TotalCapacity = totalCapacity;
        CurrentOccupancy = currentOccupancy;
        AvailableBeds = availableBeds;
        TotalStaff = totalStaff;
        MedicalStaff = medicalStaff;
        SupportStaff = supportStaff;
        Volunteers = volunteers;
        PhoneNumber = phoneNumber;
        EmergencyPhone = emergencyPhone;
        Email = email;
        WebsiteUrl = websiteUrl;
        Is24Hours = is24Hours;
        OpenTime = openTime;
        CloseTime = closeTime;
        IsTemporaryClosed = isTemporaryClosed;
        MainImageUrl = mainImageUrl;
        AdditionalImageUrls = additionalImageUrls;
        AvailableServices = availableServices;
        CreatedAt = createdAt;
        LastUpdatedAt = lastUpdatedAt;
    }
}
    