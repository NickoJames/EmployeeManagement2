
using RecordManagement.Domain.EmploymentHistories;
using Employees = RecordManagement.Domain.Employees.Employee;

namespace RecordManagement.Application.Common.Interfaces
{
    public interface IEmployementHistoryRepository
    {
        // Task AddEmploymentHistory(Guid employeeId, EmploymentHistoryDto employmentHistory);

    Task Add(EmploymentHistory employmentHistory, Guid employeeId);
    Task<Employees?> GetEmployeeById(Guid id);
    Task SaveAsync();
    }
}
