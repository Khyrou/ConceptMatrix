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
    /// Interaction logic for ModelDataPage.xaml
    /// </summary>
    public partial class ModelDataPage : UserControl
    {
        public static ModelDataPage Page;
        public ModelDataPage()
        {
            InitializeComponent();
            Page = this;
        }

        private void ForceButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmoteFlyout.IsOpen)
            {
                if (Combo1.SelectedIndex != 1)
                {
                    Combo1.SelectedIndex = 1;
                }
                else EmoteFlyout.IsOpen = !EmoteFlyout.IsOpen;
            }
            else
            {
                EmoteFlyout.IsOpen = !EmoteFlyout.IsOpen;
                Combo1.SelectedIndex = 1;
            }
        }

        private void IdleButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmoteFlyout.IsOpen)
            {
                if (Combo1.SelectedIndex != 0)
                {
                    Combo1.SelectedIndex = 0;
                }
                else EmoteFlyout.IsOpen = !EmoteFlyout.IsOpen;
            }
            else
            {
                EmoteFlyout.IsOpen = !EmoteFlyout.IsOpen;
                Combo1.SelectedIndex = 0;
            }
        }

        private void SearchPlayerEmote_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchPlayerEmote.Text.ToLower();
            PlayerList.Items.Clear();
            foreach (ExdData.Emote parse in ExdData.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (parse.Realist == true)
                {
                    PlayerList.Items.Add(new ExdData.Emote
                    {
                        Index = Convert.ToInt32(parse.Index),
                        Name = parse.Name.ToString()
                    });
                }
        }

        private void SearchBatteEmote_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchBatteEmote.Text.ToLower();
            BattleList.Items.Clear();
            foreach (ExdData.Emote parse in ExdData.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (parse.BattleReal == true)
                {
                    BattleList.Items.Add(new ExdData.Emote
                    {
                        Index = Convert.ToInt32(parse.Index),
                        Name = parse.Name.ToString()
                    });
                }
        }

        private void SearchMonsterEmote_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchMonsterEmote.Text.ToLower();
            MonsterList.Items.Clear();
            foreach (ExdData.Emote parse in ExdData.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                if (parse.SpeacialReal == true)
                {
                    MonsterList.Items.Add(new ExdData.Emote
                    {
                        Index = Convert.ToInt32(parse.Index),
                        Name = parse.Name.ToString()
                    });
                }
        }

        private void SearchAllEmote_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = SearchAllEmote.Text.ToLower();
            AllList.Items.Clear();
            foreach (ExdData.Emote parse in ExdData.Emotesx.Where(g => g.Name.ToLower().Contains(filter)))
                AllList.Items.Add(new ExdData.Emote
                {
                    Index = Convert.ToInt32(parse.Index),
                    Name = parse.Name.ToString()
                });
        }

        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayerList.SelectedCells.Count > 0)
            {
                if (PlayerList.SelectedItem == null)
                    return;
             //   Console.WriteLine(Combo1.SelectedIndex);
                if (Combo1.SelectedIndex == 0)
                {
                    var Value = (ExdData.Emote)PlayerList.SelectedItem;
                    BaseModel.AddressList["IdleAnimation"].WriteMemory(Value.Index.ToString());
                }
                if (Combo1.SelectedIndex == 1)
                {
                    var Value = (ExdData.Emote)PlayerList.SelectedItem;
                    BaseModel.AddressList["ForceAnimation"].WriteMemory(Value.Index.ToString());
                }
            }
        }

        private void BattleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BattleList.SelectedCells.Count > 0)
            {
                if (BattleList.SelectedItem == null)
                    return;
                //   Console.WriteLine(Combo1.SelectedIndex);
                if (Combo2.SelectedIndex == 0)
                {
                    var Value = (ExdData.Emote)BattleList.SelectedItem;
                    BaseModel.AddressList["IdleAnimation"].WriteMemory(Value.Index.ToString());
                }
                if (Combo2.SelectedIndex == 1)
                {
                    var Value = (ExdData.Emote)BattleList.SelectedItem;
                    BaseModel.AddressList["ForceAnimation"].WriteMemory(Value.Index.ToString());
                }
            }
        }

        private void MonsterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonsterList.SelectedCells.Count > 0)
            {
                if (MonsterList.SelectedItem == null)
                    return;
                //   Console.WriteLine(Combo1.SelectedIndex);
                if (Combo3.SelectedIndex == 0)
                {
                    var Value = (ExdData.Emote)MonsterList.SelectedItem;
                    BaseModel.AddressList["IdleAnimation"].WriteMemory(Value.Index.ToString());
                }
                if (Combo3.SelectedIndex == 1)
                {
                    var Value = (ExdData.Emote)MonsterList.SelectedItem;
                    BaseModel.AddressList["ForceAnimation"].WriteMemory(Value.Index.ToString());
                }
            }
        }

        private void AllList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllList.SelectedCells.Count > 0)
            {
                if (AllList.SelectedItem == null)
                    return;
                //   Console.WriteLine(Combo1.SelectedIndex);
                if (Combo4.SelectedIndex == 0)
                {
                    var Value = (ExdData.Emote)AllList.SelectedItem;
                    BaseModel.AddressList["IdleAnimation"].WriteMemory(Value.Index.ToString());
                }
                if (Combo4.SelectedIndex == 1)
                {
                    var Value = (ExdData.Emote)AllList.SelectedItem;
                    BaseModel.AddressList["ForceAnimation"].WriteMemory(Value.Index.ToString());
                }
            }
        }

        private void AnimSetZero_Click(object sender, RoutedEventArgs e)
        {
			((FloatAddress)BaseModel.AddressList["AnimationSpeed"]).WriteMemory((float)0);
        }
    }
}
