using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Domain.Entity;


namespace Task3.Infrastructure.Persistence;


public class TaskDb3 : DbContext
{
    public TaskDb3(DbContextOptions<TaskDb3> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!; 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TaskDb3).Assembly);
    }
}
