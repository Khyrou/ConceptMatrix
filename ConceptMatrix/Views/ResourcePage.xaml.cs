using ConceptMatrix.Backend;
using ConceptMatrix.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for ResourcePage.xaml
    /// </summary>
    public partial class ResourcePage : UserControl
    {
        public static ResourcePage Resourcepage;
        public ResourcePage()
        {
            InitializeComponent();
            Resourcepage = this;
        }
        private int _tribe = 0;
        private int _gender = 0;
        private int _face;
        private bool DidUserInteract = false;
        private bool UserDoneInteraction = false;
        private bool isUserInteraction;
        private ExdData.Resident[] _residents;

        public class FeatureSelect
        {
            public int ID { get; set; }
            public SaintCoinach.Imaging.ImageFile FeatureImage { get; set; }
        }
        public class Features
        {
            public int FeatureID { get; set; }
            public ImageSource FeatureImage { get; set; }
        }

        private void MetroAnimatedTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.OriginalSource is TabControl)
            {
                if (HairTab.IsSelected)
                {
                    CharaMakeFeatureSelector(
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value, 0);
                }
                else if (PaintTab.IsSelected)
                {
                    CheckIncluded.IsChecked = false;
                    CharaMakeFeatureSelector(
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value, 1);
                }
                else if (FacialTab.IsSelected)
                {
                    CharaMakeFeatureSelector3(
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[5].Value,
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value);
                }
                else if (NPCTab.IsSelected)
                {
                    if (!UserDoneInteraction) ResidentSelector(ExdData.Residents.Values.Where(c => c.IsGoodNpc()).ToArray());
                }
            }
            else return;
            e.Handled = true;
        }

        #region Actor Features: Hairstyle,Facepaint, Facial Feature
        public void CharaMakeFeatureSelector(int tribe, int gender, int Call)
        {
            if (DidUserInteract) return;
            if (tribe == 0)
            {
                MessageBox.Show("You can't have Clan set to None when using this!", "Concept Matrix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DidUserInteract = true;
            _tribe = tribe;
            _gender = gender;

            if (Call == 0) FillHairStyle();
            else { FillFacePaint(); CheckIncluded.IsChecked = false; }
        }
        public void CharaMakeFeatureSelector3(int face, int tribe, int gender)
        {
            if (DidUserInteract) return;
            if (tribe == 0)
            {
                MessageBox.Show("You can't have Clan set to None when using this!", "Concept Matrix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DidUserInteract = true;
            _tribe = tribe;
            _gender = gender;
            _face = face;
            FillFacialFeature(_face, tribe, gender);
        }
        ExdData.CharaMakeCustomizeFeature GetFeature(int startIndex, int length, byte dataKey)
        {
            if (dataKey == 0)
                return null; // Custom or not specified.

            for (var i = 1; i < length; i++)
            {
                // Debug.WriteLine(startIndex + i);
                var feature = ExdData.CharaMakeFeatures[startIndex + i];

                if (feature.FeatureID == dataKey)
                {
                    return feature;
                }
            }

            return null; // Not found - custom.
        }
        int GetHairstyleCustomizeIndex(int tribeKey, bool isMale)
        {
            switch (tribeKey)
            {
                case 1: // Midlander
                    return isMale ? 0 : 100;
                case 2: // Highlander
                    return isMale ? 200 : 300;
                case 3: // Wildwood
                case 4: // Duskwight
                    return isMale ? 400 : 500;
                case 5: // Plainsfolks
                case 6: // Dunesfolk
                    return isMale ? 600 : 700;
                case 7: // Seeker of the Sun
                case 8: // Keeper of the Moon
                    return isMale ? 800 : 900;
                case 9: // Sea Wolf
                case 10: // Hellsguard
                    return isMale ? 1000 : 1100;
                case 11: // Raen
                case 12: // Xaela
                    return isMale ? 1200 : 1300;
                case 13: // The Lost/Helions
                case 14: // The Lost/Helions
                    return 1400;
                case 15: // Rava
                case 16: // Veena
                    return 1500;
            }

            throw new NotImplementedException();
        }
        int GetFacePaintByIndex(int tribeKey, bool isMale)
        {
            switch (tribeKey)
            {
                case 1: // Midlander
                    return isMale ? 1600 : 1650;
                case 2: // Highlander
                    return isMale ? 1700 : 1750;
                case 3: // Wildwood
                    return isMale ? 1800 : 1850;
                case 4: // Duskwight
                    return isMale ? 1900 : 1950;
                case 5: // Plainsfolks
                    return isMale ? 2000 : 2050;
                case 6: // Dunesfolk
                    return isMale ? 2100 : 2150;
                case 7: // Seeker of the Sun
                    return isMale ? 2200 : 2250;
                case 8: // Keeper of the Moon
                    return isMale ? 2300 : 2350;
                case 9: // Sea Wolf
                    return isMale ? 2400 : 2450;
                case 10: // Hellsguard
                    return isMale ? 2500 : 2550;
                case 11: // Raen
                    return isMale ? 2600 : 2650;
                case 12: // Xaela
                    return isMale ? 2700 : 2750;
                case 13: // Helions
                    return 2800;
                case 14: // The Lost
                    return 2850;
                case 15: // Rava
                    return 2900;
                case 16: // Veena
                    return 2950;
            }

            throw new NotImplementedException();
        }

        public void FillHairStyle()
        {
            try
            {
                CharacterFeature.Items.Clear();
                int added = 0;
                for (int i = 0; i < 200; i++)
                {
                    var feature = GetFeature(GetHairstyleCustomizeIndex(_tribe, _gender == 0), 100, (byte)i);

                    if (feature == null)
                        continue;
                    CharacterFeature.Items.Add(new FeatureSelect() { ID = feature.FeatureID, FeatureImage = feature.Icon });
                    added++;
                }
                DidUserInteract = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void FillFacePaint()
        {
            try
            {
                FacePaintFeature.Items.Clear();
                int added = 0;
                for (int i = 0; i < 200; i++)
                {
                    if (i == 0)
                    {
                        FacePaintFeature.Items.Add(new FeatureSelect() { ID = 0, FeatureImage = null });
                        added++;
                        continue;
                    }
                    var feature = GetFeature(GetFacePaintByIndex(_tribe, _gender == 0), 50, (byte)i);

                    if (feature == null)
                        continue;
                    FacePaintFeature.Items.Add(new FeatureSelect() { ID = feature.FeatureID, FeatureImage = feature.Icon });
                    added++;
                }
                DidUserInteract = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private enum FacialEnums
        {
            Feature1 = 1,
            Feature2 = 2,
            Feature3 = 4,
            Feature4 = 8,
            Feature5 = 16,
            ExtraFeature = 32,
            ExtraFeature2 = 64
        }
        public void FillFacialFeature(int FaceKey, int tribeKey, int gender)
        {
            try
            {
                FaceKey--;
                if (FaceKey < 0) FaceKey = 0;
                FacialFeatureView.Items.Clear();
                if (FaceKey > 3 && tribeKey >= 2 && tribeKey != 13 && tribeKey != 14 ||
                    FaceKey >= 6 && tribeKey == 1 && gender == 0 ||
                    FaceKey >= 5 && tribeKey == 1 && gender == 1) { FaceKey = 0; }
                if (tribeKey == 13 || tribeKey == 14) gender = 0; //Hrothgar
                if (tribeKey == 15 || tribeKey == 16) gender = 1; // Veria
                var valuesAsList = Enum.GetValues(typeof(FacialEnums)).Cast<FacialEnums>().ToList();
                foreach (var CharaFeature in ExdData.CharaMakeFeatures2)
                {
                    if (tribeKey != CharaFeature.Value.Tribe) continue;
                    if (tribeKey == CharaFeature.Value.Tribe && gender == CharaFeature.Value.Gender)
                    {
                        FacialFeatureView.Items.Add(new Features() { FeatureID = 0, FeatureImage = ExdData.GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Nope")) });
                        for (int i = 0; i < 7; i++)
                        {
                            try
                            {
                                int IconUIID = FaceKey + (i * 4);
                                int NewID = (int)valuesAsList[i];
                                FacialFeatureView.Items.Add(new Features() { FeatureID = NewID, FeatureImage = CharaFeature.Value.Features[IconUIID].Icon });
                            }
                            catch
                            {
                                int NewID = (int)valuesAsList[i];
                                FacialFeatureView.Items.Add(new Features() { FeatureID = NewID, FeatureImage = null });
                            }
                        }
                        FacialFeatureView.Items.Add(new Features() { FeatureID = 128, FeatureImage = ExdData.GetImageStream((System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("Legacy")) });
                    }
                }
                DidUserInteract = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void HairButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!HairTab.IsSelected)
                {
                    HairTab.IsSelected = true;
                    CharaMakeFeatureSelector(
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value, 0);
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                HairTab.IsSelected = true;
                CharaMakeFeatureSelector(
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value, 0);
            }
        }

        private void FacePaintButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!PaintTab.IsSelected)
                {
                    PaintTab.IsSelected = true;
                    CheckIncluded.IsChecked = false;
                    CharaMakeFeatureSelector(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value, ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value, 1);
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                PaintTab.IsSelected = true;
                CheckIncluded.IsChecked = false;
                CharaMakeFeatureSelector(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value, ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value, 1);
            }
        }

        private void FacialFeatureButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!FacialTab.IsSelected)
                {
                    FacialTab.IsSelected = true;
                    CharaMakeFeatureSelector3(
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[5].Value,
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                        ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value);
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                FacialTab.IsSelected = true;
                CharaMakeFeatureSelector3(
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[5].Value,
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value);
            }
        }

        private void CharacterFeature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterFeature.SelectedItem == null)
                return;
            var Value = (FeatureSelect)CharacterFeature.SelectedItem;
            ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[6].WriteMemory((byte)Value.ID);
        }
        private void FacePaintFeature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FacePaintFeature.SelectedItem == null)
                return;
            var Value = (FeatureSelect)FacePaintFeature.SelectedItem;
            if (CheckIncluded.IsChecked == true) Value.ID += 128;
            ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[24].WriteMemory((byte)Value.ID);
        }

        private void FacialFeatureView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FacialFeatureView.SelectedItem == null)
                return;
            byte result = 0;
            foreach (Features r in FacialFeatureView.SelectedItems)
            {
                if (r.FeatureID == 0)
                {
                    FacialFeatureView.SelectedIndex = -1;
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[12].WriteMemory(0);
                    return;
                }
                else result += (byte)r.FeatureID;
            }
            ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[12].WriteMemory(result);
            e.Handled = true;
        }
        #endregion

        #region ColorSelector Tab
        public void CharaMakeColorSelector(CmpReader colorMap, int start, int length)
        {
            colorListView.Items.Clear();
            for (int i = start; i < start + length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 48;
                item.Height = 48;
                var newColor = new SolidColorBrush(Color.FromArgb(colorMap.Colors[i].A, colorMap.Colors[i].R, colorMap.Colors[i].G, colorMap.Colors[i].B));
                item.Background = newColor;
                item.FontSize = 18;
                item.Content = (i - start);
                colorListView.Items.Add(item);
            }
        }

        public void CharaMakeColorSelectorLips(CmpReader colorMap, int start, int length)
        {
            colorListView.Items.Clear();
            for (int i = start; i < start + length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 48;
                item.Height = 48;
                var newColor = new SolidColorBrush(Color.FromArgb(colorMap.Colors[i].A, colorMap.Colors[i].R, colorMap.Colors[i].G, colorMap.Colors[i].B));
                item.Background = newColor;
                item.FontSize = 14;
                item.Content = "D:" + (i - start);
                colorListView.Items.Add(item);
            }
            for (int i = 0; i < 32; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 48;
                item.Height = 48;
                item.FontSize = 14;
                item.Visibility = Visibility.Collapsed;
                colorListView.Items.Add(item);
            }
            for (int i = 1792; i < 1792 + 96; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Width = 48;
                item.Height = 48;
                var newColor = new SolidColorBrush(Color.FromArgb(colorMap.Colors[i].A, colorMap.Colors[i].R, colorMap.Colors[i].G, colorMap.Colors[i].B));
                item.Background = newColor;
                item.FontSize = 14;
                item.Content = "L:" + (i - (1792 - 128));
                colorListView.Items.Add(item);
            }
        }

        public static int GetHair(int clan, bool gender)
        {
            switch (clan)
            {
                case 1: //Midlander
                    return !gender ? 4864 : 3584;
                case 2: //Highlander
                    return !gender ? 7424 : 6144;
                case 3: //Wildwood
                    return !gender ? 9984 : 8704;
                case 4: //Duskwight
                    return !gender ? 12544 : 11264;
                case 5: //Plainsfolk
                    return !gender ? 15104 : 13824;
                case 6: //Dunesfolk
                    return !gender ? 17664 : 16384;
                case 7: //Seeker of the Sun
                    return !gender ? 20224 : 18944;
                case 8: //Keeper of the Moon
                    return !gender ? 22784 : 21504;
                case 9: // Sea Wolf
                    return !gender ? 25344 : 24064;
                case 10: //Hellsguard
                    return !gender ? 27904 : 26624;
                case 11: // Raen
                    return !gender ? 30464 : 29184;
                case 12: // Xaela
                    return !gender ? 33024 : 31744;
                case 13: //Helions
                    return 34304;
                case 14: //The Lost
                    return 36608;
                case 15: // Rava
                    return 40704;
                case 16: // Veena
                    return 43264;
                default:
                    throw new NotImplementedException();
            }
        }
        public static int GetSkin(int Clan, bool Gender)
        {
            switch (Clan)
            {
                case 1: //Midlander
                    return !Gender ? 4608 : 3328;
                case 2: //Highlander
                    return !Gender ? 7168 : 5888;
                case 3: //Wildwood
                    return !Gender ? 9728 : 8448;
                case 4: //Duskwight
                    return !Gender ? 12288 : 11008;
                case 5: //Plainsfolk
                    return !Gender ? 14848 : 13568;
                case 6: //Dunesfolk
                    return !Gender ? 17408 : 16128;
                case 7: //Seeker of the Sun
                    return !Gender ? 19968 : 18688;
                case 8: //Keeper of the Moon
                    return !Gender ? 22528 : 21248;
                case 9: //Sea Wolf
                    return !Gender ? 25088 : 23808;
                case 10: //Hellsguard
                    return !Gender ? 27648 : 26368;
                case 11: //Raen
                    return !Gender ? 28928 : 30208;
                case 12: //Xaela
                    return !Gender ? 31488 : 32768;
                case 13: //Helions
                    return 34048;
                case 14: //The Lost
                    return 35840;
                case 15: // Rava
                    return 40448;
                case 16: // Veena
                    return 43008;
                default:
                    throw new NotImplementedException();
            }
        }
        private void HairColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 1)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelector(ExdData._colorMap,
                        GetHair(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                        Convert.ToBoolean(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value)), 192);
                    ColorBox.SelectedIndex = 1;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelector(ExdData._colorMap,
                    GetHair(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                    Convert.ToBoolean(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value)), 192);
                ColorBox.SelectedIndex = 1;
            }
        }

        private void ColorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isUserInteraction)
            {
                switch (ColorBox.SelectedIndex)
                {
                    case 0:
                        CharaMakeColorSelector(ExdData._colorMap, GetSkin(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value, Convert.ToBoolean(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value)), 192);
                        break;
                    case 1:
                        CharaMakeColorSelector(ExdData._colorMap, GetHair(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value, Convert.ToBoolean(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value)), 192);
                        break;
                    case 2:
                        CharaMakeColorSelector(ExdData._colorMap, 256, 192);
                        break;
                    case 3:
                        CharaMakeColorSelectorLips(ExdData._colorMap, 512, 96);
                        break;
                    case 4:
                        CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                        break;
                    case 5:
                        CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                        break;
                    case 6:
                        CharaMakeColorSelector(ExdData._colorMap, 1152, 96);
                        break;
                    case 7:
                        CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                        break;
                    default:
                        break;
                }
                isUserInteraction = false;
            }
        }

        private void HighlightColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 2)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelector(ExdData._colorMap, 256, 192);
                    ColorBox.SelectedIndex = 2;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelector(ExdData._colorMap, 256, 192);
                ColorBox.SelectedIndex = 2;
            }
        }

        private void LeftEyeColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 5)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                    ColorBox.SelectedIndex = 5;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                ColorBox.SelectedIndex = 5;
            }
        }

        private void FacePaintColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 6)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelector(ExdData._colorMap, 512, 96);
                    ColorBox.SelectedIndex = 6;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelector(ExdData._colorMap, 512, 96);
                ColorBox.SelectedIndex = 6;
            }
        }

        private void RightEyeColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 4)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                    ColorBox.SelectedIndex = 4;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                ColorBox.SelectedIndex = 4;
            }
        }

        private void SkinColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 0)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelector(ExdData._colorMap,
                        GetSkin(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                        Convert.ToBoolean(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value)), 192);
                    ColorBox.SelectedIndex = 0;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelector(ExdData._colorMap,
                    GetSkin(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value,
                    Convert.ToBoolean(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[1].Value)), 192);
                ColorBox.SelectedIndex = 0;
            }
        }

        private void LimbalEyeColor_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 7)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                    ColorBox.SelectedIndex = 7;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelector(ExdData._colorMap, 0, 192);
                ColorBox.SelectedIndex = 7;
            }
        }

        private void LipColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ColorTab.IsSelected || ColorBox.SelectedIndex != 3)
                {
                    ColorTab.IsSelected = true;
                    CharaMakeColorSelectorLips(ExdData._colorMap, 512, 96);
                    ColorBox.SelectedIndex = 3;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ColorTab.IsSelected = true;
                CharaMakeColorSelectorLips(ExdData._colorMap, 512, 96);
                ColorBox.SelectedIndex = 3;
            }
        }

        private void ColorBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isUserInteraction = true;
        }

        private void colorListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorListView.SelectedItem == null)
                return;
            switch (ColorBox.SelectedIndex)
            {
                case 0:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[8].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                case 1:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[10].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                case 2:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[11].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                case 3:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[20].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                case 4:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[9].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                case 5:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[15].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                case 6:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[25].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                case 7:
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[13].WriteMemory((byte)colorListView.SelectedIndex);
                    break;
                default:
                    break;
            }
        }
