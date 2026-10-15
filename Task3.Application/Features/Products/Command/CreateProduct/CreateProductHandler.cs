using AutoMapper;
using MediatR;
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

        public CreateProductHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
                     
            await _productService.AddAsync(
                product,
                cancellationToken);

            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}