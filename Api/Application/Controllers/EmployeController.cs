using Api.Application.Errors;
using Api.Application.Services;
using Api.Requests;

using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

public class EmployeController : DemoEfCoreController
{
    private readonly IEmployeService _employeService;

    public EmployeController(IEmployeService employeService)
    {
        _employeService = employeService;
    }

    [HttpGet("api/employees/{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return OkResult(_employeService.GetById(new GetEmployeByIdRequest { Id = id }));
    }

    [HttpPost("api/employees")]
    public IActionResult Create([FromBody] CreateEmployeRequest request)
    {
        var result = _employeService.Create(request);
        return CreatedAtResult(
            result,
            nameof(GetById),
            employee => employee.Id
        );
    }
}