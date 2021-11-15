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
    public partial class AddOwnerForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;

        public AddOwnerForm(DataController dc, MainForm mnu)
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
            cboNZRAMemb.Text = "";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu.Show();
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            if ((txtFirstName.Text == "") || (txtLastName.Text == "") ||
                (txtStreetAddress.Text == "") ||
                (txtSuburb.Text == "") || (txtCity.Text == "") ||
                (txtEmailAddress.Text == "") || (txtPhoneNumber.Text == "") || (cboNZRAMemb.Text == "")) 
            {
                MessageBox.Show("You are missing one or more information fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DataRow newOwnerRow = DC.dtOwner.NewRow();

                newOwnerRow["OwnerLastName"] = txtLastName.Text;
                newOwnerRow["OwnerFirstName"] = txtFirstName.Text;
                newOwnerRow["OwnerStreetAddress"] = txtStreetAddress.Text;
                newOwnerRow["OwnerSuburb"] = txtSuburb.Text;
                newOwnerRow["OwnerPhoneNumber"] = txtPhoneNumber.Text;
                newOwnerRow["OwnerEmailAddress"] = txtEmailAddress.Text;
                newOwnerRow["OwnerCity"] = txtCity.Text;
                newOwnerRow["NZRAMembership"] = cboNZRAMemb.Text;
                DC.dtOwner.Rows.Add(newOwnerRow);
                DC.UpdateOwner();
                if (MessageBox.Show("Owner Added Successfully, would you like to add another?", "Acknowledgement",
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
