namespace RecordManagement.Application.Employee.Commands.EducationalBackground;

using ErrorOr;
using MediatR;
using RecordManagement.Application.Common.Interfaces;
using RecordManagement.Domain.Educationalbackgrounds;
using RecordManagement.Domain.Educationalbackgrounds.ValueObjects;
using RecordManagement.Domain.Employees.ValueObjects;
using System.Threading;
using System.Threading.Tasks;
using EducationalBackgrounds = RecordManagement.Domain.Educationalbackgrounds.EducationalBackground;



public class AddEducationalBackgroundCommandHandler : IRequestHandler<AddEducationalBackgroundCommand,ErrorOr<EducationalBackgrounds>>
{
    private readonly IEducationalBackgroundRepository _employeeRepository;

    public AddEducationalBackgroundCommandHandler(IEducationalBackgroundRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<ErrorOr<EducationalBackgrounds>> Handle(AddEducationalBackgroundCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

     var employee = await _employeeRepository.GetEmployeeById(command.employeeId);
        if (employee is null)
        {
            return Error.NotFound(description: "Employee not found");
        }
        if (string.IsNullOrWhiteSpace(command.Degree))
        {
            return Error.Validation(code: "Degree Invalid", description: "Degree cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(command.School))
        {
            return Error.Validation(code: "School Invalid", description: "School cannot be empty.");
        }
        if (command.YearGraduated <= 0)
        {
            return Error.Validation(code: "YearGraduated Invalid", description: "Year Graduated must be a positive number.");
        }


        var educationalBackground = EducationalBackgrounds.Create(

           command.Degree,
           command.School,
           command.YearGraduated
           );

            await _employeeRepository.Add(educationalBackground, command.employeeId);

            return educationalBackground;
        
       

      


    }

    
}
