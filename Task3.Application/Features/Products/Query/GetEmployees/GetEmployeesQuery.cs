using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Query.GetEmployees
{
    public record GetEmployeesQuery
    : IRequest<List<EmployeeResponseDto>>;
}
