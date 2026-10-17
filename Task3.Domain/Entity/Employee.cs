using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Domain.Entity;

public class Employee : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string JobTitle { get; private set; } = string.Empty;

    public decimal Salary { get; private set; }

    private Employee() { }


    public Employee(string name, string email, string jobTitle, decimal salary) => (Name, Email, JobTitle, Salary) = (name, email, jobTitle, salary);

    public void UpdateEmployee(string name, string email, string jobTitle, decimal salary)
    {
        Name = name;
        Email = email;
        JobTitle = jobTitle;
        Salary = salary;
    }

}
