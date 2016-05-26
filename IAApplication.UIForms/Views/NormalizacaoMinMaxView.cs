using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAApplication.UIForms.Views
{
    public partial class NormalizacaoMinMaxView : Form
    {
        public string PathBase { get; set; }
        private IAApplicationView main;
        public NormalizacaoMinMaxView(IAApplicationView main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            // Cria o OpenFileDialog
            var openFileDialog = new OpenFileDialog();
            //Exibi a janela para busca de arquivos
            openFileDialog.ShowDialog();
            // Retorna o path do arquivo selecionado para a variavel CaminhoDoArquivo
            txtPath.Text = openFileDialog.FileName;
            
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            main.PathBase = txtPath.Text;
            main.PosicaoClasse = Convert.ToInt32(txtClasse.Text);
            main.NormalizarBase();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtPath.Text = string.Empty;
            this.Close();
        }
    }
}
