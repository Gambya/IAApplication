namespace IAApplication.UIForms.Views
{
    partial class KMeansView
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.confirmaCentroide = new System.Windows.Forms.Button();
            this.cancelarCentroide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Posição X Cemtróides";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Posição Y Cemtróides";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(194, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(157, 20);
            this.textBox2.TabIndex = 4;
            // 
            // confirmaCentroide
            // 
            this.confirmaCentroide.Location = new System.Drawing.Point(194, 57);
            this.confirmaCentroide.Name = "confirmaCentroide";
            this.confirmaCentroide.Size = new System.Drawing.Size(157, 23);
            this.confirmaCentroide.TabIndex = 6;
            this.confirmaCentroide.Text = "Confirmar Centróides";
            this.confirmaCentroide.UseVisualStyleBackColor = true;
            this.confirmaCentroide.Click += new System.EventHandler(this.confirmaCentroide_Click);
            // 
            // cancelarCentroide
            // 
            this.cancelarCentroide.Location = new System.Drawing.Point(12, 57);
            this.cancelarCentroide.Name = "cancelarCentroide";
            this.cancelarCentroide.Size = new System.Drawing.Size(157, 23);
            this.cancelarCentroide.TabIndex = 7;
            this.cancelarCentroide.Text = "Cancelar";
            this.cancelarCentroide.UseVisualStyleBackColor = true;
            this.cancelarCentroide.Click += new System.EventHandler(this.cancelarCentroide_Click);
            // 
            // KMeansView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 91);
            this.Controls.Add(this.cancelarCentroide);
            this.Controls.Add(this.confirmaCentroide);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KMeansView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Centroide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button confirmaCentroide;
        private System.Windows.Forms.Button cancelarCentroide;
    }
}