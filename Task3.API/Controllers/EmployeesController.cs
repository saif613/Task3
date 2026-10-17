using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task3.Application.DTOs;
using Task3.Application.Features.Products.Command.CreateEmployee;
using Task3.Application.Features.Products.Command.DeleteEmployee;
using Task3.Application.Features.Products.Command.UpdateEmployee;
using Task3.Application.Features.Products.Query.GetEmployeeById;
using Task3.Application.Features.Products.Query.GetEmployees;

namespace Task3.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/employees
    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var employees = await _mediator.Send(new GetEmployeesQuery(), cancellationToken);

        return Ok(employees);
    }

    // GET: api/employees/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id), cancellationToken);

        if (employee is null)
            return NotFound();

        return Ok(employee);
    }

    // POST: api/employees
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateEmployeeDto dto,
        CancellationToken cancellationToken)
    {
        var employee = await _mediator.Send(
            new CreateEmployeeCommand(dto),
            cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = employee.Id },
            employee);
    }

    // PUT: api/employees/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateEmployeeDto dto,
        CancellationToken cancellationToken)
    {
        var updated = await _mediator.Send(
            new UpdateEmployeeCommand(id, dto),
            cancellationToken);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/employees/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        var deleted = await _mediator.Send(
            new DeleteEmployeeCommand(id),
            cancellationToken);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
