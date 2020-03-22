using ConceptMatrix.Backend;
using ConceptMatrix.Backend.Commands;
using ConceptMatrix.ViewModel;
using ConceptMatrix.Views;
using Newtonsoft.Json;
using SaintCoinach.Xiv;
using SaintCoinach.Xiv.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Pointer = Nhaama.Memory.Pointer;

namespace ConceptMatrix.Models
{
	public class BaseModel : INotifyPropertyChanged
	{
		public static Definitions Offsets;
		// Thread for the given model.
		private Thread thread;
		public static bool CheckingGPose = false;
		#region Objects used for UI
		void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public bool EnabledEditing { get; set; }
		private int animIndex;
		public int AnimIndex
		{
			get => animIndex;
			set { animIndex = value; OnPropertyChanged("AnimIndex"); }
		}
		public int WritingCheck = 0;

		private ObservableCollection<string> names;

		public ObservableCollection<string> Names
		{
			get => names;
			set => names = value;
		}
		private int selectedIndex;

		public int SelectedIndex
		{
			get => selectedIndex;
			set => selectedIndex = value;
		}
		public int OldIndex;
		public bool InGpose = false;
		public bool GposeChecked { get; set; }
		// Target Mode
		private bool TargetMode { get; set; }
		private bool GPoseTargetMode { get; set; } = true;
		public bool TargetModeActive
		{
			get => GposeChecked ? GPoseTargetMode : TargetMode;
			set
			{
				if (GposeChecked) 
				{
					GPoseTargetMode = value; 
				}
				else
					TargetMode = value;
			}
		}
		public static SaintCoinach.Xiv.Items.Equipment[] AllEquipment;

		public static ExdData.Item[] AllEquipmentX;
		public static EquipmentSelectorViewModel MainhandSelect { get; set; }
		public static EquipmentSelectorViewModel OffhandSelect { get; set; }
		public static EquipmentSelectorViewModel HeadSelect { get; set; }
		public static EquipmentSelectorViewModel BodySelect { get; set; }
		public static EquipmentSelectorViewModel HandsSelect { get; set; }
		public static EquipmentSelectorViewModel LegsSelect { get; set; }
		public static EquipmentSelectorViewModel FeetSelect { get; set; }
		public static EquipmentSelectorViewModel EarsSelect { get; set; }
		public static EquipmentSelectorViewModel NeckSelect { get; set; }
		public static EquipmentSelectorViewModel WristSelect { get; set; }
		public static EquipmentSelectorViewModel RingLSelect { get; set; }
		public static EquipmentSelectorViewModel RingRSelect { get; set; }
        #endregion

        public GameModel gameModel { get; set; }
		public static bool AltTabbed { get; set; }
		public RefreshEntitiesCommand RefreshEntitiesCommand { get; }
		public ActorRefreshCommand ActorRefreshCommand { get; }
		private readonly List<PropertyInfo> props = new List<PropertyInfo>();
		public static ObservableDictionary<string, MemoryInterface> AddressList { get; set; }
		
		public static Pointer ActorData;
		public static Pointer Skeleton1;
		public static Pointer Skeleton2;
		public static Pointer Skeleton3;
		public static Pointer Skeleton4;
		public static Pointer Skeleton5;
		public static Pointer Skeleton6;
		public static Pointer Physics1;
		public static Pointer Physics2;
		public static Pointer Physics3;
		public static Pointer RenderActor1;
		public static Pointer RenderActor2;

		public static Pointer GposeCheckOffset;
		public static Pointer GposeCheckOffset2;

		public static Pointer CameraPointer;
		public static Pointer MusicPointer;
		public static Pointer TerritoryPointer;
		public static Pointer TimePointer;
		public static Pointer WeatherPointer;
		public static Pointer GposeFilterPointer;

		public static int OldActorID = 0;

