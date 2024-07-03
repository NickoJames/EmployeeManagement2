using Mapster;
using RecordManagement.Application.Employee.Commands.CreateEmployee;
using RecordManagement.Application.Employee.Commands.EducationalBackground;
using RecordManagement.Application.Employee.Commands.Reference;
using RecordManagement.Application.Employee.Commands.SkillsAndQualification;
using RecordManagement.Contracts.EmployeeRequest;
using RecordManagement.Contracts.EmployeeRequests;

namespace RecordManagement.Api.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Mapping for CreateEmployeeCommand
            config.NewConfig<(Guid EmployeeId, CreateEmployeeRequest Request), CreateEmployeeCommand>()
                .Map(dest => dest.EmployeeId, src => src.EmployeeId)
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.PersonalInformation, src => src.Request.PersonalInformation)
                .Map(dest => dest.ContactInformation, src => src.Request.ContactInformation);

            // Mapping for AddEducationalBackgroundCommand
            config.NewConfig<(Guid employeeId, AddEducationalBackgroundRequest Request), AddEducationalBackgroundCommand>()
                .Map(dest => dest.employeeId, src => src.employeeId)
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Degree, src => src.Request.Degree)
                .Map(dest => dest.School, src => src.Request.School)
                .Map(dest => dest.YearGraduated, src => src.Request.YearGraduated);

            // Mapping for AddEmployementHistoryCommand
            config.NewConfig<(Guid EmployeeId, AddEmploymentHistoryRequest Request), AddEmployementHistoryCommand>()
                .Map(dest => dest.EmployeeId, src => src.EmployeeId)
                .Map(dest => dest.Employer, src => src.Request.Employer)
                .Map(dest => dest.Position, src => src.Request.Position)
                .Map(dest => dest.StartDate, src => src.Request.StartDate)
                .Map(dest => dest.EndDate, src => src.Request.EndDate);

            // Mapping for AddSkillCommand
            config.NewConfig<(Guid EmployeeId, AddSkillRequest Request), AddSkillCommand>()
                .Map(dest => dest.EmployeeId, src => src.EmployeeId)
                .Map(dest => dest.Skill, src => src.Request.Skill)
                .Map(dest => dest.Language, src => src.Request.Language);

            // Mapping for AddReferenceCommand
            config.NewConfig<(Guid EmployeeId, AddReference Request), AddReferenceCommand>()
                .Map(dest => dest.EmployeeId, src => src.EmployeeId)
                .Map(dest => dest.Name, src => src.Request.Name)
                .Map(dest => dest.ContactInformation, src => src.Request.ContactInformation);
        }
    }
}
