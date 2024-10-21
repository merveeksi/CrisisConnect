namespace Core.Persistence.Dynamic;

//sıralama işlemleri için kullanılır
public class Sort
{
    public string Field { get; set; }
    public string Dir { get; set; }  // ASC or DESC, yönü belirler

    public Sort()
    {
        Field = string.Empty;
        Dir = string.Empty;
    }

    public Sort(string field, string dir)
    {
        Field = field;
        Dir = dir;
    }
}