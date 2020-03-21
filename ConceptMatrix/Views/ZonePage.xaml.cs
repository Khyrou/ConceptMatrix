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
    /// Interaction logic for ZonePage.xaml
    /// </summary>
    public partial class ZonePage : UserControl
    {
        public static ZonePage Zonepage;
        private List<ExdData.Weather> AllowedWeathers;
        private bool isUserInteraction = false;
        public ZonePage()
        {
            InitializeComponent();
            Zonepage = this;
        }

        private void TimeResetButton_Click(object sender, RoutedEventArgs e)
        {
            TimeUPDown.Value = 0;
        }

        private void RefreshWeather_Click(object sender, RoutedEventArgs e)
        {
            var territory = MainWindow.GameProcess.ReadInt32(BaseModel.TerritoryPointer, BaseModel.Offsets.Territory);

            if (!ExdData.TerritoryTypes.ContainsKey(territory))
            {
                MessageBox.Show("Could not find your current zone. Make sure you are using the latest version.", "Concept Matrix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ExdData.TerritoryTypes[territory].WeatherRate == null)
            {
                MessageBox.Show("Setting weather is not supported for your current zone.", "Concept Matrix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            WeatherSelector(ExdData.TerritoryTypes[territory].WeatherRate.AllowedWeathers, MainWindow.GameProcess.ReadByte(BaseModel.WeatherPointer + BaseModel.Offsets.Weather));
        }
        public void WeatherSelector(List<ExdData.Weather> allowedWeathers, int currentWeather)
        {

            AllowedWeathers = allowedWeathers;
            WeatherBox.Items.Clear();
            for (int i = 0; i < allowedWeathers.Count; i++)
            {
                if (allowedWeathers[i].Index == 0 || allowedWeathers[i].Icon == null)
                {
                    WeatherBox.Items.Add(new ExdData.Weather
                    {
                        Index = Convert.ToInt32(allowedWeathers[i].Index),
                        Name = allowedWeathers[i].Name.ToString(),
                        Icon = null
                    });
                }
                else
                {
                    WeatherBox.Items.Add(new ExdData.Weather
                    {
                        Index = Convert.ToInt32(allowedWeathers[i].Index),
                        Name = allowedWeathers[i].Name.ToString(),
                        Icon = allowedWeathers[i].Icon
                    });
                }

                if (allowedWeathers[i].Index == currentWeather)
                    WeatherBox.SelectedIndex = i;
            }
        }

        private void BGMButton_Click(object sender, RoutedEventArgs e)
        {
            BGMFlyOut.IsOpen = !BGMFlyOut.IsOpen;
        }

        private void SearchBGM_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchBGM.Text.ToLower();
            BGMBox.Items.Clear();

            foreach (KeyValuePair<int,ExdData.BGM> xD in ExdData.BGMs.Where(g => g.Value.Name.ToLower().Contains(filter)))
                BGMBox.Items.Add(new ExdData.BGM
                {
                    Index = Convert.ToInt32(xD.Value.Index),
                    Name = xD.Value.Name.ToString(),
                    Location = xD.Value.Location.ToString(),
                });
        }

        private void BGMBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BGMBox.SelectedCells.Count > 0)
            {
                if (BGMBox.SelectedItem == null)
                    return;
                var Value = (ExdData.BGM)BGMBox.SelectedItem;
                MainWindow.GameProcess.Write(Value.Index, BaseModel.MusicPointer, BaseModel.Offsets.Music);
                MainWindow.GameProcess.Write(Value.Index, BaseModel.MusicPointer, BaseModel.Offsets.Music2);
            }
        }

        private void WeatherBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isUserInteraction)
            {
                if (WeatherBox.SelectedItem == null) return;
                ((ByteAddress)BaseModel.AddressList["Weather"]).WriteMemory((byte)AllowedWeathers[WeatherBox.SelectedIndex].Index);
            }
            isUserInteraction = false;
        }

        private void WeatherBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isUserInteraction = true;
        }

        private void BGMApply_Click(object sender, RoutedEventArgs e)
        {
            var Value = int.Parse(BGMTextBox.Text);
            MainWindow.GameProcess.Write(Value, BaseModel.MusicPointer, BaseModel.Offsets.Music);
            MainWindow.GameProcess.Write(Value, BaseModel.MusicPointer, BaseModel.Offsets.Music2);
        }

        private void RenderToggle_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.GameProcess.WriteBytes(BaseModel.RenderActor1.Adressed, 0x90, 0x90, 0x90, 0x90, 0x90);
        }

        private void RenderToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            MainWindow.GameProcess.WriteBytes(BaseModel.RenderActor1.Adressed, 0xE9, 0xB8, 0x00, 0x00, 0x00);
        }

        private void RenderButton_Click(object sender, RoutedEventArgs e)
        {
            var Old = MainWindow.GameProcess.ReadBytes(BaseModel.RenderActor2.Adressed, 2);
            MainWindow.GameProcess.WriteBytes(BaseModel.RenderActor2.Adressed, 0x00, 0x00);
            Task.Delay(150).Wait();
            MainWindow.GameProcess.WriteBytes(BaseModel.RenderActor2.Adressed, Old);
        }
    }
}
