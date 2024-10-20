namespace Core.Persistence.Repositories;

public class Entity<TId>
{
    public TId Id { get; set; }
    
    public DateTime CreatedDate { get; set; } //ne zaman oluşturuldu
    
    public DateTime? UpdatedDate { get; set; } //ne zaman güncellendi
    
    public DateTime? DeletedDate { get; set; } //ne zaman silindi

    public Entity()
    {
        Id = default;
    }

    public Entity(TId id)
    {
        Id = id;
    }
}