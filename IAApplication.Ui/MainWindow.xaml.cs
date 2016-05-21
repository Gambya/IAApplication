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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IAApplication.Helpers;
using IAApplication.Ui.Views;

namespace IAApplication.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string pathBase = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuNormalizationClick(object sender, RoutedEventArgs e)
        {
            var normalizeView = new NormalizacaoView();
            normalizeView.Show();
        }
    }
}
