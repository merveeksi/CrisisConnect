namespace Core.Persistence.Dynamic;

public class Filter
{
    public string Field { get; set; }   //alan adı
    
    public string? Value { get; set; }  //değer
    public string Operator { get; set; }  //operatör
    
    public string? Logic { get; set; }  //mantıksal operatör, and, or,birden fazla filtrede kullanılacak

    public IEnumerable<Filter>? Filters { get; set; } //birden fazla filtrede kullanılacak

    public Filter()
    {
        Field = string.Empty;
        Operator = string.Empty;
    }

    public Filter(string field, string @operator)
    {
        Field = field;
        Operator = @operator;
    }
}
