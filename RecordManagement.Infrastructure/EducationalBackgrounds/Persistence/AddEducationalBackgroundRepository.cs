
using Microsoft.EntityFrameworkCore;
using RecordManagement.Application.Common.Interfaces;
using RecordManagement.Domain.Educationalbackgrounds;
using RecordManagement.Domain.Educationalbackgrounds.ValueObjects;
using RecordManagement.Domain.Employees;
using RecordManagement.Domain.Employees.ValueObjects;
using RecordManagement.Infrastructure.Common.Persistence;


namespace RecordManagement.Infrastructure.EducationalBackgrounds.Persistence
{
    public class AddEducationalBackgroundRepository : IEducationalBackgroundRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public AddEducationalBackgroundRepository(EmployeeDbContext dbContext)
        {

            _dbContext = dbContext;
        }

 

        public async Task Add(EducationalBackground educationalBackground, Guid employeeId)
        {
            var employee = await _dbContext.Employees
           .Include(e => e.EducationalBackgrounds)
           .FirstOrDefaultAsync(e => e.Id == EmployeeId.Create(employeeId));

            if (employee == null) 
            {
                throw new ArgumentException("EmployeeNotFound");
            }

            employee.AddEducationalBackground(educationalBackground);
            //    employee.EducationalBackgrounds.Add(educationalBackground);
            await _dbContext.SaveChangesAsync();
            // Save changes to the database


        }

        public async Task<Employee?> GetEmployeeById(Guid id)
        {
            var employee = await _dbContext.Employees
           .Include(e => e.EducationalBackgrounds)
           .FirstOrDefaultAsync(e => e.Id == EmployeeId.Create(id));

            if (employee == null)
            {
                throw new ArgumentException("EmployeeNotFound");
            }
            return employee;
        }
  

        public Task SaveAsync()
        {

            return Task.CompletedTask;

        }


        /*  public async Task AddEducationalBackground(Guid employeeId, EducationalBackgroundDto educationalBackground)
       {
           var employee = await _dbContext.Employees
                                          .Include(e => e.EducationalBackgrounds)
                                          .FirstOrDefaultAsync(e => e.Id == employeeId);

           if (employee is null)
           {
               throw new Exception("Employee not found.");
           }

           employee.EducationalBackgrounds.Add(new EducationalBackground(

             educationalBackground.Degree,
             educationalBackground.School,
             educationalBackground.YearGraduated
         ));

           await _dbContext.SaveChangesAsync();
       }*/


        /*     public async Task<Employee?> GetEmployeeById(Guid employeeId)
             {
                 return await _dbContext.Employees.FirstOrDefaultAsync(Employee => Employee.Id == employeeId);

             }*/



    }
}
