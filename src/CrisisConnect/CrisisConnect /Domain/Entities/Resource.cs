using System.Security.AccessControl;
using Core.Persistence.Repositories;

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
    public DateTime ExpiryDate { get; set; }
    
    // Tracking
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
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
    
    public Resource(Guid id, string name, ResourceType type, int quantity, string location):this()
    {
        Id = id;
        Name = name;
        Type = type;
        Quantity = quantity;
        Location = location;
    }
}