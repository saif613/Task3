using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.DTOs;
using Task3.Application.Features.Products.Query.GetProducts;
using Task3.Application.Interface;

namespace Task3.Application.Features.Products.Query.GetProductById
{
    public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, ProductResponseDto?>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        private readonly ILogger<GetProductsHandler> _logger;

        public GetProductByIdHandler(IProductService productService, IMapper mapper,
    ILogger<GetProductsHandler> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductResponseDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving product with ID {ProductId}", request.Id); 

            var product = await _productService.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (product is null){
                _logger.LogWarning("Product with ID {ProductId} was not found", request.Id);
            }
            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}