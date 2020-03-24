using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ConceptMatrix.Backend;
using ConceptMatrix.Models;
using ConceptMatrix.Views;
using SaintCoinach.Xiv.Items;


namespace ConceptMatrix.ViewModel
{
    public class EquipmentSelectorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseModel Parent { get; private set; }

        private ExdData.Item _SelectedEquipment { get; set; }

        public ExdData.Item SelectedEquipment
        {
            get => _SelectedEquipment;
            set
            {
                _SelectedEquipment = value;

                if (value == null)
                {
                    SelectedValid = false;
                //    SetValues("", 0, 0, 0, false, 0);
                    return;
                }
                else
                {
                    SelectedValid = true;
                }
                // if you know a better way to do this dm me
                SetValues(SelectedEquipment.Name,
                            SelectedEquipment.ModelMain.Value1,
                            SelectedEquipment.ModelMain.Value2,
                            SelectedEquipment.ModelMain.Value3,
                            SelectedEquipment.IsDyeable,
                            Stain);

                OnPropertyChanged("SelectedEquipment");
            }
        }

        public ExdData.Item SelectedEquipmentUser
        {
            get => SelectedEquipment;
            set
            {

                if (value == null)
                {
                    SelectedValid = false;
                    return;
                }
                else
                {
                    SelectedValid = true;
                }
                // if you know a better way to do this dm me
                //Console.WriteLine(value.Name);
                MemoryEdit(value.ModelMain.Value1,
                            value.ModelMain.Value2,
                            value.ModelMain.Value3,
                            false,
                            Stain);
                OnPropertyChanged("SelectedEquipmentUser");
            }
        }

        public string SelectedText { get; set; }
        public bool SelectedValid { get; set; }

        private ushort _Model { get; set; }
        private ushort _Base { get; set; }
        private ushort _Variant { get; set; }
        private ushort _Stain { get; set; }

        public ushort Model
        {
            get => _Model;
            set
            {
                _Model = value;
            }
        }

        public ushort UserModel
        {
            get => Model;
            set
            {
                if (Equals(Model, value)) return;
                ExdData.Item eq = PossibleEquipment
                                .FirstOrDefault(e =>
                                    e.ModelMain.Value1 == value
                                    && e.ModelMain.Value2 == _Base
                                    && e.ModelMain.Value3 == _Variant);
                if (eq == null)
                {
                    _Model = value;
                    MemoryEdit(value, _Base, _Variant, false, Stain);
                }
                if (eq != null)
                {
                    _Model = value;
                    MemoryEdit(eq.ModelMain.Value1, eq.ModelMain.Value2, eq.ModelMain.Value3, false, Stain);
                }
            }
        }

        public ushort Base
        {
            get => _Base;
            set
            {
                _Base = value;
            }
        }

        public ushort UserBase
        {
            get => Base;
            set
            {
                if (Equals(Base, value)) return;
                ExdData.Item eq = PossibleEquipment
                    .FirstOrDefault(e =>
                        e.ModelMain.Value1 == _Model
                        && e.ModelMain.Value2 == value
                        && e.ModelMain.Value3 == _Variant);
                if (eq == null)
                {
                    _Base = value;
                    MemoryEdit(_Model, value, _Variant, false, Stain);
                }
                if (eq != null)
                {
                    _Base = value;
                    MemoryEdit(eq.ModelMain.Value1, eq.ModelMain.Value2, eq.ModelMain.Value3, false, Stain);
                }
            }
        }

        public ushort Variant
        {
            get => _Variant;
            set
            {
                _Variant = value;
            }
        }
        public ushort UserVariant
        {
            get => Variant;
            set
            {
                if (Equals(Variant, value)) return;
                ExdData.Item eq = PossibleEquipment
                    .FirstOrDefault(e =>
                        e.ModelMain.Value1 == _Model
                        && e.ModelMain.Value2 == _Base
                        && e.ModelMain.Value3 == value);
                if (eq == null) 
                {
                    _Variant = value;
                    MemoryEdit(_Model, _Base, value, false, Stain);
                }
                if (eq != null)
                {
                    _Variant = value;
                    MemoryEdit(eq.ModelMain.Value1, eq.ModelMain.Value2, eq.ModelMain.Value3, false, Stain);
                }
            }
        }

