using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecordManagement.Domain.Employees.ValueObjects;

public class EmployeeIdConverter : ValueConverter<EmployeeId, Guid>
{
    public EmployeeIdConverter()
        : base(
            employeeId => employeeId.Value, // Convert EmployeeId to Guid
            guid => EmployeeId.Create(guid)) // Convert Guid to EmployeeId
    { }
}