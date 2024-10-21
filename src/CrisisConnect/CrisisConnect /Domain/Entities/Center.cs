using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Center:Entity<Guid> //yardım merkezi
{
    public string Name { get; set; } 
    
    public string Location { get; set; }

    public int Capacity { get; set; }

    public int CurrentStaff { get; set; } //yardım merkezindeki personel sayısı
    
    public List<Volunteer> Volunteers { get; set; } //yardım merkezindeki gönüllüler
    
    public List<Resource> Resources { get; set; } //yardım merkezindeki kaynaklar
    
    public List<Logistic> Logistics { get; set; } //yardım merkezindeki lojistik bilgiler

    public Center()
    {
        
    }

    public Center(Guid id, string name, string location, int capacity, int currentStaff, List<Volunteer> volunteers, List<Resource> resources, List<Logistic> logistics)
    {
        Id = id;
        Name = name;
        Location = location;
        Capacity = capacity;
        CurrentStaff = currentStaff;
        Volunteers = volunteers;
        Resources = resources;
        Logistics = logistics;
    }
}