using RecordManagement.Domain.Common.Models;

namespace RecordManagement.Domain.Employees.ValueObjects
{
    public sealed class EmployeeId : AggregateRootId<Guid>
    {
        public override Guid Value { get ; protected set ; }

        private EmployeeId(Guid value) 
        {
            Value = value;
        }
        public static EmployeeId CreateUnique()
        {
            return new EmployeeId(Guid.NewGuid());
        }

        public static EmployeeId Create(Guid employeeId) 
        {
            return new EmployeeId(employeeId);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618
        private EmployeeId() {}
#pragma warning disable CS8618
    }
}
