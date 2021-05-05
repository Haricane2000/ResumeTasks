using _2nd_task.Entities;
using System;

namespace _2nd_task
{
    public class Holiday
    {
        public Guid Id { get; set; }
        public DateTime StartHolidayDate { get; set; }
        public DateTime EndHolidayDate { get; set; }
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public override string ToString() => $"{EmployeeId} {StartHolidayDate} {EndHolidayDate}";
    }
}
