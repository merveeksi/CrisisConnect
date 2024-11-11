namespace Domain.ValueObjects;

public sealed record ShelterId
{
    public long Value { get; init; }
    
    public ShelterId(long value)
    {
        if (value <= 0)
            throw new ArgumentException("Shelter ID cannot be less than or equal to 0");

        Value = value;
    }
    
    public static implicit operator long(ShelterId shelterId) => shelterId.Value;
    public static implicit operator ShelterId(long value) => new(value);
}