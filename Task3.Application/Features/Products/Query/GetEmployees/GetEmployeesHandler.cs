using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.Features.Products.Query.GetEmployees
{
    public class GetEmployeesHandler
      : IRequestHandler<GetEmployeesQuery, List<EmployeeResponseDto>>
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public GetEmployeesHandler(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<EmployeeResponseDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _service.GetAllAsync(cancellationToken);

            return _mapper.Map<List<EmployeeResponseDto>>(employees);
        }
    }
}
