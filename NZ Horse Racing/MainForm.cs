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
    public partial class MainForm : Form
    {
        private DataController DC;
        private MainForm frmMnu;

        public MainForm(MainForm frmMnu)
        {
            this.frmMnu = frmMnu;
        }

        private AddCustomerForm frmAddCustomer;
        private UpdateCustomerForm frmUpdateCustomer;
        private DeleteCustomerForm frmDeleteCustomer;
        private ProduceCustomerReportForm frmCustomerReport;
        private AddOwnerForm frmAddOwner;
        private UpdateOwnerForm frmUpdateOwner;
        private DeleteOwnerForm frmDeleteOwner;
        private ProduceOwnerReportForm frmOwnerReport;
        private LoginForm loginForm;

        

       

       

        public MainForm(LoginForm loginForm)
        {
            this.loginForm = loginForm;            
            loginForm.Hide();
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DC = new DataController();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (frmAddCustomer == null)
            {
                frmAddCustomer = new AddCustomerForm(DC, this); 
            }
            frmAddCustomer.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to logout?", "Logout",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
                loginForm.Show();
                
            }
            

            
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (frmUpdateCustomer == null)
            {
                frmUpdateCustomer = new UpdateCustomerForm(DC, this);
            }
            frmUpdateCustomer.ShowDialog();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (frmDeleteCustomer == null)
            {
                frmDeleteCustomer = new DeleteCustomerForm(DC, this);
            }
            frmDeleteCustomer.ShowDialog();
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            if (frmAddOwner == null)
            {
                frmAddOwner = new AddOwnerForm(DC, this);
            }
            frmAddOwner.ShowDialog();
        }

        private void btnUpdateOwner_Click(object sender, EventArgs e)
        {
            if (frmUpdateOwner == null)
            {
                frmUpdateOwner = new UpdateOwnerForm(DC, this);
            }
            frmUpdateOwner.ShowDialog();
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (frmDeleteOwner == null)
            {
                frmDeleteOwner = new DeleteOwnerForm(DC, this);
            }
            frmDeleteOwner.ShowDialog();
        }

        private void btnCustomerReport_Click(object sender, EventArgs e)
        {
            if (frmCustomerReport == null)
            {
                frmCustomerReport = new ProduceCustomerReportForm(DC, this);
            }
            frmCustomerReport.ShowDialog();
        }

        private void btnOwnerReport_Click(object sender, EventArgs e)
        {
            if (frmOwnerReport == null)
            {
                frmOwnerReport = new ProduceOwnerReportForm(DC, this);
            }
            frmOwnerReport.ShowDialog();
        }
    }
}
