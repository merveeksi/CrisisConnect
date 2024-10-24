using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Logistic:Entity<Guid> //lojistik
{
    public Guid ResourceId { get; set; } //taşınan kaynak Id'si

    public Guid DisasterId { get; set; }

    public string Destination { get; set; } //kaynakların varış yeri

    public DateTime EstimatedArrival { get; set; } //tahmini varış zamanı

    public TransportStatus CurrentStatus { get; set; } //taşınma durumu, örneğin: yolda, varış noktasında

    public virtual Disaster? Disaster { get; set; }
    public virtual Resource? Resource { get; set; }
    
    public Logistic()
    {
        
    }
    
    public Logistic(Guid id, Guid resourceId, Guid disasterId, string destination, DateTime estimatedArrival, TransportStatus currentStatus):this()
    {
        Id = id;
        ResourceId = resourceId;
        DisasterId = disasterId;
        Destination = destination;
        EstimatedArrival = estimatedArrival;
        CurrentStatus = currentStatus;
    }
}