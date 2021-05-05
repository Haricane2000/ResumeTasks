using _2nd_task.Configs;
using _2nd_task.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace _2nd_task
{
    public class AppContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
                throw new ArgumentNullException("Arguments == null");

            const string connectionString = "Data Source=.\\SQLEXPRESS;" +
                                            "Initial Catalog=HomeworkDB;" +
                                            "Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("Arguments == null");

            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new HolidayConfig());
            modelBuilder.ApplyConfiguration(new TrainingConfig());

        }
    }
}
