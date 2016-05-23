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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.implementaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kMeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarCentróidesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rodarKMeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somKohoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chPoints = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chPoints)).BeginInit();
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
            this.kMeansToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarCentróidesToolStripMenuItem,
            this.rodarKMeansToolStripMenuItem});
            this.kMeansToolStripMenuItem.Name = "kMeansToolStripMenuItem";
            this.kMeansToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.kMeansToolStripMenuItem.Text = "KMeans";
            // 
            // cadastrarCentróidesToolStripMenuItem
            // 
            this.cadastrarCentróidesToolStripMenuItem.Name = "cadastrarCentróidesToolStripMenuItem";
            this.cadastrarCentróidesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.cadastrarCentróidesToolStripMenuItem.Text = "Cadastrar Centróides";
            this.cadastrarCentróidesToolStripMenuItem.Click += new System.EventHandler(this.cadastrarCentróidesToolStripMenuItem_Click);
            // 
            // rodarKMeansToolStripMenuItem
            // 
            this.rodarKMeansToolStripMenuItem.Name = "rodarKMeansToolStripMenuItem";
            this.rodarKMeansToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.rodarKMeansToolStripMenuItem.Text = "Selecionar Base";
            this.rodarKMeansToolStripMenuItem.Click += new System.EventHandler(this.rodarKMeansToolStripMenuItem_Click);
            // 
            // somKohoToolStripMenuItem
            // 
            this.somKohoToolStripMenuItem.Name = "somKohoToolStripMenuItem";
            this.somKohoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.somKohoToolStripMenuItem.Text = "SOM/Kohonen";
            this.somKohoToolStripMenuItem.Click += new System.EventHandler(this.somKohoToolStripMenuItem_Click);
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
            this.minMaxToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.minMaxToolStripMenuItem.Text = "Min-Max";
            this.minMaxToolStripMenuItem.Click += new System.EventHandler(this.minMaxToolStripMenuItem_Click);
            // 
            // chPoints
            // 
            this.chPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chPoints.BackColor = System.Drawing.Color.DimGray;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chPoints.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chPoints.Legends.Add(legend1);
            this.chPoints.Location = new System.Drawing.Point(0, 27);
            this.chPoints.Name = "chPoints";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chPoints.Series.Add(series1);
            this.chPoints.Size = new System.Drawing.Size(784, 509);
            this.chPoints.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // IAApplicationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chPoints);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IAApplicationView";
            this.Text = "IAApplication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chPoints)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chPoints;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarCentróidesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rodarKMeansToolStripMenuItem;
    }
}

