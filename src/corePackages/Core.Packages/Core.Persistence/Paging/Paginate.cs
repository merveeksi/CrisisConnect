namespace Core.Persistence.Paging;

//sayfalama işlemleri
public class Paginate<T>
{
    public Paginate() 
    {
        Items = Array.Empty<T>();
    }

    public int Size { get; set; }
    public int Index { get; set; }
    
    public int Count { get; set; }            //toplam kayıt sayısı
    public int Pages { get; set; }            //toplam sayfa sayısı
    public IList<T> Items { get; set; }       //sayfadaki kayıtlar, data

    public bool HasPrevious => Index > 0;     //önceki sayfa var mı?
    
    public bool HasNext => Index+1 < Pages;   //sonraki sayfa var mı?
}