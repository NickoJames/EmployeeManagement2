using RecordManagement.Domain.Common.Models;

namespace RecordManagement.Domain.References.ValueObjects
{
    public sealed class ReferenceId : ValueObject
    {
        public  Guid Value { get; private set; }

        private ReferenceId(Guid value)
        {
            Value = value;
        }
        public static ReferenceId CreateUnique()
        {
            return new ReferenceId(Guid.NewGuid());
        }

        public static ReferenceId Create(Guid employeeId)
        {
            return new ReferenceId(employeeId);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618
        private ReferenceId() { }
#pragma warning disable CS8618
    }
}
