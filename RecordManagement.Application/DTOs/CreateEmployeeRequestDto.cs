
namespace RecordManagement.Application.DTOs
{
    public record CreateEmployeeRequest
    {
        public PersonalInformationDto PersonalInformation { get; set; } = null!;
        public ContactInformationDto ContactInformation { get; set; } = null!;
        
    }
}