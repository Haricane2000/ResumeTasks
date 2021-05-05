using _2nd_task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _2nd_task.Configs
{
    internal sealed class TrainingConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Arguments == null");

            entity.ToTable(nameof(Training));
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(128);
            entity.Property(x => x.StartDate).HasColumnType("date");
            entity.Property(x => x.EndDate).HasColumnType("date");
            entity.Property(x => x.Description).HasMaxLength(128);

            entity.HasMany(x => x.Employees)
                .WithMany(x => x.Trainings)
                .UsingEntity<EmployeeTraining>(
                    right => right.HasOne<Employee>().WithMany().HasForeignKey(x => x.EmployeeId),
                    left => left.HasOne<Training>().WithMany().HasForeignKey(x => x.TrainingId),
                    join => join.ToTable("EmployeeTraining"));
        }
    }
}
