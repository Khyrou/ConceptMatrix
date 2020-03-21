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
    /// Interaction logic for EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : UserControl
    {
        public static EquipmentPage Page;
        public string EquipName;
        public EquipmentPage()
        {
            InitializeComponent();
            Page = this;
        }

        private void SearchEquip_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchEquip.Text.ToLower();
            if (EquipName == "Mainhand" ||EquipName == "Offhand")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Offhand || s.Key == (int)ExdData.Slot.Mainhand))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Head")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Head))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Body")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Body))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Hands")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Hands))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Legs")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Legs))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Feet")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Feet))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Ears")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Ears))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Neck")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Neck))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Wrist")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Wrists))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Left Ring")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.FingerL || s.Key == (int)ExdData.Slot.FingerR))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
            else if (EquipName == "Right Ring")
            {
                EquipList.ItemsSource = BaseModel.AllEquipmentX
                    .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.FingerL || s.Key == (int)ExdData.Slot.FingerR))
                    .Where(g => g.Name.ToLower().Contains(filter))
                    .ToList();
            }
        }

        private void EquipList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EquipList.SelectedCells.Count > 0)
            {
                if (EquipList.SelectedItem == null)
                    return;
                var Value = (ExdData.Item)EquipList.SelectedItem;
                if (EquipName == "Mainhand")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    ushort[] ints2 = new ushort[] { Value.ModelSub.Value1, Value.ModelSub.Value2, Value.ModelSub.Value3, Value.ModelSub.Value4 };
                    byte[] bytes2 = ints2.SelectMany(BitConverter.GetBytes).ToArray();
                    BaseModel.AddressList["Mainhand"].WriteMemory(bytes);
                    BaseModel.AddressList["Offhand"].WriteMemory(bytes2);
                }
                else if (EquipName == "Offhand")
                {

                    ushort[] ints = new ushort[] { Value.ModelSub.Value1, Value.ModelSub.Value2, Value.ModelSub.Value3, Value.ModelSub.Value4 };
                    if (Value.Name.Contains("Shield"))ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    BaseModel.AddressList["Offhand"].WriteMemory(bytes);
                }
                else if (EquipName == "Head")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Head"].WriteMemory(bytes);
                }
                else if (EquipName == "Body")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Body"].WriteMemory(bytes);
                }
                else if (EquipName == "Hands")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Hands"].WriteMemory(bytes);
                }
                else if (EquipName == "Legs")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Legs"].WriteMemory(bytes);
                }
                else if (EquipName == "Feet")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Feet"].WriteMemory(bytes);
                }
                else if (EquipName == "Ears")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Ears"].WriteMemory(bytes);
                }
                else if (EquipName == "Neck")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Neck"].WriteMemory(bytes);
                }
                else if (EquipName == "Wrist")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["Wrist"].WriteMemory(bytes);
                }
                else if (EquipName == "Left Ring")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["LRing"].WriteMemory(bytes);
                }
                else if (EquipName == "Right Ring")
                {
                    ushort[] ints = new ushort[] { Value.ModelMain.Value1, Value.ModelMain.Value2, Value.ModelMain.Value3, Value.ModelMain.Value4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    BaseModel.AddressList["RRing"].WriteMemory(bytes);
                }
            }
        }
    }
}
