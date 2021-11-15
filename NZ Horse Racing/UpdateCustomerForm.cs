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
    public partial class UpdateCustomerForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;
        private CurrencyManager cmCustomer;
        private CurrencyManager currencyManager;
        

        public UpdateCustomerForm(DataController dc, MainForm mnu)
        {
            InitializeComponent();
            DC = dc;
            frmMenu = mnu;
            frmMenu.Hide();
            lstCustomers.Items.Clear();
            loadCustomers();
            BindControls();
        }

       

        private void ClearFields()
        {
            txtCustomerID.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtStreetAddress.Text = "";
            txtSuburb.Text = "";
            txtCity.Text = "";
            txtEmailAddress.Text = "";
            txtPhoneNumber.Text = "";
            cboStatus.Text = "";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu.Show();
        }

        public void BindControls()
        {

            currencyManager = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Customers"];
        }

        private void loadCustomers()
        {
            string customerText = "";
            foreach (DataRow drCustomer in DC.dtCustomer.Rows)
            {


                customerText = drCustomer["CustomerID"] + ": ";
                customerText += drCustomer["CustomerFirstName"] + " " + drCustomer["CustomerLastName"];
                lstCustomers.Items.Add(customerText);

            }
        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem != null)
            {
                string customer, custIDText, firstnameText, lastnameText, streetText, suburbText, cityText, emailText, phoneText, statusText = "";
                txtLastName.Text = "";
                txtCustomerID.Text = "";
                txtFirstName.Text = "";
                txtStreetAddress.Text = "";
                txtSuburb.Text = "";
                txtCity.Text = "";
                txtEmailAddress.Text = "";
                txtPhoneNumber.Text = "";
                cboStatus.Text = "";
                CurrencyManager cmCustomer;
                cmCustomer = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Customers"];

                customer = lstCustomers.SelectedItem.ToString();
                string[] parts = customer.Split(':');
                int custID = Convert.ToInt32(parts[0]);
                cmCustomer.Position = DC.customerView.Find(custID);
                DataRow drCustomer = DC.dtCustomer.Rows[cmCustomer.Position];
                emailText = drCustomer["CustomerEmailAddress"].ToString();
                phoneText = drCustomer["CustomerPhoneNumber"].ToString();
                custIDText = drCustomer["CustomerID"].ToString();
                lastnameText = drCustomer["CustomerLastName"].ToString();
                firstnameText = drCustomer["CustomerFirstName"].ToString();
                streetText = drCustomer["CustomerStreetAddress"].ToString();
                suburbText = drCustomer["CustomerSuburb"].ToString();
                cityText = drCustomer["CustomerCity"].ToString();
                statusText = drCustomer["CreditStatus"].ToString();

                txtCustomerID.Text += custIDText;
                txtEmailAddress.Text += emailText;
                txtPhoneNumber.Text += phoneText;
                txtLastName.Text += lastnameText;
                txtFirstName.Text += firstnameText;
                txtStreetAddress.Text += streetText;
                txtSuburb.Text += suburbText;
                txtCity.Text += cityText;
                cboStatus.Text += statusText;

                lastnameText = "";
                firstnameText = "";
                custIDText = "";
                streetText = "";
                suburbText = "";
                cityText = "";
                statusText = "";
                emailText = "";
                phoneText = "";
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            string customer = "";
            cmCustomer = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Customers"];
            customer = lstCustomers.SelectedItem.ToString();
            string[] parts = customer.Split(':');
            int customerID = Convert.ToInt32(parts[0]);
            cmCustomer.Position = DC.customerView.Find(customerID);

            DataRow updateCustomerRow = DC.dtCustomer.Rows[cmCustomer.Position];
            if ((txtStreetAddress.Text == "") || (txtSuburb.Text == "") || (cboStatus.Text == "") || (txtCity.Text == "") ||
                (txtLastName.Text == "") || (txtFirstName.Text == "") || (txtEmailAddress.Text == "") || (txtPhoneNumber.Text == ""))
            {
                MessageBox.Show("Please fill in  all fields correctly", "Error");
            }
            else
            {

                if (MessageBox.Show("Are you sure you want to update this customer?", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    updateCustomerRow["CustomerFirstName"] = txtFirstName.Text;
                    updateCustomerRow["CustomerLastName"] = txtLastName.Text;
                    updateCustomerRow["CustomerStreetAddress"] = txtStreetAddress.Text;
                    updateCustomerRow["CustomerSuburb"] = txtSuburb.Text;
                    updateCustomerRow["CustomerCity"] = txtCity.Text;
                    updateCustomerRow["CustomerEmailAddress"] = txtEmailAddress.Text;
                    updateCustomerRow["CustomerPhoneNumber"] = txtPhoneNumber.Text;
                    updateCustomerRow["CreditStatus"] = cboStatus.Text;
                    cmCustomer.EndCurrentEdit();
                    DC.UpdateCustomer();
                    if (MessageBox.Show("Customer Updated Successfully, would you like to update another?", "Acknowledgement",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        ClearFields();
                        lstCustomers.Items.Clear();
                        loadCustomers();
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
