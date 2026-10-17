
using MediatR;
using Task3.Application.Features.Products.Command.DeleteEmployee;

namespace Task3.Application.Features.Employees.Command.DeleteEmployee;

public class DeleteEmployeeHandler
    : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeService _service;

    public DeleteEmployeeHandler(IEmployeeService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _service.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (employee is null)
            return false;
        
        await _service.Delete(employee, cancellationToken);

        return true;
    }
}
