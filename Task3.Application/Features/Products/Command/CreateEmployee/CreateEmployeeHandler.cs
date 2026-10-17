using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Task3.Domain.Entity;

namespace Task3.Application.Features.Products.Command.CreateEmployee
{

    public class CreateEmployeeHandler: IRequestHandler<CreateEmployeeCommand, EmployeeResponseDto>
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;


        public CreateEmployeeHandler(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<EmployeeResponseDto> Handle(CreateEmployeeCommand request,  CancellationToken cancellationToken)
        {

            var employee = _mapper.Map<Employee>(request.Employee);

            await _service.AddAsync(employee, cancellationToken);

            return _mapper.Map<EmployeeResponseDto>(employee);
        }
    }
}
