using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Request:Entity<Guid> //yardım talebi
{
    public Guid DisasterId { get; set; } //yardım talebinin bağlı olduğu afetin Id'si, HasForeignKey için
    public Guid ResourceId { get; set; } //HasForeignKey için
    public Guid VolunteerId { get; set; } //HasForeignKey için
    public RequestStatus Status { get; set; } //yardım talebinin durumu, e.g. Pending, Completed, In Progress etc.
    public string Location { get; set; } //yardım talebinin bulunduğu yer
    public DateTime DateRequested { get; set; } //yardım talebinin ne zaman yapıldığı
    public PriorityLevel Priority { get; set; } //yardım talebinin öncelik seviyesi, e.g. High, Medium, Low.
    public virtual Disaster? Disaster { get; set; }
    public virtual Resource? Resource{ get; set; } //HasOne için
    public virtual Volunteer? Volunteer { get; set; } //HasOne için
    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<RequestResource> RequestResources { get; set; }
    
    
    public Request()
    {
        Resources = new HashSet<Resource>();
        RequestResources = new HashSet<RequestResource>();
       
    }
    
    public Request(Guid id, Guid disasterId, Guid resourceId, Guid volunteerId, RequestStatus status, string location, DateTime dateRequested, PriorityLevel priority):this()
    {
        Id = id;
        DisasterId = disasterId;
        ResourceId = resourceId;
        VolunteerId = volunteerId;
        Status = status;
        Location = location;
        DateRequested = dateRequested;
        Priority = priority;
    }
}