using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Request:Entity<Guid> //yardım talebi
{
    public Guid DisasterId { get; set; } //yardım talebinin bağlı olduğu afetin Id'si

    public List<Resource> RequestedResources { get; set; } //yardım talebinde bulunan kaynaklar

    public string Status { get; set; } //yardım talebinin durumu, e.g. Pending, Completed, In Progress etc.

    public string Location { get; set; } //yardım talebinin bulunduğu yer
    
    public DateTime DateRequested { get; set; } //yardım talebinin ne zaman yapıldığı

    public string PriorityLevel { get; set; } //yardım talebinin öncelik seviyesi, e.g. High, Medium, Low.
    
    public Request()
    {
        
    }
    
    public Request(Guid id, Guid disasterId, List<Resource> requestedResources, string status, string location, DateTime dateRequested, string priorityLevel)
    {
        Id = id;
        DisasterId = disasterId;
        RequestedResources = requestedResources;
        Status = status;
        Location = location;
        DateRequested = dateRequested;
        PriorityLevel = priorityLevel;
    }
}