namespace Api.Domain.ValueObjects;

public partial record PhoneNumber
{
    private string Value { get; init; }

    
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
        }

        // Remove any non-digit characters except for the leading '+' sign
        value = CleanPhoneRegex().Replace(value, "");
        
        // Extract the digits from the input string
        if (value.Length is < 10 or > 15)
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
            10 => $"({Value[..3]}) {Value[3..6]}-{Value[6..]}",
            11 => $"+{Value[0]} ({Value[1..4]}) {Value[4..7]}-{Value[7..]}",
            _ => Value // Return as is for lengths other than 10 or 11
        };
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"[^\d+]")]
    private static partial System.Text.RegularExpressions.Regex CleanPhoneRegex();
}