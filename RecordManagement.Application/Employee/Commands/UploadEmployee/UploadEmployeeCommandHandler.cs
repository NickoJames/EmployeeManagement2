using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using RecordManagement.Application.Common.Interfaces;
using RecordManagement.Domain.ContactInformations;
using RecordManagement.Domain.PersonalInformations;
using System.Globalization;
using System.Net.Mail;
using System.Reflection;
using Employees = RecordManagement.Domain.Employees.Employee;
using EducationalBackgrounds = RecordManagement.Domain.Educationalbackgrounds.EducationalBackground;
using Employmenthistories = RecordManagement.Domain.EmploymentHistories.EmploymentHistory;
using Skills = RecordManagement.Domain.SkillsAndQualifications.SkillsAndQualification;
using References = RecordManagement.Domain.References.Reference;

namespace RecordManagement.Application.Employee.Commands.UploadEmployee
{
    public class UploadEmployeeCommandHandler : IRequestHandler<UploadEmployeeCommand, List<Employees>>
    {
        private readonly IEmployeeRepository1 _employeeRepository1;

        public UploadEmployeeCommandHandler(IEmployeeRepository1 employeeRepository1)
        {
            _employeeRepository1 = employeeRepository1;
        }

        public async Task<List<Employees>> Handle(UploadEmployeeCommand request, CancellationToken cancellationToken)
        {
            using (var stream = new MemoryStream())
            {
                await request.File.CopyToAsync(stream, cancellationToken);
                stream.Position = 0;
                
                var employees = ReadCsvFile(stream);
                 _employeeRepository1.AddEmployees(employees);
                return employees;
            }
        }


        private List<Employees> ReadCsvFile(Stream stream)
        {
            using (var reader = new StreamReader(stream))

            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {

                
            }))
            {
              
                csv.Read();
                csv.ReadHeader();
                var records = new List<Employees>();

                while (csv.Read())
                {
                   
                    var employees = Employees.Create(
                        PersonalInformation.Create(
                       csv.GetField("FirstName"),
                       csv.GetField("MiddleName"),
                       csv.GetField("LastName"),
                       DateTime.Parse(csv.GetField("DateOfBirth")),
                       csv.GetField("PlaceOfBirth"),
                       csv.GetField("Gender"),
                       csv.GetField("CivilStatus"),
                       csv.GetField("Citizenship"),
                       int.Parse(csv.GetField("Height")),
                       int.Parse(csv.GetField("Weight")),
                       csv.GetField("BloodType")
                            ),
                        ContactInformation.create(
                        csv.GetField("PhoneNumber"),
                        csv.GetField("MobileNumber"),
                        csv.GetField("EmailAddress"),
                        csv.GetField("PermanentAddress"),
                        csv.GetField("PresentAddress"))
                        );


                    var educationalBackground = EducationalBackgrounds.Create(
                        csv.GetField("Degree"),
                        csv.GetField("School"),
                       int.Parse (csv.GetField("YearGraduated"))
                      
                        );
                    var employmentHistory = Employmenthistories.Create(
                        csv.GetField("Employer"),
                        csv.GetField("Position"),
                        DateTime.Parse(csv.GetField("StartDate")),
                        DateTime.Parse(csv.GetField("EndDate")));

                    var skills = Skills.Create(
                        csv.GetField("Skill"),
                        csv.GetField("Language")
                        );
                    var references = References.Create(
                        csv.GetField("Name"),
                        csv.GetField("ContactInformation"));


                    employees.AddEducationalBackground(educationalBackground);
                    employees.AddEmploymentHistories(employmentHistory);
                    employees.AddSkills(skills);
                    employees.AddReferences(references);
                    

                    records.Add(employees);
                }

                return records;
            }
        }


    }
}
