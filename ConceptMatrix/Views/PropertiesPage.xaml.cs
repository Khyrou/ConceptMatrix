using ConceptMatrix.Backend;
using ConceptMatrix.Models;
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

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for PropertiesPage.xaml
    /// </summary>
    public partial class PropertiesPage : UserControl
    {
        public static PropertiesPage Page;
        public PropertiesPage()
        {
            InitializeComponent();
            Page = this;
        }

        private void WetButton_Checked(object sender, RoutedEventArgs e)
        {
            ((FloatAddress)BaseModel.AddressList["Wetness"]).WriteMemory(2f);
        }

        private void DrenchedButton_Checked(object sender, RoutedEventArgs e)
        {
            ((FloatAddress)BaseModel.AddressList["Drenched"]).WriteMemory(6f);
        }
    }
}
