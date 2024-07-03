using RecordManagement.Domain.Common.Models;

namespace RecordManagement.Domain.ContactInformations.ValueObjects
{
    public sealed class ContactinformationId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private ContactinformationId(Guid value)
        {
            Value = value;
        }
        public static ContactinformationId CreateUnique()
        {
            return new ContactinformationId(Guid.NewGuid());
        }

        public static ContactinformationId Create(Guid employeeId)
        {
            return new ContactinformationId(employeeId);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618
        private ContactinformationId() { }
#pragma warning disable CS8618
    }
}
