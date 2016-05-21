using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IAApplication.Ui.ViewModels;

namespace IAApplication.Ui.Views
{
    /// <summary>
    /// Interaction logic for NormalizacaoView.xaml
    /// </summary>
    public partial class NormalizacaoView : Window
    {
        public NormalizacaoViewModel viewModel;
        public NormalizacaoView()
        {
            InitializeComponent();
        }

        private void btnSelectBase_Click(object sender, RoutedEventArgs e)
        {
            // Cria o OpenFileDialog
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //Exibi a janela para busca de arquivos
            bool? dialogResult = openFileDialog.ShowDialog();
            // Verifica se um arquivo foi selecionado
            if (dialogResult == true)
            {
                // Retorna o path do arquivo selecionado para a variavel CaminhoDoArquivo
                viewModel.PathBase = openFileDialog.FileName;
            }
        }
    }
}
