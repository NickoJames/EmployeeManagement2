using ErrorOr;
using MediatR;
using RecordManagement.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordManagement.Application.Employee.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<EmployeeDeleteCommand, Deleted>
    {

        private readonly IEmployeeRepository1 _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository1 employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Deleted> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepository.DeleteEmployee(request.UniqueId);
            return Result.Deleted;
        }
    }
}
