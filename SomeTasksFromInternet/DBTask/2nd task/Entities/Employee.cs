using System;
using System.Collections.Generic;
using System.Text;

namespace _2nd_task.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public Employee() => Trainings = new HashSet<Training>();

        public override string ToString() => $"{FirstName} {SecondName}";
    }
}
