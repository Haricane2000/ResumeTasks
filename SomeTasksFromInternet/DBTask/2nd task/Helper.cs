using _2nd_task.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2nd_task
{
    public static class Helper
    {
        public static void Holidays(AppContext _context)
        {
            if (_context == null)
                throw new ArgumentNullException("Arguments == null");

            List<Holiday> list = new List<Holiday>();

            foreach (Holiday a in _context.Holidays)
                list.Add(a);

            var li = list.Select(x => x)
                .Where(x => (x.EndHolidayDate - x.StartHolidayDate).Days > 30)
                .GroupBy(x => x.EmployeeId);

            foreach (var n in li)
                Console.WriteLine(n.ToList().First());
        }

        public static void FinishTrainings(AppContext _context)
        {
            if (_context == null)
                throw new ArgumentNullException("Arguments == null");

            int count = 1;
            List<Holiday> hol = _context.Holidays.Select(x => x).ToList();
            List<Training> trainings = _context.Trainings.Select(x => x).ToList();
            List<Employee> emp = _context.Employees.Select(x => x).ToList();

            Console.WriteLine("----Proccess----");

            foreach (var item in trainings)
            {
                var correct = hol.GroupBy(x => x.EmployeeId);
                foreach (var a in correct)
                {
                    var b = a.Select(x => x).Where(x => (x.StartHolidayDate >= item.StartDate && x.StartHolidayDate <= item.EndDate)
                     || (x.EndHolidayDate <= item.EndDate && x.EndHolidayDate >= item.EndDate)
                     || (x.StartHolidayDate <= item.StartDate && x.EndHolidayDate >= item.EndDate)).Count();

                    if (b == 0)
                    {
                        AddToList(count, emp, item, a);
                    }
                }

                count++;
            }

            _context.SaveChanges();
        }

        static void AddToList(int count, List<Employee> emp, Training item, IGrouping<Guid, Holiday> a)
        {
            if (emp == null || item == null || a == null)
                throw new ArgumentNullException("Arguments == null");

            if (count == 1)
                foreach (Employee empl in emp)
                    if (empl.Id == a.Key)
                        empl.Trainings.Add(item);

            if (count == 2)
                foreach (Employee empl in emp)
                    if (empl.Id == a.Key)
                        empl.Trainings.Add(item);
        }
    }
}
