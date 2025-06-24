namespace Api.Domain.Validation;

public abstract class Constants
{
    public const int MaxNameLength = 100;
    public const int MaxAddressLength = 200;
    public const int MaxCityLength = 100;
    public const int MaxStateLength = 50;
    public const int MaxPhoneNumberLength = 15;
    public const int MaxEmailLength = 254; // RFC 5321
    public const int MaxTitleLength = 150;
    public const int MaxDescriptionLength = 500;

    public static readonly DateTime MinDateOfBirth = new DateTime(1900, 1, 1);
    
}