#endregion

        #region NPC Tab
        public void ResidentSelector(ExdData.Resident[] residents)
        {
            UserDoneInteraction = true;
            residentlist.Items.Clear();
            _residents = residents;
            foreach (ExdData.Resident resident in _residents) residentlist.Items.Add(resident);
            _residents = residents;
        }

        private void NPCButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!NPCTab.IsSelected)
                {
                    NPCTab.IsSelected = true;
                    if (!UserDoneInteraction) ResidentSelector(ExdData.Residents.Values.Where(c => c.IsGoodNpc()).ToArray());
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                NPCTab.IsSelected = true;
                if (!UserDoneInteraction) ResidentSelector(ExdData.Residents.Values.Where(c => c.IsGoodNpc()).ToArray());
            }
        }

        private void SearchNPCName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchNPCName.Text.ToLower();
            residentlist.Items.Clear();
            foreach (ExdData.Resident resident in _residents.Where(g => g.Name.ToLower().Contains(filter))) residentlist.Items.Add(resident);
        }

        private void residentlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (residentlist.SelectedCells.Count > 0)
            {
                if (residentlist.SelectedItem == null) return;
                var Choice = residentlist.SelectedItem as ExdData.Resident;
                if (LoadType.SelectedIndex == 1 || LoadType.SelectedIndex == 0) 
                {
                    ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).WriteMemory(Choice.Gear.Customize);
                    ((Int32Address)BaseModel.AddressList["ModelChara"]).WriteMemory(Choice.Gear.ModelChara);
                }
                if (LoadType.SelectedIndex == 2 || LoadType.SelectedIndex == 0)
                {
                    ushort[] ints = new ushort[] { Choice.Gear.MainWep.Item1, Choice.Gear.MainWep.Item2, Choice.Gear.MainWep.Item3, Choice.Gear.MainWep.Item4 };
                    byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    ((WeaponArray)BaseModel.AddressList["Mainhand"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.OffWep.Item1, Choice.Gear.OffWep.Item2, Choice.Gear.OffWep.Item3, Choice.Gear.OffWep.Item4 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    ((WeaponArray)BaseModel.AddressList["Offhand"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.HeadGear.Item1, Choice.Gear.HeadGear.Item2, Choice.Gear.HeadGear.Item3, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    bytes[3] = Choice.Gear.HeadGear.Item3;
                    ((EquipmentArray)BaseModel.AddressList["Head"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.BodyGear.Item1, Choice.Gear.BodyGear.Item2, Choice.Gear.BodyGear.Item3, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    bytes[3] = Choice.Gear.BodyGear.Item3;
                    ((EquipmentArray)BaseModel.AddressList["Body"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.HandsGear.Item1, Choice.Gear.HandsGear.Item2, Choice.Gear.HandsGear.Item3, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    bytes[3] = Choice.Gear.HandsGear.Item3;
                    ((EquipmentArray)BaseModel.AddressList["Hands"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.LegsGear.Item1, Choice.Gear.LegsGear.Item2, Choice.Gear.LegsGear.Item3, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    bytes[3] = Choice.Gear.LegsGear.Item3;
                    ((EquipmentArray)BaseModel.AddressList["Legs"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.FeetGear.Item1, Choice.Gear.FeetGear.Item2, Choice.Gear.FeetGear.Item3, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    bytes[3] = Choice.Gear.FeetGear.Item3;
                    ((EquipmentArray)BaseModel.AddressList["Feet"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.EarGear.Item1, Choice.Gear.EarGear.Item2, 0, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    ((EquipmentArray)BaseModel.AddressList["Ears"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.NeckGear.Item1, Choice.Gear.NeckGear.Item2, 0, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    ((EquipmentArray)BaseModel.AddressList["Neck"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.WristGear.Item1, Choice.Gear.WristGear.Item2, 0, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    ((EquipmentArray)BaseModel.AddressList["Wrist"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.RRingGear.Item1, Choice.Gear.RRingGear.Item2, 0, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    ((EquipmentArray)BaseModel.AddressList["RRing"]).WriteMemoryX(bytes);

                    ints = new ushort[] { Choice.Gear.LRingGear.Item1, Choice.Gear.LRingGear.Item2, 0, 0 };
                    bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                    Array.Resize(ref bytes, 4);
                    ((EquipmentArray)BaseModel.AddressList["LRing"]).WriteMemoryX(bytes);
                }
            }
        }
        #endregion

        private void ModelCharaButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActorCustom.IsOpen)
            {
                if (!ModelTab.IsSelected)
                {
                    ModelTab.IsSelected = true;
                }
                else ActorCustom.IsOpen = !ActorCustom.IsOpen;
            }
            else
            {
                ActorCustom.IsOpen = !ActorCustom.IsOpen;
                ModelTab.IsSelected = true;
            }
        }

        private void ModelCharaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelCharaList.SelectedCells.Count > 0)
            {
                if (ModelCharaList.SelectedItem == null)
                    return;
                var Value = (ExdData.Monster)ModelCharaList.SelectedItem;
                BaseModel.AddressList["ModelChara"].WriteMemory(Value.Index);
            }
        }

        private void SearchModelName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchModelName.Text.ToLower();
            ModelCharaList.Items.Clear();
            foreach (ExdData.Monster parse in ExdData.MonsterX.Where(g => g.Name.ToLower().Contains(filter)))
                if (parse.Real == true)
                {
                    ModelCharaList.Items.Add(new ExdData.Monster
                    {
                        Index = Convert.ToInt32(parse.Index),
                        Name = parse.Name.ToString()
                    });
                }
        }

        private void UnfreezeButton_Click(object sender, RoutedEventArgs e)
        {
            ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).UnfreezeArray();
        }

        private void FreezeButton_Click(object sender, RoutedEventArgs e)
        {
            ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).FreezeArray();
        }
    }
}