        public ushort Stain
        {
            get => _Stain;
            set => _Stain = value;
        }

        public ushort UserStain
        {
            get => Stain;
            set 
            {
                if (Equals(Stain, value)) return;
                MemoryEdit(_Model, _Base, _Variant, true, value);
            }
        }
        private bool _Freeze { get; set; }
        public bool Freeze
        {
            get 
            {
                if (BaseModel.AddressList == null) return _Freeze;
                else return BaseModel.AddressList[AddressName].Freeze;
            }
            set 
            { 
                _Freeze = value;
                if (BaseModel.AddressList != null) 
                    BaseModel.AddressList[AddressName].Freeze = value;
                OnPropertyChanged(nameof(Freeze));
            }
        }
        public ObservableCollection<ExdData.Item> PossibleEquipment { get; set; }
        public bool ShouldEnableVariant { get; set; }
        public bool ShouldEnableStain { get; set; } = true;
        public string Title { get; set; }
        public string AddressName { get; set; }

        public EquipmentSelectorViewModel(BaseModel parent, string title, string addressName)
        {
            Parent = parent;
            PossibleEquipment = new ObservableCollection<ExdData.Item>();
            Title = title;
            AddressName = addressName;
            if (title == "Ears"|| title == "Neck" || title == "Wrist" || title == "Left Ring" || title == "Right Ring") ShouldEnableStain = false;
        }
        private ushort[] oldvalue = new ushort[1];
        public void SetValues(string text, ushort m, ushort b, ushort v, bool stain, ushort s)
        {
            Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
            {
                if (EquipmentPage.Page.KeepDye.IsChecked == true) s = UserStain;
            });
            ushort[] ints = new ushort[] { m, b, v, s };
            bool equal = ints.SequenceEqual(oldvalue);
            if (equal) return;
            oldvalue = ints;
            ExdData.Item eq = PossibleEquipment.FirstOrDefault(e => e.ModelMain.Value1 == m && e.ModelMain.Value2 == b && e.ModelMain.Value3 == v);
            ExdData.Item sq = PossibleEquipment.FirstOrDefault(e => e.ModelSub.Value1 == m && e.ModelSub.Value2 == b && e.ModelSub.Value3 == v);
            if (eq == null && sq==null)
            {
                SelectedText = "Custom/Unknown Equipment";
                ShouldEnableVariant = true;
            }
            else if (eq!=null)
            {
                SelectedEquipment = eq;
                SelectedText = eq.Name;
            }
            else if(sq != null)
            {
                SelectedEquipment = sq;
                SelectedText = sq.Name+" Offhand";
                
            }
         //   Console.WriteLine(SelectedText + $" {Title}");
            OnPropertyChanged(nameof(SelectedEquipment));
            _Model = m;
            Model = m;
            _Base = b;
            Base = b;

            ShouldEnableVariant = v != 0;
            _Variant = v;
            Variant = v;

        //    ShouldEnableStain = stain;
            _Stain = s;
            Stain = s;

