namespace GwApiNETExample.Controls
{
    partial class GwMapUserControl
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
            this.checkBoxShowGridLines = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // checkBoxShowGridLines
            // 
            this.checkBoxShowGridLines.AutoSize = true;
            this.checkBoxShowGridLines.Location = new System.Drawing.Point(3, 3);
            this.checkBoxShowGridLines.Name = "checkBoxShowGridLines";
            this.checkBoxShowGridLines.Size = new System.Drawing.Size(103, 17);
            this.checkBoxShowGridLines.TabIndex = 0;
            this.checkBoxShowGridLines.Text = "Show Grid Lines";
            this.checkBoxShowGridLines.UseVisualStyleBackColor = true;
            this.checkBoxShowGridLines.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 392);
            this.panel1.TabIndex = 2;
            // 
            // GwMapUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxShowGridLines);
            this.Name = "GwMapUserControl";
            this.Size = new System.Drawing.Size(540, 421);
            this.Load += new System.EventHandler(this.GwMapUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxShowGridLines;
        private System.Windows.Forms.Panel panel1;
    }
}
