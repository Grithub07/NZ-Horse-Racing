
namespace NZ_Horse_Racing
{
    partial class DeleteOwnerForm
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDeleteOwner = new System.Windows.Forms.Button();
            this.txtOwnerID = new System.Windows.Forms.TextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblOwnerID = new System.Windows.Forms.Label();
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblSuburb = new System.Windows.Forms.Label();
            this.lblStreetAddress = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lstOwners = new System.Windows.Forms.ListBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtNZRAMembs = new System.Windows.Forms.TextBox();
            this.lblMemb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(591, 397);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(166, 73);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDeleteOwner
            // 
            this.btnDeleteOwner.Location = new System.Drawing.Point(315, 397);
            this.btnDeleteOwner.Name = "btnDeleteOwner";
            this.btnDeleteOwner.Size = new System.Drawing.Size(166, 73);
            this.btnDeleteOwner.TabIndex = 42;
            this.btnDeleteOwner.Text = "Delete Owner";
            this.btnDeleteOwner.UseVisualStyleBackColor = true;
            this.btnDeleteOwner.Click += new System.EventHandler(this.btnDeleteOwner_Click);
            // 
            // txtOwnerID
            // 
            this.txtOwnerID.Enabled = false;
            this.txtOwnerID.Location = new System.Drawing.Point(436, 87);
            this.txtOwnerID.MaxLength = 40;
            this.txtOwnerID.Name = "txtOwnerID";
            this.txtOwnerID.Size = new System.Drawing.Size(88, 27);
            this.txtOwnerID.TabIndex = 41;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Calibri", 36F);
            this.lblHeading.Location = new System.Drawing.Point(229, 13);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(296, 59);
            this.lblHeading.TabIndex = 40;
            this.lblHeading.Text = "Delete Owner";
            // 
            // lblOwnerID
            // 
            this.lblOwnerID.AutoSize = true;
            this.lblOwnerID.Location = new System.Drawing.Point(361, 90);
            this.lblOwnerID.Name = "lblOwnerID";
            this.lblOwnerID.Size = new System.Drawing.Size(74, 19);
            this.lblOwnerID.TabIndex = 39;
            this.lblOwnerID.Text = "Owner ID:";
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.Enabled = false;
            this.txtStreetAddress.Location = new System.Drawing.Point(436, 216);
            this.txtStreetAddress.MaxLength = 30;
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(260, 27);
            this.txtStreetAddress.TabIndex = 38;
            // 
            // txtSuburb
            // 
            this.txtSuburb.Enabled = false;
            this.txtSuburb.Location = new System.Drawing.Point(436, 259);
            this.txtSuburb.MaxLength = 11;
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(133, 27);
            this.txtSuburb.TabIndex = 37;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Location = new System.Drawing.Point(436, 173);
            this.txtFirstName.MaxLength = 40;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(203, 27);
            this.txtFirstName.TabIndex = 36;
            // 
            // txtLastName
            // 
            this.txtLastName.Enabled = false;
            this.txtLastName.Location = new System.Drawing.Point(436, 130);
            this.txtLastName.MaxLength = 40;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(203, 27);
            this.txtLastName.TabIndex = 35;
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(378, 262);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(57, 19);
            this.lblSuburb.TabIndex = 34;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblStreetAddress
            // 
            this.lblStreetAddress.AutoSize = true;
            this.lblStreetAddress.Location = new System.Drawing.Point(328, 219);
            this.lblStreetAddress.Name = "lblStreetAddress";
            this.lblStreetAddress.Size = new System.Drawing.Size(107, 19);
            this.lblStreetAddress.TabIndex = 33;
            this.lblStreetAddress.Text = "Street Address:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(352, 176);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(83, 19);
            this.lblFirstName.TabIndex = 32;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(353, 133);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(82, 19);
            this.lblLastName.TabIndex = 31;
            this.lblLastName.Text = "Last Name:";
            // 
            // lstOwners
            // 
            this.lstOwners.FormattingEnabled = true;
            this.lstOwners.ItemHeight = 19;
            this.lstOwners.Location = new System.Drawing.Point(13, 93);
            this.lstOwners.Name = "lstOwners";
            this.lstOwners.Size = new System.Drawing.Size(281, 327);
            this.lstOwners.TabIndex = 30;
            this.lstOwners.SelectedIndexChanged += new System.EventHandler(this.lstOwners_SelectedIndexChanged);
            // 
            // txtCity
            // 
            this.txtCity.Enabled = false;
            this.txtCity.Location = new System.Drawing.Point(436, 302);
            this.txtCity.MaxLength = 11;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(157, 27);
            this.txtCity.TabIndex = 44;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(397, 305);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(38, 19);
            this.lblCity.TabIndex = 43;
            this.lblCity.Text = "City:";
            // 
            // txtNZRAMembs
            // 
            this.txtNZRAMembs.Enabled = false;
            this.txtNZRAMembs.Location = new System.Drawing.Point(436, 345);
            this.txtNZRAMembs.MaxLength = 11;
            this.txtNZRAMembs.Name = "txtNZRAMembs";
            this.txtNZRAMembs.Size = new System.Drawing.Size(68, 27);
            this.txtNZRAMembs.TabIndex = 46;
            // 
            // lblMemb
            // 
            this.lblMemb.AutoSize = true;
            this.lblMemb.Location = new System.Drawing.Point(301, 348);
            this.lblMemb.Name = "lblMemb";
            this.lblMemb.Size = new System.Drawing.Size(134, 19);
            this.lblMemb.TabIndex = 45;
            this.lblMemb.Text = "NZRA Membership:";
            // 
            // DeleteOwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 482);
            this.Controls.Add(this.txtNZRAMembs);
            this.Controls.Add(this.lblMemb);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.btnDeleteOwner);
            this.Controls.Add(this.txtOwnerID);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.lblOwnerID);
            this.Controls.Add(this.txtStreetAddress);
            this.Controls.Add(this.txtSuburb);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblSuburb);
            this.Controls.Add(this.lblStreetAddress);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lstOwners);
            this.Controls.Add(this.btnReturn);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DeleteOwnerForm";
            this.Text = "Delete Owner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnDeleteOwner;
        private System.Windows.Forms.TextBox txtOwnerID;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblOwnerID;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblSuburb;
        private System.Windows.Forms.Label lblStreetAddress;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.ListBox lstOwners;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtNZRAMembs;
        private System.Windows.Forms.Label lblMemb;
    }
}