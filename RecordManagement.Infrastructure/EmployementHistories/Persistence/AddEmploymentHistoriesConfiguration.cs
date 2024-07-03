using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecordManagement.Domain.EmploymentHistories.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee = RecordManagement.Domain.Employees.Employee;

namespace RecordManagement.Infrastructure.EmployementHistories.Persistence
{
    public class AddEmploymentHistoriesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
         
          ConfigureEmployementHistoryTable(builder);
        }

        public static void ConfigureEmployementHistoryTable(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsMany(eh => eh.EmploymentHistories, ehb =>
            {
                ehb.ToTable("EmploymentHistories");

                ehb.WithOwner().HasForeignKey("EmployeeId");
                ehb.HasKey("Id");
                ehb.Property(eh => eh.Id)
                .ValueGeneratedNever()
                .HasConversion(
                        id => id.Value,
                        value => EmployementHistoriesId.Create(value));

                ehb.Property(e => e.Employer).HasColumnName("Employer");
                ehb.Property(e => e.Position).HasColumnName("Position");
                ehb.Property(e => e.StartDate).HasColumnName("StartDate");
                ehb.Property(e => e.EndDate).HasColumnName("EndDate");
             


            });
        }
    }
}
