namespace Domain.ValueObjects;

public sealed record VolunteerId
{
    public long Value { get; init; }
    
    public VolunteerId(long value)
    {
        if (value <= 0)
            throw new ArgumentException("Volunteer ID cannot be less than or equal to 0");

        Value = value;
    }
    
    public static implicit operator long(VolunteerId volunteerId) => volunteerId.Value;
    public static implicit operator VolunteerId(long value) => new(value);
}