using Api.Application.Errors;
using Api.Application.Services;
using Api.Requests;

using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

public class EmployeeController : DemoEfCoreController
{
    private readonly IEmployeeService _EmployeeService;
    private readonly ValidationService _validationService;

    public EmployeeController(IEmployeeService EmployeeService, ValidationService validationService)
    {
        _EmployeeService = EmployeeService;
        _validationService = validationService;
    }

    [HttpGet("api/Employees/{id:guid}")]
    public IActionResult GetById([FromRoute]GetEmployeeByIdRequest request)
    {
        return OkResult(_EmployeeService.GetById(request.Id));
    }

    [HttpPost("api/Employees")]
    public IActionResult Create([FromBody] CreateEmployeeRequest request)
    {
        var validationResult = _validationService.Validate(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var result = _EmployeeService.Add(request.ToEmployee());
        return CreatedAtResult(
            result,
            nameof(GetById),
            emp => emp.Id
        );
    }
}