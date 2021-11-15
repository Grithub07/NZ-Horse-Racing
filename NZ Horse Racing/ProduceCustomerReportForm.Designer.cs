
namespace NZ_Horse_Racing
{
    partial class ProduceCustomerReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProduceCustomerReportForm));
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.prntCustomers = new System.Drawing.Printing.PrintDocument();
            this.prvCustomers = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(259, 43);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(157, 63);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(39, 43);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(157, 63);
            this.btnPrintReport.TabIndex = 2;
            this.btnPrintReport.Text = "Generate Customers Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // prntCustomers
            // 
            this.prntCustomers.DocumentName = "Report";
            this.prntCustomers.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prntCustomers_PrintPage);
            // 
            // prvCustomers
            // 
            this.prvCustomers.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prvCustomers.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prvCustomers.ClientSize = new System.Drawing.Size(400, 300);
            this.prvCustomers.Document = this.prntCustomers;
            this.prvCustomers.Enabled = true;
            this.prvCustomers.Icon = ((System.Drawing.Icon)(resources.GetObject("prvCustomers.Icon")));
            this.prvCustomers.Name = "prvCustomers";
            this.prvCustomers.Visible = false;
            // 
            // ProduceCustomerReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 149);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnReturn);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProduceCustomerReportForm";
            this.Text = "Produce Customer Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Drawing.Printing.PrintDocument prntCustomers;
        private System.Windows.Forms.PrintPreviewDialog prvCustomers;
    }
}