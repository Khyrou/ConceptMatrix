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
    /// Interaction logic for EquipmentPropertiesPage.xaml
    /// </summary>
    public partial class EquipmentPropertiesPage : UserControl
    {
        public EquipmentPropertiesPage()
        {
            InitializeComponent();
        }

        private void ZeroMain_Click(object sender, RoutedEventArgs e)
        {
            ((FloatAddress)BaseModel.AddressList["WeaponX"]).WriteMemory((float)0);
            ((FloatAddress)BaseModel.AddressList["WeaponY"]).WriteMemory((float)0);
            ((FloatAddress)BaseModel.AddressList["WeaponZ"]).WriteMemory((float)0);
        }

        private void ZeroOff_Click(object sender, RoutedEventArgs e)
        {
            ((FloatAddress)BaseModel.AddressList["OffhandX"]).WriteMemory((float)0);
            ((FloatAddress)BaseModel.AddressList["OffhandY"]).WriteMemory((float)0);
            ((FloatAddress)BaseModel.AddressList["OffhandZ"]).WriteMemory((float)0);
        }

        private void DefaultMain_Click(object sender, RoutedEventArgs e)
        {
            ((FloatAddress)BaseModel.AddressList["WeaponX"]).WriteMemory((float)1);
            ((FloatAddress)BaseModel.AddressList["WeaponY"]).WriteMemory((float)1);
            ((FloatAddress)BaseModel.AddressList["WeaponZ"]).WriteMemory((float)1);
        }

        private void DefaultSub_Click(object sender, RoutedEventArgs e)
        {
            ((FloatAddress)BaseModel.AddressList["OffhandX"]).WriteMemory((float)1);
            ((FloatAddress)BaseModel.AddressList["OffhandY"]).WriteMemory((float)1);
            ((FloatAddress)BaseModel.AddressList["OffhandZ"]).WriteMemory((float)1);
        }
    }
}
