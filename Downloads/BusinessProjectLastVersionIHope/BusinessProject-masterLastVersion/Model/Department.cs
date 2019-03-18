using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new List<Employee>();

        }

        public Department(string name, double salary)
        {
            this.Name = name;
            this.BaseSalary = salary;
            Employees = new List<Employee>();
        }
    }
}
