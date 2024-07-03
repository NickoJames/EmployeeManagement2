using Microsoft.EntityFrameworkCore;
using RecordManagement.Domain;

using RecordManagement.Domain.ContactInformations;
using RecordManagement.Domain.Educationalbackgrounds;
using RecordManagement.Domain.Employees;
using RecordManagement.Domain.EmploymentHistories;
using RecordManagement.Domain.References;
using RecordManagement.Domain.SkillsAndQualifications;
using RecordManagement.Infrastructure.EducationalBackgrounds;
using RecordManagement.Infrastructure.EducationalBackgrounds.Persistence;
using RecordManagement.Infrastructure.Employees.Persistence;
using System.Reflection;

namespace RecordManagement.Infrastructure.Common.Persistence
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
    
        public DbSet<EducationalBackground> EducationalBackgrounds { get; set; } = null!;
        public DbSet<EmploymentHistory> EmploymentHistories { get; set; } = null!;
        public DbSet<SkillsAndQualification> Skills { get; set; }
        public DbSet<Reference> References { get; set; }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
