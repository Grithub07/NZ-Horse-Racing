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
    public partial class AddCustomerForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;
       

        public AddCustomerForm(DataController dc, MainForm mnu)
        {
            InitializeComponent();
            DC = dc;
            frmMenu = mnu;
            frmMenu.Hide();
        }

        

        private void ClearFields()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtEmailAddress.Text = "";
            txtStreetAddress.Text = "";
            txtSuburb.Text = "";
            txtCity.Text = "";
            txtPhoneNumber.Text = "";
            cboStatus.Text = "";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu.Show();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            
            if ((txtFirstName.Text == "") || (txtLastName.Text == "") ||
                (txtStreetAddress.Text == "") ||
                (txtSuburb.Text == "") || (txtCity.Text == "") ||
                (txtEmailAddress.Text == "")|| (txtPhoneNumber.Text == "") || (cboStatus.Text == ""))
            {
                MessageBox.Show("You are missing one or more information fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

             DataRow newCustomerRow = DC.dtCustomer.NewRow();

             newCustomerRow["CustomerLastName"] = txtLastName.Text;
             newCustomerRow["CustomerFirstName"] = txtFirstName.Text;
             newCustomerRow["CustomerStreetAddress"] = txtStreetAddress.Text;
             newCustomerRow["CustomerSuburb"] = txtSuburb.Text;
             newCustomerRow["CustomerPhoneNumber"] = txtPhoneNumber.Text;
             newCustomerRow["CustomerEmailAddress"] = txtEmailAddress.Text;
             newCustomerRow["CustomerCity"] = txtCity.Text;
             newCustomerRow["CreditStatus"] = cboStatus.Text;
             DC.dtCustomer.Rows.Add(newCustomerRow);
             DC.UpdateCustomer();
                if (MessageBox.Show("Customer Added Successfully, would you like to add another?", "Acknowledgement",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    ClearFields();
                }
                else
                {
                    ClearFields();
                    this.Hide();
                    frmMenu.Show();
                }





            }



                
    




        }
        
    }
}
