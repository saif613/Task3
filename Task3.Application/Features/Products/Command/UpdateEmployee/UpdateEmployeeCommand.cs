using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.DTOs;

namespace Task3.Application.Features.Products.Command.UpdateEmployee
{
    public record UpdateEmployeeCommand(
    int Id,
    UpdateEmployeeDto Employee) : IRequest<bool>;
}
