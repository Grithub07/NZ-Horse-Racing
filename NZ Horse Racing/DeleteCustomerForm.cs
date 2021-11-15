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
    public partial class DeleteCustomerForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;
        private CurrencyManager cmCustomer;
        private CurrencyManager currencyManager;
        

        public DeleteCustomerForm(DataController dc, MainForm mnu)
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
            txtEmailAddress.Text = "";          
            txtPhoneNumber.Text = "";
            
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



        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu.Show();
        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem != null)
            {
                
                string customer, custIDText, firstnameText, lastnameText, emailText, phoneText = "";
                txtLastName.Text = "";
                txtCustomerID.Text = "";
                txtFirstName.Text = "";
                txtEmailAddress.Text = "";
                txtPhoneNumber.Text = "";
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
                txtCustomerID.Text += custIDText;
                txtEmailAddress.Text += emailText;
                txtPhoneNumber.Text += phoneText;
                txtLastName.Text += lastnameText;
                txtFirstName.Text += firstnameText;
                lastnameText = "";
                firstnameText = "";

                custIDText = "";
                lastnameText = "";
                firstnameText = "";
                emailText = "";
                phoneText = "";             


            }

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DataRow deleteCustomerRow = DC.dtCustomer.Rows[currencyManager.Position];
            DataRow[] drBooking = deleteCustomerRow.GetChildRows(DC.dtCustomer.ChildRelations["CUSTOMERS_BOOKINGS"]);
            if (drBooking.Length == 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this customer", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteCustomerRow.Delete();
                    DC.UpdateCustomer();
                    lstCustomers.Items.Clear();
                    loadCustomers();

                    if (MessageBox.Show("Customer deleted successfully, would you like to delete another?", "Acknowledgement",
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
                else
                {
                  ClearFields();

                }
            }
            else
            {
                MessageBox.Show("Customers with bookings cannot be deleted", "Error");
            }
        }
    }
}
