using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Alert:Entity<Guid> //acil durum uyarısı
{
    public string Message { get; set; }

    public string Severity { get; set; } //acil durumun ciddiyeti, örneğin: hafif, orta, ciddi

    public DateTime Datelssued { get; set; } //acil durum uyarısının verildiği zaman

    public string Location { get; set; } //acil durumun meydana geldiği yer
    
    public string AlertType { get; set; } //acil durum tipi, örneğin: yangın, deprem
    
    public string AlertStatus { get; set; } //acil durumun durumu, örneğin: devam ediyor, sona erdi

    public Alert()
    {
        
    }

    public Alert(Guid id, string message, string severity, DateTime datelssued, string location, string alertType, string alertStatus)
    {
        Id = id;
        Message = message;
        Severity = severity;
        Datelssued = datelssued;
        Location = location;
        AlertType = alertType;
        AlertStatus = alertStatus;
    }
}
