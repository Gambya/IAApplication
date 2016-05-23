using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAApplication.Domain.Entities;

namespace IAApplication.UIForms.Views
{
    public partial class KMeansView : Form
    {
        private IAApplicationView main;
        public KMeansView(IAApplicationView main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void confirmaCentroide_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(this, @"Será necessário preenchimento das posições dos centróides", @"Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            main.BaseCentroides.Add(new Centroide(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)));
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void cancelarCentroide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
