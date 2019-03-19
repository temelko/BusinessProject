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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            UsernameBox.Text = "georgiev";

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "georgiev" && PasswordBox.Text == "2001")
            {
                this.Visible = false;
                ChooseDepOrEmpForm chooseOne = new ChooseDepOrEmpForm();
                chooseOne.Show();
            }
            else
            {
                MessageBox.Show("You have entered wrong username or password", "Incorrect data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogInBtn.PerformClick();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
