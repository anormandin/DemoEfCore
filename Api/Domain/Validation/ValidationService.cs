using FluentValidation.Results;

namespace Api.Domain.Validation;

using FluentValidation;

public class ValidationService
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ValidationResult Validate<TRequest>(TRequest request)
    {
        var validator = _serviceProvider.GetService(typeof(IValidator<TRequest>)) as IValidator<TRequest>;
        if (validator == null)
            throw new InvalidOperationException($"No validator found for {typeof(TRequest).Name}");

        return validator.Validate(request);
    }
}