using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Resource:Entity<Guid> //kaynak
{
    public string Name { get; set; } //kaynağın adı
    
    public string Type { get; set; } //kaynağın türü
    
    public int Quantity { get; set; } //kaynağın miktarı
    
    public string Location { get; set; } //kaynağın bulunduğu yer
    
    public Guid DisasterId { get; set; } //kaynağın bağlı olduğu afetin Id'si
    
    public Resource()
    {
        
    }
    
    public Resource(Guid id, string name, string type, int quantity, string location, Guid disasterId)
    {
        Id = id;
        Name = name;
        Type = type;
        Quantity = quantity;
        Location = location;
        DisasterId = disasterId;
    }
}