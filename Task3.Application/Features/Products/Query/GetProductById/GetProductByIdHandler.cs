using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.DTOs;
using Task3.Application.Interface;

namespace Task3.Application.Features.Products.Query.GetProductById
{
    public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, ProductResponseDto?>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (product is null)
                return null;

            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}