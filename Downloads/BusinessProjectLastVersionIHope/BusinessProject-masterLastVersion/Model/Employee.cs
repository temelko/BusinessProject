using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public FamilyStatus Status { get; set; }
        public int Internship { get; set; }
        public Department Dep { get; set; }
        public double? Salary { get; set; }

        public Employee()
        {

        }

        public Employee(string name, int years, FamilyStatus s, int internship, Department d)
        {
            this.Name = name;
            this.Year = years;
            this.Status = s;
            this.Internship = internship;
            this.Dep = d;
            CalculateSalary();
        }
        public void CalculateSalary()
        {
            Salary = Dep.BaseSalary + Dep.BaseSalary * 0.01 * Internship;
            if (Status.ToString() == "married" && Salary <= 5000)
            {
                Salary += 0.05 * Dep.BaseSalary;
            }
            else if (Salary > 5000 && Status.ToString() == "married")
            {
                Salary += 250;
            }
        }
    }
}