            OnPropertyChanged(nameof(UserModel));
            OnPropertyChanged(nameof(UserBase));
            OnPropertyChanged(nameof(UserVariant));
            OnPropertyChanged(nameof(UserStain));
        }
        public void SetValuesX(string text, ushort m, ushort b, ushort v, bool stain, ushort s)
        {
            ushort[] ints = new ushort[] { m, b, v, s };
            bool equal = ints.SequenceEqual(oldvalue);
            if (equal) return;
            oldvalue = ints;
            ExdData.Item eq = PossibleEquipment.FirstOrDefault(e => e.ModelMain.Value1 == m && e.ModelMain.Value2 == b && e.ModelMain.Value3 == v);
            ExdData.Item sq = PossibleEquipment.FirstOrDefault(e => e.ModelSub.Value1 == m && e.ModelSub.Value2 == b && e.ModelSub.Value3 == v);
            if (eq == null && sq == null)
            {
                SelectedText = "Custom/Unknown Equipment";
                ShouldEnableVariant = true;
            }
            else if (eq != null)
            {
                SelectedEquipment = eq;
                SelectedText = eq.Name;
            }
            else if (sq != null)
            {
                SelectedEquipment = sq;
                SelectedText = sq.Name + " Offhand";

            }
            //   Console.WriteLine(SelectedText + $" {Title}");
            OnPropertyChanged(nameof(SelectedEquipment));
            _Model = m;
            Model = m;
            _Base = b;
            Base = b;

            ShouldEnableVariant = v != 0;
            _Variant = v;
            Variant = v;

            //ShouldEnableStain = stain;
            _Stain = s;
            Stain = s;

            OnPropertyChanged(nameof(UserModel));
            OnPropertyChanged(nameof(UserBase));
            OnPropertyChanged(nameof(UserVariant));
            OnPropertyChanged(nameof(UserStain));
        }

        public void MemoryEdit(ushort m, ushort b, ushort v, bool EditedFromStain, ushort s)
        {
            Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
            {
                if (EquipmentPage.Page.KeepDye.IsChecked == true&& !EditedFromStain) s = UserStain;
            });
            ushort[] ints = new ushort[] { m, b, v, s };    
            bool equal = ints.SequenceEqual(oldvalue);
            if (equal) return;
            oldvalue = ints;
            ExdData.Item eq = PossibleEquipment.FirstOrDefault(e => e.ModelMain.Value1 == m && e.ModelMain.Value2 == b && e.ModelMain.Value3 == v);
            byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
            if (Title == "Mainhand")
            {
                BaseModel.AddressList["Mainhand"].WriteMemory(bytes);
                if (eq != null)
                {
                    if (this != BaseModel.OffhandSelect && eq.HasSubModel())
                    {
                        BaseModel.OffhandSelect.SelectedEquipment = eq;
                        BaseModel.OffhandSelect.SetValues(eq.Name + " Offhand",
                            eq.ModelSub.Value1,
                            eq.ModelSub.Value2,
                            eq.ModelSub.Value3,
                            eq.IsDyeable,
                            s);
                        ints = new ushort[] { eq.ModelSub.Value1, eq.ModelSub.Value2, eq.ModelSub.Value3, s };
                        bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                        BaseModel.AddressList["Offhand"].WriteMemory(bytes);
                    }
                }
            }
            else if (Title != "Offhand")
            {
                Array.Resize(ref bytes, 4);
                bytes[3] = (byte)s;
                BaseModel.AddressList[AddressName].WriteMemory(bytes);
            }
            else BaseModel.AddressList["Offhand"].WriteMemory(bytes);

            if (eq == null)
            {
                SelectedEquipment = eq;
                SelectedText = "Custom/Unknown Equipment";
                ShouldEnableVariant = true;
            }
            else
            {

                SelectedEquipment = eq;
                ShouldEnableVariant = v != 0;
            }
            OnPropertyChanged(nameof(SelectedEquipment));

            _Model = m;
            _Base = b;
            _Variant = v;

           // ShouldEnableStain = stain;
            _Stain = s;
            Stain = s;

            OnPropertyChanged(nameof(UserModel));
            OnPropertyChanged(nameof(UserBase));
            OnPropertyChanged(nameof(UserVariant));
            OnPropertyChanged(nameof(UserStain));
            OnPropertyChanged(nameof(SelectedEquipmentUser));

        }
    }
}
