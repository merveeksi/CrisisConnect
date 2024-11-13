using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Logistic:Entity<Guid> //lojistik
{
    // Basic Information
    public string Name { get; set; }
    public string Description { get; set; }
    public LogisticType Type { get; set; }
    public LogisticStatus Status { get; set; }
    
    // Delivery Information
    public string SourceLocation { get; set; }
    public string DestinationLocation { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }
    
    // Content Information
    public string Content { get; set; }
    public int Quantity { get; set; }
    public string Priority { get; set; }
    
    // Tracking
    public Guid? AssignedVehicleId { get; set; }
    public Guid? ResponsiblePersonId { get; set; }
    
    public Logistic()
    {
        
    }

    public Logistic(Guid id, string name, string description, LogisticType type, LogisticStatus status, string sourceLocation, 
        string destinationLocation, DateTime expectedDeliveryDate, DateTime? actualDeliveryDate, string content, int quantity, string priority, 
        Guid? assignedVehicleId, Guid? responsiblePersonId):this()
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        Status = status;
        SourceLocation = sourceLocation;
        DestinationLocation = destinationLocation;
        ExpectedDeliveryDate = expectedDeliveryDate;
        ActualDeliveryDate = actualDeliveryDate;
        Content = content;
        Quantity = quantity;
        Priority = priority;
        AssignedVehicleId = assignedVehicleId;
        ResponsiblePersonId = responsiblePersonId;
    }
  
}