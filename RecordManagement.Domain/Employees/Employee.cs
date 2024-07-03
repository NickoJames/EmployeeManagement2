namespace RecordManagement.Domain.Employees;

using System.ComponentModel.DataAnnotations;
using RecordManagement.Domain.Common.Models;
using RecordManagement.Domain.ContactInformations;
using RecordManagement.Domain.Educationalbackgrounds;
using RecordManagement.Domain.Educationalbackgrounds.ValueObjects;
using RecordManagement.Domain.Employees.ValueObjects;
using RecordManagement.Domain.EmploymentHistories;

using RecordManagement.Domain.PersonalInformations;
using RecordManagement.Domain.References;
using RecordManagement.Domain.SkillsAndQualifications;
using RecordManagement.Domain.SkillsAndQualifications.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

public sealed class Employee : AggregateRoot<EmployeeId, Guid>
    {
     
        public PersonalInformation PersonalInfo { get; private set; }
        public ContactInformation ContactInfo { get; private set;}




    private readonly List<EducationalBackground> _educationalBackgrounds = new();
    private readonly List<EmploymentHistory> _employmentHistories = new();
    private readonly List<SkillsAndQualification> _skillsAndQualifications = new();
    private readonly List<Reference> _references = new();


    public IReadOnlyList<EducationalBackground> EducationalBackgrounds => _educationalBackgrounds.AsReadOnly();
    public IReadOnlyList<EmploymentHistory> EmploymentHistories => _employmentHistories.AsReadOnly();
    public IReadOnlyList<SkillsAndQualification> SkillsAndQualifications => _skillsAndQualifications.AsReadOnly();
    public IReadOnlyList<Reference> References => _references.AsReadOnly();


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Employee() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
   
    
    private Employee(
            EmployeeId employeeId,
            PersonalInformation personalInfo, 
            ContactInformation contactInfo) : base (employeeId)
        
        {
      PersonalInfo = personalInfo;
         ContactInfo = contactInfo;
   
    }

    public static Employee Create(
        PersonalInformation personalInformation,
        ContactInformation contactInformation) 
        {
        return new Employee(
           EmployeeId.CreateUnique(),
           personalInformation,
           contactInformation);
 
    }

    public void AddEducationalBackground(EducationalBackground educationalBackground)
    {
        if (_educationalBackgrounds.Any(eb => eb.Degree == educationalBackground.Degree && eb.School == educationalBackground.School && eb.YearGraduated == educationalBackground.YearGraduated))
        {
            throw new InvalidOperationException("This educational background already exists.");
        }

        _educationalBackgrounds.Add(educationalBackground);

    }

    public void AddEmploymentHistories(EmploymentHistory employmentHistory)
    {
        if (employmentHistory.StartDate >= employmentHistory.EndDate)
        {
            throw new InvalidOperationException("Start date must be before end date.");
        }
      

        _employmentHistories.Add(employmentHistory);
    }
    public void AddSkills(SkillsAndQualification skillsAndQualification)
    {
        if (_skillsAndQualifications.Any(sq => sq.Skill == skillsAndQualification.Skill))
        {
            throw new InvalidOperationException("This skill is already added.");
        }
        if (_skillsAndQualifications.Any(sq => sq.Language == skillsAndQualification.Language))
        {
            throw new InvalidOperationException("This Language is already added.");
        }
        _skillsAndQualifications.Add(skillsAndQualification);
    }
    public void AddReferences(Reference reference)
    {
        _references.Add(reference);
    }



  


}


