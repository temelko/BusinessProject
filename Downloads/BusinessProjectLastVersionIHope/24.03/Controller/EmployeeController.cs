using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class EmployeeController
    {
        BusinessProjectDbContext businessContext;

        public EmployeeController()
        {

        }

        public void AddEmployee(string name, int year, FamilyStatus famStatus, int internship, string departmentName)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                Employee newEmployee = new Employee(name, year, famStatus, internship, businessContext.Departments.First(x => x.Name == departmentName));
                businessContext.Employees.Add(newEmployee);
                businessContext.SaveChanges();
            }
            
        }

        public bool CheckIfTheEmployeeExists(string EmployeeName)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                try
                {
                    string gettingTheName = businessContext.Employees.First(x => x.Name == EmployeeName).Name;
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        public Employee SearchForAnEmployee(string employeeName)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                return businessContext.Employees.First(x => x.Name == employeeName);
            }
           
        }

        public void RemoveEmployeeById(int id)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
               

                businessContext.Employees.Remove(businessContext.Employees.FirstOrDefault(x => x.EmployeeId == id));

                businessContext.SaveChanges();
            }
        }

        public void RemoveEmployee(Employee employeeForRemoving)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                businessContext.Employees.Remove(employeeForRemoving);
                businessContext.SaveChanges();
            }
          
        }

        public Employee GetEmployeeByName(string employeeName)
        {
            using (businessContext = new BusinessProjectDbContext())
            {

                return businessContext.Employees.Where(x => x.Name == employeeName)
                    .Include(x => x.Dep).FirstOrDefault();
            }

        }

        public void ReworkEmployee(Employee foundEmployee, string name, int year, FamilyStatus fStat, int internship, string depName, double salary)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                businessContext.Employees.First(x => x.EmployeeId == foundEmployee.EmployeeId).Name = name;
                businessContext.Employees.First(x => x.EmployeeId == foundEmployee.EmployeeId).Year = year;
                businessContext.Employees.First(x => x.EmployeeId == foundEmployee.EmployeeId).Status = fStat;
                businessContext.Employees.First(x => x.EmployeeId == foundEmployee.EmployeeId).Internship = internship;
                businessContext.Employees.First(x => x.EmployeeId == foundEmployee.EmployeeId).Dep = businessContext.Departments.First(x=> x.Name == depName);
                businessContext.Employees.First(x => x.EmployeeId == foundEmployee.EmployeeId).Salary = salary;
           
                businessContext.SaveChanges();
            }

        }

        public bool EmployeeBirthdateDataValidation(string date, string month, int year)
        {
            bool flag = false;
            if (date =="01" || date =="02" || date =="03" || date == "04" || date =="05"
                || date =="06" || date=="07" || date =="08" || date =="09" || date =="10"
                || date =="11" || date =="12" || date == "13" || date == "14" || date == "15"
                || date == "16" || date == "17" || date == "18" || date == "19" || date == "20"
                || date == "21" || date == "22" || date == "23" || date == "24" || date == "25"
                || date == "26" || date == "27" || date == "28" || date == "29" || date == "30"
                || date == "31" || date == "1" || date == "2" || date == "3" || date == "4"
                || date == "5" || date == "6" || date == "7" || date == "8" || date == "9")
            {
                flag = true;
            }

            if (month == "01" || month == "02" || month == "03" || month == "04" || month == "05"
                || month == "06" || month == "07" || month == "08" || month == "09" || month == "10"
                || month == "11" || month == "12"||  month == "1" || month == "2" || month == "3" || month == "4"
                || month == "5" || month == "6" || month == "7" || month == "8" || month == "9")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            if (year<1900 || year >2009)
            {
                flag = false;
            }
            if (year%4!=0)
            {
                if ((month == "02" || month == "2") && (date == "29" || date == "30"
                                || date == "31"))
                {
                    flag = false;
                }
                else if ((month == "02" || month == "2") && (date == "30"
                                || date == "31")) 
                {
                    flag = false;
                }
            }

            return flag;
        }

        public bool EmployeeInternshipDataValidation(int internship, int year)
        {
            int personYear = 2019 - year;
            if (personYear-16 < internship)
            {
                return false;
            }
            return true;
        }

        public bool EmployeeSalaryValidation(string salary, Department d)
        {
            using (businessContext=new BusinessProjectDbContext())
            {
                if (int.Parse(salary) < d.BaseSalary)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
