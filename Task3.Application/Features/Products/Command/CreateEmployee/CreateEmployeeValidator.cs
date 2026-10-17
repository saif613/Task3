using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Command.CreateEmployee
{
    public class CreateEmployeeValidator
     : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Employee.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Employee.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(150);

            RuleFor(x => x.Employee.JobTitle)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Employee.Salary)
                .GreaterThanOrEqualTo(0);
        }
    }
}
