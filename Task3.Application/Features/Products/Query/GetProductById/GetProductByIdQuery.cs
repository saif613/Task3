using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.DTOs;

namespace Task3.Application.Features.Products.Query.GetProductById
{
    public record GetProductByIdQuery(int Id)
     : IRequest<ProductResponseDto?>;
}
