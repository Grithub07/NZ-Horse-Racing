using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZ_Horse_Racing
{
    public partial class LoginForm : Form
    {

        
        private MainForm frmMenu;


        public LoginForm()
        {
            InitializeComponent();          
            
            
        }

        
       

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFields()
        {
            txtUser.Text = "";
            txtPassword.Text = "";

        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassword.PasswordChar = (char)0;
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text == "") || (txtPassword.Text == ""))

            {
                MessageBox.Show("Please enter your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else try
            {
                EmployeesDataSetTableAdapters.EmployeesTableAdapter user = new EmployeesDataSetTableAdapters.EmployeesTableAdapter();
                EmployeesDataSet.EmployeesDataTable dt = user.GetDataByUsernamePassword(txtUser.Text, txtPassword.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("You have successfully been logged in.", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    
                    frmMenu = new MainForm(this);
                    
                    frmMenu.ShowDialog();
                        ClearFields();


                }
                else
                {
                    MessageBox.Show("Your username or password is incorrect. ", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
