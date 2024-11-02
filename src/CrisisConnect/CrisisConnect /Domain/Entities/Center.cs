using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Center : Entity<Guid> //yardım merkezi
{
    public string Name { get; set; }

    public string Location { get; set; }

    public int Capacity { get; set; }

    public int CurrentStaff { get; set; } //yardım merkezindeki personel sayısı
    
    public string ImageUrl { get; set; }

    public List<Volunteer> Volunteers { get; set; } //yardım merkezindeki gönüllüler

    public List<Resource> Resources { get; set; } //yardım merkezindeki kaynaklar

    public List<Logistic> Logistics { get; set; } //yardım merkezindeki lojistik bilgiler
    
    // Primary relationships
    public virtual Disaster? Disaster { get; set; }
    public ICollection<Team> Teams { get; set; }
    
    public Center()
    {
        Teams = new HashSet<Team>(); 
    }
    
    public Center(Guid id, string name, string location, int capacity, int currentStaff, 
        List<Volunteer> volunteers, List<Resource> resources, List<Logistic> logistics, string imageUrl):this()
    {
        Id = id;
        Name = name;
        Location = location;
        Capacity = capacity;
        CurrentStaff = currentStaff;
        Volunteers = volunteers;
        Resources = resources;
        Logistics = logistics;
        ImageUrl = imageUrl;
    }

}