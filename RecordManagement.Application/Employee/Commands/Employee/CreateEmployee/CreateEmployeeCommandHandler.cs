namespace RecordManagement.Application.Employee.Commands.CreateEmployee;

using MediatR;
using RecordManagement.Application.Common.Interfaces;

using Employees = RecordManagement.Domain.Employees.Employee;
using System.Threading;
using System.Threading.Tasks;
using RecordManagement.Domain.PersonalInformations;
using RecordManagement.Domain.ContactInformations;
using ErrorOr;

//using RecordManagement.Application.Employee.Commands.Employee.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand,ErrorOr<Employees>>
{
    private readonly IEmployeeRepository1 _employeeRepository1;

    public CreateEmployeeCommandHandler(IEmployeeRepository1 employeeRepository1)
    {
        _employeeRepository1 = employeeRepository1;
    }

    public async Task<ErrorOr<Employees>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

            if (string.IsNullOrWhiteSpace(command.PersonalInformation.FirstName))
        {
            return Error.Validation(code: "FirstName Invalid", description: "FirstName cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(command.PersonalInformation.LastName))
        {
            return Error.Validation(code: "LastName Invalid", description: "LastName cannot be empty.");
        }
       
        var employee = Employees.Create(
            PersonalInformation.Create(
                command.PersonalInformation.FirstName,
                command.PersonalInformation.MiddleName,
                command.PersonalInformation.LastName,
                command.PersonalInformation.DateOfBirth,
                command.PersonalInformation.PlaceOfBirth,
                command.PersonalInformation.Gender,
                command.PersonalInformation.CivilStatus,
                command.PersonalInformation.Citizenship,
                command.PersonalInformation.Height,
                command.PersonalInformation.Weight,
                command.PersonalInformation.BloodType),
            ContactInformation.create(
                command.ContactInformation.PermanentAddress,
                command.ContactInformation.PresentAddress,
                command.ContactInformation.PhoneNumber,
                command.ContactInformation.MobileNumber,
                command.ContactInformation.EmailAddress
                )

            );
        _employeeRepository1.Add(employee);
  

        return employee;
    }

}