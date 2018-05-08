namespace GwApiNETExample.Controls
{
    partial class RecipeSearchUserControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDownloadCount = new System.Windows.Forms.Label();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.buttonUpdateRecipes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxIdList = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SearchResultsBox = new System.Windows.Forms.ListBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelTotalRecipes = new System.Windows.Forms.Label();
            this.labelSearchCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelTime);
            this.groupBox1.Controls.Add(this.labelDownloadCount);
            this.groupBox1.Controls.Add(this.progressBarDownload);
            this.groupBox1.Controls.Add(this.buttonUpdateRecipes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComboBoxIdList);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Downloading";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(164, 73);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(66, 13);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "1000.000 (s)";
            // 
            // labelDownloadCount
            // 
            this.labelDownloadCount.AutoSize = true;
            this.labelDownloadCount.Location = new System.Drawing.Point(164, 51);
            this.labelDownloadCount.Name = "labelDownloadCount";
            this.labelDownloadCount.Size = new System.Drawing.Size(72, 13);
            this.labelDownloadCount.TabIndex = 4;
            this.labelDownloadCount.Text = "30000/30000";
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(164, 19);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(100, 23);
            this.progressBarDownload.TabIndex = 3;
            // 
            // buttonUpdateRecipes
            // 
            this.buttonUpdateRecipes.Location = new System.Drawing.Point(33, 46);
            this.buttonUpdateRecipes.Name = "buttonUpdateRecipes";
            this.buttonUpdateRecipes.Size = new System.Drawing.Size(125, 23);
            this.buttonUpdateRecipes.TabIndex = 2;
            this.buttonUpdateRecipes.Text = "Update Recipes";
            this.buttonUpdateRecipes.UseVisualStyleBackColor = true;
            this.buttonUpdateRecipes.Click += new System.EventHandler(this.buttonUpdateRecipes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // ComboBoxIdList
            // 
            this.ComboBoxIdList.FormattingEnabled = true;
            this.ComboBoxIdList.Location = new System.Drawing.Point(33, 19);
            this.ComboBoxIdList.Name = "ComboBoxIdList";
            this.ComboBoxIdList.Size = new System.Drawing.Size(125, 21);
            this.ComboBoxIdList.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelSearchCount);
            this.groupBox2.Controls.Add(this.SearchResultsBox);
            this.groupBox2.Controls.Add(this.buttonSearch);
            this.groupBox2.Controls.Add(this.textBoxSearch);
            this.groupBox2.Controls.Add(this.labelTotalRecipes);
            this.groupBox2.Location = new System.Drawing.Point(3, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 270);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // SearchResultsBox
            // 
            this.SearchResultsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchResultsBox.FormattingEnabled = true;
            this.SearchResultsBox.Location = new System.Drawing.Point(6, 65);
            this.SearchResultsBox.Name = "SearchResultsBox";
            this.SearchResultsBox.Size = new System.Drawing.Size(269, 173);
            this.SearchResultsBox.TabIndex = 3;
            this.SearchResultsBox.SelectedIndexChanged += new System.EventHandler(this.SearchResults_SelectedIndexChanged);
            this.SearchResultsBox.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(148, 30);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(6, 32);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(136, 20);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Text = "Not Implemented";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.buttonSearch_Click);
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // labelTotalRecipes
            // 
            this.labelTotalRecipes.AutoSize = true;
            this.labelTotalRecipes.Location = new System.Drawing.Point(6, 16);
            this.labelTotalRecipes.Name = "labelTotalRecipes";
            this.labelTotalRecipes.Size = new System.Drawing.Size(85, 13);
            this.labelTotalRecipes.TabIndex = 0;
            this.labelTotalRecipes.Text = "Known Recipes:";
            // 
            // labelSearchCount
            // 
            this.labelSearchCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelSearchCount.AutoSize = true;
            this.labelSearchCount.Location = new System.Drawing.Point(3, 248);
            this.labelSearchCount.Name = "labelSearchCount";
            this.labelSearchCount.Size = new System.Drawing.Size(45, 13);
            this.labelSearchCount.TabIndex = 4;
            this.labelSearchCount.Text = "Results:";
            // 
            // RecipeSearchUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecipeSearchUserControl";
            this.Size = new System.Drawing.Size(287, 383);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDownloadCount;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.Button buttonUpdateRecipes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelTotalRecipes;
        private System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.ComboBox ComboBoxIdList;
        public System.Windows.Forms.ListBox SearchResultsBox;
        private System.Windows.Forms.Label labelSearchCount;
    }
}
