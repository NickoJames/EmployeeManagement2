
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecordManagement.Application.Common.Interfaces;
using RecordManagement.Contracts.EmployeeRequest;
using RecordManagement.Infrastructure;
using RecordManagement.Infrastructure.Common.Persistence;
using RecordManagement.Infrastructure.EducationalBackgrounds.Persistence;
using RecordManagement.Infrastructure.Employees.Persistence;
using RecordManagement.Infrastructure.EmployementHistories.Persistence;
using RecordManagement.Infrastructure.References.Persistence;
using RecordManagement.Infrastructure.Skills.Persistence;



namespace RecordManagement.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null.");
        }

        services.AddDbContext<EmployeeDbContext>(options => options.UseSqlite("Data Source = EmployeeManagement.db"));

        services.AddScoped<IEmployeeRepository1, EmployeeRepository>();
        services.AddScoped<IAddReferencesRepository, AddReferenceRepository>();
        services.AddScoped<IAddSkillsRepository, AddskillReposistory>();
        services.AddScoped<IEducationalBackgroundRepository, AddEducationalBackgroundRepository>();
        services.AddScoped<IEmployementHistoryRepository, AddEmploymentHistoriesRepository>();
       

        return services;


    }

}