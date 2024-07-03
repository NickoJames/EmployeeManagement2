using ErrorOr;
using MediatR;
using Skills = RecordManagement.Domain.SkillsAndQualifications.SkillsAndQualification;

namespace RecordManagement.Application.Employee.Commands.SkillsAndQualification;


public record AddSkillCommand(
    Guid EmployeeId,
    string Skill,
    string Language
    ) : IRequest<ErrorOr<Skills>>;