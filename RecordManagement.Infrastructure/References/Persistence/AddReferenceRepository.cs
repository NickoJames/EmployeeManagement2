using Microsoft.EntityFrameworkCore;
using RecordManagement.Application.Common.Interfaces;

using RecordManagement.Domain.Employees;
using RecordManagement.Domain.Employees.ValueObjects;
using RecordManagement.Domain.References;
using RecordManagement.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordManagement.Infrastructure.References.Persistence
{
    internal class AddReferenceRepository : IAddReferencesRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public AddReferenceRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       

        public async Task Add(Reference reference, Guid employeeId)
        {
            var employee = await _dbContext.Employees
            .Include(e => e.References)
            .FirstOrDefaultAsync(e => e.Id == EmployeeId.Create(employeeId));

            if (employee == null)
            {
                throw new ArgumentException("EmployeeNotFound");
            }

            employee.AddReferences(reference);
            //    employee.EducationalBackgrounds.Add(educationalBackground);
            await _dbContext.SaveChangesAsync();
            // Save changes to the database
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

