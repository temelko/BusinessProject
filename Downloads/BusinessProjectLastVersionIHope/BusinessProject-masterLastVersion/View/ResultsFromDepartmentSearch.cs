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
    public partial class ResultsFromDepartmentSearch : Form
    {
        DepartmentController depController = new DepartmentController();
        private string currentDepName;
        private Department currentDepartment;
        public void SetDepartmentName(string currentDepartmentName)
        {
            currentDepName = currentDepartmentName;
            currentDepartment = depController.GetDepartmentByName(currentDepName);
        }
        
        public ResultsFromDepartmentSearch()
        {
            InitializeComponent();
        }

        private void ResultsFromDepartmentSearch_Load(object sender, EventArgs e)
        {
            DepartmentNameBox.Text = currentDepName;
           
            DepartBaseSalaryBox.Text = depController.GetDepartmentByName(DepartmentNameBox.Text).BaseSalary.ToString();
            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                depController.ReworkDepartmentName(currentDepartment, DepartmentNameBox.Text);
                
                    if (!depController.DepartmentSalaryDataValidation(double.Parse(DepartBaseSalaryBox.Text)))
                    {
                        throw new NullReferenceException("Salary is too low!");
                    }
                    //else if (currentDepartment.BaseSalary!=double.Parse(DepartBaseSalaryBox.Text))
                   // {

                        depController.ReworkDepartmentSalary(currentDepartment, double.Parse(DepartBaseSalaryBox.Text));
                     
                    //}
                MessageBox.Show("Operation is successful!", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                DepartmentOptionForm dep = new DepartmentOptionForm();
                dep.Visible = true;


             }

             catch (Exception ex)
              {

              MessageBox.Show(ex.Message, "Incorrect data",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

             }

        }

        private void DepartmentNameBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void DepartBaseSalaryBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DepartmentOptionForm dep = new DepartmentOptionForm();
            dep.Visible = true;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

                depController.RemoveDepartment(currentDepName);
                MessageBox.Show("Operation is successful!", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                DepartmentOptionForm depOpt = new DepartmentOptionForm();
                depOpt.Visible = true;
          
        }

    }
}
