using Newtonsoft.Json;
using SaintCoinach.Imaging;
using SaintCoinach.Xiv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GearTuple = System.Tuple<ushort, byte, byte>;
using WepTuple = System.Tuple<ushort, ushort, ushort, ushort>;

namespace ConceptMatrix.Backend
{
	public class GearSet
	{
		public GearTuple HeadGear { get; set; }
		public GearTuple BodyGear { get; set; }
		public GearTuple HandsGear { get; set; }
		public GearTuple LegsGear { get; set; }
		public GearTuple FeetGear { get; set; }
		public GearTuple EarGear { get; set; }
		public GearTuple NeckGear { get; set; }
		public GearTuple WristGear { get; set; }
		public GearTuple RRingGear { get; set; }
		public GearTuple LRingGear { get; set; }

		public WepTuple MainWep { get; set; }
		public WepTuple OffWep { get; set; }
		public byte[] Customize { get; set; }

		public int ModelChara { get; set; }

		public string ToJson()
		{
			return JsonConvert.SerializeObject(this);
		}

		public static GearSet FromJson(string json)
		{
			return JsonConvert.DeserializeObject<GearSet>(json);
		}
	}
	public class ExdData
    {
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DeleteObject(IntPtr value);

		public static CmpReader _colorMap = new CmpReader(Properties.Resources.human);

		public enum Slot
		{
			Mainhand = 0,
			Offhand,
			Head,
			Body,
			Hands,
			Legs = 6,
			Feet,
			Ears,
			Neck,
			Wrists,
			FingerL,
			FingerR
		}
		public class Item
		{
			public int Index { get; set; }

			public string Name { get; set; }

			public Quad ModelMain { get ;set; }
			public Quad ModelSub { get; set; }

			public ClassJobCategory ClassJobCategory { get; set; }
			public EquipSlotCategory EquipSlotCategory { get; set; }
			public bool IsDyeable { get; set; }
			public int Gender { get; set; }

			public SaintCoinach.Imaging.ImageFile Icon { get; set; }

			public override string ToString()
			{
				return Name;
			}
		}
		public class Resident
		{
			public int Index { get; set; }
			public string Name { get; set; }
			public GearSet Gear { get; set; }

			public override string ToString()
			{
				return Name;
			}

			public bool IsGoodNpc()
			{
				if (Gear.Customize[0] != 0 && Name.Length != 0)
					return true;

				return false;
			}
		}

		public class CharaMakeCustomizeFeature
		{
			public int Index { get; set; }
			public int FeatureID { get; set; }
			public SaintCoinach.Imaging.ImageFile Icon { get; set; }
	
		}
		public class Features
		{
			public int FeatureID { get; set; }
			public ImageSource Icon { get; set; }
		}

		public class CharaMakeCustomizeFeature2
		{
			public int Index { get; set; }
			public int Race { get; set; }
			public int Gender { get; set; }
			public int Tribe { get; set; }
			public List<Features> Features { get; set; }
		}

		public class Weather
		{
			public int Index { get; set; }
			public string Name { get; set; }
			public ushort Key { get; set; }
			public SaintCoinach.Imaging.ImageFile Icon { get; set; }
		}

		public class TerritoryType
		{
			public int Index { get; set; }
			public WeatherRate WeatherRate { get; set; }
		}
		public class WeatherRate
		{
			public int Index { get; set; }
			public List<Weather> AllowedWeathers { get; set; }
		}

		public class BGM
		{
			public int Index { get; set; }
			public string Name { get; set; }
			public string Location { get; set; }
			public string Note { get; set; }
		}

		public class Monster
		{
			public int Index { get; set; }
			public bool Real { get; set; }
			public string Name { get; set; }
			public override string ToString()
			{
				return Name;
			}
		}

		public class Emote
		{
			public int Index { get; set; }
			public bool Realist { get; set; }
			public bool SpeacialReal { get; set; }
			public bool BattleReal { get; set; }
			public string Name { get; set; }
			public override string ToString()
			{
				return Name;
			}
		}
		public static Emote[] Emotesx;
		public static Monster[] MonsterX;
		public static Dictionary<int, TerritoryType> TerritoryTypes = null;
		public static Dictionary<int, Item> Items = null;
		public static Dictionary<int, CharaMakeCustomizeFeature> CharaMakeFeatures = null;
		public static Dictionary<int, CharaMakeCustomizeFeature2> CharaMakeFeatures2 = null;
		public static Dictionary<int, Resident> Residents = null;
		public static Dictionary<int, BGM> BGMs = null;
		public static Dictionary<int, Emote> Emotes = null;
		public static Dictionary<int, Monster> Monsters = null;
		public static List<string> Stain = null;

		public static ImageSource CreateSource(ImageFile file)
		{
			var argb = ImageConverter.GetA8R8G8B8(file);
			return BitmapSource.Create(
				file.Width, file.Height,
				96, 96,
				PixelFormats.Bgra32, null,
				argb, file.Width * 4);
		}
		public static BitmapSource GetImageStream(System.Drawing.Image myImage)
		{
			var bitmap = new System.Drawing.Bitmap(myImage);
			IntPtr bmpPt = bitmap.GetHbitmap();
			BitmapSource bitmapSource =
			 System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
				   bmpPt,
				   IntPtr.Zero,
				   Int32Rect.Empty,
				   BitmapSizeOptions.FromEmptyOptions());

			//freeze bitmapSource and clear memory to avoid memory leaks
			bitmapSource.Freeze();
			DeleteObject(bmpPt);

			return bitmapSource;
		}
	}
}
