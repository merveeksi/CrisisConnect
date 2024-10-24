using System.Security.AccessControl;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Resource:Entity<Guid> //kaynak
{
    public string Name { get; set; } //kaynağın adı
    
    public ResourceType Type { get; set; } //kaynağın türü
    
    public int Quantity { get; set; } //kaynağın miktarı
    
    public string Location { get; set; } //kaynağın bulunduğu yer
    
    public Guid DisasterId { get; set; } //kaynağın bağlı olduğu afetin Id'si
    
    public virtual Disaster? Disaster { get; set; } //kaynağın bağlı olduğu afet

    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<Logistic> Logistics { get; set; }
    
    public Resource()
    {
        Resources = new HashSet<Resource>();
        Requests = new HashSet<Request>();
        Logistics = new HashSet<Logistic>();
    }
    
    public Resource(Guid id, string name, ResourceType type, int quantity, string location, Guid disasterId):this()
    {
        Id = id;
        Name = name;
        Type = type;
        Quantity = quantity;
        Location = location;
        DisasterId = disasterId;
    }
}