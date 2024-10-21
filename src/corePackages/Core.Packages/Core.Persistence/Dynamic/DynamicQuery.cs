namespace Core.Persistence.Dynamic;

//DynamicQuery sınıfı, filtreleme ve sıralama işlemlerini yapmak için kullanılır.
public class DynamicQuery
{
    public IEnumerable<Sort>? Sort { get; set; }
    public Filter? Filter { get; set; }

    public DynamicQuery()
    {
        
    }

    public DynamicQuery(IEnumerable<Sort>? sort, Filter? filter)
    {
        Filter = filter;
        Sort = sort;
    }
}