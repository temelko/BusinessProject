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
    public partial class DepartmentOptionForm : Form
    {
        public DepartmentController depController = new DepartmentController();

        public DepartmentOptionForm()
        {
            InitializeComponent();
            

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ChooseDepOrEmpForm choose = new ChooseDepOrEmpForm();
            choose.Visible = true;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                string depName = DepartmentNameBox.Text;
                double salary = double.Parse(DepartBaseSalaryBox.Text);
                if (!depController.DepartmentNameDataValidation(depName))
                {
                    throw new Exception("Department with this name already exists!");
                }
                else if (!depController.DepartmentSalaryDataValidation(salary))
                {
                    throw new Exception("The salary is too low!");
                }
                else
                {
                    depController.AddDepartment(depName, salary);
                    MessageBox.Show("Operation is successful!", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                }
            }
                      
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Incorrect data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchBox.Text = null;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

        }

        private void DepartmentNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DepartBaseSalaryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchBox_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
        }

        private void DepartmentOptionForm_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "Search for department";
        }

        private void SearchBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void SearchBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!depController.CheckIfTheDepartmentExist(SearchBox.Text))
                {
                    throw new Exception("Department with this name does not exists!");
                }
                if (SearchBox.Text=="Temporary department")
                {
                    throw new ArgumentException("Temporary department can not be reworked!");
                }
                this.Visible = false;
                ResultsFromDepartmentSearch departmentForm = new ResultsFromDepartmentSearch();
              
                departmentForm.SetDepartmentName(SearchBox.Text);
                departmentForm.Visible = true;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Incorrect data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void DepartmentNameBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            ChooseDepOrEmpForm choose = new ChooseDepOrEmpForm();
            choose.Visible = true;
        }

        private void DepartmentOptionForm_Load(object sender, EventArgs e)
        {
         
        }

        private void ClearInput()
        {
            this.DepartmentNameBox.Text = string.Empty;
            this.DepartBaseSalaryBox.Text = string.Empty;
        }
    }
}
