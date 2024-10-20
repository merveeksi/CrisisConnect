using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Team:Entity<Guid> //müdahale ekibi
{
    public string Name { get; set; }

    public string Specialty { get; set; } //ekibin uzmanlık alanı

    public List<Volunteer> TeamMembers { get; set; } //ekip üyeleri

    public string CurrentAssignment { get; set; } //şu anki görevi
    
    public Team()
    {
        
    }
    
    public Team(Guid id, string name, string specialty, List<Volunteer> teamMembers, string currentAssignment)
    {
        Id = id;
        Name = name;
        Specialty = specialty;
        TeamMembers = teamMembers;
        CurrentAssignment = currentAssignment;
    }
}