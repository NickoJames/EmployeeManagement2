using ErrorOr;
using MediatR;
using EducationalBackgrounds = RecordManagement.Domain.Educationalbackgrounds.EducationalBackground;



namespace RecordManagement.Application.Employee.Commands.EducationalBackground;

public record AddEducationalBackgroundCommand(
Guid employeeId, 
string Degree,
string School,
int YearGraduated
) :
 IRequest<ErrorOr<EducationalBackgrounds>>;
