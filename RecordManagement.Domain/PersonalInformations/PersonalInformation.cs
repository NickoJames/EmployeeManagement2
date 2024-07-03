
using System.ComponentModel.DataAnnotations;
namespace RecordManagement.Domain.PersonalInformations;
 public class PersonalInformation
    { 
    
        public string FirstName { get; private set; }
        public string MidlleName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PlaceOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string CivilStatus { get; private set; }
        public string Citizenship { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string BloodType { get; private set; }

         private PersonalInformation(string firstName , string middleName, string lastName, DateTime dateOfBirth, string placeOfBirth, string gender, string civilStatus, string citizenship, int height, int weight, string bloodType)
        {
            FirstName = firstName;
            MidlleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            Gender = gender;
            CivilStatus = civilStatus;
            Citizenship = citizenship;
            Height = height;
            Weight = weight;
            BloodType = bloodType;
        }


        public static PersonalInformation Create(
           string firstName,
           string middleName,
           string lastName,
           DateTime dateOfBirth,
           string placeOfBirth,
           string gender,
           string civilStatus,
           string citizenship,
           int height,
           int weight,
           string bloodType
            ) 
            { return new PersonalInformation(
                firstName,
                middleName, 
                lastName, 
                dateOfBirth, 
                placeOfBirth, 
                gender, 
                civilStatus, 
                citizenship, 
                height, 
                weight, 
                bloodType); }









#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private PersonalInformation() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
