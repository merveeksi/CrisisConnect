using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Donor:Entity<Guid> //bağışçı
{
    public string FirstName { get; set; } //bağışçının adı
    
    public string LastName { get; set; } //bağışçının soyadı
    
    public string? Email { get; set; } //bağışçının e-posta adresi
    
    public decimal PhoneNumber { get; set; } //bağışçının telefon numarası
    
    public string Location { get; set; } //bağışçının bulunduğu yer
    
    public List<Resource> DonatedResources { get; set; } //bağışçının bağışladığı kaynaklar

    public Donor()
    {
        
    }
    
    public Donor(Guid id, string firstName, string lastName, string email, decimal phoneNumber, string location, List<Resource> donatedResources)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Location = location;
        DonatedResources = donatedResources;
    }
}