namespace GwApiNETExample.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.BuildLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPageGuildDetails = new System.Windows.Forms.TabPage();
            this.tabPageColors = new System.Windows.Forms.TabPage();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.tabPageRecipes = new System.Windows.Forms.TabPage();
            this.ToolTipMainForm = new System.Windows.Forms.ToolTip(this.components);
            this.itemDetailsUserControl1 = new GwApiNETExample.Controls.ItemDetailsUserControl();
            this.itemsSearchUserControl1 = new GwApiNETExample.Controls.ItemsSearchUserControl();
            this.guildDetailsUserControl1 = new GwApiNETExample.Controls.GuildDetailsUserControl();
            this.colorsUserControl1 = new GwApiNETExample.Controls.ColorsUserControl();
            this.recipeViewerUserControl1 = new GwApiNETExample.Controls.RecipeViewerUserControl();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageGuildDetails.SuspendLayout();
            this.tabPageColors.SuspendLayout();
            this.tabPageRecipes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.StatusLabel,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.BuildLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 477);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(774, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(35, 22);
            this.StatusLabel.Text = "Done";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel2.Text = "GW Build:";
            // 
            // BuildLabel
            // 
            this.BuildLabel.Name = "BuildLabel";
            this.BuildLabel.Size = new System.Drawing.Size(34, 22);
            this.BuildLabel.Text = "Build";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Location = new System.Drawing.Point(0, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(774, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageItems);
            this.tabControl1.Controls.Add(this.tabPageGuildDetails);
            this.tabControl1.Controls.Add(this.tabPageColors);
            this.tabControl1.Controls.Add(this.tabPageMap);
            this.tabControl1.Controls.Add(this.tabPageRecipes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 428);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.splitContainer1);
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems.Size = new System.Drawing.Size(766, 402);
            this.tabPageItems.TabIndex = 0;
            this.tabPageItems.Text = "Items";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.itemDetailsUserControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.itemsSearchUserControl1);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(760, 396);
            this.splitContainer1.SplitterDistance = 599;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabPageGuildDetails
            // 
            this.tabPageGuildDetails.BackColor = System.Drawing.Color.Transparent;
            this.tabPageGuildDetails.Controls.Add(this.guildDetailsUserControl1);
            this.tabPageGuildDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageGuildDetails.Name = "tabPageGuildDetails";
            this.tabPageGuildDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGuildDetails.Size = new System.Drawing.Size(766, 402);
            this.tabPageGuildDetails.TabIndex = 1;
            this.tabPageGuildDetails.Text = "Guild Details";
            // 
            // tabPageColors
            // 
            this.tabPageColors.AutoScroll = true;
            this.tabPageColors.Controls.Add(this.colorsUserControl1);
            this.tabPageColors.Location = new System.Drawing.Point(4, 22);
            this.tabPageColors.Name = "tabPageColors";
            this.tabPageColors.Size = new System.Drawing.Size(766, 402);
            this.tabPageColors.TabIndex = 2;
            this.tabPageColors.Text = "Colors";
            this.tabPageColors.UseVisualStyleBackColor = true;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Size = new System.Drawing.Size(766, 402);
            this.tabPageMap.TabIndex = 3;
            this.tabPageMap.Text = "Map";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // tabPageRecipes
            // 
            this.tabPageRecipes.Controls.Add(this.recipeViewerUserControl1);
            this.tabPageRecipes.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecipes.Name = "tabPageRecipes";
            this.tabPageRecipes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecipes.Size = new System.Drawing.Size(766, 402);
            this.tabPageRecipes.TabIndex = 4;
            this.tabPageRecipes.Text = "Recipes";
            this.tabPageRecipes.UseVisualStyleBackColor = true;
            // 
            // itemDetailsUserControl1
            // 
            this.itemDetailsUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemDetailsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDetailsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.itemDetailsUserControl1.Name = "itemDetailsUserControl1";
            this.itemDetailsUserControl1.Size = new System.Drawing.Size(599, 396);
            this.itemDetailsUserControl1.TabIndex = 0;
            // 
            // itemsSearchUserControl1
            // 
            this.itemsSearchUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemsSearchUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsSearchUserControl1.Location = new System.Drawing.Point(0, 0);
            this.itemsSearchUserControl1.Name = "itemsSearchUserControl1";
            this.itemsSearchUserControl1.Size = new System.Drawing.Size(153, 396);
            this.itemsSearchUserControl1.TabIndex = 0;
            // 
            // guildDetailsUserControl1
            // 
            this.guildDetailsUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.guildDetailsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guildDetailsUserControl1.GuildNameSearch = "";
            this.guildDetailsUserControl1.Location = new System.Drawing.Point(3, 3);
            this.guildDetailsUserControl1.Name = "guildDetailsUserControl1";
            this.guildDetailsUserControl1.Size = new System.Drawing.Size(760, 396);
            this.guildDetailsUserControl1.TabIndex = 0;
            // 
            // colorsUserControl1
            // 
            this.colorsUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.colorsUserControl1.Name = "colorsUserControl1";
            this.colorsUserControl1.Size = new System.Drawing.Size(766, 402);
            this.colorsUserControl1.TabIndex = 0;
            // 
            // recipeViewerUserControl1
            // 
            this.recipeViewerUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.recipeViewerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeViewerUserControl1.Location = new System.Drawing.Point(3, 3);
            this.recipeViewerUserControl1.Name = "recipeViewerUserControl1";
            this.recipeViewerUserControl1.Size = new System.Drawing.Size(760, 396);
            this.recipeViewerUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 502);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "GwApi Example";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageItems.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPageGuildDetails.ResumeLayout(false);
            this.tabPageColors.ResumeLayout(false);
            this.tabPageRecipes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPageGuildDetails;
        private Controls.ItemsSearchUserControl itemsSearchUserControl1;
        private Controls.ItemDetailsUserControl itemDetailsUserControl1;
        private Controls.GuildDetailsUserControl guildDetailsUserControl1;
        private System.Windows.Forms.TabPage tabPageColors;
        private System.Windows.Forms.TabPage tabPageMap;
        public System.Windows.Forms.ToolTip ToolTipMainForm;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripLabel StatusLabel;
        private Controls.ColorsUserControl colorsUserControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel BuildLabel;
        private System.Windows.Forms.TabPage tabPageRecipes;
        private Controls.RecipeViewerUserControl recipeViewerUserControl1;
    }
}

