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
    public partial class ProduceOwnerReportForm : Form
    {
        private DataController DC;
        private MainForm frmMenu;
        private int amountOfOwnersPrinted, pagesAmountExpected;
        private DataRow[] ownersForPrint;

        public ProduceOwnerReportForm(DataController dc, MainForm mnu)
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

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            amountOfOwnersPrinted = 0;
            string strSort = "OwnerID";
            string strFilter = null;
            ownersForPrint = DC.dsNZHorseRacing.Tables["Owners"].Select(strFilter, strSort, DataViewRowState.CurrentRows);
            pagesAmountExpected = ownersForPrint.Length;
            prvOwners.Show();
        }

        private void printOwners_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            int topMarginOwner = topMargin + 100;
            int topMarginHorse = topMargin + 101;            
            int rightMargin = e.MarginBounds.Right;
            g.DrawString("New Zealand Horse Racing" + "\n" + "Owners Report", headingFont, brush, leftMargin + headingLeftMargin, topMargin);
            linesSoFar++;

            DataRow drOwner = ownersForPrint[amountOfOwnersPrinted];
            CurrencyManager cmOwner;
            cmOwner = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Owners"];
            CurrencyManager cmHorses;
            cmHorses = (CurrencyManager)this.BindingContext[DC.dsNZHorseRacing, "Horses"];


            g.DrawString("Owner ID: " + drOwner["OwnerID"].ToString() + "\n" + "Name: " + drOwner["OwnerLastName"] +
               ", " + drOwner["OwnerFirstName"] + "\n" + "Street Address: " + drOwner["OwnerStreetAddress"] + "\t\t" + "Suburb: " + drOwner["OwnerSuburb"] +
               "\n" + "City: " + drOwner["OwnerCity"] + "\n" + "NZRA Membership: " + drOwner["NZRAMembership"] + "\n\n" + "Horses: "
               , textFont, brush, leftMargin, topMarginOwner);


            DataRow[] drHorses = drOwner.GetChildRows(DC.dtOwner.ChildRelations["OWNERS_HORSES"]);
            if (drHorses.Length == 0)
            {
                linesSoFar++;
                linesSoFar++;
                linesSoFar++;
                linesSoFar++;
                linesSoFar++;
                linesSoFar++;
                linesSoFar++;
                linesSoFar++;
                g.DrawString("This owner has no horses", textFont, brush, leftMargin, topMarginHorse +
                        (linesSoFar * textFont.Height));

                amountOfOwnersPrinted++;
                if (!(amountOfOwnersPrinted == pagesAmountExpected))
                {
                    e.HasMorePages = true;
                }
            }
            else
            {
                foreach (DataRow draHorse in drHorses)
                {

                    linesSoFar++;
                    linesSoFar++;
                    linesSoFar++;
                    linesSoFar++;
                    linesSoFar++;
                    string horseText = "";
                    int aHorseID = Convert.ToInt32(draHorse["HorseID"].ToString());
                    cmHorses.Position = DC.horseView.Find(aHorseID);
                    DataRow drHorse = DC.dtHorse.Rows[cmHorses.Position];
                    horseText = "Horse ID: " + drHorse["HorseID"] + "\n" + "Name: " + "Status: " + drHorse["HorseName"];

                    linesSoFar++;
                    linesSoFar++;
                    g.DrawString(horseText, textFont, brush, leftMargin, topMarginHorse +
                        (linesSoFar * textFont.Height));                                






                }
                amountOfOwnersPrinted++;
                if (!(amountOfOwnersPrinted == pagesAmountExpected))
                {
                    e.HasMorePages = true;
                }


            }
        }
    }
}
