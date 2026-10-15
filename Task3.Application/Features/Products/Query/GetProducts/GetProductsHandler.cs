using AutoMapper;
using MediatR;
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

        public GetProductsHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync(cancellationToken);

            return _mapper.Map<List<ProductResponseDto>>(products);
        }
    }
}