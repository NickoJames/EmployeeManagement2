

namespace RecordManagement.Contracts.EmployeeRequest
{
    public record CreateEmployeeRequest
    (
         PersonalInformationRequest PersonalInformation,
         ContactInformationRequest ContactInformation 
        
    );

    public record PersonalInformationRequest
   (
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


    public record ContactInformationRequest
       (
          string PermanentAddress,
          string PresentAddress,
          string PhoneNumber,
          string MobileNumber,
          string EmailAddress
       );

}