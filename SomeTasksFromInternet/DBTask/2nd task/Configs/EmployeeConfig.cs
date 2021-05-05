using _2nd_task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _2nd_task.Configs
{
    internal sealed class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Arguments == null");

            entity.ToTable(nameof(Employee));
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Email).IsRequired().HasMaxLength(128);
            entity.Property(x => x.FirstName).IsRequired().HasMaxLength(128);
            entity.Property(x => x.SecondName).IsRequired().HasMaxLength(128);
        }
    }
}
