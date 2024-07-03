using ErrorOr;
using MediatR;
using EmloymentHistories = RecordManagement.Domain.EmploymentHistories.EmploymentHistory;


namespace RecordManagement.Application.Employee.Commands.EducationalBackground;

public record AddEmployementHistoryCommand(
        Guid EmployeeId,
        string Employer,
        string Position,
        DateTime StartDate,
        DateTime EndDate
) :
 IRequest<ErrorOr<EmloymentHistories>>;