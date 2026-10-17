using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Query.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int Id)
    : IRequest<EmployeeResponseDto?>;
}
