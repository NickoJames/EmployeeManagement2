using RecordManagement.Domain.Common.Models;

namespace RecordManagement.Domain.SkillsAndQualifications.ValueObjects
{
    public sealed class SkillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private SkillId(Guid value)
        {
            Value = value;
        }
        public static SkillId CreateUnique()
        {
            return new SkillId(Guid.NewGuid());
        }

        public static SkillId Create(Guid employeeId)
        {
            return new SkillId(employeeId);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618
        private SkillId() { }
#pragma warning disable CS8618
    }
}
