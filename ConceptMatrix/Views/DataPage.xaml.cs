using ConceptMatrix.Backend;
using Microsoft.VisualBasic.FileIO;
using SaintCoinach;
using SaintCoinach.Xiv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using GearTuple = System.Tuple<ushort, byte, byte>;
using WepTuple = System.Tuple<ushort, ushort, ushort, ushort>;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for DataPage.xaml
    /// </summary>
    public partial class DataPage : UserControl
    {
        private SaintCoinach.Xiv.Item[] AllEquipment;
        public DataPage()
        {
            InitializeComponent();
            SheetName.Text = "Starting up SaintCoinach...";
          //  const string GameDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\FINAL FANTASY XIV Online";
            ARealmReversed Realm = new ARealmReversed(MainWindow.GamePath, SaintCoinach.Ex.Language.English);
            Realm.Packs.GetPack(new SaintCoinach.IO.PackIdentifier("exd", SaintCoinach.IO.PackIdentifier.DefaultExpansion, 0)).KeepInMemory = false;

            var Race = Realm.GameData.GetSheet<SaintCoinach.Xiv.Race>();
            var Tribe = Realm.GameData.GetSheet<SaintCoinach.Xiv.Tribe>();
            var Items = Realm.GameData.GetSheet<SaintCoinach.Xiv.Item>();
            var Stains = Realm.GameData.GetSheet<SaintCoinach.Xiv.Stain>();
            var ENpcBase = Realm.GameData.GetSheet<SaintCoinach.Xiv.ENpcBase>();
            var Territory = Realm.GameData.GetSheet<SaintCoinach.Xiv.TerritoryType>();
            var Weather = Realm.GameData.GetSheet<SaintCoinach.Xiv.Weather>();
            var CharaMakeCustomize = Realm.GameData.GetSheet<SaintCoinach.Xiv.CharaMakeCustomize>();
            var CharaMakeType = Realm.GameData.GetSheet<SaintCoinach.Xiv.CharaMakeType>();
            var eNpcResidents = Realm.GameData.GetSheet<SaintCoinach.Xiv.ENpcResident>();
            var TitleSheet = Realm.GameData.GetSheet<SaintCoinach.Xiv.Title>();
            var StatusSheet = Realm.GameData.GetSheet < SaintCoinach.Xiv.Status>();
            HashSet<byte> StatusIds = new HashSet<byte>();

            AllEquipment = Realm.GameData.GetSheet<SaintCoinach.Xiv.Item>().ToArray();
            ExdData.Items = new Dictionary<int, ExdData.Item>();
            ExdData.Residents = new Dictionary<int, ExdData.Resident>();
            ExdData.CharaMakeFeatures = new Dictionary<int, ExdData.CharaMakeCustomizeFeature>();
            ExdData.CharaMakeFeatures2 = new Dictionary<int, ExdData.CharaMakeCustomizeFeature2>();
            ExdData.TerritoryTypes = new Dictionary<int, ExdData.TerritoryType>();
            ExdData.BGMs = new Dictionary<int, ExdData.BGM>();
            ExdData.Emotes = new Dictionary<int, ExdData.Emote>();
            ExdData.Monsters = new Dictionary<int, ExdData.Monster>();
            ExdData.Stain = new List<string>();

            Task.Run(() =>
            {

                var size = AllEquipment.Length;

                for (int i = 0; i < size; i++)
                {
                    if (AllEquipment[i].EquipSlotCategory.Key == 0)
                    {
                        if (AllEquipment[i].Key == 0)
                        {
                            var itemX = new ExdData.Item
                            {
                                Index = AllEquipment[i].Key,
                                Name = AllEquipment[i].Name,
                                ClassJobCategory = AllEquipment[i].ClassJobCategory,
                                EquipSlotCategory = AllEquipment[i].EquipSlotCategory,
                                ModelMain = AllEquipment[i].ModelMain,
                                ModelSub = AllEquipment[i].ModelSub,
                                IsDyeable = AllEquipment[i].IsDyeable,
                            };
                            if (AllEquipment[i].Key == 0) itemX.Name = "None";
                            if (AllEquipment[i].Icon == null) itemX.Icon = null;
                            else itemX.Icon = AllEquipment[i].Icon;
                            App.AllEquipmentX.Add(itemX);
                        }
                        continue;
                    }

                    var item = new ExdData.Item
                    {
                        Index = AllEquipment[i].Key,
                        Name = AllEquipment[i].Name,
                        ClassJobCategory = AllEquipment[i].ClassJobCategory,
                        EquipSlotCategory = AllEquipment[i].EquipSlotCategory,
                        ModelMain = AllEquipment[i].ModelMain,
                        ModelSub = AllEquipment[i].ModelSub,
                        IsDyeable = AllEquipment[i].IsDyeable,
                    };
                    if (AllEquipment[i].Key == 0) item.Name = "None";
                    if (AllEquipment[i].Icon == null) item.Icon = null;
                    else item.Icon = AllEquipment[i].Icon;
                    App.AllEquipmentX.Add(item);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        SheetName.Text = "Equipment";
                        PB.Value = (i * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }

                for (int i = 0; i < Race.Count; i++)
                {
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        if (i == 0) ResourcePage.Resourcepage.RaceBox.Items.Add("None");
                        else ResourcePage.Resourcepage.RaceBox.Items.Add(Race[i].Feminine);

                        SheetName.Text = Race.Name;
                        PB.Value = (i * 100) / Race.Count;
                        Percentage.Text = $"{PB.Value}%";
                    });
                }
                for (int i = 0; i < Tribe.Count; i++)
                {
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        if (i == 0) ResourcePage.Resourcepage.ClanBox.Items.Add("None");
                        else ResourcePage.Resourcepage.ClanBox.Items.Add(Tribe[i].Feminine);
                        SheetName.Text = Tribe.Name;
                        PB.Value = (i * 100) / Tribe.Count;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
                size = Stains.Count;
                for (int i = 0; i < size; i++)
                {
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        string DyeName = Stains[i].Name;
                        if (DyeName.Length <= 0) DyeName = "None";
                        ExdData.Stain.Add(DyeName);
                        SheetName.Text = "Dyes";
                        PB.Value = (i * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
                size = Territory.Count;
                int TerritoryI = 0;
                foreach (var TerritoryIndex in Territory)
                {
                    TerritoryI++;
                    ExdData.TerritoryType territory = new ExdData.TerritoryType
                    {
                        Index = TerritoryIndex.Key,
                        WeatherRate = new ExdData.WeatherRate()
                    };
                    territory.WeatherRate.AllowedWeathers = new List<ExdData.Weather>();
                    foreach (var WeatherRate in TerritoryIndex.WeatherRate.PossibleWeathers)
                    {
                        territory.WeatherRate.Index = WeatherRate.Key;
                        //   Test.Icon
                        if (WeatherRate.Key != 0) territory.WeatherRate.AllowedWeathers.Add(new ExdData.Weather() { Index = WeatherRate.Key, Name = WeatherRate.Name, Icon = WeatherRate.Icon });
                        else territory.WeatherRate.AllowedWeathers.Add(new ExdData.Weather() { Index = WeatherRate.Key, Name = "None", Icon = null });
                    }
                    if (TerritoryIndex.RegionPlaceName.Name == "Norvrandt")
                    {
                        territory.WeatherRate.AllowedWeathers.Add(new ExdData.Weather() { Index = 118, Name = "Everlasting Light #1", Icon = Weather[118].Icon });
                        territory.WeatherRate.AllowedWeathers.Add(new ExdData.Weather() { Index = 129, Name = "Everlasting Light #2", Icon = Weather[129].Icon });
                    }
                    ExdData.TerritoryTypes.Add(TerritoryIndex.Key, territory);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        SheetName.Text = "Territory";
                        PB.Value = (TerritoryI * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
                size = Weather.Count;
                for (int i = 0; i < size; i++)
                {
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        byte[] Bytes = { (byte)Weather[i].Key, (byte)Weather[i].Key };
                        if (Weather[i].Icon != null)
                        {
                            ZonePage.Zonepage.WeatherBox2.Items.Add(new ExdData.Weather
                            {
                                Index = Convert.ToInt32(Weather[i].Key),
                                Key = BitConverter.ToUInt16(Bytes, 0),
                                Name = Weather[i].Name.ToString(),
                                Icon = Weather[i].Icon,
                            });
                        }
                        else
                        {
                            ZonePage.Zonepage.WeatherBox2.Items.Add(new ExdData.Weather
                            {
                                Index = Convert.ToInt32(Weather[i].Key),
                                Key = BitConverter.ToUInt16(Bytes, 0),
                                Name = Weather[i].Name.ToString(),
                                Icon = null,
                            });
                        }
                        SheetName.Text = "Weather";
                        PB.Value = (i * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }

                size = eNpcResidents.Count+1000000;
                for (int i = 1000000; i < size; i++)
                {
                    ExdData.Residents.Add(eNpcResidents[i].Key, new ExdData.Resident { Index = eNpcResidents[i].Key, Name = eNpcResidents[i].Singular });
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        SheetName.Text = "NPC Names";
                        PB.Value = ((i- 1000000) * 100) / (size- 1000000);
                        Percentage.Text = $"{PB.Value}%";
                    });
                }
                size = ENpcBase.Count+1000000;
                for (int i = 1000000; i < size; i++)
                {
                    GearSet gear = new GearSet();
                    List<byte> customize = new List<byte>();
                    customize.AddRange(new List<byte>() { 
                        Convert.ToByte(ENpcBase[i].Race.Key), Convert.ToByte(ENpcBase[i].Gender)
                       , Convert.ToByte(ENpcBase[i].BodyType), Convert.ToByte(ENpcBase[i].Height)
                   , Convert.ToByte(ENpcBase[i].Tribe.Key), Convert.ToByte(ENpcBase[i].Face) , Convert.ToByte(ENpcBase[i].HairStyle), Convert.ToByte(ENpcBase[i].HairHighlight)
                   , Convert.ToByte(ENpcBase[i].SkinColor), Convert.ToByte(ENpcBase[i].EyeHeterochromia), Convert.ToByte(ENpcBase[i].HairColor), Convert.ToByte(ENpcBase[i].HairHighlightColor)
                   , Convert.ToByte(ENpcBase[i].FacialFeature), Convert.ToByte(ENpcBase[i].FacialFeatureColor), Convert.ToByte(ENpcBase[i].Eyebrows), Convert.ToByte(ENpcBase[i].EyeColor)
                   , Convert.ToByte(ENpcBase[i].EyeShape), Convert.ToByte(ENpcBase[i].Nose), Convert.ToByte(ENpcBase[i].Jaw), Convert.ToByte(ENpcBase[i].Mouth)
                   , Convert.ToByte(ENpcBase[i].LipColor), Convert.ToByte(ENpcBase[i].BustOrTone1), Convert.ToByte(ENpcBase[i].ExtraFeature1), Convert.ToByte(ENpcBase[i].ExtraFeature2OrBust)
                   , Convert.ToByte(ENpcBase[i].FacePaint), Convert.ToByte(ENpcBase[i].FacePaintColor) });
                    gear.Customize = customize.ToArray();
                    gear.ModelChara = ENpcBase[i].ModelChara.Key;
                    if (ENpcBase[i].NpcEquip.Key > 0)
                    {
                        gear.MainWep = new WepTuple(ENpcBase[i].NpcEquip.ModelMain.Value1, ENpcBase[i].NpcEquip.ModelMain.Value2, ENpcBase[i].NpcEquip.ModelMain.Value3, (ushort)ENpcBase[i].NpcEquip.DyeMain.Key);
                        gear.OffWep = new WepTuple(ENpcBase[i].NpcEquip.ModelSub.Value1, ENpcBase[i].NpcEquip.ModelSub.Value2, ENpcBase[i].NpcEquip.ModelSub.Value3, (ushort)ENpcBase[i].NpcEquip.DyeOff.Key);
                        gear.HeadGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelHead[0] + ENpcBase[i].NpcEquip.ModelHead[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelHead[2], (byte)ENpcBase[i].NpcEquip.DyeHead.Key);
                        gear.BodyGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelBody[0] + ENpcBase[i].NpcEquip.ModelBody[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelBody[2], (byte)ENpcBase[i].NpcEquip.DyeBody.Key);
                        gear.HandsGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelHands[0] + ENpcBase[i].NpcEquip.ModelHands[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelHands[2], (byte)ENpcBase[i].NpcEquip.DyeHands.Key);
                        gear.LegsGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelLegs[0] + ENpcBase[i].NpcEquip.ModelLegs[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelLegs[2], (byte)ENpcBase[i].NpcEquip.DyeLegs.Key);
                        gear.FeetGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelFeet[0] + ENpcBase[i].NpcEquip.ModelFeet[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelFeet[2], (byte)ENpcBase[i].NpcEquip.DyeFeet.Key);
                        gear.EarGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelEars[0] + ENpcBase[i].NpcEquip.ModelEars[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelEars[2], 0);
                        gear.NeckGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelNeck[0] + ENpcBase[i].NpcEquip.ModelNeck[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelNeck[2], 0);
                        gear.WristGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelWrists[0] + ENpcBase[i].NpcEquip.ModelWrists[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelWrists[2], 0);
                        gear.RRingGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelRightRing[0] + ENpcBase[i].NpcEquip.ModelRightRing[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelRightRing[2], 0);
                        gear.LRingGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].NpcEquip.ModelLeftRing[0] + ENpcBase[i].NpcEquip.ModelLeftRing[1] * 256)), (byte)ENpcBase[i].NpcEquip.ModelLeftRing[2], 0);
                    }
                    else
                    {
                        gear.MainWep = new WepTuple(ENpcBase[i].ModelMain.Value1, ENpcBase[i].ModelMain.Value2, ENpcBase[i].ModelMain.Value3, (ushort)ENpcBase[i].DyeMain.Key);
                        gear.OffWep = new WepTuple(ENpcBase[i].ModelSub.Value1, ENpcBase[i].ModelSub.Value2, ENpcBase[i].ModelSub.Value3, (ushort)ENpcBase[i].DyeOff.Key);
                        gear.HeadGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelHead[0] + ENpcBase[i].ModelHead[1] * 256)), (byte)ENpcBase[i].ModelHead[2], (byte)ENpcBase[i].DyeHead.Key);
                        gear.BodyGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelBody[0] + ENpcBase[i].ModelBody[1] * 256)), (byte)ENpcBase[i].ModelBody[2], (byte)ENpcBase[i].DyeBody.Key);
                        gear.HandsGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelHands[0] + ENpcBase[i].ModelHands[1] * 256)), (byte)ENpcBase[i].ModelHands[2], (byte)ENpcBase[i].DyeHands.Key);
                        gear.LegsGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelLegs[0] + ENpcBase[i].ModelLegs[1] * 256)), (byte)ENpcBase[i].ModelLegs[2], (byte)ENpcBase[i].DyeLegs.Key);
                        gear.FeetGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelFeet[0] + ENpcBase[i].ModelFeet[1] * 256)), (byte)ENpcBase[i].ModelFeet[2], (byte)ENpcBase[i].DyeFeet.Key);
                        gear.EarGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelEars[0] + ENpcBase[i].ModelEars[1] * 256)), (byte)ENpcBase[i].ModelEars[2], 0);
                        gear.NeckGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelNeck[0] + ENpcBase[i].ModelNeck[1] * 256)), (byte)ENpcBase[i].ModelNeck[2], 0);
                        gear.WristGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelWrists[0] + ENpcBase[i].ModelWrists[1] * 256)), (byte)ENpcBase[i].ModelWrists[2], 0);
                        gear.RRingGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelRightRing[0] + ENpcBase[i].ModelRightRing[1] * 256)), (byte)ENpcBase[i].ModelRightRing[2], 0);
                        gear.LRingGear = new GearTuple(Convert.ToUInt16((ENpcBase[i].ModelLeftRing[0] + ENpcBase[i].ModelLeftRing[1] * 256)), (byte)ENpcBase[i].ModelLeftRing[2], 0);
                    }
                    ExdData.Residents[ENpcBase[i].Key].Gear = gear;
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        SheetName.Text = "NPC Data";
                        PB.Value = ((i - 1000000) * 100) / (size - 1000000);
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
                size = CharaMakeCustomize.Count;
                for (int i = 0; i < size; i++)
                {
                    var feature = new ExdData.CharaMakeCustomizeFeature
                    {
                        Index = CharaMakeCustomize[i].Key,
                        FeatureID = CharaMakeCustomize[i].FeatureID
                    };
                    if (CharaMakeCustomize[i].Icon == null) feature.Icon = null;
                    else feature.Icon = CharaMakeCustomize[i].Icon;
                    ExdData.CharaMakeFeatures.Add(i, feature);

                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        SheetName.Text = "CharaMakeCustomize";
                        PB.Value = (i * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
                size = CharaMakeType.Count;
                for (int i = 0; i < size; i++)
                {
                    var feature = new ExdData.CharaMakeCustomizeFeature2
                    {
                        Index = CharaMakeType[i].Key,
                        Gender = CharaMakeType[i].Gender,
                        Race = CharaMakeType[i].Race.Key,
                        Tribe = CharaMakeType[i].Tribe.Key
                    };
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        feature.Features = FeatureD(CharaMakeType[i].FacialFeatureIcon);
                        ExdData.CharaMakeFeatures2.Add(CharaMakeType[i].Key, feature);

                        SheetName.Text = "CharaMakeType";
                        PB.Value = (i * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
                size = Realm.GameData.GetSheet<SaintCoinach.Xiv.BGM>().Count();
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Properties.Resources.BGM)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        ExdData.BGM bGM = new ExdData.BGM();
                        //Processing row
                        string[] fields = parser.ReadFields();
                        int fCount = 0;
                        bGM.Index = int.Parse(fields[0]);
                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 2)
                            {
                                bGM.Name = field;
                            }
                            if (fCount == 3)
                            {
                                bGM.Location = field;
                            }
                            if (fCount == 4)
                            {
                                bGM.Note = field;
                            }
                        }
                        this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                        {
                            rowCount++;
                            ExdData.BGMs.Add(bGM.Index, bGM);
                            ZonePage.Zonepage.BGMBox.Items.Add(new ExdData.BGM { Index = bGM.Index, Name = bGM.Name, Location = bGM.Location });

                            SheetName.Text = "BGMs";
                            PB.Value = (rowCount * 100) / size;
                            Percentage.Text = $"{PB.Value}%";

                        });
                    }
                    parser.Dispose();
                }
                size = 7756;
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Properties.Resources.actiontimeline)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        ExdData.Emote emote = new ExdData.Emote();
                        //Processing row
                        string[] fields = parser.ReadFields();
                        int fCount = 0;
                        emote.Index = int.Parse(fields[0]);
                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 2)
                                emote.Name = field;
                        }
                        this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                        {
                            rowCount++;
                            if (emote.Name.Contains("normal/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("mon_sp/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.SpeacialReal = true; }
                            if (emote.Name.Contains("battle/")) { emote.Name = emote.Name.Remove(0, 7).ToString(); emote.BattleReal = true; }
                            if (emote.Name.Contains("human_sp/")) { emote.Name = emote.Name.Remove(0, 9).ToString(); emote.SpeacialReal = true; }
                            ExdData.Emotes.Add(emote.Index, emote);
                            if (emote.Realist == true) ModelDataPage.Page.PlayerList.Items.Add(new ExdData.Emote { Index = emote.Index, Name = emote.Name });
                            else if (emote.SpeacialReal == true) ModelDataPage.Page.MonsterList.Items.Add(new ExdData.Emote { Index = emote.Index, Name = emote.Name });
                            else if (emote.BattleReal == true) ModelDataPage.Page.BattleList.Items.Add(new ExdData.Emote { Index = emote.Index, Name = emote.Name });
                            ModelDataPage.Page.AllList.Items.Add(new ExdData.Emote { Index = emote.Index, Name = emote.Name });
                            SheetName.Text = "Emotes";
                            PB.Value = (rowCount * 100) / size;
                            Percentage.Text = $"{PB.Value}%";

                        });
                    }
                    parser.Dispose();
                }
                size = 3000;
                ExdData.Emotesx = ExdData.Emotes.Values.ToArray();
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Properties.Resources.MonsterList)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        rowCount++;
                        ExdData.Monster monster = new ExdData.Monster();
                        //Processing row
                        string[] fields = parser.ReadFields();
                        int fCount = 0;
                        monster.Index = int.Parse(fields[0]);
                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 2)
                            {
                                monster.Name = field;
                            }
                        }
                        if (monster.Name.Length >= 1) monster.Real = true;
                        ExdData.Monsters.Add(monster.Index, monster);
                        this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                        {
                            if (monster.Real) ResourcePage.Resourcepage.ModelCharaList.Items.Add(new ExdData.Monster { Index = monster.Index, Name = monster.Name });

                            SheetName.Text = "ModelChara";
                            PB.Value = (rowCount * 100) / size;
                            Percentage.Text = $"{PB.Value}%";

                        });
                    }
                    parser.Dispose();
                }
                ExdData.MonsterX = ExdData.Monsters.Values.ToArray();
                size = TitleSheet.Count;
                for (int i = 0; i < size; i++)
                {
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        string Title = TitleSheet[i].Feminine;
                        if (Title.Length <= 0) Title = "No Title";
                        ResourcePage.Resourcepage.TitleBox.Items.Add(Title);

                        SheetName.Text = "Title";
                        PB.Value = (i * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
                size = StatusSheet.Count;
                for (int i = 0; i < size; i++)
                {
                    if (StatusIds.Contains(StatusSheet[i].VFX) || StatusSheet[i].VFX <= 0 && i != 0) continue;
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        StatusIds.Add(StatusSheet[i].VFX);
                        string name = StatusSheet[i].Name.ToString();
                        if (name.Length <= 0) name = "None";
                        PropertiesPage.Page.StatusBox.Items.Add(new ComboBoxItem() { Content = name, Tag = StatusSheet[i].Key });

                        SheetName.Text = "Status Effect";
                        PB.Value = (i * 100) / size;
                        Percentage.Text = $"{PB.Value}%";

                    });
                }
            }).ContinueWith(t => this.Dispatcher.Invoke(() => 
            { 
                MainWindow.Main.InitializeModel();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }));
        }
        public static ImageSource CreateSource(SaintCoinach.Imaging.ImageFile file)
        {
            var argb = SaintCoinach.Imaging.ImageConverter.GetA8R8G8B8(file);
            return System.Windows.Media.Imaging.BitmapSource.Create(
                                       file.Width, file.Height,
                96, 96,
                PixelFormats.Bgra32, null,
                argb, file.Width * 4);
        }

        private List<ExdData.Features> FeatureD(IEnumerable<SaintCoinach.Xiv.CharaMakeType.CharaMakeFeatureIcon> parse)
        {
            List<ExdData.Features> NewList = new List<ExdData.Features>();
            foreach (var Parse in parse)
            {
                try
                {
                    if (Parse.FacialFeatureIcon == null) NewList.Add(new ExdData.Features { FeatureID = Parse.Count, Icon = null });
                    else NewList.Add(new ExdData.Features { FeatureID = Parse.Count, Icon = ExdData.CreateSource(Parse.FacialFeatureIcon) });
                }
                catch
                {
                    NewList.Add(new ExdData.Features { FeatureID = Parse.Count, Icon = null });
                }
            }
            return NewList;
        }
    }
}
