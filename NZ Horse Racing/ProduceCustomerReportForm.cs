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
    public partial class ProduceCustomerReportForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;
        private int amountOfCustomersPrinted, pagesAmountExpected;
        private DataRow[] customersForPrint;
      

        public ProduceCustomerReportForm(DataController dc, MainForm mnu)
        {
            InitializeComponent();
            DC = dc;
            frmMenu = mnu;
            frmMenu.Hide();
        }

       

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu.Show();
        }

        private void prntCustomers_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int linesSoFar = 0;
            Font textFont = new Font("Arial", 15, FontStyle.Regular);
            Font textFontCenter = new Font("Arial", 10, FontStyle.Regular);
            Font totalSubtotal = new Font("Arial", 10, FontStyle.Bold);
            Font headingFont = new Font("Arial", 25, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int headingLeftMargin = 50;
            int topMarginCustomer = topMargin + 100;            
            int rightMargin = e.MarginBounds.Right;
            g.DrawString("New Zealand Horse Racing" + "\n" + "Customers Report", headingFont, brush, leftMargin + headingLeftMargin, topMargin);
            linesSoFar++;

            DataRow drCustomer = customersForPrint[amountOfCustomersPrinted];
            CurrencyManager cmCustomer;
            cmCustomer = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Owners"];
            CurrencyManager cmBookings;
            cmBookings = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Bookings"];
            DataRow[] drBookings = drCustomer.GetChildRows(DC.dtCustomer.ChildRelations["CUSTOMERS_BOOKINGS"]);

            int bookingsmade = drBookings.Length;


            g.DrawString("Customer ID: " + drCustomer["CustomerID"].ToString() + "\n" + "Name: " + drCustomer["CustomerLastName"] +
               ", " + drCustomer["CustomerFirstName"] +  "\t \t" + "Bookings Made:" + bookingsmade + 
               "\n" + "Street Address: " + drCustomer["CustomerStreetAddress"] + "\t\t" + "Suburb: " + drCustomer["CustomerSuburb"] +
               "\n" + "City: " + drCustomer["CustomerCity"] + "\n" + "Credit Status: " + drCustomer["CreditStatus"] + "\n\n", textFont, brush, leftMargin, topMarginCustomer);


            
             amountOfCustomersPrinted++;
             if (!(amountOfCustomersPrinted == pagesAmountExpected))
             {
               e.HasMorePages = true;
             }


            

        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            amountOfCustomersPrinted = 0;
            string strSort = "CustomerLastName, CustomerFirstName";
            string strFilter = null;
            customersForPrint = DC.dsNZHorseRacing.Tables["Customers"].Select(strFilter, strSort, DataViewRowState.CurrentRows);
            pagesAmountExpected = customersForPrint.Length;
            prvCustomers.Show();
        }
    }
}
