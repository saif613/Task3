using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Query.GetEmployeeById
{
    public class GetEmployeeByIdHandler
      : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseDto?>
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<EmployeeResponseDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _service.GetByIdAsync(request.Id, cancellationToken);

            return employee is null ? null : _mapper.Map<EmployeeResponseDto>(employee);
        }
    }
}
