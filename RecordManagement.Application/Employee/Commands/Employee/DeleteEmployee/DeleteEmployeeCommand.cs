using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordManagement.Application.Employee.Commands.Employee.DeleteEmployee
{
    public record EmployeeDeleteCommand(Guid UniqueId) : IRequest<Deleted>;

}
