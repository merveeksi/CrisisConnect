using System.Security.AccessControl;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Resource:Entity<Guid> //kaynak
{ 
    public string Name { get; set; } //kaynağın adı
    public ResourceType Type { get; set; } //kaynağın türü
    
    public int Quantity { get; set; } //kaynağın miktarı
    
    public string Location { get; set; } //kaynağın bulunduğu yer
    
   
    
    public Resource()
    {
    }
    
    public Resource(Guid id, string name, ResourceType type, int quantity, string location):this()
    {
        Id = id;
        Name = name;
        Type = type;
        Quantity = quantity;
        Location = location;
    }
}