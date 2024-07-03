using RecordManagement.Application.DTOs;

using Employees = RecordManagement.Domain.Employees.Employee;

namespace RecordManagement.Application.Common.Interfaces
{
    public interface IEmployeeRepository1
    {

      //  Task<Employees> CreateEmployee(Guid uniqueId, CreateEmployeeRequest request);
        
        void Add(Employees employee);
        Task DeleteEmployee(Guid employeeId);
        Task<IEnumerable<Employees?>> EmployeeListAsync(Guid employeeId);
        void AddEmployeesAsync(List<Employees> employee);



    }
}

