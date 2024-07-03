using Microsoft.EntityFrameworkCore;
using RecordManagement.Application.Common.Interfaces;

using RecordManagement.Domain.Employees;
using RecordManagement.Domain.Employees.ValueObjects;
using RecordManagement.Domain.SkillsAndQualifications;
using RecordManagement.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordManagement.Infrastructure.Skills.Persistence
{
    public class AddskillReposistory : IAddSkillsRepository
    {

        private readonly EmployeeDbContext _dbContext;

        public AddskillReposistory(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

     

        public async Task Add(SkillsAndQualification skillsAndQualification, Guid employeeId)
        {
            var employee = await _dbContext.Employees
            .Include(e => e.EducationalBackgrounds)
            .FirstOrDefaultAsync(e => e.Id == EmployeeId.Create(employeeId));

            if (employee == null)
            {
                throw new ArgumentException("EmployeeNotFound");
            }

            employee.AddSkills(skillsAndQualification);
            
            await _dbContext.SaveChangesAsync();
      

        }

        public Task<Employee?> GetEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {

            return Task.CompletedTask;

        }

    }
}
