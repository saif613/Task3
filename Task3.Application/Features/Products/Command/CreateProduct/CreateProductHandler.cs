using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Application.DTOs;
using Task3.Application.Interface;
using Task3.Domain.Entity;

namespace Task3.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductHandler
      : IRequestHandler<CreateProductCommand, ProductResponseDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        private readonly ILogger<CreateProductHandler> _logger;

        public CreateProductHandler(IProductService productService, IMapper mapper,
    ILogger<CreateProductHandler> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating product {ProductName}", request.Name);

            var product = _mapper.Map<Product>(request);
                     
            await _productService.AddAsync(
                product,
                cancellationToken);

            _logger.LogInformation("Product created successfully with ID {ProductId}", product.Id);

            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}