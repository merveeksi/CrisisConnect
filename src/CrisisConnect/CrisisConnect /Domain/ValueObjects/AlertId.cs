namespace Domain.ValueObjects;

public record struct AlertId
{
    public long Value { get; init; }
    
    public AlertId(long value)
    {
        if (value <= 0)
            throw new ArgumentException("Alert ID cannot be less than or equal to 0");

        Value = value;
    }
    
    public static implicit operator long(AlertId alertId) => alertId.Value;
    public static implicit operator AlertId(long value) => new(value);
}