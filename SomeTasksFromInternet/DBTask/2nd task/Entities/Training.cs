using _2nd_task.Entities;
using System;
using System.Collections.Generic;

namespace _2nd_task
{
    public class Training 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public Training() => Employees = new HashSet<Employee>();

        public override string ToString() => $"{Id} {Title}";

    }
}
