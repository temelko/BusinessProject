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
    public partial class EmployeeOptionsForm : Form
    {
        DepartmentController depController = new DepartmentController();
        EmployeeController empController = new EmployeeController();

        public EmployeeOptionsForm()
        {
            InitializeComponent();
            SelectDepartment_CmbBox.DataSource=depController.GetAllDepartments().Select(x => x.Name).ToArray();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchBox.Text = null;
        }

        private void EmployeeOptionsForm_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "Search for an employee";
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            FamilyStatus famStat = new FamilyStatus();
            if (SingleRBtn.Checked)
            {
                famStat = FamilyStatus.single;
            }
            else if (MarriedRBtn.Checked)
            {
                famStat = FamilyStatus.married;
            }
            try
            {
                if (!empController.EmployeeBirthdateDataValidation(DayTxtBox.Text, MonthTxtBox.Text, int.Parse(YearBox.Text)))
                {
                    throw new ArgumentException();
                }
                if (!empController.EmployeeInternshipDataValidation(int.Parse(InternshipBox.Text), int.Parse(YearBox.Text)))
                {
                    throw new InvalidOperationException();
                }
             
              
                    empController.AddEmployee(NameBox.Text, int.Parse(YearBox.Text),
                        famStat, int.Parse(InternshipBox.Text),
                        depController.GetDepartmentByName(SelectDepartment_CmbBox.Text).Name);
                
                MessageBox.Show("Operation is successful!", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputData();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("You have enterned not existing department!", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(InvalidOperationException)
            {
                
                MessageBox.Show("You have entered invalid internship!", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("You have entered wrong birthdate!", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception )
            {

                MessageBox.Show("You have entered wrong data!", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }

        private void SearchBox_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
        }

        private void EmployeeOptionsForm_Click_1(object sender, EventArgs e)
        {
            SearchBox.Text = "Search for an employee";
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var employeeSearchName = SearchBox.Text;

            if (empController.CheckIfTheEmployeeExists(employeeSearchName))
            {
                var employee = empController.GetEmployeeByName(employeeSearchName);

                ResultFromEmployeeSearch resultFromEmployeeSForm = new ResultFromEmployeeSearch(employee);

                resultFromEmployeeSForm.Show();
            }
            else
            {
                MessageBox.Show("There is no employee with this name", "Employee not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ClearInputData()
        {
            this.NameBox.Text = string.Empty;
            this.InternshipBox.Text = string.Empty;
            this.DayTxtBox.Text = string.Empty;
            this.MonthTxtBox.Text = string.Empty;
            this.YearBox.Text = string.Empty;
            this.MarriedRBtn.Checked = false;
            this.SingleRBtn.Checked = false;
            this.SelectDepartment_CmbBox.Text = string.Empty;
        }

        private void EmployeeOptionsForm_Load(object sender, EventArgs e)
        {
         
        }
    }
}
