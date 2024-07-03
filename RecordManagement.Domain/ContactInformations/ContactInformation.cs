
namespace RecordManagement.Domain.ContactInformations;



 public class ContactInformation
    {
       
    
        public string PermanentAddress { get; private set; }
        public string PresentAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string MobileNumber { get; private set; }
        public string EmailAddress { get; private set; }

        public ContactInformation(string permanentAddress, string presentAddress, string phoneNumber, string mobileNumber, string emailAddress)
        {
            PermanentAddress = permanentAddress;
            PresentAddress = presentAddress;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            EmailAddress = emailAddress;
        }
        public static ContactInformation create(
          string permanentAddress,
          string presentAddress,
          string phoneNumber,
          string mobileNumber,
          string emailAddress
            ) {
        return new ContactInformation(permanentAddress,presentAddress,phoneNumber,mobileNumber,emailAddress);
            }






#pragma warning disable CS8618 
    private ContactInformation() { }
#pragma warning restore CS8618 



}



