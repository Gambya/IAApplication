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
using IAApplication.UIForms.Views;
using IAApplication.Helpers;

namespace IAApplication.UIForms
{
    public partial class IAApplicationView : Form
    {
        public string PathBase { get; set; }
        public IAApplicationView()
        {
            InitializeComponent();
        }

        private void minMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var normaMinMaxView = new NormalizacaoMinMaxView(this);
            normaMinMaxView.Show();
        }
        #region "Normalização"
        public void NormalizarBase()
        {
            var strBuilderDado = new StringBuilder();
            var listaDados = new List<double>();
            if (!File.Exists(PathBase)) return;
            using (var stream = new StreamReader(PathBase))
            {
                var strFile = Regex.Replace(stream.ReadToEnd(), Environment.NewLine, ",");
                listaDados.AddRange(strFile.Split(',').ToList().ConvertAll(new Converter<string, double>(ConvertToDouble)));
            }
            using (var stream = new StreamReader(PathBase))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var dados = line.Split(',').ToList().ConvertAll(new Converter<string,double>(ConvertToDouble));
                    foreach (var dado in dados)
                    {
                        strBuilderDado.Append($"{Normalization.NormalizeToMinMax(dado, listaDados)}".Replace(",","."));
                        strBuilderDado.Append(",");
                    }
                    strBuilderDado.Remove(strBuilderDado.Length - 1, 1);
                    strBuilderDado.AppendLine();
                }
                if (!SalvarArquivo(strBuilderDado))
                {
                    //informar na barra de status
                }
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
                var dialogResult = saveFileDialog.ShowDialog();
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

        private static double ConvertToDouble(string input)
        {
            if (Regex.IsMatch(input, @"^\."))
                input = input.Replace(".", "0,");
            input = input.Replace(".", ",");
            return Convert.ToDouble(input);
        }
        #endregion
    }
}
