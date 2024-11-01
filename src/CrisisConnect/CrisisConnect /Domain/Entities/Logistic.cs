using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Logistic:Entity<Guid> //lojistik
{
    public Guid ResourceId { get; set; } //taşınan kaynak Id'si

    public string Name { get; set; }
    public string Destination { get; set; } //kaynakların varış yeri
    public DateTime EstimatedArrival { get; set; } //tahmini varış zamanı
    public TransportStatus CurrentStatus { get; set; } //taşınma durumu, örneğin: yolda, varış noktasında
    
    public Logistic()
    {
        
    }
    
    public Logistic(Guid id, Guid resourceId, string name, string destination, DateTime estimatedArrival, TransportStatus currentStatus):this()
    {
        Id = id;
        ResourceId = resourceId;
        Name = name;
        Destination = destination;
        EstimatedArrival = estimatedArrival;
        CurrentStatus = currentStatus;
    }
}