namespace Api.Requests;

public class CreateEmployeRequestValidator : AbstractValidator<CreateEmployeRequest>
{
    public CreateEmployeRequestValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty()
            .WithMessage(_ => string.Format(Validations.RequiredField, nameof(CreateEmployeRequest.FirstName)))
            .MaximumLength(Constants.MaxNameLength)
            .WithMessage(_ => string.Format(Validations.MaxLength, nameof(CreateEmployeRequest.FirstName),
                Constants.MaxNameLength));

        RuleFor(r => r.LastName)
            .NotEmpty()
            .WithMessage(_ => string.Format(Validations.RequiredField, nameof(CreateEmployeRequest.LastName)))
            .MaximumLength(Constants.MaxNameLength)
            .WithMessage(_ =>
                string.Format(Validations.MaxLength, nameof(CreateEmployeRequest.LastName), Constants.MaxNameLength));

        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage(_ => string.Format(Validations.RequiredField, nameof(CreateEmployeRequest.Email)))
            .EmailAddress()
            .WithMessage(_ => string.Format(Validations.InvalidEmail, nameof(CreateEmployeRequest.Email)))
            .MaximumLength(Constants.MaxEmailLength)
            .WithMessage(_ =>
                string.Format(Validations.MaxLength, nameof(CreateEmployeRequest.Email), Constants.MaxEmailLength));

        RuleFor(r => r.DateOfBirth)
            .LessThan(DateTime.UtcNow)
            .When(r => r.DateOfBirth.HasValue)
            .WithMessage(_ => string.Format(Validations.DobMustBeInThePast));

        RuleFor(r => r.DateOfBirth)
            .GreaterThanOrEqualTo(Constants.MinDateOfBirth)
            .When(r => r.DateOfBirth.HasValue)
            .WithMessage(_ => string.Format(Validations.DobMustBeInThePast, Constants.MinDateOfBirth));
    }
}