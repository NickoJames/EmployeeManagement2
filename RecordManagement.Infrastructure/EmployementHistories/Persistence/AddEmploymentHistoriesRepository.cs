
using Microsoft.EntityFrameworkCore;
using RecordManagement.Application.Common.Interfaces;

using RecordManagement.Domain.Employees;
using RecordManagement.Domain.Employees.ValueObjects;
using RecordManagement.Domain.EmploymentHistories;
using RecordManagement.Infrastructure.Common.Persistence;


namespace RecordManagement.Infrastructure.EmployementHistories.Persistence
{
    public class AddEmploymentHistoriesRepository : IEmployementHistoryRepository
    {


        private readonly EmployeeDbContext _dbContext; 
        public AddEmploymentHistoriesRepository (EmployeeDbContext dbContext)
        {
               _dbContext = dbContext;
        }


        public async Task Add(EmploymentHistory employmentHistory, Guid employeeId)
        {
            var employee = await _dbContext.Employees
           .Include(e => e.EmploymentHistories)
           .FirstOrDefaultAsync(e => e.Id == EmployeeId.Create(employeeId));

            if (employee == null)
            {
                throw new ArgumentException("EmployeeNotFound");
            }

            employee.AddEmploymentHistories(employmentHistory);
         
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<Employee?> GetEmployeeById(Guid id)
        {
                var employee = await _dbContext.Employees
         .Include(e => e.EmploymentHistories)
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
    }
}
