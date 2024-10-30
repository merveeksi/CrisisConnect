namespace Application.Features.Donors.Queries.GetListByDynamic;

public class GetListByDynamicDonorListItemDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal AmountDonated { get; set; } // Bağışladığı toplam miktar
    
    public DateTime DonationDate { get; set; } // Bağış tarih

    // İlişkiler
    public string AlertName { get; set; }
    public string DisasterName { get; set; } 
    public string TeamName { get; set; }
}