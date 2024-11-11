using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public sealed record ContactInfo
{
    public int PhoneNumber { get; }
    public string? Email { get; }
    public Address Address { get; }
    

    public ContactInfo(int phoneNumber, string? email, Address address)
    {
        if (phoneNumber <= 0)
            throw new ArgumentException("Phone number must be a positive integer.", nameof(phoneNumber));
        if (!Regex.IsMatch(phoneNumber.ToString(), @"^\d+$"))
            throw new ArgumentException("Phone number must contain only numeric characters.", nameof(phoneNumber));
        
        if (!string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            throw new ArgumentException("Invalid email address.", nameof(email));
        
        Address = address ?? throw new ArgumentNullException(nameof(address), "Address cannot be null.");

        Email = email;
        PhoneNumber = phoneNumber;
    }

    private bool IsValidEmail(string email)
    {
        // Basit bir email doğrulama işlemi.
        return email.Contains("@") && email.Contains(".");
    }

    public override string ToString()
    {
        return $"Email: {Email ?? "N/A"}, Phone: {PhoneNumber}, Address: {Address}";
    }
}