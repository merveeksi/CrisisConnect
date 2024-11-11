using Domain.Enums;

namespace Domain.ValueObjects;

public sealed record ImpactAssessment
{
    public int Magnitude { get; set; } 
    public DisasterSeverity Severity { get; set; }
    public int EstimatedAffectedPopulation { get; set; } 
    public int InjuredCount { get; set; }
    public int ConfirmedCasualties { get; set; }
    
    public ImpactAssessment(int magnitude, DisasterSeverity severity, int estimatedAffectedPopulation, int injuredCount, int confirmedCasualties)
    {
        Magnitude = magnitude;
        Severity = severity;
        EstimatedAffectedPopulation = estimatedAffectedPopulation;
        InjuredCount = injuredCount;
        ConfirmedCasualties = confirmedCasualties;
    }
}