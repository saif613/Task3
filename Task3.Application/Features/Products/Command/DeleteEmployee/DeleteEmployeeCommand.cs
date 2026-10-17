using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Command.DeleteEmployee
{
    public record DeleteEmployeeCommand(int Id) : IRequest<bool>;
}
