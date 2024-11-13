using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public sealed record ContactInfo
{
    public int PhoneNumber { get; init; }
    public string? Email { get; init; }
    public Address Address { get; init; }
    
    // Parameteresiz constructor EF Core için gerekli
    private ContactInfo() { }

    public ContactInfo(int phoneNumber, string? email, Address address)
    {
        if (phoneNumber <= 0)
            throw new ArgumentException("Phone number must be a positive integer.", nameof(phoneNumber));
        if (!Regex.IsMatch(phoneNumber.ToString(), @"^\d+$"))
            throw new ArgumentException("Phone number must contain only numeric characters.", nameof(phoneNumber));
        
        if (email != null && !IsValidEmail(email))
            throw new ArgumentException("Invalid email address.", nameof(email));
        
        Address = address ?? throw new ArgumentNullException(nameof(address), "Address cannot be null.");

        Email = email;
        PhoneNumber = phoneNumber;
    }

    private bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public override string ToString()
    {
        return $"Email: {Email ?? "N/A"}, Phone: {PhoneNumber}, Address: {Address}";
    }
}