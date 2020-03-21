using ConceptMatrix.Backend;
using ConceptMatrix.Controls;
using ConceptMatrix.Models;
using ConceptMatrix.ViewModel;
using ConceptMatrix.Views;
using ConceptMatrix.Windows;
using MaterialDesignExtensions.Controls;
using Newtonsoft.Json;
using Nhaama.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WepTuple = System.Tuple<ushort, ushort, ushort, ushort>;

namespace ConceptMatrix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        public static MainWindow Main;
        private Dictionary<MenuModel.MenuCategory, UserControl> _pages;

        public static BaseModel gameModel;

        #region CMTool/SSTool's Old Character Save Class Format
        public class CharSaves
        {
            public string Description { get; set; }
            public string DateCreated { get; set; }
            public WepTuple MainHand { get; set; }
            public WepTuple OffHand { get; set; }
            public string EquipmentBytes { get; set; }
            public string CharacterBytes { get; set; }
            public CharacterDetails characterDetails { get; set; }
        }
        public class CharacterDetails
        {
            public float Height { get; set; }
            public float BustX { get; set; }
            public float BustY { get; set; }
            public float BustZ { get; set; }
            public byte Voices { get; set; }
            public float MuscleTone { get; set; }
            public float WeaponX { get; set; }
            public float WeaponY { get; set; }
            public float WeaponZ { get; set; }
            public float OffhandX { get; set; }
            public float OffhandY { get; set; }
            public float OffhandZ { get; set; }
            public float OffhandRed { get; set; }
            public float OffhandGreen { get; set; }
            public float OffhandBlue { get; set; }
            public float WeaponRed { get; set; }
            public float WeaponGreen { get; set; }
            public float WeaponBlue { get; set; }
            public float SkinRedPigment { get; set; }
            public float SkinGreenPigment { get; set; }
            public float SkinBluePigment { get; set; }
            public float SkinRedGloss { get; set; }
            public float SkinGreenGloss { get; set; }
            public float SkinBlueGloss { get; set; }
            public float HairRedPigment { get; set; }
            public float HairGreenPigment { get; set; }
            public float HairBluePigment { get; set; }
            public float HairGlowRed { get; set; }
            public float HairGlowGreen { get; set; }
            public float HairGlowBlue { get; set; }
            public float HighlightRedPigment { get; set; }
            public float HighlightGreenPigment { get; set; }
            public float HighlightBluePigment { get; set; }
            public float LeftEyeRed { get; set; }
            public float LeftEyeGreen { get; set; }
            public float LeftEyeBlue { get; set; }
            public float RightEyeRed { get; set; }
            public float RightEyeGreen { get; set; }
            public float RightEyeBlue { get; set; }
            public float LipsBrightness { get; set; }
            public float LipsR { get; set; }
            public float LipsB { get; set; }
            public float LipsG { get; set; }
            public float LimbalR { get; set; }
            public float LimbalG { get; set; }
            public float LimbalB { get; set; }
        }
        public class OldCharSaves
        {
            public string Description
            {
                get;
                set;
            }

            public string DateCreated
            {
                get;
                set;
            }

            public string FileName
            {
                get;
                set;
            }

            public Tuple<ushort, ushort, ushort, ushort> MainHand
            {
                get;
                set;
            }

            public Tuple<ushort, ushort, ushort, ushort> OffHand
            {
                get;
                set;
            }

            public string EquipmentBytes
            {
                get;
                set;
            }

            public string CharacterBytes
            {
                get;
                set;
            }

            public CharacterDetailsOld characterDetails
            {
                get;
                set;
            }
        }
        public class CharacterDetailsOld
        {
            public Address<float> Height
            {
                get;
                set;
            }

            public Address<float> BustX
            {
                get;
                set;
            }

            public Address<float> BustY
            {
                get;
                set;
            }

            public Address<float> BustZ
            {
                get;
                set;
            }

            public Address<byte> Voices
            {
                get;
                set;
            }

            public Address<float> MuscleTone
            {
                get;
                set;
            }

            public Address<float> WeaponX
            {
                get;
                set;
            }

            public Address<float> WeaponY
            {
                get;
                set;
            }

            public Address<float> WeaponZ
            {
                get;
                set;
            }

            public Address<float> OffhandX
            {
                get;
                set;
            }

            public Address<float> OffhandY
            {
                get;
                set;
            }

            public Address<float> OffhandZ
            {
                get;
                set;
            }

            public Address<float> OffhandRed
            {
                get;
                set;
            }

            public Address<float> OffhandGreen
            {
                get;
                set;
            }

            public Address<float> OffhandBlue
            {
                get;
                set;
            }

            public Address<float> WeaponRed
            {
                get;
                set;
            }

            public Address<float> WeaponGreen
            {
                get;
                set;
            }

            public Address<float> WeaponBlue
            {
                get;
                set;
            }

            public Address<float> SkinRedPigment
            {
                get;
                set;
            }

            public Address<float> SkinGreenPigment
            {
                get;
                set;
            }

            public Address<float> SkinBluePigment
            {
                get;
                set;
            }

            public Address<float> SkinRedGloss
            {
                get;
                set;
            }

            public Address<float> SkinGreenGloss
            {
                get;
                set;
            }

            public Address<float> SkinBlueGloss
            {
                get;
                set;
            }

            public Address<float> HairRedPigment
            {
                get;
                set;
            }

            public Address<float> HairGreenPigment
            {
                get;
                set;
            }

            public Address<float> HairBluePigment
            {
                get;
                set;
            }

            public Address<float> HairGlowRed
            {
                get;
                set;
            }

            public Address<float> HairGlowGreen
            {
                get;
                set;
            }

            public Address<float> HairGlowBlue
            {
                get;
                set;
            }

            public Address<float> HighlightRedPigment
            {
                get;
                set;
            }

            public Address<float> HighlightGreenPigment
            {
                get;
                set;
            }

            public Address<float> HighlightBluePigment
            {
                get;
                set;
            }

            public Address<float> LeftEyeRed
            {
                get;
                set;
            }

            public Address<float> LeftEyeGreen
            {
                get;
                set;
            }

            public Address<float> LeftEyeBlue
            {
                get;
                set;
            }

            public Address<float> RightEyeRed
            {
                get;
                set;
            }

            public Address<float> RightEyeGreen
            {
                get;
                set;
            }

            public Address<float> RightEyeBlue
            {
                get;
                set;
            }

            public Address<float> LipsBrightness
            {
                get;
                set;
            }

            public Address<float> LipsR
            {
                get;
                set;
            }

            public Address<float> LipsB
            {
                get;
                set;
            }

            public Address<float> LipsG
            {
                get;
                set;
            }

            public Address<float> LimbalR
            {
                get;
                set;
            }

            public Address<float> LimbalG
            {
                get;
                set;
            }

            public Address<float> LimbalB
            {
                get;
                set;
            }
            public class Address<T>
            {
                public T value { get; set; }
            }

            public CharacterDetailsOld()
            {
                Height = new Address<float>();
                BustX = new Address<float>();
                BustY = new Address<float>();
                BustZ = new Address<float>();
                Voices = new Address<byte>();
                MuscleTone = new Address<float>();
                WeaponX = new Address<float>();
                WeaponY = new Address<float>();
                WeaponZ = new Address<float>();
                OffhandX = new Address<float>();
                OffhandY = new Address<float>();
                OffhandZ = new Address<float>();
                OffhandRed = new Address<float>();
                OffhandGreen = new Address<float>();
                OffhandBlue = new Address<float>();
                WeaponRed = new Address<float>();
                WeaponGreen = new Address<float>();
                WeaponBlue = new Address<float>();
                SkinRedPigment = new Address<float>();
                SkinGreenPigment = new Address<float>();
                SkinBluePigment = new Address<float>();
                SkinRedGloss = new Address<float>();
                SkinGreenGloss = new Address<float>();
                SkinBlueGloss = new Address<float>();
                HairRedPigment = new Address<float>();
                HairGreenPigment = new Address<float>();
                HairBluePigment = new Address<float>();
                HairGlowRed = new Address<float>();
                HairGlowGreen = new Address<float>();
                HairGlowBlue = new Address<float>();
                HighlightRedPigment = new Address<float>();
                HighlightGreenPigment = new Address<float>();
                HighlightBluePigment = new Address<float>();
                LeftEyeRed = new Address<float>();
                LeftEyeGreen = new Address<float>();
                LeftEyeBlue = new Address<float>();
                RightEyeRed = new Address<float>();
                RightEyeGreen = new Address<float>();
                RightEyeBlue = new Address<float>();
                LipsBrightness = new Address<float>();
                LipsR = new Address<float>();
                LipsB = new Address<float>();
                LipsG = new Address<float>();
                LimbalR = new Address<float>();
                LimbalG = new Address<float>();
                LimbalB = new Address<float>();
            }
        }
        #endregion

        public static NhaamaProcess GameProcess { get; set; }
        public static string GamePath { get; set; }

        public static Process GameProcessd;

        public MainWindow()
        {
            FindProcess();
            var ci = new CultureInfo("en-us")
            {
                NumberFormat = { NumberDecimalSeparator = "." }
            };
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;

            InitializeComponent();

            if (!InitializeNhaama())
            {
                menuPanel.IsEnabled = false;
                return;
            }

            menuPanel.DataContext = MenuModel.Instance;
            MenuModel.Instance.SwitchPageRequired += MenuModel_SwitchPageRequired;
        }
        private void FindProcess()
        {
            List<ProcessLooker.Game> GameList = new List<ProcessLooker.Game>();
            Process[] processlist = Process.GetProcesses();
            int Processcheck = 0;
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToLower().Contains("ffxiv_dx11"))
                {
                    Processcheck++;
                    GameList.Add(new ProcessLooker.Game()
                    {
                        Process = theprocess,
                        ProcessName = theprocess.ProcessName,
                        ID = theprocess.Id,
                        StartTime = theprocess.StartTime,
                        AppIcon = Extensions.IconToImageSource(System.Drawing.Icon.ExtractAssociatedIcon(theprocess.MainModule.FileName)),
                        GameDirectory = Path.GetFullPath(Path.Combine(theprocess.MainModule.FileName, "..", "..")).ToString()
                    });
                }
            }
            if (Processcheck > 1)
            {
                ProcessLooker A = new ProcessLooker(GameList);
                A.Topmost = true;
                A.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                A.ShowDialog();
                if (A.Choice == null)
                {
                    Application.Current.Shutdown();
                    return;
                }
                GamePath = A.Choice.GameDirectory;
                GameProcessd = A.Choice.Process;
            }
            else if (Processcheck == 1)
            {
                GamePath = GameList[0].GameDirectory;
                GameProcessd = GameList[0].Process;
            }
            else if (Processcheck <= 0)
            {
                ProcessLooker B = new ProcessLooker(GameList);
                B.Topmost = true;
                B.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                B.ShowDialog();
                if (B.Choice == null)
                {
                    Application.Current.Shutdown();
                    return;
                }
                GamePath = B.Choice.GameDirectory;
                GameProcessd = B.Choice.Process;
            }
        }
        private bool InitializeNhaama()
        {            
            GameProcess = GameProcessd.GetNhaamaProcess();
            if (GameProcess == null)
            {
                MessageBox.Show("Could not get the Nhaama Process for FFXIV.", "Concept Matrix", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            GameProcess.BaseProcess.EnableRaisingEvents = true;
            GameProcess.BaseProcess.Exited += (_, e) =>
            {
                MessageBox.Show(
                    "Looks like FINAL FANTASY XIV crashed or shut down.",
                    "Concept Matrix",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation
                );

                Application.Current.Shutdown();
            };

            // Success!
            return true;
        }
        private void menuPanel_RefreshClicked(object sender, EventArgs e)
        {
         //   MemoryManager.Instance.Refresh();
        }

        private void menuPanel_PageSelected(object sender, EventArgs e)
        {
           CMMenuPageSelector selector = sender as CMMenuPageSelector;
           MenuModel.MenuItemModel model = selector.DataContext as MenuModel.MenuItemModel;
           MenuModel.Instance.OnMenuSelected(model);
        }
        private void MenuModel_SwitchPageRequired(object sender, MenuModel.SwitchPageEventArgs e)
        {
            UserControl page = _pages[e.Category];
            contentFrame.Navigate(page);
            page.DataContext = e.DataContext;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 当点击窗口空白处时，使所有TextBox失去焦点
            gridSplitter.Focus();
        }

        private void MaterialWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Main = this; //(2) Defined Main (IMP)

            _pages = new Dictionary<MenuModel.MenuCategory, UserControl>()
            {
                { MenuModel.MenuCategory.Hello, new HelloPage() },
                { MenuModel.MenuCategory.Resource, new ResourcePage() },
                 { MenuModel.MenuCategory.Data, new DataPage() },
                 { MenuModel.MenuCategory.Equipment, new EquipmentPage() },
                  { MenuModel.MenuCategory.Camera, new CameraPage() },
                  { MenuModel.MenuCategory.Zone, new ZonePage() },
                  { MenuModel.MenuCategory.GPoseFilter, new GposeFilterPage() },
                  { MenuModel.MenuCategory.Matrix, new PosingMatrixPage() },
                  { MenuModel.MenuCategory.ModelData, new ModelDataPage() },
                  { MenuModel.MenuCategory.Properties, new PropertiesPage() },
                  { MenuModel.MenuCategory.EquipmentProp, new EquipmentPropertiesPage() },
            };

            MenuModel.Instance.SwitchPage(MenuModel.MenuCategory.Data, null);

        }
        public void InitializeModel()
        {
            // Create a new game model.
            gameModel = new BaseModel();
            // Set data context.
            DataContext = gameModel;

            MenuModel.Instance.ShowMessage("Make sure you're running FFXIV_DX11.exe");
        }

        private void Savebutton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //  string path = SaveSettings.Default.ProfileDirectory;
            //if (!Directory.Exists(path)) { System.IO.Directory.CreateDirectory(path); }
            Microsoft.Win32.SaveFileDialog dig = new Microsoft.Win32.SaveFileDialog();
            dig.Filter = "Concept Matrix Appearance File(*.cma)|*.cma";
           // dig.InitialDirectory = path;
            if (dig.ShowDialog() == true)
            {
                CharSaves Save1 = new CharSaves(); // Gearsave is class with all 
                string extension = System.IO.Path.GetExtension(".cma");
                string result = dig.SafeFileName.Substring(0, dig.SafeFileName.Length - extension.Length);
                Save1.Description = result;
                Save1.DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
                Save1.MainHand = new WepTuple(((WeaponArray)BaseModel.AddressList["Mainhand"]).Model, ((WeaponArray)BaseModel.AddressList["Mainhand"]).Base, ((WeaponArray)BaseModel.AddressList["Mainhand"]).Variant, ((WeaponArray)BaseModel.AddressList["Mainhand"]).Dye);
                Save1.OffHand = new WepTuple(((WeaponArray)BaseModel.AddressList["Offhand"]).Model, ((WeaponArray)BaseModel.AddressList["Offhand"]).Base, ((WeaponArray)BaseModel.AddressList["Offhand"]).Variant, ((WeaponArray)BaseModel.AddressList["Offhand"]).Dye);
                Save1.EquipmentBytes = Extensions.ByteArrayToStringU(GameProcess.ReadBytes(BaseModel.ActorData + BaseModel.Offsets.ActorEquipment, 39));
                Save1.CharacterBytes = Extensions.ByteArrayToStringU(((ByteArrayAddress)BaseModel.AddressList["ActorData"]).Value);
                Save1.characterDetails = new CharacterDetails();
                Save1.characterDetails.Height = float.Parse(((FloatAddress)BaseModel.AddressList["Height"]).Value);
                Save1.characterDetails.BustX = float.Parse(((FloatAddress)BaseModel.AddressList["BustX"]).Value);
                Save1.characterDetails.BustY = float.Parse(((FloatAddress)BaseModel.AddressList["BustY"]).Value);
                Save1.characterDetails.BustZ = float.Parse(((FloatAddress)BaseModel.AddressList["BustZ"]).Value);
                Save1.characterDetails.Voices = ((ByteAddress)BaseModel.AddressList["ActorVoice"]).Value;
                Save1.characterDetails.MuscleTone = float.Parse(((FloatAddress)BaseModel.AddressList["MuscleTone"]).Value);
                Save1.characterDetails.WeaponX = float.Parse(((FloatAddress)BaseModel.AddressList["WeaponX"]).Value);
                Save1.characterDetails.WeaponY = float.Parse(((FloatAddress)BaseModel.AddressList["WeaponY"]).Value);
                Save1.characterDetails.WeaponZ = float.Parse(((FloatAddress)BaseModel.AddressList["WeaponZ"]).Value);
                Save1.characterDetails.OffhandX = float.Parse(((FloatAddress)BaseModel.AddressList["OffhandX"]).Value);
                Save1.characterDetails.OffhandY = float.Parse(((FloatAddress)BaseModel.AddressList["OffhandY"]).Value);
                Save1.characterDetails.OffhandZ = float.Parse(((FloatAddress)BaseModel.AddressList["OffhandZ"]).Value);
                Save1.characterDetails.OffhandRed = float.Parse(((FloatAddress)BaseModel.AddressList["OffhandRed"]).Value);
                Save1.characterDetails.OffhandGreen = float.Parse(((FloatAddress)BaseModel.AddressList["OffhandGreen"]).Value);
                Save1.characterDetails.OffhandBlue = float.Parse(((FloatAddress)BaseModel.AddressList["OffhandBlue"]).Value);
                Save1.characterDetails.WeaponRed = float.Parse(((FloatAddress)BaseModel.AddressList["WeaponRed"]).Value);
                Save1.characterDetails.WeaponGreen = float.Parse(((FloatAddress)BaseModel.AddressList["WeaponGreen"]).Value);
                Save1.characterDetails.WeaponBlue = float.Parse(((FloatAddress)BaseModel.AddressList["WeaponBlue"]).Value);
                Save1.characterDetails.SkinRedPigment = float.Parse(((FloatAddress)BaseModel.AddressList["SkinRed"]).Value);
                Save1.characterDetails.SkinGreenPigment = float.Parse(((FloatAddress)BaseModel.AddressList["SkinGreen"]).Value);
                Save1.characterDetails.SkinBluePigment = float.Parse(((FloatAddress)BaseModel.AddressList["SkinBlue"]).Value);
                Save1.characterDetails.SkinRedGloss = float.Parse(((FloatAddress)BaseModel.AddressList["SkinRedGloss"]).Value);
                Save1.characterDetails.SkinGreenGloss = float.Parse(((FloatAddress)BaseModel.AddressList["SkinGreenGloss"]).Value);
                Save1.characterDetails.SkinBlueGloss = float.Parse(((FloatAddress)BaseModel.AddressList["SkinBlueGloss"]).Value);
                Save1.characterDetails.HairRedPigment = float.Parse(((FloatAddress)BaseModel.AddressList["HairRed"]).Value);
                Save1.characterDetails.HairGreenPigment = float.Parse(((FloatAddress)BaseModel.AddressList["HairGreen"]).Value);
                Save1.characterDetails.HairBluePigment = float.Parse(((FloatAddress)BaseModel.AddressList["HairBlue"]).Value);
                Save1.characterDetails.HairGlowRed = float.Parse(((FloatAddress)BaseModel.AddressList["HairRedGloss"]).Value);
                Save1.characterDetails.HairGlowGreen = float.Parse(((FloatAddress)BaseModel.AddressList["HairGreenGloss"]).Value);
                Save1.characterDetails.HairGlowBlue = float.Parse(((FloatAddress)BaseModel.AddressList["HairBlueGloss"]).Value);
                Save1.characterDetails.HighlightRedPigment = float.Parse(((FloatAddress)BaseModel.AddressList["HiglightRed"]).Value);
                Save1.characterDetails.HighlightGreenPigment = float.Parse(((FloatAddress)BaseModel.AddressList["HiglightGreen"]).Value);
                Save1.characterDetails.HighlightBluePigment = float.Parse(((FloatAddress)BaseModel.AddressList["HiglightBlue"]).Value);
                Save1.characterDetails.LeftEyeRed = float.Parse(((FloatAddress)BaseModel.AddressList["LeftEyeRed"]).Value);
                Save1.characterDetails.LeftEyeGreen = float.Parse(((FloatAddress)BaseModel.AddressList["LeftEyeGreen"]).Value);
                Save1.characterDetails.LeftEyeBlue = float.Parse(((FloatAddress)BaseModel.AddressList["LeftEyeBlue"]).Value);
                Save1.characterDetails.RightEyeRed = float.Parse(((FloatAddress)BaseModel.AddressList["RightEyeRed"]).Value);
                Save1.characterDetails.RightEyeGreen = float.Parse(((FloatAddress)BaseModel.AddressList["RightEyeGreen"]).Value);
                Save1.characterDetails.RightEyeBlue = float.Parse(((FloatAddress)BaseModel.AddressList["RightEyeBlue"]).Value);
                Save1.characterDetails.LipsR = float.Parse(((FloatAddress)BaseModel.AddressList["MouthRed"]).Value);
                Save1.characterDetails.LipsG = float.Parse(((FloatAddress)BaseModel.AddressList["MouthGreen"]).Value);
                Save1.characterDetails.LipsB = float.Parse(((FloatAddress)BaseModel.AddressList["MouthBlue"]).Value);
                Save1.characterDetails.LipsBrightness = float.Parse(((FloatAddress)BaseModel.AddressList["MouthGloss"]).Value);
                Save1.characterDetails.LimbalR = float.Parse(((FloatAddress)BaseModel.AddressList["LimbalRed"]).Value);
                Save1.characterDetails.LimbalG = float.Parse(((FloatAddress)BaseModel.AddressList["LimbalGreen"]).Value);
                Save1.characterDetails.LimbalB = float.Parse(((FloatAddress)BaseModel.AddressList["LimbalBlue"]).Value);
                string details = JsonConvert.SerializeObject(Save1, Formatting.Indented);
                File.WriteAllText(dig.FileName, details);
             //   CurrentlySaving = false;
            }
        }

        private void Loadbutton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var c = new LoadWindow();
            c.Owner = this;
            c.ShowDialog();
            if (c.Choice=="") return;
            if (c.Choice != "DatLoad")
            {
                Microsoft.Win32.OpenFileDialog dig = new Microsoft.Win32.OpenFileDialog();
                //      dig.InitialDirectory = SaveSettings.Default.ProfileDirectory;
                dig.Filter = "Concept Matrix Appearance File(*.cma;*.json)|*.cma;*.json";
                dig.DefaultExt = ".cma";
                if (dig.ShowDialog() == true)
                {
                    bool IsOld = File.ReadAllText(dig.FileName).Contains("\"value\":") ? true : false;
                    if (!IsOld)
                    {
                        CharSaves load1 = JsonConvert.DeserializeObject<CharSaves>(File.ReadAllText(dig.FileName));
                        if (c.Choice == "All" || c.Choice == "Appearance")
                        {
                            #region Actor Appearance
                            ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).WriteMemory(Extensions.StringToByteArray(load1.CharacterBytes));
                            ((ByteAddress)BaseModel.AddressList["ActorVoice"]).WriteMemory(load1.characterDetails.Voices);
                            ((FloatAddress)BaseModel.AddressList["BustX"]).WriteMemory(load1.characterDetails.BustX);
                            ((FloatAddress)BaseModel.AddressList["BustY"]).WriteMemory(load1.characterDetails.BustY);
                            ((FloatAddress)BaseModel.AddressList["BustZ"]).WriteMemory(load1.characterDetails.BustZ);
                            ((FloatAddress)BaseModel.AddressList["MuscleTone"]).WriteMemory(load1.characterDetails.MuscleTone);
                            ((FloatAddress)BaseModel.AddressList["SkinRed"]).WriteMemory(load1.characterDetails.SkinRedPigment);
                            ((FloatAddress)BaseModel.AddressList["SkinGreen"]).WriteMemory(load1.characterDetails.SkinGreenPigment);
                            ((FloatAddress)BaseModel.AddressList["SkinBlue"]).WriteMemory(load1.characterDetails.SkinBluePigment);
                            ((FloatAddress)BaseModel.AddressList["SkinRedGloss"]).WriteMemory(load1.characterDetails.SkinRedGloss);
                            ((FloatAddress)BaseModel.AddressList["SkinGreenGloss"]).WriteMemory(load1.characterDetails.SkinGreenGloss);
                            ((FloatAddress)BaseModel.AddressList["SkinBlueGloss"]).WriteMemory(load1.characterDetails.SkinBlueGloss);
                            ((FloatAddress)BaseModel.AddressList["HairRed"]).WriteMemory(load1.characterDetails.HairRedPigment);
                            ((FloatAddress)BaseModel.AddressList["HairGreen"]).WriteMemory(load1.characterDetails.HairGreenPigment);
                            ((FloatAddress)BaseModel.AddressList["HairBlue"]).WriteMemory(load1.characterDetails.HairBluePigment);
                            ((FloatAddress)BaseModel.AddressList["HairRedGloss"]).WriteMemory(load1.characterDetails.HairGlowRed);
                            ((FloatAddress)BaseModel.AddressList["HairGreenGloss"]).WriteMemory(load1.characterDetails.HairGlowGreen);
                            ((FloatAddress)BaseModel.AddressList["HairBlueGloss"]).WriteMemory(load1.characterDetails.HairGlowBlue);
                            ((FloatAddress)BaseModel.AddressList["HiglightRed"]).WriteMemory(load1.characterDetails.HighlightRedPigment);
                            ((FloatAddress)BaseModel.AddressList["HiglightGreen"]).WriteMemory(load1.characterDetails.HighlightGreenPigment);
                            ((FloatAddress)BaseModel.AddressList["HiglightBlue"]).WriteMemory(load1.characterDetails.HighlightBluePigment);
                            ((FloatAddress)BaseModel.AddressList["LeftEyeRed"]).WriteMemory(load1.characterDetails.LeftEyeRed);
                            ((FloatAddress)BaseModel.AddressList["LeftEyeGreen"]).WriteMemory(load1.characterDetails.LeftEyeGreen);
                            ((FloatAddress)BaseModel.AddressList["LeftEyeBlue"]).WriteMemory(load1.characterDetails.LeftEyeBlue);
                            ((FloatAddress)BaseModel.AddressList["RightEyeRed"]).WriteMemory(load1.characterDetails.RightEyeRed);
                            ((FloatAddress)BaseModel.AddressList["RightEyeGreen"]).WriteMemory(load1.characterDetails.RightEyeGreen);
                            ((FloatAddress)BaseModel.AddressList["RightEyeBlue"]).WriteMemory(load1.characterDetails.RightEyeBlue);
                            ((FloatAddress)BaseModel.AddressList["MouthRed"]).WriteMemory(load1.characterDetails.LipsR);
                            ((FloatAddress)BaseModel.AddressList["MouthGreen"]).WriteMemory(load1.characterDetails.LipsG);
                            ((FloatAddress)BaseModel.AddressList["MouthBlue"]).WriteMemory(load1.characterDetails.LipsB);
                            ((FloatAddress)BaseModel.AddressList["MouthGloss"]).WriteMemory(load1.characterDetails.LipsBrightness);
                            ((FloatAddress)BaseModel.AddressList["LimbalRed"]).WriteMemory(load1.characterDetails.LimbalR);
                            ((FloatAddress)BaseModel.AddressList["LimbalGreen"]).WriteMemory(load1.characterDetails.LimbalG);
                            ((FloatAddress)BaseModel.AddressList["LimbalBlue"]).WriteMemory(load1.characterDetails.LimbalB);
                            #endregion
                        }
                        if (c.Choice == "All" || c.Choice == "Equipment")
                        {
                            #region Equipment
                            ushort[] ints = new ushort[] { load1.MainHand.Item1, load1.MainHand.Item2, load1.MainHand.Item3, load1.MainHand.Item4 };
                            byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                            ((WeaponArray)BaseModel.AddressList["Mainhand"]).WriteMemoryX(bytes);

                            ints = new ushort[] { load1.OffHand.Item1, load1.OffHand.Item2, load1.OffHand.Item3, load1.OffHand.Item4 };
                            bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                            ((WeaponArray)BaseModel.AddressList["Offhand"]).WriteMemoryX(bytes);
                            byte[] EquipmentArray = Extensions.StringToByteArray(load1.EquipmentBytes);
                            //     GameProcess.WriteBytes(BaseModel.ActorData + BaseModel.Offsets.ActorEquipment, Extensions.StringToByteArray(load1.EquipmentBytes));
                            ((EquipmentArray)BaseModel.AddressList["Head"]).WriteMemoryX(EquipmentArray[0], EquipmentArray[1], EquipmentArray[2], EquipmentArray[3]);
                            ((EquipmentArray)BaseModel.AddressList["Body"]).WriteMemoryX(EquipmentArray[4], EquipmentArray[5], EquipmentArray[6], EquipmentArray[7]);
                            ((EquipmentArray)BaseModel.AddressList["Hands"]).WriteMemoryX(EquipmentArray[8], EquipmentArray[9], EquipmentArray[10], EquipmentArray[11]);
                            ((EquipmentArray)BaseModel.AddressList["Legs"]).WriteMemoryX(EquipmentArray[12], EquipmentArray[13], EquipmentArray[14], EquipmentArray[15]);
                            ((EquipmentArray)BaseModel.AddressList["Feet"]).WriteMemoryX(EquipmentArray[16], EquipmentArray[17], EquipmentArray[18], EquipmentArray[19]);
                            ((EquipmentArray)BaseModel.AddressList["Ears"]).WriteMemoryX(EquipmentArray[20], EquipmentArray[21], EquipmentArray[22], 0);
                            ((EquipmentArray)BaseModel.AddressList["Neck"]).WriteMemoryX(EquipmentArray[24], EquipmentArray[25], EquipmentArray[26], 0);
                            ((EquipmentArray)BaseModel.AddressList["Wrist"]).WriteMemoryX(EquipmentArray[28], EquipmentArray[29], EquipmentArray[30], 0);
                            ((EquipmentArray)BaseModel.AddressList["RRing"]).WriteMemoryX(EquipmentArray[32], EquipmentArray[33], EquipmentArray[34], 0);
                            ((EquipmentArray)BaseModel.AddressList["LRing"]).WriteMemoryX(EquipmentArray[36], EquipmentArray[37], EquipmentArray[38], 0);

                            ((FloatAddress)BaseModel.AddressList["WeaponX"]).WriteMemory(load1.characterDetails.WeaponX);
                            ((FloatAddress)BaseModel.AddressList["WeaponY"]).WriteMemory(load1.characterDetails.WeaponY);
                            ((FloatAddress)BaseModel.AddressList["WeaponZ"]).WriteMemory(load1.characterDetails.WeaponZ);
                            ((FloatAddress)BaseModel.AddressList["OffhandX"]).WriteMemory(load1.characterDetails.OffhandX);
                            ((FloatAddress)BaseModel.AddressList["OffhandY"]).WriteMemory(load1.characterDetails.OffhandY);
                            ((FloatAddress)BaseModel.AddressList["OffhandZ"]).WriteMemory(load1.characterDetails.OffhandZ);
                            ((FloatAddress)BaseModel.AddressList["OffhandRed"]).WriteMemory(load1.characterDetails.OffhandRed);
                            ((FloatAddress)BaseModel.AddressList["OffhandGreen"]).WriteMemory(load1.characterDetails.OffhandGreen);
                            ((FloatAddress)BaseModel.AddressList["OffhandBlue"]).WriteMemory(load1.characterDetails.OffhandBlue);
                            ((FloatAddress)BaseModel.AddressList["WeaponRed"]).WriteMemory(load1.characterDetails.WeaponRed);
                            ((FloatAddress)BaseModel.AddressList["WeaponGreen"]).WriteMemory(load1.characterDetails.WeaponGreen);
                            ((FloatAddress)BaseModel.AddressList["WeaponBlue"]).WriteMemory(load1.characterDetails.WeaponBlue);
                            #endregion
                        }
                    }
                    else
                    {
                        OldCharSaves load1 = JsonConvert.DeserializeObject<OldCharSaves>(File.ReadAllText(dig.FileName));
                        if (c.Choice == "All" || c.Choice == "Appearance")
                        {
                            #region Actor Appearance
                            ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).WriteMemory(Extensions.StringToByteArray(load1.CharacterBytes));
                            ((ByteAddress)BaseModel.AddressList["ActorVoice"]).WriteMemory(load1.characterDetails.Voices.value);
                            ((FloatAddress)BaseModel.AddressList["BustX"]).WriteMemory(load1.characterDetails.BustX.value);
                            ((FloatAddress)BaseModel.AddressList["BustY"]).WriteMemory(load1.characterDetails.BustY.value);
                            ((FloatAddress)BaseModel.AddressList["BustZ"]).WriteMemory(load1.characterDetails.BustZ.value);
                            ((FloatAddress)BaseModel.AddressList["MuscleTone"]).WriteMemory(load1.characterDetails.MuscleTone.value);
                            ((FloatAddress)BaseModel.AddressList["SkinRed"]).WriteMemory(load1.characterDetails.SkinRedPigment.value);
                            ((FloatAddress)BaseModel.AddressList["SkinGreen"]).WriteMemory(load1.characterDetails.SkinGreenPigment.value);
                            ((FloatAddress)BaseModel.AddressList["SkinBlue"]).WriteMemory(load1.characterDetails.SkinBluePigment.value);
                            ((FloatAddress)BaseModel.AddressList["SkinRedGloss"]).WriteMemory(load1.characterDetails.SkinRedGloss.value);
                            ((FloatAddress)BaseModel.AddressList["SkinGreenGloss"]).WriteMemory(load1.characterDetails.SkinGreenGloss.value);
                            ((FloatAddress)BaseModel.AddressList["SkinBlueGloss"]).WriteMemory(load1.characterDetails.SkinBlueGloss.value);
                            ((FloatAddress)BaseModel.AddressList["HairRed"]).WriteMemory(load1.characterDetails.HairRedPigment.value);
                            ((FloatAddress)BaseModel.AddressList["HairGreen"]).WriteMemory(load1.characterDetails.HairGreenPigment.value);
                            ((FloatAddress)BaseModel.AddressList["HairBlue"]).WriteMemory(load1.characterDetails.HairBluePigment.value);
                            ((FloatAddress)BaseModel.AddressList["HairRedGloss"]).WriteMemory(load1.characterDetails.HairGlowRed.value);
                            ((FloatAddress)BaseModel.AddressList["HairGreenGloss"]).WriteMemory(load1.characterDetails.HairGlowGreen.value);
                            ((FloatAddress)BaseModel.AddressList["HairBlueGloss"]).WriteMemory(load1.characterDetails.HairGlowBlue.value);
                            ((FloatAddress)BaseModel.AddressList["HiglightRed"]).WriteMemory(load1.characterDetails.HighlightRedPigment.value);
                            ((FloatAddress)BaseModel.AddressList["HiglightGreen"]).WriteMemory(load1.characterDetails.HighlightGreenPigment.value);
                            ((FloatAddress)BaseModel.AddressList["HiglightBlue"]).WriteMemory(load1.characterDetails.HighlightBluePigment.value);
                            ((FloatAddress)BaseModel.AddressList["LeftEyeRed"]).WriteMemory(load1.characterDetails.LeftEyeRed.value);
                            ((FloatAddress)BaseModel.AddressList["LeftEyeGreen"]).WriteMemory(load1.characterDetails.LeftEyeGreen.value);
                            ((FloatAddress)BaseModel.AddressList["LeftEyeBlue"]).WriteMemory(load1.characterDetails.LeftEyeBlue.value);
                            ((FloatAddress)BaseModel.AddressList["RightEyeRed"]).WriteMemory(load1.characterDetails.RightEyeRed.value);
                            ((FloatAddress)BaseModel.AddressList["RightEyeGreen"]).WriteMemory(load1.characterDetails.RightEyeGreen.value);
                            ((FloatAddress)BaseModel.AddressList["RightEyeBlue"]).WriteMemory(load1.characterDetails.RightEyeBlue.value);
                            ((FloatAddress)BaseModel.AddressList["MouthRed"]).WriteMemory(load1.characterDetails.LipsR.value);
                            ((FloatAddress)BaseModel.AddressList["MouthGreen"]).WriteMemory(load1.characterDetails.LipsG.value);
                            ((FloatAddress)BaseModel.AddressList["MouthBlue"]).WriteMemory(load1.characterDetails.LipsB.value);
                            ((FloatAddress)BaseModel.AddressList["MouthGloss"]).WriteMemory(load1.characterDetails.LipsBrightness.value);
                            ((FloatAddress)BaseModel.AddressList["LimbalRed"]).WriteMemory(load1.characterDetails.LimbalR.value);
                            ((FloatAddress)BaseModel.AddressList["LimbalGreen"]).WriteMemory(load1.characterDetails.LimbalG.value);
                            ((FloatAddress)BaseModel.AddressList["LimbalBlue"]).WriteMemory(load1.characterDetails.LimbalB.value);
                            #endregion
                        }
                        if (c.Choice == "All" || c.Choice == "Equipment")
                        {
                            #region Equipment
                            ushort[] ints = new ushort[] { load1.MainHand.Item1, load1.MainHand.Item2, load1.MainHand.Item3, load1.MainHand.Item4 };
                            byte[] bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                            ((WeaponArray)BaseModel.AddressList["Mainhand"]).WriteMemoryX(bytes);

                            ints = new ushort[] { load1.OffHand.Item1, load1.OffHand.Item2, load1.OffHand.Item3, load1.OffHand.Item4 };
                            bytes = ints.SelectMany(BitConverter.GetBytes).ToArray();
                            ((WeaponArray)BaseModel.AddressList["Offhand"]).WriteMemoryX(bytes);
                            byte[] EquipmentArray = Extensions.StringToByteArray(load1.EquipmentBytes);
                            //     GameProcess.WriteBytes(BaseModel.ActorData + BaseModel.Offsets.ActorEquipment, Extensions.StringToByteArray(load1.EquipmentBytes));
                            ((EquipmentArray)BaseModel.AddressList["Head"]).WriteMemoryX(EquipmentArray[0], EquipmentArray[1], EquipmentArray[2], EquipmentArray[3]);
                            ((EquipmentArray)BaseModel.AddressList["Body"]).WriteMemoryX(EquipmentArray[4], EquipmentArray[5], EquipmentArray[6], EquipmentArray[7]);
                            ((EquipmentArray)BaseModel.AddressList["Hands"]).WriteMemoryX(EquipmentArray[8], EquipmentArray[9], EquipmentArray[10], EquipmentArray[11]);
                            ((EquipmentArray)BaseModel.AddressList["Legs"]).WriteMemoryX(EquipmentArray[12], EquipmentArray[13], EquipmentArray[14], EquipmentArray[15]);
                            ((EquipmentArray)BaseModel.AddressList["Feet"]).WriteMemoryX(EquipmentArray[16], EquipmentArray[17], EquipmentArray[18], EquipmentArray[19]);
                            ((EquipmentArray)BaseModel.AddressList["Ears"]).WriteMemoryX(EquipmentArray[20], EquipmentArray[21], EquipmentArray[22], 0);
                            ((EquipmentArray)BaseModel.AddressList["Neck"]).WriteMemoryX(EquipmentArray[24], EquipmentArray[25], EquipmentArray[26], 0);
                            ((EquipmentArray)BaseModel.AddressList["Wrist"]).WriteMemoryX(EquipmentArray[28], EquipmentArray[29], EquipmentArray[30], 0);
                            ((EquipmentArray)BaseModel.AddressList["RRing"]).WriteMemoryX(EquipmentArray[32], EquipmentArray[33], EquipmentArray[34], 0);
                            ((EquipmentArray)BaseModel.AddressList["LRing"]).WriteMemoryX(EquipmentArray[36], EquipmentArray[37], EquipmentArray[38], 0);

                            ((FloatAddress)BaseModel.AddressList["WeaponX"]).WriteMemory(load1.characterDetails.WeaponX.value);
                            ((FloatAddress)BaseModel.AddressList["WeaponY"]).WriteMemory(load1.characterDetails.WeaponY.value);
                            ((FloatAddress)BaseModel.AddressList["WeaponZ"]).WriteMemory(load1.characterDetails.WeaponZ.value);
                            ((FloatAddress)BaseModel.AddressList["OffhandX"]).WriteMemory(load1.characterDetails.OffhandX.value);
                            ((FloatAddress)BaseModel.AddressList["OffhandY"]).WriteMemory(load1.characterDetails.OffhandY.value);
                            ((FloatAddress)BaseModel.AddressList["OffhandZ"]).WriteMemory(load1.characterDetails.OffhandZ.value);
                            ((FloatAddress)BaseModel.AddressList["OffhandRed"]).WriteMemory(load1.characterDetails.OffhandRed.value);
                            ((FloatAddress)BaseModel.AddressList["OffhandGreen"]).WriteMemory(load1.characterDetails.OffhandGreen.value);
                            ((FloatAddress)BaseModel.AddressList["OffhandBlue"]).WriteMemory(load1.characterDetails.OffhandBlue.value);
                            ((FloatAddress)BaseModel.AddressList["WeaponRed"]).WriteMemory(load1.characterDetails.WeaponRed.value);
                            ((FloatAddress)BaseModel.AddressList["WeaponGreen"]).WriteMemory(load1.characterDetails.WeaponGreen.value);
                            ((FloatAddress)BaseModel.AddressList["WeaponBlue"]).WriteMemory(load1.characterDetails.WeaponBlue.value);
                            #endregion
                        }
                    }
                }
                else return;
            }
            else
            {
                CharacterSaveWindow SaveWindow = new CharacterSaveWindow();
                SaveWindow.Owner = this;
                SaveWindow.ShowDialog();
                if (SaveWindow.Choice != null) ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).WriteMemory(SaveWindow.Choice);
                else return;

            }
        }

        private void UncheckButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (KeyValuePair<string, MemoryInterface> entry in BaseModel.AddressList)
            {
                entry.Value.Freeze = false;
            }
             ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).UnfreezeArray();
        }
    }
}