using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Team:Entity<Guid> //müdahale ekibi
{
    public Guid? VolunteerId { get; set; }
    public Guid? CenterId { get; set; }
    
    // Basic Information
    public string Name { get; set; }
    public TeamSpecialty Specialty { get; set; }
    public TeamStatus Status { get; set; }
    
    // Team Details
    public int MaxCapacity { get; set; }
    public int CurrentMemberCount { get; set; }
    public bool IsActive { get; set; }
    
    // Mission Information
    public string CurrentMission { get; set; }
    public DateTime? MissionStartTime { get; set; }
    public DateTime? ExpectedEndTime { get; set; }
    
    // Location
    public string CurrentLocation { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    
    
    // Navigation property
    public virtual Center? Center { get; set; }
    public virtual Volunteer? Volunteer { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    
    public Team()
    {
        Requests = new HashSet<Request>();
    }

    public Team(Guid id, Guid volunteerId, Guid centerId, string name, TeamSpecialty specialty, TeamStatus status, int maxCapacity, 
        int currentMemberCount, bool isActive, string currentMission, DateTime? missionStartTime, DateTime? expectedEndTime, 
        string currentLocation, double? latitude, double? longitude) : this()
    {
        VolunteerId = volunteerId;
        CenterId = centerId;
        Name = name;
        Specialty = specialty;
        Status = status;
        MaxCapacity = maxCapacity;
        CurrentMemberCount = currentMemberCount;
        IsActive = isActive;
        CurrentMission = currentMission;
        MissionStartTime = missionStartTime;
        ExpectedEndTime = expectedEndTime;
        CurrentLocation = currentLocation;
        Latitude = latitude;
        Longitude = longitude;
    }
   
}