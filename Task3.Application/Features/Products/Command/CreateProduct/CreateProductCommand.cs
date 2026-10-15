using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.DTOs;

namespace Task3.Application.Features.Products.Command.CreateProduct
{
    public record CreateProductCommand(
     string Name,
     decimal Price
 ) : IRequest<ProductResponseDto>;
}
