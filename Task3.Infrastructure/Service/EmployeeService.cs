using Microsoft.EntityFrameworkCore;
using Task3.Domain.Entity;
using Task3.Infrastructure.Persistence;

public class EmployeeService : IEmployeeService
{
    private readonly TaskDb3 _context;

    public EmployeeService(TaskDb3 context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Employees
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
    {
        await _context.Employees.AddAsync(employee, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Employee employee, CancellationToken cancellationToken)
    {
        employee.UpdateEmployee(employee.Name, employee.Email, employee.JobTitle, employee.Salary);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Employee employee, CancellationToken cancellationToken)
    {
        employee.SoftDelete();  
        await _context.SaveChangesAsync(cancellationToken);
    }
}