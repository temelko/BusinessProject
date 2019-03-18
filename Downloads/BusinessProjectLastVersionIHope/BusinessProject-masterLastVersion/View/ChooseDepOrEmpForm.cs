
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
    public partial class ChooseDepOrEmpForm : Form
    {
        //BusinessProjectDbContext db;
        public ChooseDepOrEmpForm()
        {
            InitializeComponent();

        }

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            EmployeeOptionsForm employeeOptions = new EmployeeOptionsForm();
            employeeOptions.Show();


        }

        private void DepartmentBtn_Click(object sender, EventArgs e)
        {
        
            DepartmentOptionForm departmentOptions = new DepartmentOptionForm();
            departmentOptions.ShowDialog();
            this.Visible = false;

        }

        private void EmployeeBtn_Click_1(object sender, EventArgs e)
        {
            EmployeeOptionsForm employee = new EmployeeOptionsForm();
            employee.ShowDialog();
            this.Visible = false;
        }

        private void ChooseDepOrEmpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
