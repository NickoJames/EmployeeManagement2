using MediatR;
using RecordManagement.Application.Common.Interfaces;


namespace RecordManagement.Application.Employee.Queries;

public class EmployeeListQueryHandler : IRequestHandler<EmployeeListQuery, IEnumerable<Domain.Employees.Employee>>
{               
    private readonly IEmployeeRepository1 _employeeRepository;

    public EmployeeListQueryHandler(IEmployeeRepository1 employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Domain.Employees.Employee>> Handle(EmployeeListQuery request, CancellationToken cancellationToken)
    {
        var Id = request.UniqueId;
        var employees = await _employeeRepository.EmployeeListAsync(Id);
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return employees;
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }
}