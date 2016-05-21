namespace IAApplication.UIForms
{
    partial class IAApplicationView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.implementaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kMeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somKohoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.implementaçõesToolStripMenuItem,
            this.normalizaçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // implementaçõesToolStripMenuItem
            // 
            this.implementaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kMeansToolStripMenuItem,
            this.somKohoToolStripMenuItem});
            this.implementaçõesToolStripMenuItem.Name = "implementaçõesToolStripMenuItem";
            this.implementaçõesToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.implementaçõesToolStripMenuItem.Text = "Implementações";
            // 
            // kMeansToolStripMenuItem
            // 
            this.kMeansToolStripMenuItem.Name = "kMeansToolStripMenuItem";
            this.kMeansToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.kMeansToolStripMenuItem.Text = "KMeans";
            // 
            // somKohoToolStripMenuItem
            // 
            this.somKohoToolStripMenuItem.Name = "somKohoToolStripMenuItem";
            this.somKohoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.somKohoToolStripMenuItem.Text = "SOM/Kohonen";
            // 
            // normalizaçãoToolStripMenuItem
            // 
            this.normalizaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minMaxToolStripMenuItem});
            this.normalizaçãoToolStripMenuItem.Name = "normalizaçãoToolStripMenuItem";
            this.normalizaçãoToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.normalizaçãoToolStripMenuItem.Text = "Normalização";
            // 
            // minMaxToolStripMenuItem
            // 
            this.minMaxToolStripMenuItem.Name = "minMaxToolStripMenuItem";
            this.minMaxToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.minMaxToolStripMenuItem.Text = "Min-Max";
            this.minMaxToolStripMenuItem.Click += new System.EventHandler(this.minMaxToolStripMenuItem_Click);
            // 
            // IAApplicationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IAApplicationView";
            this.Text = "IAApplication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem implementaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kMeansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem somKohoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minMaxToolStripMenuItem;
    }
}

