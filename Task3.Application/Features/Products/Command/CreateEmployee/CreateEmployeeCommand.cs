using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Command.CreateEmployee
{
    public record CreateEmployeeCommand(CreateEmployeeDto Employee)
      : IRequest<EmployeeResponseDto>;
}
