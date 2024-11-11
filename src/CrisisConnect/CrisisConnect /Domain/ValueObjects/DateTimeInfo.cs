namespace Domain.ValueObjects;

public sealed record DateTimeInfo
{
    // Timing Information
    public DateTime DateOccurred { get; set; } 
    public DateTime? DateResolved { get; set; }

    // Audit
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    

    public DateTimeInfo(DateTime dateOccurred, DateTime? dateResolved, DateTime createdAt, DateTime? lastUpdatedAt)
    {
        if (dateOccurred == default)
            throw new ArgumentException("DateOccurred cannot be the default DateTime value.", nameof(dateOccurred));

        if (createdAt == default)
            throw new ArgumentException("CreatedAt cannot be the default DateTime value.", nameof(createdAt));

        DateOccurred = dateOccurred;
        DateResolved = dateResolved;
        CreatedAt = createdAt;
        LastUpdatedAt = lastUpdatedAt;
    }

    // ToString method to display DateTime
    public override string ToString()
    {
        return $"Date Occurred: {DateOccurred}, Date Resolved: {DateResolved?.ToString() ?? "N/A"}, Created At: {CreatedAt}, Last Updated At: {LastUpdatedAt?.ToString() ?? "N/A"}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DateOccurred, DateResolved, CreatedAt, LastUpdatedAt);
    }
}