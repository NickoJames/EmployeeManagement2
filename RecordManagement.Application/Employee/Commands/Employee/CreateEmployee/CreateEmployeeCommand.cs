using ErrorOr;
using MediatR;

using Employees =  RecordManagement.Domain.Employees.Employee;




namespace RecordManagement.Application.Employee.Commands.CreateEmployee;
public record CreateEmployeeCommand(
    Guid EmployeeId,
    PersonalInformationCommand PersonalInformation,
    ContactInformationCommand ContactInformation) : IRequest<ErrorOr<Employees>>;


public record PersonalInformationCommand (
       string FirstName,
       string MiddleName,
       string LastName,
       DateTime DateOfBirth,
       string PlaceOfBirth,
       string Gender,
       string CivilStatus,
       string Citizenship,
       int Height,
       int Weight,
       string BloodType
    );

public record ContactInformationCommand(
    string PermanentAddress,
          string PresentAddress,
          string PhoneNumber,
          string MobileNumber,
          string EmailAddress
    );

