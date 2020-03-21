using MaterialDesignExtensions.Controls;
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

namespace ConceptMatrix.Windows
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : MaterialWindow
    {
        public string Choice = "";

        public LoadWindow()
        {
            InitializeComponent();
        }

        private void LoadAll_Click(object sender, RoutedEventArgs e)
        {
            Choice = "All";
            Close();
        }

        private void LoadApp_Click(object sender, RoutedEventArgs e)
        {
            Choice = "Appearance";
            Close();
        }

        private void LoadEquip_Click(object sender, RoutedEventArgs e)
        {
            Choice = "Equipment";
            Close();
        }

        private void LoadDat_Click(object sender, RoutedEventArgs e)
        {
            Choice = "DatLoad";
            Close();
        }
    }
}
