using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Request:Entity<Guid> //yardım talebi
{
    public Guid ShelterId { get; set; } 
  
    // Basic Request Information
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public RequestType Type { get; set; }
    public RequestStatus Status { get; set; }
    public PriorityLevel Priority { get; set; }
    
    // Location Details
    public string City { get; set; }
    public string District { get; set; }
    public string DetailedAddress { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    // Quantities and Requirements
    public int RequiredQuantity { get; set; }
    public int? FulfilledQuantity { get; set; }
    public string SpecialRequirements { get; set; }
    public bool RequiresSpecialTransport { get; set; }
    public int NumberOfPeopleAffected { get; set; }

    // Timing Information
    public DateTime DateRequested { get; set; }
    public DateTime? DateNeededBy { get; set; }
    public DateTime? DateAssigned { get; set; }
    public DateTime? DateFulfilled { get; set; }
    
    // Contact Information
    public string RequestorName { get; set; }
    public string ContactPhone { get; set; }
    public string AlternateContactPhone { get; set; }

    // Tracking
    public bool IsUrgent { get; set; }
    public string CancellationReason { get; set; }
    public string Notes { get; set; }
    
    // Audit
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    
    //Navigation Properties
    public virtual Shelter? Shelter { get; set; }
    
    
    public Request()
    {
    }

    public Request(Guid id, Guid shelterId, string title, string description, RequestType type, RequestStatus status, PriorityLevel priority, 
        string city, string district, string detailedAddress, double? latitude, double? longitude, int requiredQuantity, int? fulfilledQuantity, 
        string specialRequirements, bool requiresSpecialTransport, int numberOfPeopleAffected, DateTime dateRequested, DateTime? dateNeededBy, 
        DateTime? dateAssigned, DateTime? dateFulfilled, string requestorName, string contactPhone, string alternateContactPhone, bool isUrgent, 
        string cancellationReason, string notes, DateTime createdAt, DateTime? lastUpdatedAt, Shelter? shelter):this()
    {
        Id = id;
        ShelterId = shelterId;
        Title = title;
        Description = description;
        Type = type;
        Status = status;
        Priority = priority;
        City = city;
        District = district;
        DetailedAddress = detailedAddress;
        Latitude = latitude;
        Longitude = longitude;
        RequiredQuantity = requiredQuantity;
        FulfilledQuantity = fulfilledQuantity;
        SpecialRequirements = specialRequirements;
        RequiresSpecialTransport = requiresSpecialTransport;
        NumberOfPeopleAffected = numberOfPeopleAffected;
        DateRequested = dateRequested;
        DateNeededBy = dateNeededBy;
        DateAssigned = dateAssigned;
        DateFulfilled = dateFulfilled;
        RequestorName = requestorName;
        ContactPhone = contactPhone;
        AlternateContactPhone = alternateContactPhone;
        IsUrgent = isUrgent;
        CancellationReason = cancellationReason;
        Notes = notes;
        CreatedAt = createdAt;
        LastUpdatedAt = lastUpdatedAt;
        Shelter = shelter;
    }
}