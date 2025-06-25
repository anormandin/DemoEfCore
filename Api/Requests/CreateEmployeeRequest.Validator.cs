namespace Api.Requests;

public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
{
    public CreateEmployeeRequestValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty()
            .WithMessage(_ => string.Format(Validations.RequiredField, nameof(CreateEmployeeRequest.FirstName)))
            .MaximumLength(Constants.MaxNameLength)
            .WithMessage(_ => string.Format(Validations.MaxLength, nameof(CreateEmployeeRequest.FirstName),
                Constants.MaxNameLength));

        RuleFor(r => r.LastName)
            .NotEmpty()
            .WithMessage(_ => string.Format(Validations.RequiredField, nameof(CreateEmployeeRequest.LastName)))
            .MaximumLength(Constants.MaxNameLength)
            .WithMessage(_ =>
                string.Format(Validations.MaxLength, nameof(CreateEmployeeRequest.LastName), Constants.MaxNameLength));

        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage(_ => string.Format(Validations.RequiredField, nameof(CreateEmployeeRequest.Email)))
            .EmailAddress()
            .WithMessage(_ => string.Format(Validations.InvalidEmail, nameof(CreateEmployeeRequest.Email)))
            .MaximumLength(Constants.MaxEmailLength)
            .WithMessage(_ =>
                string.Format(Validations.MaxLength, nameof(CreateEmployeeRequest.Email), Constants.MaxEmailLength));

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