using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Query.GetEmployeeById
{
    public class GetEmployeeByIdValidator
     : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}
