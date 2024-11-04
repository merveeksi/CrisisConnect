using Core.Persistence.Repositories;
using Domain.Enums;
using ResourceType = System.Security.AccessControl.ResourceType;

namespace Domain.Entities;

public class Resource:Entity<Guid> //kaynak
{ 
    // Basic Information
    public string Name { get; set; }
    public ResourceType Type { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; }
    
    // Additional Details
    public string Description { get; set; }
    public string Unit { get; set; }  // kg, litre, adet vb.
    public int MinimumQuantity { get; set; }
    
    // Status
    public bool IsAvailable { get; set; }
    public DateTime? ExpiryDate { get; set; }
    
    // Tracking
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Other
    public bool IsActive { get; set; }
    public ResourceStatus Status { get; set; }
    public bool HasTransferRestriction { get; set; }
    public bool IsPerishable { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool RequiresColdChain { get; set; }
    public int AvailableQuantity { get; set; }
    public bool IsReserved { get; set; }
    public int MinimumStockLevel { get; set; }
    
    // Navigation Properties
    public virtual ICollection<Center> Centers { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<Shelter> Shelters { get; set; }
    public virtual ICollection<Donor> Donors { get; set; }
    
    public Resource()
    {
        Centers = new HashSet<Center>();
        Requests = new HashSet<Request>();
        Shelters = new HashSet<Shelter>();
        Donors = new HashSet<Donor>();
    }

    public Resource(Guid id, string name, ResourceType type, int quantity, string location, string description, string unit, 
        int minimumQuantity, bool isAvailable, DateTime expiryDate, DateTime createdAt, DateTime updatedAt, bool isActive, 
        ResourceStatus status, bool hasTransferRestriction, bool isPerishable, DateTime expirationDate, bool requiresColdChain):this()
    {
        Id = id;
        Name = name;
        Type = type;
        Quantity = quantity;
        Location = location;
        Description = description;
        Unit = unit;
        MinimumQuantity = minimumQuantity;
        IsAvailable = isAvailable;
        ExpiryDate = expiryDate;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
        Status = status;
        HasTransferRestriction = hasTransferRestriction;
        IsPerishable = isPerishable;
        ExpirationDate = expirationDate;
        RequiresColdChain = requiresColdChain;
    }
}