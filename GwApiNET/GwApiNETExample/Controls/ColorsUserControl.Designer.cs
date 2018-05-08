namespace GwApiNETExample.Controls
{
    partial class ColorsUserControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.checkBoxForceUpdate = new System.Windows.Forms.CheckBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cloth = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Leather = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Metal = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Cloth,
            this.Leather,
            this.Metal});
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(526, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(3, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // checkBoxForceUpdate
            // 
            this.checkBoxForceUpdate.AutoSize = true;
            this.checkBoxForceUpdate.Location = new System.Drawing.Point(84, 7);
            this.checkBoxForceUpdate.Name = "checkBoxForceUpdate";
            this.checkBoxForceUpdate.Size = new System.Drawing.Size(90, 17);
            this.checkBoxForceUpdate.TabIndex = 2;
            this.checkBoxForceUpdate.Text = "Ignore Cache";
            this.checkBoxForceUpdate.UseVisualStyleBackColor = true;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.FillWeight = 5F;
            this.Id.HeaderText = "ID:Name";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Id.Width = 74;
            // 
            // Cloth
            // 
            this.Cloth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cloth.FillWeight = 30F;
            this.Cloth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cloth.HeaderText = "Cloth";
            this.Cloth.Name = "Cloth";
            this.Cloth.ReadOnly = true;
            this.Cloth.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Leather
            // 
            this.Leather.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Leather.FillWeight = 30F;
            this.Leather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Leather.HeaderText = "Leather";
            this.Leather.Name = "Leather";
            this.Leather.ReadOnly = true;
            this.Leather.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Metal
            // 
            this.Metal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Metal.FillWeight = 30F;
            this.Metal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Metal.HeaderText = "Metal";
            this.Metal.Name = "Metal";
            this.Metal.ReadOnly = true;
            this.Metal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColorsUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxForceUpdate);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ColorsUserControl1";
            this.Size = new System.Drawing.Size(526, 403);
            this.Load += new System.EventHandler(this.ColorsUserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.CheckBox checkBoxForceUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewButtonColumn Cloth;
        private System.Windows.Forms.DataGridViewButtonColumn Leather;
        private System.Windows.Forms.DataGridViewButtonColumn Metal;

    }
}
