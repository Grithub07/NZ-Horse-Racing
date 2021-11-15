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
    public partial class DeleteOwnerForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;        
        private CurrencyManager cmOwner;
        private CurrencyManager currencyManager;

        public DeleteOwnerForm(DataController dc, MainForm mnu)
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

            txtNZRAMembs.Text = "";
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
                string owner, ownerIDText, firstnameText, lastnameText, streetText, suburbText, cityText, membsText = "";
                txtLastName.Text = "";
                txtOwnerID.Text = "";
                txtFirstName.Text = "";
                txtStreetAddress.Text = "";
                txtSuburb.Text = "";
                txtCity.Text = "";
                txtNZRAMembs.Text = "";
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
                membsText = drOwner["NZRAMembership"].ToString();
                lastnameText = drOwner["OwnerLastName"].ToString();
                firstnameText = drOwner["OwnerFirstName"].ToString();
                txtOwnerID.Text += ownerIDText;
                txtStreetAddress.Text += streetText;
                txtSuburb.Text += suburbText;
                txtCity.Text += cityText;
                txtNZRAMembs.Text += membsText;
                txtLastName.Text += lastnameText;
                txtFirstName.Text += firstnameText;
                lastnameText = "";
                firstnameText = "";

                ownerIDText = "";
                streetText = "";
                suburbText = "";
                cityText = "";
                membsText = "";


            }
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            DataRow deleteOwnerRow = DC.dtOwner.Rows[currencyManager.Position];
            DataRow[] drHorses = deleteOwnerRow.GetChildRows(DC.dtOwner.ChildRelations["OWNERS_HORSES"]);
            if (drHorses.Length == 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this owner", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteOwnerRow.Delete();
                    DC.UpdateOwner();
                    lstOwners.Items.Clear();
                    loadOwners();

                    if (MessageBox.Show("Owner deleted successfully, would you like to delete another?", "Acknowledgement",
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
            else
            {
                MessageBox.Show("Owners with horses cannot be deleted", "Error");
            }
        }
    }
}
