using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecordManagement.Domain.Educationalbackgrounds;
using RecordManagement.Domain.Educationalbackgrounds.ValueObjects;
using RecordManagement.Domain.Employees;
using RecordManagement.Domain.Employees.ValueObjects;
using System.Reflection;



namespace RecordManagement.Infrastructure.EducationalBackgrounds.Persistence
{
    public class AddEducationalBackgroundConfiguration : IEntityTypeConfiguration<Employee>
    {
         public void Configure(EntityTypeBuilder<Employee> builder)
        {
             ConfigureEducationalBackgroundTable(builder);

        }

        public static void ConfigureEducationalBackgroundTable(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsMany(eb => eb.EducationalBackgrounds, ebr =>
            {
                ebr.ToTable("EducationalBackgrounds");

                ebr.WithOwner().HasForeignKey("EmployeeId");
                ebr.HasKey("Id");

                ebr.Property(e => e.Id)
                    .HasColumnName("EducationalBackgroundId")
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    value => EducationalBackgroundId.Create(value));

                ebr.Property(eb => eb.Degree).HasColumnName("Degree");
                ebr.Property(eb => eb.School).HasColumnName("School");
                ebr.Property(eb => eb.YearGraduated).HasColumnName("YearGraduated");



            });


        }






    }
}
