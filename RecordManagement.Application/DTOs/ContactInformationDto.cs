namespace RecordManagement.Application.DTOs

{
    public record ContactInformationDto
(
        // public string PermanentAddress { get; set; } = null!;
        // public string PresentAddress { get; set; }= null!;
        // public string PhoneNumber { get; set; }= null!;
        // public string MobileNumber { get; set; }= null!;
        // public string EmailAddress { get; set; }= null!;

        string PermanentAddress,
        string PresentAddress,
        string PhoneNumber,
        string MobileNumber,
        string EmailAddress


);
}
