using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Alert:Entity<Guid> //acil durum uyarısı
{
    public string Name { get; set; }
    public string Message { get; set; }

    public SeverityLevel Severity { get; set; } //acil durumun ciddiyeti, örneğin: hafif, orta, ciddi

    public DateTime Datelssued { get; set; } //acil durum uyarısının verildiği zaman

    public string Location { get; set; } //acil durumun meydana geldiği yer
    
    public string AlertType { get; set; } //acil durum tipi, örneğin: yangın, deprem
    
    public string AlertStatus { get; set; } //acil durumun durumu, örneğin: devam ediyor, sona erdi
    
    
    // Navigation Properties
    public virtual Disaster? Disaster { get; set; } 
    
    public Alert()
    {
    }
    
    public Alert(Guid id, string name, string message, SeverityLevel severity, 
        DateTime datelssued, string location, string alertType, string alertStatus):this()
    {
        Id = id;
        Name = name;
        Message = message;
        Severity = severity;
        Datelssued = datelssued;
        Location = location;
        AlertType = alertType;
        AlertStatus = alertStatus;
    }
}
