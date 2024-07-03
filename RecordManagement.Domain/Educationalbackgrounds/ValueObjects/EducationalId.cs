using RecordManagement.Domain.Common.Models;
using RecordManagement.Domain.Employees.ValueObjects;

namespace RecordManagement.Domain.Educationalbackgrounds.ValueObjects
{
    public sealed class EducationalBackgroundId : ValueObject
    {
        public  Guid Value { get; private set; }

        private EducationalBackgroundId(Guid value)
        {
            Value = value;
        }
        public static EducationalBackgroundId CreateUnique()
        {
            return new EducationalBackgroundId(Guid.NewGuid());
        }

        public static EducationalBackgroundId Create(Guid value)
        {
           return new EducationalBackgroundId(value);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
#pragma warning disable CS8618
        private EducationalBackgroundId() { }
#pragma warning disable CS8618
    }
}
