using ErrorOr;
using MediatR;
using RecordManagement.Application.Common.Interfaces;
using RecordManagement.Application.Employee.Commands.EducationalBackground;
using EmploymentHistories = RecordManagement.Domain.EmploymentHistories.EmploymentHistory;

namespace RecordManagement.Application.Employee.Commands.EmploymentHistory;

public class AddEmploymentHistoryCommandHandler : IRequestHandler<AddEmployementHistoryCommand ,ErrorOr<EmploymentHistories>>
{

    private readonly IEmployementHistoryRepository _employeeRepository;

    public AddEmploymentHistoryCommandHandler(IEmployementHistoryRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ErrorOr<EmploymentHistories>> Handle(AddEmployementHistoryCommand command ,CancellationToken cancellationToken)
    {
         await Task.CompletedTask;

        var employee = await _employeeRepository.GetEmployeeById(command.EmployeeId);

        if (employee is null)
        {
            return Error.NotFound(description: "Employee not found");
        }

        if (string.IsNullOrWhiteSpace(command.Employer))
        {
            return Error.Validation(code: "Employer Invalid", description: "Employer cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(command.Position))
        {
            return Error.Validation(code: "Position Invalid", description: "Position cannot be empty.");
        }
        if (command.StartDate >= command.EndDate)
        {
            return Error.Validation(code: "Invalid", description: "Start date must be before end date.");
         
        }
        var employmentHistory = EmploymentHistories.Create(
            command.Employer,
            command.Position,
            command.StartDate,
            command.EndDate
            );
        await _employeeRepository.Add(employmentHistory, command.EmployeeId);
    

       return employmentHistory;
    
    }

}