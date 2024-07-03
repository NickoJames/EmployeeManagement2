using Microsoft.EntityFrameworkCore;
using RecordManagement.Application.Common.Interfaces;
using RecordManagement.Domain.Employees;
using RecordManagement.Infrastructure.Common.Persistence;

namespace RecordManagement.Infrastructure.Employees.Persistence
{
    public class EmployeeRepository : IEmployeeRepository1
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Employee employee)
        {
           _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void AddEmployeesAsync(List<Employee> employee)
        {
            _dbContext.Employees.AddRange(employee);
            _dbContext.SaveChanges();
        }

        async public Task DeleteEmployee(Guid UniqueId)
        {
            var employee = await _dbContext.Employees.FindAsync(UniqueId);
        }


        //Queries


        public async Task<IEnumerable<Employee?>> EmployeeListAsync(Guid employeeId)
        {
            var employee = await _dbContext.Employees
          .Include(e => e.EducationalBackgrounds)
           .Include(e => e.EmploymentHistories)
           .Include(e => e.SkillsAndQualifications)
            .Include(e => e.References)
         .AsSplitQuery()
         .ToListAsync();

            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            return employee;
        }

    }
}
