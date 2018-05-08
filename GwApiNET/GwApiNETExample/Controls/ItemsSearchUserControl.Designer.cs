namespace GwApiNETExample.Controls
{
    partial class ItemsSearchUserControl
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
            this.labelItemCount = new System.Windows.Forms.Label();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.labelPercent = new System.Windows.Forms.Label();
            this.progressBarItemDownload = new System.Windows.Forms.ProgressBar();
            this.buttonDownloadItems = new System.Windows.Forms.Button();
            this.buttonRefreshIds = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxItemIds = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.labelPercent);
            this.groupBox1.Controls.Add(this.progressBarItemDownload);
            this.groupBox1.Controls.Add(this.buttonDownloadItems);
            this.groupBox1.Controls.Add(this.buttonRefreshIds);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxItemIds);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Retrival";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelItemCount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSeconds, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(83, 39);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // labelItemCount
            // 
            this.labelItemCount.AutoSize = true;
            this.labelItemCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelItemCount.Location = new System.Drawing.Point(3, 19);
            this.labelItemCount.Name = "labelItemCount";
            this.labelItemCount.Size = new System.Drawing.Size(77, 20);
            this.labelItemCount.TabIndex = 6;
            this.labelItemCount.Text = "20000/20000";
            this.labelItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelItemCount.Visible = false;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSeconds.Location = new System.Drawing.Point(3, 0);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(77, 19);
            this.labelSeconds.TabIndex = 5;
            this.labelSeconds.Text = "1000s";
            this.labelSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSeconds.Visible = false;
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(234, 72);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(33, 13);
            this.labelPercent.TabIndex = 2;
            this.labelPercent.Text = "100%";
            this.labelPercent.Visible = false;
            // 
            // progressBarItemDownload
            // 
            this.progressBarItemDownload.Location = new System.Drawing.Point(213, 46);
            this.progressBarItemDownload.Name = "progressBarItemDownload";
            this.progressBarItemDownload.Size = new System.Drawing.Size(75, 23);
            this.progressBarItemDownload.TabIndex = 4;
            this.progressBarItemDownload.Visible = false;
            // 
            // buttonDownloadItems
            // 
            this.buttonDownloadItems.Location = new System.Drawing.Point(89, 46);
            this.buttonDownloadItems.Name = "buttonDownloadItems";
            this.buttonDownloadItems.Size = new System.Drawing.Size(118, 23);
            this.buttonDownloadItems.TabIndex = 3;
            this.buttonDownloadItems.Text = "Download All";
            this.buttonDownloadItems.UseVisualStyleBackColor = true;
            this.buttonDownloadItems.Click += new System.EventHandler(this.buttonDownloadItems_Click);
            // 
            // buttonRefreshIds
            // 
            this.buttonRefreshIds.Location = new System.Drawing.Point(213, 17);
            this.buttonRefreshIds.Name = "buttonRefreshIds";
            this.buttonRefreshIds.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshIds.TabIndex = 2;
            this.buttonRefreshIds.Text = "Refresh IDs";
            this.buttonRefreshIds.UseVisualStyleBackColor = true;
            this.buttonRefreshIds.Click += new System.EventHandler(this.buttonRefreshIds_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item ID List:";
            // 
            // comboBoxItemIds
            // 
            this.comboBoxItemIds.FormattingEnabled = true;
            this.comboBoxItemIds.Location = new System.Drawing.Point(89, 19);
            this.comboBoxItemIds.Name = "comboBoxItemIds";
            this.comboBoxItemIds.Size = new System.Drawing.Size(118, 21);
            this.comboBoxItemIds.TabIndex = 0;
            this.comboBoxItemIds.SelectedIndexChanged += new System.EventHandler(this.comboBoxItemIds_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonSearch);
            this.groupBox2.Controls.Add(this.textBoxSearch);
            this.groupBox2.Location = new System.Drawing.Point(3, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item Search";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(237, 17);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(6, 19);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(225, 20);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // ItemsSearchUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemsSearchUserControl";
            this.Size = new System.Drawing.Size(326, 334);
            this.Load += new System.EventHandler(this.ItemsSearchUserControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBarItemDownload;
        private System.Windows.Forms.Button buttonDownloadItems;
        private System.Windows.Forms.Button buttonRefreshIds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxItemIds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelItemCount;
    }
}
