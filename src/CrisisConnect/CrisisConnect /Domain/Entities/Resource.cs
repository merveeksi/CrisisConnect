using System.Security.AccessControl;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Resource:Entity<Guid> //kaynak
{
    public Guid DisasterId { get; set; }
    public string Name { get; set; } //kaynağın adı
    
    public ResourceType Type { get; set; } //kaynağın türü
    
    public int Quantity { get; set; } //kaynağın miktarı
    
    public string Location { get; set; } //kaynağın bulunduğu yer
    public virtual Disaster? Disaster { get; set; } //kaynağın bağlı olduğu afet

    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<Logistic> Logistics { get; set; }
    public virtual ICollection<RequestResource> RequestResources { get; set; }
    
    public Resource()
    {
        Resources = new HashSet<Resource>();
        Requests = new HashSet<Request>();
        Logistics = new HashSet<Logistic>();
        RequestResources = new HashSet<RequestResource>();
    }
    
    public Resource(Guid id, Guid disasterId, string name, ResourceType type, int quantity, string location):this()
    {
        Id = id;
        DisasterId = disasterId;
        Name = name;
        Type = type;
        Quantity = quantity;
        Location = location;
    }
}