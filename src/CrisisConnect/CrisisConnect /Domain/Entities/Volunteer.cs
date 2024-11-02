using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Volunteer:Entity<Guid> //gönüllü
{ 
    public Guid TeamId { get; set; }
    public string FirstName { get; set; } //gönüllünün adı
    
    public string LastName { get; set; } //gönüllünün soyadı
    
    public List<string> Skills { get; set; } //gönüllünün sahip olduğu yetenekler
    
    public bool Availability { get; set; } //gönüllünün müsaitlik durumu
    
    public string Location { get; set; } //gönüllünün bulunduğu yer
    
    public string? Email { get; set; } //gönüllünün e-posta adresi
    
    public string PhoneNumber { get; set; } //gönüllünün telefon numarası
    
    public string ImageUrl { get; set; }
    
    // Navigation Properties
    public virtual Shelter? Shelter { get; set; }
    public virtual Team? Team { get; set; }
    public virtual ICollection<Request> Requests { get; set; }

    public Volunteer()
    {
        Requests = new HashSet<Request>();
    }
    
    public Volunteer(Guid id, Guid teamId, string firstName, string lastName, List<string> skills, 
        bool availability, string location, string email, string phoneNumber, string imageUrl):this()
    {
        Id = id;
        TeamId = teamId;
        FirstName = firstName;
        LastName = lastName;
        Skills = skills;
        Availability = availability;
        Location = location;
        Email = email;
        PhoneNumber = phoneNumber;
        ImageUrl = imageUrl;
    }
}