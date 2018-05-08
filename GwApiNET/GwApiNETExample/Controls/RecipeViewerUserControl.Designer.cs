namespace GwApiNETExample.Controls
{
    partial class RecipeViewerUserControl
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
            this.recipeDetailsUserControl1 = new GwApiNETExample.Controls.RecipeDetailsUserControl();
            this.recipeSearchUserControl1 = new GwApiNETExample.Controls.RecipeSearchUserControl();
            this.SuspendLayout();
            // 
            // recipeDetailsUserControl1
            // 
            this.recipeDetailsUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipeDetailsUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.recipeDetailsUserControl1.Location = new System.Drawing.Point(3, 3);
            this.recipeDetailsUserControl1.Name = "recipeDetailsUserControl1";
            this.recipeDetailsUserControl1.Size = new System.Drawing.Size(376, 418);
            this.recipeDetailsUserControl1.TabIndex = 0;
            // 
            // recipeSearchUserControl1
            // 
            this.recipeSearchUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipeSearchUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.recipeSearchUserControl1.Location = new System.Drawing.Point(385, 3);
            this.recipeSearchUserControl1.Name = "recipeSearchUserControl1";
            this.recipeSearchUserControl1.Size = new System.Drawing.Size(286, 418);
            this.recipeSearchUserControl1.TabIndex = 1;
            // 
            // RecipeViewerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recipeSearchUserControl1);
            this.Controls.Add(this.recipeDetailsUserControl1);
            this.Name = "RecipeViewerUserControl";
            this.Size = new System.Drawing.Size(671, 424);
            this.ResumeLayout(false);

        }

        #endregion

        private RecipeDetailsUserControl recipeDetailsUserControl1;
        private RecipeSearchUserControl recipeSearchUserControl1;
    }
}
