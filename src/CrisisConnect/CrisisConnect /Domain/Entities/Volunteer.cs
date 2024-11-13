using Core.Persistence.Repositories;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Volunteer:Entity<VolunteerId> //gönüllü
{ 
    // Assignment
    public Guid? TeamId { get; set; }
    public ShelterId? ShelterId { get; set; }
    
    // Basic Information
    public FullName FullName { get; set; }
    public int PhoneNumber { get; set; }
    public Email? Email { get; set; }
    public Address Address { get; set; }
    public string Skills { get; set; }
    public string? ImageUrl { get; set; }
    
    
    // Navigation Properties
    public virtual Shelter? Shelter { get; set; }
    public virtual Team? Team { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public string IdentityNumber { get; set; }

    public Volunteer()
    {
        Requests = new HashSet<Request>();
    }

    public Volunteer(VolunteerId id, ShelterId shelterId, FullName fullName, int phoneNumber, Email email, Address address, string skills, string imageUrl) : this()
    {
        Id = id;
        ShelterId = shelterId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Skills = skills;
        ImageUrl = imageUrl;
    }
}