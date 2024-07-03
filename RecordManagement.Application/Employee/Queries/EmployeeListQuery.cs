

using MediatR;

namespace RecordManagement.Application.Employee.Queries;

public record EmployeeListQuery
 (Guid UniqueId) : IRequest<IEnumerable<Domain.Employees.Employee>>;

