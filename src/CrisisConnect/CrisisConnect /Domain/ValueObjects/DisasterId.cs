namespace Domain.ValueObjects;

public record struct DisasterId
{
    public long Value { get; init; }
    
    public DisasterId(long value)
    {
        if (value <= 0)
            throw new ArgumentException("Disaster ID cannot be less than or equal to 0");

        Value = value;
    }
    
    public static implicit operator long(DisasterId disasterId) => disasterId.Value;
    public static implicit operator DisasterId(long value) => new(value);
}
