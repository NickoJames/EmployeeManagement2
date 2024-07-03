using MediatR;
using Microsoft.AspNetCore.Http;
using Employees = RecordManagement.Domain.Employees.Employee;
namespace RecordManagement.Application.Employee.Commands.UploadEmployee
{
    public record UploadEmployeeCommand (IFormFile File) : IRequest<List<Employees>>;
   
}
