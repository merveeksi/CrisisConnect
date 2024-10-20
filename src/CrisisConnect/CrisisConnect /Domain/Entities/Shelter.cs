using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Shelter:Entity<Guid> //barınak
{
    public string Location { get; set; }

    public string ContactInfo { get; set; } //barınağın iletişim bilgileri

    public int Capacity { get; set; } //barınağın kapasitesi

    public string Status { get; set; } //barınağın durumu, örneğin: açık, kapalı
    
    public int CurrentOccupancy { get; set; } //barınağın şu anki doluluk oranı
    
    public Shelter()
    {
        
    }
    
    public Shelter(Guid id, string location, string contactInfo, int capacity, string status, int currentOccupancy)
    {
        Id = id;
        Location = location;
        ContactInfo = contactInfo;
        Capacity = capacity;
        Status = status;
        CurrentOccupancy = currentOccupancy;
    }
}