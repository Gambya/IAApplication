using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAApplication.Domain.Services;
using IAApplication.UIForms.Views;
using IAApplication.Helpers;
using IAApplication.Infra.IA.Services;
using IAApplication.Domain.Entities;

namespace IAApplication.UIForms
{
    public partial class IAApplicationView : Form
    {
        public string PathBase { get; set; }
        public List<Centroide> BaseCentroides;
        public List<Objetos> BaseObjetos;
        public IAApplicationView()
        {
            InitializeComponent();
            BaseCentroides = new List<Centroide>();
            BaseObjetos = new List<Objetos>();
        }

        private void minMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var normaMinMaxView = new NormalizacaoMinMaxView(this);
            normaMinMaxView.Show();
        }

        #region "Normalização"
        public void NormalizarBase()
        {
            var strBuilderDado = Normalization.NormalizarBase(PathBase);
            if (!SalvarArquivo(strBuilderDado))
            {
                //informar na barra de status
            }
            MessageBox.Show(this, $"Base {PathBase} normalizada com MinMax.", @"Situação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool SalvarArquivo(StringBuilder strBuilderDado)
        {
            try
            {
                // Cria o OpenFileDialog
                var saveFileDialog = new SaveFileDialog();
                //Exibi a janela para busca de arquivos
                saveFileDialog.ShowDialog();
                // Retorna o path do arquivo selecionado para a variavel CaminhoDoArquivo
                PathBase = saveFileDialog.FileName;
                File.WriteAllText(PathBase, strBuilderDado.ToString());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Não foi possivel salvar base\n{ex.Message}", @"Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private void somKohoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #region "KMeans"
        private void cadastrarCentróidesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var kmeansView = new KMeansView(this);
            kmeansView.Show();
        }
        private void rodarKMeansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria o OpenFileDialog
            var openFileDialog = new OpenFileDialog();
            //Exibi a janela para busca de arquivos
            openFileDialog.ShowDialog();
            // Retorna o path do arquivo selecionado para a variavel CaminhoDoArquivo
            var baseDados = openFileDialog.FileName;
            IKMeanService kService = new KMeanService();
            BaseObjetos = kService.LerDados(baseDados);
            kService.KMeansRun(BaseObjetos, BaseCentroides);
        }
        #endregion
    }
}
