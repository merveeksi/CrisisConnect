using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Shelter:Entity<Guid> //barınak
{
    public string Name { get; set; }
    public string Location { get; set; }

    public string ContactInfo { get; set; } //barınağın iletişim bilgileri

    public int Capacity { get; set; } //barınağın kapasitesi

    public string Status { get; set; } //barınağın durumu, örneğin: açık, kapalı
    
    public int CurrentOccupancy { get; set; } //barınağın şu anki doluluk oranı
    public string ImageUrl { get; set; }

    public virtual Disaster? Disaster { get; set; }
    
    public Shelter()
    {
        
    }
    
    public Shelter(Guid id, string name, string location, string contactInfo, int capacity, string status, int currentOccupancy, string imageUrl):this()
    {
        Id = id;
        Name = name;
        Location = location;
        ContactInfo = contactInfo;
        Capacity = capacity;
        Status = status;
        CurrentOccupancy = currentOccupancy;
        ImageUrl = imageUrl;
    }
}