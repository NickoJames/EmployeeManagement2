namespace RecordManagement.Application.DTOs
{
    public record PersonalInformationDto(
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
}
