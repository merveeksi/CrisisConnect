using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Volunteer:Entity<Guid> //gönüllü
{ 
    // Assignment
    public Guid TeamId { get; set; }
    public Guid ShelterId { get; set; }
    // Basic Information
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Location { get; set; }
    
    // Skills and Status
    public string Skills { get; set; } // Comma separated skills
    public bool IsAvailable { get; set; }
    
    // Resources
    public string ImageUrl { get; set; }
    
    // Audit
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation Properties
    public virtual Shelter? Shelter { get; set; }
    public virtual Team? Team { get; set; }
    public virtual ICollection<Request> Requests { get; set; }

    public Volunteer()
    {
        Requests = new HashSet<Request>();
    }

    public Volunteer(Guid id, Guid teamId, Guid shelterId, string firstName, string lastName, string email, string phoneNumber, 
        string location, string skills, bool isAvailable, string imageUrl, DateTime createdAt, DateTime updatedAt):this()
    {
        Id = id;
        TeamId = teamId;
        ShelterId = shelterId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Location = location;
        Skills = skills;
        IsAvailable = isAvailable;
        ImageUrl = imageUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}