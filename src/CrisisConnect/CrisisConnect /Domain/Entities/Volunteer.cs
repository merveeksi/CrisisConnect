using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Volunteer:Entity<Guid> //gönüllü
{
    public string FirstName { get; set; } //gönüllünün adı
    
    public string Lastname { get; set; } //gönüllünün soyadı
    
    public List<string> Skills { get; set; } //gönüllünün sahip olduğu yetenekler
    
    public bool Availability { get; set; } //gönüllünün müsaitlik durumu
    
    public string Location { get; set; } //gönüllünün bulunduğu yer
    
    public string? Email { get; set; } //gönüllünün e-posta adresi
    
    public string PhoneNumber { get; set; } //gönüllünün telefon numarası
    
    public Volunteer()
    {
        
    }
    
    public Volunteer(Guid id, string firstName, string lastname, List<string> skills, bool availability, string location, string email, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        Lastname = lastname;
        Skills = skills;
        Availability = availability;
        Location = location;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}