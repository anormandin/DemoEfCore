using ErrorOr;
using FluentValidation.Results;

namespace Api.Extensions;

public static class ValidationResultExtensions
{
    public static List<Error> ToErrorList(this ValidationResult validationResult)
    {
        return validationResult.Errors
            .Select(error => Error.Validation(
                error.PropertyName,
                error.ErrorMessage))
            .ToList();
    }
    
}