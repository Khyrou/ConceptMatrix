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
    /// Interaction logic for GposeFilterPage.xaml
    /// </summary>
    public partial class GposeFilterPage : UserControl
    {
        public GposeFilterPage()
        {
            InitializeComponent();
        }

        private void FilterEnable_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.GameProcess.Write(BaseModel.GposeFilterPointer + BaseModel.Offsets.GposeFilterEnable, Convert.ChangeType(0x40, TypeCode.Byte));
        }

        private void FilterEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            MainWindow.GameProcess.Write(BaseModel.GposeFilterPointer + BaseModel.Offsets.GposeFilterEnable, Convert.ChangeType(0x00, TypeCode.Byte));
        }

        private void Filters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filters.SelectedItem == null) return;
            if (Filters.IsKeyboardFocusWithin || Filters.IsMouseOver)
            {
                if (Filters.SelectedIndex == 0) { FilterEnable.IsChecked = false; MainWindow.GameProcess.Write(BaseModel.GposeFilterPointer + BaseModel.Offsets.GposeFilterEnable, Convert.ChangeType(0x00, TypeCode.Byte)); }
                else { FilterEnable.IsChecked = true; MainWindow.GameProcess.Write(BaseModel.GposeFilterPointer + BaseModel.Offsets.GposeFilterEnable, Convert.ChangeType(0x40, TypeCode.Byte)); }
                string Value = (string)((ComboBoxItem)Filters.SelectedItem).Tag;
                ((FloatArrayAddress)BaseModel.AddressList["GposeFilterTable"]).WriteMemory(Extensions.StringToByteArray(Value));
            }
        }
    }
}
