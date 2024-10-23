namespace Application.Features.Disasters.Commands.Create;

//Vereceğim bilgi
public class CreatedDisasterResponse
{
    public string Name { get; set; }   //afet adı
    
    public Guid Id { get; set; }   //afet id'si

    public DateTime CreateDate { get; set; }
    
}