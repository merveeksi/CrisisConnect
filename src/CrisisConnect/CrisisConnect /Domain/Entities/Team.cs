using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Team:Entity<Guid> //müdahale ekibi
{
    public string Name { get; set; }

    public string Specialty { get; set; } //ekibin uzmanlık alanı

    public List<Volunteer> TeamMembers { get; set; } //ekip üyeleri

    public string CurrentAssignment { get; set; } //şu anki görevi
    
    public string ImageUrl { get; set; }

    public virtual ICollection<Volunteer> Volunteers { get; set; }
    public virtual Disaster? Disaster { get; set; }
    
    public Team()
    {
        Volunteers = new HashSet<Volunteer>();
    }
    
    public Team(Guid id, string name, string specialty, List<Volunteer> teamMembers, string currentAssignment, string imageUrl):this()
    {
        Id = id;
        Name = name;
        Specialty = specialty;
        TeamMembers = teamMembers;
        CurrentAssignment = currentAssignment;
        ImageUrl = imageUrl;
    }
}