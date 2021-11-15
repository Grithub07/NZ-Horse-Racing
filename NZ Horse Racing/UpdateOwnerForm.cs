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
    public partial class UpdateOwnerForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;
        private CurrencyManager cmOwner;
        private CurrencyManager currencyManager;

        public UpdateOwnerForm(DataController dc, MainForm mnu)
        {
            InitializeComponent();
            DC = dc;
            frmMenu = mnu;
            frmMenu.Hide();
            lstOwners.Items.Clear();
            loadOwners();
            BindControls();
        }

        private void ClearFields()
        {
            txtOwnerID.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtStreetAddress.Text = "";
            txtSuburb.Text = "";
            txtCity.Text = "";
            txtPhoneNumber.Text = "";
            txtEmailAddress.Text = "";
            cboMembs.Text = "";
        }

        public void BindControls()
        {

            currencyManager = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Owners"];
        }

        private void loadOwners()
        {
            string ownerText = "";
            foreach (DataRow drOwner in DC.dtOwner.Rows)
            {


                ownerText = drOwner["OwnerID"] + ": ";
                ownerText += drOwner["OwnerFirstName"] + " " + drOwner["OwnerLastName"];
                lstOwners.Items.Add(ownerText);

            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu.Show();
        }

        private void lstOwners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwners.SelectedItem != null)
            {
                string owner, ownerIDText, firstnameText, lastnameText, streetText, suburbText, cityText, phoneText, emailText, membsText = "";
                txtLastName.Text = "";
                txtOwnerID.Text = "";
                txtFirstName.Text = "";
                txtStreetAddress.Text = "";
                txtSuburb.Text = "";
                txtCity.Text = "";
                txtEmailAddress.Text = "";
                txtPhoneNumber.Text = "";
                cboMembs.Text = "";
                CurrencyManager cmOwner;
                cmOwner = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Owners"];

                owner = lstOwners.SelectedItem.ToString();
                string[] parts = owner.Split(':');
                int ownerID = Convert.ToInt32(parts[0]);
                cmOwner.Position = DC.ownerView.Find(ownerID);
                DataRow drOwner = DC.dtOwner.Rows[cmOwner.Position];
                streetText = drOwner["OwnerStreetAddress"].ToString();
                suburbText = drOwner["OwnerSuburb"].ToString();
                ownerIDText = drOwner["OwnerID"].ToString();
                cityText = drOwner["OwnerCity"].ToString();
                phoneText = drOwner["OwnerPhoneNumber"].ToString();
                emailText = drOwner["OwnerEmailAddress"].ToString();
                membsText = drOwner["NZRAMembership"].ToString();
                lastnameText = drOwner["OwnerLastName"].ToString();
                firstnameText = drOwner["OwnerFirstName"].ToString();
                txtOwnerID.Text += ownerIDText;
                txtStreetAddress.Text += streetText;
                txtSuburb.Text += suburbText;
                txtCity.Text += cityText;
                txtPhoneNumber.Text += phoneText;
                txtEmailAddress.Text += emailText;
                cboMembs.Text += membsText;
                txtLastName.Text += lastnameText;
                txtFirstName.Text += firstnameText;
                lastnameText = "";
                firstnameText = "";
                ownerIDText = "";
                streetText = "";
                suburbText = "";
                cityText = "";
                phoneText = "";
                emailText = "";
                membsText = "";
            }
        }

        private void btnUpdateOwner_Click(object sender, EventArgs e)
        {

            string owner = "";
            cmOwner = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Owners"];
            owner = lstOwners.SelectedItem.ToString();
            string[] parts = owner.Split(':');
            int ownerID = Convert.ToInt32(parts[0]);
            cmOwner.Position = DC.ownerView.Find(ownerID);
            DataRow updateOwnerRow = DC.dtOwner.Rows[cmOwner.Position];
            if ((txtStreetAddress.Text == "") || (txtSuburb.Text == "") || (cboMembs.Text == "") || (txtCity.Text == "") ||
                (txtLastName.Text == "") || (txtFirstName.Text == "") || (txtEmailAddress.Text == "") || (txtPhoneNumber.Text == ""))
            {
                MessageBox.Show("Please fill in  all fields correctly", "Error");
            }
            else
            {

                if (MessageBox.Show("Are you sure you want to update this owner?", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    updateOwnerRow["OwnerFirstName"] = txtFirstName.Text;
                    updateOwnerRow["OwnerLastName"] = txtLastName.Text;
                    updateOwnerRow["OwnerStreetAddress"] = txtStreetAddress.Text;
                    updateOwnerRow["OwnerSuburb"] = txtSuburb.Text;
                    updateOwnerRow["OwnerCity"] = txtCity.Text;
                    updateOwnerRow["OwnerEmailAddress"] = txtEmailAddress.Text;
                    updateOwnerRow["OwnerPhoneNumber"] = txtPhoneNumber.Text;
                    updateOwnerRow["NZRAMembership"] = cboMembs.Text;

                    cmOwner.EndCurrentEdit();
                    DC.UpdateOwner();
                    if (MessageBox.Show("Owner Updated Successfully, would you like to update another?", "Acknowledgement",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        ClearFields();
                        lstOwners.Items.Clear();
                        loadOwners();
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
}
