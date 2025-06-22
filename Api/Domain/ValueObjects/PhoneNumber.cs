namespace Api.Domain.ValueObjects;

public record PhoneNumber
{
    private string Value { get; init; }

    
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
        }
        
        // Extract the digits from the input string
        value = System.Text.RegularExpressions.Regex.Replace(value, @"[^\d+]", "");
        if (value.Length < 10 || value.Length > 15)
        {
            throw new ArgumentException("Phone number must be between 10 and 15 digits.", nameof(value));
        }

        Value = value;
    }
    
    /// <summary>
    /// Simple and naive string representation of the phone number.
    /// </summary>
    public override string ToString()
    {
        // Format the phone number as needed, e.g., (123) 456-7890
        return Value.Length switch
        {
            10 => $"({Value.Substring(0, 3)}) {Value.Substring(3, 3)}-{Value.Substring(6)}",
            11 => $"+{Value[0]} ({Value.Substring(1, 3)}) {Value.Substring(4, 3)}-{Value.Substring(7)}",
            _ => Value // Return as is for lengths other than 10 or 11
        };
    }
}