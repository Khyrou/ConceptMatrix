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
    /// Interaction logic for EquipmentSelectorView.xaml
    /// </summary>
    public partial class EquipmentSelectorView : UserControl
    {
        public class TextList : List<string> { }

        public EquipmentSelectorView()
        {
            InitializeComponent();
            StainBox.ItemsSource = ExdData.Stain;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentPage.Page.EquipmentFlyout.IsOpen)
            {
                if(EquipmentPage.Page.EquipName != (string)CheckboxEquip.Content)
                {
                    EquipmentPage.Page.EquipName = (string)CheckboxEquip.Content;
                    if ((string)CheckboxEquip.Content == "Mainhand" || (string)CheckboxEquip.Content == "Offhand")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Offhand || s.Key == (int)ExdData.Slot.Mainhand))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Head")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Head))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Body")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Body))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Hands")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Hands))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Legs")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Legs))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Feet")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Feet))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Ears")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Ears))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Neck")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Neck))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Wrist")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Wrists))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Left Ring")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.FingerL || s.Key == (int)ExdData.Slot.FingerR))
                            .ToList();
                    }
                    else if ((string)CheckboxEquip.Content == "Right Ring")
                    {
                        EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                            .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.FingerL || s.Key == (int)ExdData.Slot.FingerR))
                            .ToList();
                    }
                }
                else EquipmentPage.Page.EquipmentFlyout.IsOpen = !EquipmentPage.Page.EquipmentFlyout.IsOpen;
                
            }
            else
            {
                EquipmentPage.Page.EquipmentFlyout.IsOpen = !EquipmentPage.Page.EquipmentFlyout.IsOpen;
                EquipmentPage.Page.EquipName = (string)CheckboxEquip.Content;
                if ((string)CheckboxEquip.Content == "Mainhand" || (string)CheckboxEquip.Content == "Offhand")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Offhand || s.Key == (int)ExdData.Slot.Mainhand))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Head")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Head))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Body")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Body))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Hands")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Hands))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Legs")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Legs))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Feet")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Feet))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Ears")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Ears))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Neck")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Neck))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Wrist")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Wrists))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Left Ring")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.FingerL || s.Key == (int)ExdData.Slot.FingerR))
                        .ToList();
                }
                else if ((string)CheckboxEquip.Content == "Right Ring")
                {
                    EquipmentPage.Page.EquipList.ItemsSource = BaseModel.AllEquipmentX
                        .Where(D => D.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.FingerL || s.Key == (int)ExdData.Slot.FingerR))
                        .ToList();
                }
            }
        }
    }
}
