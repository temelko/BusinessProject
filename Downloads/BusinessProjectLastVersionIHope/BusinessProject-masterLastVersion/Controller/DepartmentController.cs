using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class DepartmentController
    {

        public DepartmentController()
        {

        }

        public BusinessProjectDbContext businessContext;

        public void AddDepartment(string name, double salary)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                Department dep = new Department(name, salary);

                businessContext.Departments.Add(dep);
                businessContext.SaveChanges();
            }

        }
        
        public void RemoveDepartment(string depName)
        {
            Department currentDep = GetDepartmentByName(depName);
            using (businessContext = new BusinessProjectDbContext())
            {
                
                List<Employee> empList = new List<Employee>();
                var result = (from r in businessContext.Employees select r).ToList();
                foreach (var emp in result)
                {
                    if (emp.Dep==currentDep)
                    {
                        Employee newEmployee = new Employee(emp.Name, emp.Year, emp.Status, emp.Internship, businessContext.Departments.First(x => x.Name == "TemporaryDepartment"));                  
                        
                        empList.Add(newEmployee);
                    }
                }
                
                foreach (var el in empList)
                {
                    businessContext.Employees.Add(el);
                    businessContext.SaveChanges();

                }


                businessContext.Departments.Remove(businessContext.Departments.FirstOrDefault(x=> x.Name == depName));
                businessContext.SaveChanges();
            }

        }

        public bool DepartmentNameDataValidation(string depName)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                foreach (var el in businessContext.Departments)
                {
                    if (el.Name == depName)
                    {
                        return false;
                    } 
                }
            }
            return true;
        }

        public bool DepartmentSalaryDataValidation(double salary)
        {
            if (salary < 500)
            {
                return false;
            }
            return true;

        }

        public bool CheckIfTheDepartmentExist(string depName)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                try
                {
                    string gettingTheName = businessContext.Departments.First(x => x.Name == depName).Name;
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
               
            }
        }
        
        public void ReworkDepartmentName(Department currentDep, string newDepName)
        {
            
            using (businessContext = new BusinessProjectDbContext())
            {
                Department departmentForRework = businessContext.Departments.First(x=> x.DepartmentId == currentDep.DepartmentId );
                departmentForRework.Name = newDepName;
                businessContext.SaveChanges();
            }
        }

        public void ReworkDepartmentSalary(Department currentDep, double salary)
        {
            
            using (businessContext = new BusinessProjectDbContext())
            {
                currentDep.BaseSalary = salary;
                businessContext.SaveChanges();

                foreach (var emp in currentDep.Employees)
                {
                    if (emp.Salary < currentDep.BaseSalary)
                    {
                        emp.CalculateSalary();
                        businessContext.SaveChanges();
                    }
                }
            }
        
        }
     

        public IEnumerable<Department> GetAllDepartments()
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                return businessContext.Departments.ToList();
            }
        }

        public Department GetDepartmentByName(string name)
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                return businessContext.Departments.FirstOrDefault(x => x.Name == name);
            }
        }

        public List<Employee> ReturnEmployees()
        {
            using (businessContext = new BusinessProjectDbContext())
            {
                return businessContext.Employees.ToList();
            }
        }


            // Peca DONT'T USE THIS METHOD!!!
            //public void RemoveAll()
            //{
            //    using (businessContext = new BusinessProjectDbContext())
            //    {
            //        foreach (var el in businessContext.Departments)
            //        {
            //            if (el.Name!="TemporaryDepartment")
            //            {
            //                RemoveDepartment(el.Name);
            //            }

            //        }
            //    }

            //}

        }
    }
