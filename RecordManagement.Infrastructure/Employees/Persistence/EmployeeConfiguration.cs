using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecordManagement.Domain.Educationalbackgrounds.ValueObjects;
using RecordManagement.Domain.Employees;
using RecordManagement.Domain.Employees.ValueObjects;
using RecordManagement.Infrastructure.EducationalBackgrounds.Persistence;


namespace RecordManagement.Infrastructure.Employees.Persistence
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id  => id.Value,
                value => EmployeeId.Create(value)
             );

            builder.OwnsOne(e => e.PersonalInfo, pi =>
            {
                pi.Property(p => p.FirstName).HasColumnName("FirstName");
                pi.Property(p => p.MidlleName).HasColumnName("MiddleName");
                pi.Property(p => p.LastName).HasColumnName("LastName");
                pi.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
                pi.Property(p => p.PlaceOfBirth).HasColumnName("PlaceOfBirth");
                pi.Property(p => p.Gender).HasColumnName("Gender");
                pi.Property(p => p.CivilStatus).HasColumnName("CivilStatus");
                pi.Property(p => p.Citizenship).HasColumnName("Citizenship");
                pi.Property(p => p.Height).HasColumnName("Height");
                pi.Property(p => p.Weight).HasColumnName("Weight");
                pi.Property(p => p.BloodType).HasColumnName("BloodType");
            });

            builder.OwnsOne(e => e.ContactInfo, ci =>
            {
                ci.Property(c => c.PermanentAddress).HasColumnName("PermanentAddress");
                ci.Property(c => c.PresentAddress).HasColumnName("PresentAddress");
                ci.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
                ci.Property(c => c.MobileNumber).HasColumnName("MobileNumber");
                ci.Property(c => c.EmailAddress).HasColumnName("EmailAddress");
            });


    
        }
    }
}