		private ClassJob _SelectedClassJob;
		public ClassJob SelectedClassJob
		{
			get => _SelectedClassJob;
			set
			{
				//	UpdateEquipmentLists();
				// try
				// {
				//     UpdateEquipmentLists();
				// }
				// catch (Exception ex)
				// {
				//     System.Diagnostics.Debug.WriteLine(ex.Message);
				//     System.Diagnostics.Debug.WriteLine(ex.StackTrace);
				// }
			}
		}
		public ObservableCollection<ClassJob> ClassJobs { get; set; }
		public void Add(string name, MemoryInterface value)
		{
			AddressList.Add(name, value);
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AddressList"));
			}
		}
		public BaseModel()
		{
			MainWindow.Main.GposeToggle.DataContext = this;
			MainWindow.Main.TargetToggle.DataContext = this;
			using (var r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Offsets.json")))
			{
				Offsets = JsonConvert.DeserializeObject<Definitions>(r.ReadToEnd());
			}


			AllEquipmentX = App.AllEquipmentX.ToArray();

			ClassJobs = new ObservableCollection<ClassJob>();
			/*App.Realm.GameData
				.GetSheet<ClassJob>()
				.Where(x => x.Name != "adventurer")
				.ToList()
				.ForEach(x => ClassJobs.Add(x));*/

			MainhandSelect = new EquipmentSelectorViewModel(this, "Mainhand", "Mainhand");
			OffhandSelect = new EquipmentSelectorViewModel(this, "Offhand", "Offhand");

			HeadSelect = new EquipmentSelectorViewModel(this, "Head", "Head");
			BodySelect = new EquipmentSelectorViewModel(this, "Body", "Body");
			HandsSelect = new EquipmentSelectorViewModel(this, "Hands", "Hands");
			LegsSelect = new EquipmentSelectorViewModel(this, "Legs", "Legs");
			FeetSelect = new EquipmentSelectorViewModel(this, "Feet", "Feet");

			EarsSelect = new EquipmentSelectorViewModel(this, "Ears", "Ears");
			NeckSelect = new EquipmentSelectorViewModel(this, "Neck", "Neck");
			WristSelect = new EquipmentSelectorViewModel(this, "Wrist", "Wrist");
			RingLSelect = new EquipmentSelectorViewModel(this, "Left Ring", "LRing");
			RingRSelect = new EquipmentSelectorViewModel(this, "Right Ring", "RRing");
			UpdateEquipmentLists();


			//SelectedClassJob = ClassJobs[22];
			//		MainhandSelect.SetValues("", 601, 1, 8, false, 0); 
			Names = new ObservableCollection<string>();
			RefreshEntitiesCommand = new RefreshEntitiesCommand(this);
			ActorRefreshCommand = new ActorRefreshCommand(this);
			// refresh the list initially
			Refresh();
			// Get the properties of the model.
			AddressList = new ObservableDictionary<string, MemoryInterface>();
			var a = new GameModel();
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AddressList"));
			}

			MenuModel.Instance.PlayerList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.Resource,
				IsMarked = false,
				ContentText = "Appearance",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.PlayerList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.Equipment,
				IsMarked = false,
				ContentText = "Equipment",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.PlayerList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.ModelData,
				IsMarked = false,
				ContentText = "Model Data",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.PlayerList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.Properties,
				IsMarked = false,
				ContentText = "Properties",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.PlayerList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.EquipmentProp,
				IsMarked = false,
				ContentText = "Equipment Properties",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.ResearchList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.Camera,
				IsMarked = false,
				ContentText = "Camera Settings",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.ResearchList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.Zone,
				IsMarked = false,
				ContentText = "Instance Settings",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.ResearchList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.GPoseFilter,
				IsMarked = false,
				ContentText = "Gpose Filters",
				BubbleText = "",
				PageModel = this,
			});
			MenuModel.Instance.ArmyList.Add(new MenuModel.MenuItemModel()
			{
				Category = MenuModel.MenuCategory.Matrix,
				IsMarked = false,
				ContentText = "Posing Matrix",
				BubbleText = "",
				PageModel = new PoseMatrixViewModel(),
			});
			Work();
		}

		/// <summary>
		/// Puts the model to work reading and writing data.
		/// </summary>
		public void Work()
		{
			try
			{
				// Create the thread.
				thread = new Thread(new ThreadStart(async () =>
				{
					// Pointer : Player Appearance, Equipment and other data within the ActorTable. 
					ActorData = new Pointer(MainWindow.GameProcess, Offsets.ActorTable + (((ulong)SelectedIndex + 1) * 8), 0);
					CameraPointer = new Pointer(MainWindow.GameProcess, Offsets.CameraOffset, 0);
					TimePointer = new Pointer(MainWindow.GameProcess, Offsets.TimeOffset, 0);
					WeatherPointer = new Pointer(MainWindow.GameProcess, Offsets.WeatherOffset, 0);
					GposeFilterPointer = new Pointer(MainWindow.GameProcess, Offsets.GposeFiltersOffset, 0);
					TerritoryPointer = new Pointer(MainWindow.GameProcess, Offsets.TerritoryOFfset, 0);
					MusicPointer = new Pointer(MainWindow.GameProcess, Offsets.MusicOffset, 0);
					Skeleton1 = new Pointer(MainWindow.GameProcess, Offsets.SkeletonOffset1);
					Skeleton2 = new Pointer(MainWindow.GameProcess, Offsets.SkeletonOffset2);
					Skeleton3 = new Pointer(MainWindow.GameProcess, Offsets.SkeletonOffset3);
					Skeleton4 = new Pointer(MainWindow.GameProcess, Offsets.SkeletonOffset4);
					Skeleton5 = new Pointer(MainWindow.GameProcess, Offsets.SkeletonOffset5);
					Skeleton6 = new Pointer(MainWindow.GameProcess, Offsets.SkeletonOffset6);
					Physics1 = new Pointer(MainWindow.GameProcess, Offsets.PhysicsOffset1);
					Physics2 = new Pointer(MainWindow.GameProcess, Offsets.PhysicsOffset2);
					Physics3 = new Pointer(MainWindow.GameProcess, Offsets.PhysicsOffset3);
					RenderActor1 = new Pointer(MainWindow.GameProcess, Offsets.RenderOffset1);
					RenderActor2 = new Pointer(MainWindow.GameProcess, Offsets.RenderOffset2);

					GposeCheckOffset =  new Pointer(MainWindow.GameProcess, Offsets.GposeCheckOffset);

					GposeCheckOffset2 = new Pointer(MainWindow.GameProcess, Offsets.GposeCheck2Offset);
					OldIndex = SelectedIndex;
					// Loop indefinitely.
					while (true)
					{
						
						if (GposeChecked)
						{
							if (TargetModeActive)
								ActorData = new Pointer(MainWindow.GameProcess, Offsets.GposeOffset, 0);
							else ActorData = new Pointer(MainWindow.GameProcess, Offsets.GposeOffset, 0);
						}
						else if (TargetModeActive)
						{
							if (!GposeChecked) ActorData = new Pointer(MainWindow.GameProcess, Offsets.TargetOffset, 0);
							else ActorData = new Pointer(MainWindow.GameProcess, Offsets.GposeOffset, 0);
						}
						else ActorData = new Pointer(MainWindow.GameProcess, Offsets.ActorTable + (((ulong)SelectedIndex + 1) * 8), 0);
						if (!CheckingGPose)
						{
							var Gposecheck = MainWindow.GameProcess.ReadByte(GposeCheckOffset.Adressed);
							if (Gposecheck == 0)
							{
								if (InGpose)
								{
									GposeChecked = false;
									InGpose = false;
									Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
									{
										ModelDataPage.Page.StackViewX.IsEnabled = false;
										ModelDataPage.Page.StackViewY.IsEnabled = false;
										ModelDataPage.Page.StackViewZ.IsEnabled = false;
										CameraPage.Page.StackViewX.IsEnabled = false;
										CameraPage.Page.StackViewY.IsEnabled = false;
										CameraPage.Page.StackViewZ.IsEnabled = false;
										PropertiesPage.Page.VFXStack.IsEnabled = false;
										PosingMatrixPage.PosingMatrix.PoseMatrixSetting.IsEnabled = false;
										PosingMatrixPage.PosingMatrix.EditModeButton.IsChecked = false;
										AddressList["CameraX"].Freeze = false;
										AddressList["CameraY"].Freeze = false;
										AddressList["CameraZ"].Freeze = false;
									});
								}
							}
							else if (Gposecheck == 1 && MainWindow.GameProcess.ReadByte(GposeCheckOffset2.Adressed) == 4)
							{
								if (!InGpose)
								{
									Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
									{
										ModelDataPage.Page.StackViewX.IsEnabled = true;
										ModelDataPage.Page.StackViewY.IsEnabled = true;
										ModelDataPage.Page.StackViewZ.IsEnabled = true;
										CameraPage.Page.StackViewX.IsEnabled = true;
										CameraPage.Page.StackViewY.IsEnabled = true;
										CameraPage.Page.StackViewZ.IsEnabled = true;
										PropertiesPage.Page.VFXStack.IsEnabled = true;
										PosingMatrixPage.PosingMatrix.PoseMatrixSetting.IsEnabled = true;

									});

									SelectedIndex = 0;
									GposeChecked = true;
									ActorData = new Pointer(MainWindow.GameProcess, Offsets.ActorTable + 8, 0);
									MainWindow.GameProcess.Write(ActorData + 0x8C, Convert.ChangeType(2, TypeCode.Byte));
									Task.Delay(1000).Wait();
									MainWindow.GameProcess.Write(ActorData + 0x8C, Convert.ChangeType(1, TypeCode.Byte));
									Task.Delay(50).Wait();
									ActorData = new Pointer(MainWindow.GameProcess, Offsets.GposeOffset, 0);
									MainWindow.GameProcess.Write(ActorData + 0x8C, Convert.ChangeType(1, TypeCode.Byte));
									InGpose = true;
								}
							}
						}
						if (EnabledEditing) MainWindow.GameProcess.Write(GposeFilterPointer + Offsets.GposeFilterEnable, Convert.ChangeType(0x40, TypeCode.Byte));

						foreach (KeyValuePair<string, MemoryInterface> entry in AddressList)
						{
							if (entry.Value.Freeze) { entry.Value.WriteMemoryFrozen(); }
						    else entry.Value.Read();
						}
						Application.Current.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
						{
							//Silly way to fix this issue
							if (MainWindow.Main.IsActive == false && !AltTabbed)
							{
								AltTabbed = true;
								FocusManager.SetFocusedElement(FocusManager.GetFocusScope(MainWindow.Main.Gposex), null);
							}
							else if (MainWindow.Main.IsActive) AltTabbed = false;

							// Check if the actor is changed and if it did, update posing matrix.
							if (((Int32Address)BaseModel.AddressList["ActorID"]).Value != OldActorID)
							{
								OldActorID = ((Int32Address)BaseModel.AddressList["ActorID"]).Value;
								if (PosingMatrixPage.PosingMatrix.EditModeButton.IsChecked == true)
								{
									if (PoseMatrixViewModel.PoseVM.PointerPath != null) PosingMatrixPage.PosingMatrix.GetPointers(PoseMatrixViewModel.PoseVM.TheButton);
									PosingMatrixPage.PosingMatrix.EnableTertiary();
								}
							//I'm failure
							((BustScale)AddressList["BustScale"]).userchanged = false;
							}
						});
						// Sleep for a bit.
						await Task.Delay(02);
					}
				}));

				// Start the thread.
				thread.Start();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public static Pointer GetPointerType(PointerType pointerType)
		{
			switch (pointerType)
			{
				case PointerType.ActorData:
					return ActorData;
				case PointerType.Camera:
					return CameraPointer;
				case PointerType.Time:
					return TimePointer;
				case PointerType.Weather:
					return WeatherPointer;
				case PointerType.GposeFilters:
					return GposeFilterPointer;
				case PointerType.GposeAddress:
					return new Pointer(MainWindow.GameProcess, Offsets.GposeOffset, 0);
			}
			return null;
		}
		/// <summary>
		/// Refresh the entity list
		/// </summary>
		public void Refresh()
		{
			try
			{
				// get the array size
				ulong ArraySize = new Pointer(MainWindow.GameProcess, Offsets.ActorTable).PointerValue;

				// clear the entity list
				Names.Clear();

				float x1 = 0;
				float y1 = 0;
				float z1 = 0;

				// loop over entity list size
				for (int i = 0; i < (int)ArraySize; i++)
				{
					Pointer Pointer = new Pointer(MainWindow.GameProcess, Offsets.ActorTable + (((ulong)i + 1) * 8), 0);
					string name = MainWindow.GameProcess.ReadString(Pointer + Offsets.Name);

					int Radius = 0;
					float x2 = MainWindow.GameProcess.ReadFloat(Pointer, Offsets.PositionX);
					float y2 = MainWindow.GameProcess.ReadFloat(Pointer, Offsets.PositionY);
					float z2 = MainWindow.GameProcess.ReadFloat(Pointer, Offsets.PositionZ);
					if (i == 0)
					{
						x1 = x2;
						y1 = y2;
						z1 = z2;
					}
					else
					{
						Radius = (int)Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2)));
					}
					if (i != 0)
					{
						name += $" ({Radius})";
					}

					Names.Add(name);
				}

				// set the index if its under 0
				if (SelectedIndex < 0)
				{
					SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.ToString() + ex.StackTrace + ex.InnerException);
			}
		}
		public void ActorRefresh()
		{
			var EntityType = MainWindow.GameProcess.ReadByte(ActorData + Offsets.ActorType);
			if (EntityType == 1)
			{
				MainWindow.GameProcess.Write(ActorData + Offsets.ActorType, Convert.ChangeType(2, TypeCode.Byte));
				MainWindow.GameProcess.Write(ActorData + Offsets.ActorRender, Convert.ChangeType(2, TypeCode.Byte));
				Task.Delay(50).Wait();
				MainWindow.GameProcess.Write(ActorData + Offsets.ActorRender, Convert.ChangeType(0, TypeCode.Byte));
				Task.Delay(50).Wait();
				MainWindow.GameProcess.Write(ActorData + Offsets.ActorType, Convert.ChangeType(1, TypeCode.Byte));
			}
			else
			{
				MainWindow.GameProcess.Write(ActorData + Offsets.ActorRender, Convert.ChangeType(2, TypeCode.Byte));
				Task.Delay(50).Wait();
				MainWindow.GameProcess.Write(ActorData + Offsets.ActorRender, Convert.ChangeType(0, TypeCode.Byte));
			}
		}

		public void UpdateEquipmentLists()
		{
			OffhandSelect.PossibleEquipment.Clear();
			OffhandSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Offhand||s.Key == (int)ExdData.Slot.Mainhand))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(OffhandSelect.PossibleEquipment.Add);

			if (OffhandSelect.PossibleEquipment.Count > 0)
				OffhandSelect.SelectedEquipment = OffhandSelect.PossibleEquipment[0];

			MainhandSelect.PossibleEquipment.Clear();
			MainhandSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Mainhand))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(MainhandSelect.PossibleEquipment.Add);

			if (MainhandSelect.PossibleEquipment.Count > 0)
				MainhandSelect.SelectedEquipment = MainhandSelect.PossibleEquipment[0];



			HeadSelect.PossibleEquipment.Clear();
			HeadSelect.PossibleEquipment.Add(AllEquipmentX[0]);
			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Head))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(HeadSelect.PossibleEquipment.Add);

			if (HeadSelect.PossibleEquipment.Count > 0)
				HeadSelect.SelectedEquipment = HeadSelect.PossibleEquipment[0];

			BodySelect.PossibleEquipment.Clear();
			BodySelect.PossibleEquipment.Add(AllEquipmentX[0]);
			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Body))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(BodySelect.PossibleEquipment.Add);

			if (BodySelect.PossibleEquipment.Count > 0)
				BodySelect.SelectedEquipment = BodySelect.PossibleEquipment[0];

			HandsSelect.PossibleEquipment.Clear();
			HandsSelect.PossibleEquipment.Add(AllEquipmentX[0]);
			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Hands))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(HandsSelect.PossibleEquipment.Add);

			if (HandsSelect.PossibleEquipment.Count > 0)
				HandsSelect.SelectedEquipment = HandsSelect.PossibleEquipment[0];

			LegsSelect.PossibleEquipment.Clear();
			LegsSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Legs))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(LegsSelect.PossibleEquipment.Add);

			if (LegsSelect.PossibleEquipment.Count > 0)
				LegsSelect.SelectedEquipment = LegsSelect.PossibleEquipment[0];

			FeetSelect.PossibleEquipment.Clear();
			FeetSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Feet))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(FeetSelect.PossibleEquipment.Add);

			if (FeetSelect.PossibleEquipment.Count > 0)
				FeetSelect.SelectedEquipment = FeetSelect.PossibleEquipment[0];

			EarsSelect.PossibleEquipment.Clear();
			EarsSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Ears))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(EarsSelect.PossibleEquipment.Add);

			if (EarsSelect.PossibleEquipment.Count > 0)
				EarsSelect.SelectedEquipment = EarsSelect.PossibleEquipment[0];

			NeckSelect.PossibleEquipment.Clear();
			NeckSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Neck))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(NeckSelect.PossibleEquipment.Add);

			if (NeckSelect.PossibleEquipment.Count > 0)
				NeckSelect.SelectedEquipment = NeckSelect.PossibleEquipment[0];

			WristSelect.PossibleEquipment.Clear();
			WristSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Wrists))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(WristSelect.PossibleEquipment.Add);

			if (WristSelect.PossibleEquipment.Count > 0)
				WristSelect.SelectedEquipment = WristSelect.PossibleEquipment[0];

			RingLSelect.PossibleEquipment.Clear();
			RingRSelect.PossibleEquipment.Clear();
			RingLSelect.PossibleEquipment.Add(AllEquipmentX[0]);
			RingRSelect.PossibleEquipment.Add(AllEquipmentX[0]);

			AllEquipmentX
				.Where(e => e.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.FingerL || s.Key == (int)ExdData.Slot.FingerR))
				.OrderBy(e => e.Name)
				.ToList()
				.ForEach(e => {
					RingLSelect.PossibleEquipment.Add(e);
					RingRSelect.PossibleEquipment.Add(e);
				});

			if (RingLSelect.PossibleEquipment.Count > 0)
			{
				RingLSelect.SelectedEquipment = RingLSelect.PossibleEquipment[0];
				RingRSelect.SelectedEquipment = RingLSelect.PossibleEquipment[0];
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

	}
}
