using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Logistic:Entity<Guid> //lojistik
{
    public Guid Resourceld { get; set; } //taşınan kaynak Id'si

    public string Destination { get; set; } //kaynakların varış yeri

    public DateTime EstimatedArrival { get; set; } //tahmini varış zamanı

    public string CurrentStatus { get; set; } //taşınma durumu, örneğin: yolda, varış noktasında
    
    public Logistic()
    {
        
    }
    
    public Logistic(Guid id, Guid resourceld, string destination, DateTime estimatedArrival, string currentStatus)
    {
        Id = id;
        Resourceld = resourceld;
        Destination = destination;
        EstimatedArrival = estimatedArrival;
        CurrentStatus = currentStatus;
    }
}