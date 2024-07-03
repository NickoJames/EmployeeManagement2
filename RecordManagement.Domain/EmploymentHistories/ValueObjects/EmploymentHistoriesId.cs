using RecordManagement.Domain.Common.Models;

namespace RecordManagement.Domain.EmploymentHistories.ValueObjects
{
    public sealed class EmployementHistoriesId : ValueObject
    {
        public  Guid Value { get; private set; }

        private EmployementHistoriesId(Guid value)
        {
            Value = value;
        }
        public static EmployementHistoriesId CreateUnique()
        {
            return new EmployementHistoriesId(Guid.NewGuid());
        }

        public static EmployementHistoriesId Create(Guid employeeId)
        {
            return new EmployementHistoriesId(employeeId);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618
        private EmployementHistoriesId() { }
#pragma warning disable CS8618
    }
}
