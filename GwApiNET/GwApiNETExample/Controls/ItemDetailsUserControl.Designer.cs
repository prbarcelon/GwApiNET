namespace GwApiNETExample.Controls
{
    partial class ItemDetailsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelRestrictions = new System.Windows.Forms.Label();
            this.labelRarity = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelVendorValue = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDetails = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.labelRestrictions, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelRarity, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelLevel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelDescription, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelVendorValue, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 376);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelRestrictions
            // 
            this.labelRestrictions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRestrictions.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelRestrictions, 4);
            this.labelRestrictions.Location = new System.Drawing.Point(109, 65);
            this.labelRestrictions.Name = "labelRestrictions";
            this.labelRestrictions.Size = new System.Drawing.Size(62, 13);
            this.labelRestrictions.TabIndex = 6;
            this.labelRestrictions.Text = "Restrictions";
            this.labelRestrictions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRarity
            // 
            this.labelRarity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRarity.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelRarity, 4);
            this.labelRarity.Location = new System.Drawing.Point(109, 13);
            this.labelRarity.Name = "labelRarity";
            this.labelRarity.Size = new System.Drawing.Size(34, 13);
            this.labelRarity.TabIndex = 5;
            this.labelRarity.Text = "Rarity";
            this.labelRarity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLevel
            // 
            this.labelLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLevel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelLevel, 4);
            this.labelLevel.Location = new System.Drawing.Point(109, 26);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(33, 13);
            this.labelLevel.TabIndex = 4;
            this.labelLevel.Text = "Level";
            this.labelLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDescription.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelDescription, 4);
            this.labelDescription.Location = new System.Drawing.Point(109, 39);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Description";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVendorValue
            // 
            this.labelVendorValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelVendorValue.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelVendorValue, 4);
            this.labelVendorValue.Location = new System.Drawing.Point(109, 52);
            this.labelVendorValue.Name = "labelVendorValue";
            this.labelVendorValue.Size = new System.Drawing.Size(71, 13);
            this.labelVendorValue.TabIndex = 2;
            this.labelVendorValue.Text = "Vendor Value";
            this.labelVendorValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 7);
            this.pictureBox1.Size = new System.Drawing.Size(100, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelName, 5);
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(394, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 4);
            this.groupBox2.Controls.Add(this.labelDetails);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(109, 81);
            this.groupBox2.Name = "groupBox2";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox2, 6);
            this.groupBox2.Size = new System.Drawing.Size(288, 292);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // labelDetails
            // 
            this.labelDetails.AutoSize = true;
            this.labelDetails.Location = new System.Drawing.Point(6, 16);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(39, 13);
            this.labelDetails.TabIndex = 0;
            this.labelDetails.Text = "Details";
            // 
            // ItemDetailsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemDetailsUserControl";
            this.Size = new System.Drawing.Size(406, 395);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelRestrictions;
        private System.Windows.Forms.Label labelRarity;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelVendorValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelDetails;
    }
}
