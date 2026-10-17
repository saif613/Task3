using Task3.Domain.Entity;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken);

    Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(Employee employee, CancellationToken cancellationToken);

    Task Update(Employee employee, CancellationToken cancellationToken);

    Task Delete(Employee employee, CancellationToken cancellationToken);

}