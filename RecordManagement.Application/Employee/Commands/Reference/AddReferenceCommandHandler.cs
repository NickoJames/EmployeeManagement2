using ErrorOr;
using MediatR;
using RecordManagement.Application.Common.Interfaces;
using References = RecordManagement.Domain.References.Reference;

namespace RecordManagement.Application.Employee.Commands.Reference;

public class AddReferenceCommandHandler : IRequestHandler<AddReferenceCommand, ErrorOr<References>>
{
    private readonly IAddReferencesRepository _employeeRepository;

    public AddReferenceCommandHandler(IAddReferencesRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

        public async Task<ErrorOr<References>> Handle(AddReferenceCommand command, CancellationToken cancellationToken)
        {
        await Task.CompletedTask;
        if (string.IsNullOrWhiteSpace(command.Name))
        {
            return Error.Validation(code: "Name Invalid", description: "Name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(command.ContactInformation))
        {
            return Error.Validation(code: "ContactInformation Invalid", description: "Contact Information cannot be empty.");
        }

        var employementHistory = References.Create(
            command.Name,
            command.ContactInformation
            );

        await _employeeRepository.Add(employementHistory , command.EmployeeId);




       return employementHistory;

        }

}