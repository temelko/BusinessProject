using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ResultFromEmployeeSearch : Form
    {
        EmployeeController employeeController = new EmployeeController();
        DepartmentController depController = new DepartmentController();
        private Employee currentEmployee;
        public ResultFromEmployeeSearch(Employee currentEmployee)
        {
            InitializeComponent();
            this.currentEmployee = currentEmployee;
            this.NameBox.Text = currentEmployee.Name;
            this.InternshipBox.Text = currentEmployee.Internship.ToString();
            this.SalaryTxtBox.Text = currentEmployee.Salary.ToString();

            SelectDepartment_CmbBox.DataSource=depController.GetAllDepartments().Select(x => x.Name).ToArray();
            SelectDepartment_CmbBox.Text = currentEmployee.Dep.Name;
            if (currentEmployee.Status.Equals(FamilyStatus.married))
            {
                this.MarriedRBtn.Checked = true;
            }
            else
            {
                this.SingleRBtn.Checked = true;
            }
        }
        private void ResultFromEmployeeSearch_Load(object sender, EventArgs e)
        {
            

        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ClearInputData();
            employeeController.RemoveEmployeeById(currentEmployee.EmployeeId);
            currentEmployee = null;

            MessageBox.Show("Employee successfully removed", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Visible = false;
            EmployeeOptionsForm emp = new EmployeeOptionsForm();
            emp.Visible = true;
        }

        private void ClearInputData()
        {
            this.NameBox.Text = string.Empty;
            this.InternshipBox.Text = string.Empty;
            this.SalaryTxtBox.Text = string.Empty;

            this.MarriedRBtn.Checked = false;
            this.SingleRBtn.Checked = false;

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FamilyStatus famStatus = FamilyStatus.single;
                if (MarriedRBtn.Checked)
                {
                    famStatus = FamilyStatus.married;
                }
           
                if (!employeeController.EmployeeSalaryValidation(SalaryTxtBox.Text, depController.GetDepartmentByName(SelectDepartment_CmbBox.Text)))
                {
                    throw new Exception("The salary is too low!");
                }
                employeeController.ReworkEmployee(currentEmployee, NameBox.Text, int.Parse(SalaryTxtBox.Text), famStatus, int.Parse(InternshipBox.Text),
                   SelectDepartment_CmbBox.Text, double.Parse(SalaryTxtBox.Text));
                MessageBox.Show("Operation is successful!", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                EmployeeOptionsForm emp = new EmployeeOptionsForm();
                emp.Visible = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Incorrect data",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void ResultFromEmployeeSearch_Load_1(object sender, EventArgs e)
        {
           
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            ClearInputData();
            employeeController.RemoveEmployeeById(currentEmployee.EmployeeId);
            currentEmployee = null;

            MessageBox.Show("Employee successfully removed", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Visible = false;
            EmployeeOptionsForm emp = new EmployeeOptionsForm();
            emp.Visible = true;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            EmployeeOptionsForm empOpt = new EmployeeOptionsForm();
            empOpt.Visible = true;
        }
    }
}
