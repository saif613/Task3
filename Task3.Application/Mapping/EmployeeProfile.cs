
using AutoMapper;
using Task3.Domain.Entity;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDto, Employee>()
            .ConstructUsing(dto => new Employee(
                dto.Name,
                dto.Email,
                dto.JobTitle,
                dto.Salary
            ));

        CreateMap<Employee, EmployeeResponseDto>();
    }
}
