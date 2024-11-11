using Core.Persistence.Repositories;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Donor:Entity<Guid> //bağışçı
{
    public FullName FullName { get; set; }
    public string PhoneNumber { get; set; } //bağışçının telefon numarası
    public string? Email { get; set; } //bağışçının e-posta adresi
    public string Location { get; set; } //bağışçının bulunduğu yer
    
    // Navigation Properties
    public virtual ICollection<Resource> Resources { get; set; }
    

    public Donor()
    {
        Resources = new HashSet<Resource>();
    }

    public Donor(Guid id, string fullName, string phoneNumber, string location)
    {
        Id = id;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Location = location;
    }
}