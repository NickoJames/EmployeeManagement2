using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecordManagement.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordManagement.Domain.References.ValueObjects;

namespace RecordManagement.Infrastructure.References.Persistence 
{
      public class AddReferenceConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
            ConfigureReferenceTable(builder);

        }

        public static void ConfigureReferenceTable(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsMany(r => r.References, rb =>
            {
                rb.ToTable("References");
                rb.WithOwner().HasForeignKey("EmployeeId");
                rb.HasKey("Id");
                rb.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ReferenceId.Create(value)
                 );
                rb.Property(rbe => rbe.Name).HasColumnName("Name");
                rb.Property(rbe => rbe.ContactInformation).HasColumnName("ContactInformation");
            });
        }
    }
}
