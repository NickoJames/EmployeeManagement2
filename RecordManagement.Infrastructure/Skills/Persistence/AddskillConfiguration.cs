using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecordManagement.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordManagement.Domain.SkillsAndQualifications.ValueObjects;

namespace RecordManagement.Infrastructure.Skills.Persistence 
{
    public class AddskillConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
            ConfigureSkillTable(builder);

        }
        public static void ConfigureSkillTable(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsMany(s => s.SkillsAndQualifications, sb =>
            {
                sb.ToTable("Skills");
                sb.WithOwner().HasForeignKey("EmployeeId");
                sb.HasKey("Id");
                sb.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => SkillId.Create(value)
                 );

                sb.Property(se => se.Language).HasColumnName("Language");
                sb.Property(se => se.Skill).HasColumnName("Skill");

            });
        }
    }
}
