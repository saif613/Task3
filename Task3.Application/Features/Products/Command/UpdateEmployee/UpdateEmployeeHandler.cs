
using MediatR;
using Task3.Application.DTOs;
using Task3.Application.Features.Products.Command.UpdateEmployee;
using Task3.Domain.Entity;

namespace Task3.Application.Features.Employees.Command.UpdateEmployee;

public class UpdateEmployeeHandler
    : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IEmployeeService _service;

    public UpdateEmployeeHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(
        UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _service.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (employee is null)
            return false;

        employee.UpdateEmployee(
       request.Employee.Name,
       request.Employee.Email,
       request.Employee.JobTitle,
       request.Employee.Salary);

        await _service.Update(employee, cancellationToken);

        return true;
    }
}
