using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _2nd_task.Configs
{
    internal sealed class HolidayConfig : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Arguments == null");

            entity.ToTable("Holiday");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.StartHolidayDate).HasColumnType("date");
            entity.Property(x => x.EndHolidayDate).HasColumnType("date");
            entity.Property(x => x.EmployeeId);

            entity.HasOne(x => x.Employee).WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
