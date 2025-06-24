using ErrorOr;

using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoEfCoreController : ControllerBase
{
    protected IActionResult OkResult<T>(ErrorOr<T> result)
    {
        return result.Match(
            value => Ok(value),
            HandleErrors);
    }

    protected IActionResult CreatedAtResult<T>(ErrorOr<T> result, string actionName, Func<T, object> idSelector)
    {
        return result.Match(
            value => CreatedAtAction(actionName, new { id = idSelector(value) }, value),
            HandleErrors);
    }

    protected IActionResult NoContentResult(ErrorOr<Success> result)
    {
        return result.Match(
            _ => NoContent(),
            HandleErrors);
    }

    private IActionResult HandleErrors(IEnumerable<Error> errors)
    {
        var firstError = errors.First();
        return firstError.Type switch
        {
            ErrorType.NotFound => NotFound(errors),
            ErrorType.Validation => BadRequest(errors),
            ErrorType.Conflict => Conflict(errors),
            ErrorType.Unauthorized => Unauthorized(),
            ErrorType.Forbidden => Forbid(),
            _ => BadRequest(errors)
        };
    }
}