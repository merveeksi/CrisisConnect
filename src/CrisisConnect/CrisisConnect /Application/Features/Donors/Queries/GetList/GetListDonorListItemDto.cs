namespace Application.Features.Donors.Queries.GetList;

public class GetListDonorListItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal AmountDonated { get; set; } // Bağışladığı toplam miktar

    public DateTime DonationDate { get; set; } // Bağış tarih
}