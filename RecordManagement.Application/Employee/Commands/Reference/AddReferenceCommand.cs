using ErrorOr;
using MediatR;
using References = RecordManagement.Domain.References.Reference;

namespace RecordManagement.Application.Employee.Commands.Reference;

public record AddReferenceCommand (
    Guid EmployeeId,
    string Name,
    string ContactInformation
    ) : IRequest<ErrorOr<References>>;