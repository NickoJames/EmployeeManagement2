

using RecordManagement.Domain.References;

using Employees = RecordManagement.Domain.Employees.Employee;

namespace RecordManagement.Application.Common.Interfaces
{
    public interface IAddReferencesRepository
    {
        // Task AddReference(Guid employeeId, ReferenceDto reference);

        Task Add(Reference reference, Guid EmployeeId);
        Task<Employees?> GetEmployeeById(Guid id);
        Task SaveAsync();

    }
}
