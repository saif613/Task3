
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[ApiController]
[Route("api/[controller]")]
public class PerformanceController : ControllerBase
{
    private readonly IServiceScopeFactory _scopeFactory;

    public PerformanceController(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    private async Task<int> ReadEmployeesAsync(
        CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();

        var service = scope.ServiceProvider
            .GetRequiredService<IEmployeeService>();

        var employees = await service.GetAllAsync(cancellationToken);

        return employees.Count;
    }

    [HttpGet("compare")]
    public async Task<IActionResult> Compare(
        CancellationToken cancellationToken)
    {
        // Warm-up: تشغيل الاستعلام قبل القياس
        await ReadEmployeesAsync(cancellationToken);
        await ReadEmployeesAsync(cancellationToken);

        // 1. Sequential execution
        var stopwatch = Stopwatch.StartNew();

        var firstCount = await ReadEmployeesAsync(cancellationToken);
        var secondCount = await ReadEmployeesAsync(cancellationToken);

        stopwatch.Stop();
        var sequentialMs = stopwatch.Elapsed.TotalMilliseconds;

        // 2. Parallel execution
        stopwatch.Restart();

        var firstTask = ReadEmployeesAsync(cancellationToken);
        var secondTask = ReadEmployeesAsync(cancellationToken);

        var counts = await Task.WhenAll(firstTask, secondTask);

        stopwatch.Stop();
        var parallelMs = stopwatch.Elapsed.TotalMilliseconds;

        var improvement = sequentialMs > 0
            ? (sequentialMs - parallelMs) / sequentialMs * 100
            : 0;

        return Ok(new
        {
            Sequential = new
            {
                TimeMs = Math.Round(sequentialMs, 2),
                Results = new[] { firstCount, secondCount }
            },
            Parallel = new
            {
                TimeMs = Math.Round(parallelMs, 2),
                Results = counts
            },
            ImprovementPercent = Math.Round(improvement, 2),
            Conclusion = improvement > 0
                ? "Parallel execution was faster in this run."
                : "Parallel execution was not faster in this run."
        });
    }
}
