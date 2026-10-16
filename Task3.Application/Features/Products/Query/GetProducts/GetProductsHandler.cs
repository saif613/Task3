using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.DTOs;
using Task3.Application.Interface;

namespace Task3.Application.Features.Products.Query.GetProducts
{
    public class GetProductsHandler
     : IRequestHandler<GetProductsQuery, List<ProductResponseDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        private readonly ILogger<GetProductsHandler> _logger;

        public GetProductsHandler(IProductService productService, IMapper mapper,
    ILogger<GetProductsHandler> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductResponseDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving all active products");

            var products = await _productService.GetAllAsync(cancellationToken);

            _logger.LogInformation("Retrieved {ProductCount} products", products.Count);

            return _mapper.Map<List<ProductResponseDto>>(products);
        }
    }
}