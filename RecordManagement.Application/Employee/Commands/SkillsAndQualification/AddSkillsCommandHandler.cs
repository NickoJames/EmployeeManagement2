using ErrorOr;
using MediatR;
using RecordManagement.Application.Common.Interfaces;
using RecordManagement.Domain.SkillsAndQualifications;
using Skills = RecordManagement.Domain.SkillsAndQualifications.SkillsAndQualification;

namespace RecordManagement.Application.Employee.Commands.SkillsAndQualification;

public class AddSkillCommandHandler : IRequestHandler<AddSkillCommand, ErrorOr< Skills>>
{

        private readonly IAddSkillsRepository _employeeRepository;

    public AddSkillCommandHandler(IAddSkillsRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ErrorOr<Skills>> Handle(AddSkillCommand command ,CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (string.IsNullOrWhiteSpace(command.Skill))
        {
            return Error.Validation(code: "Skill Invalid", description: "Skill cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(command.Language))
        {
            return Error.Validation(code: "Language Invalid", description: "Language cannot be empty.");
        }
        var skill = Skills.Create(
            command.Skill,
            command.Language
            );

        await _employeeRepository.Add(skill , command.EmployeeId);
     

       return skill;

    }


}

