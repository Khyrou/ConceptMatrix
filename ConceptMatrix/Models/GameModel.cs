using ConceptMatrix.Backend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConceptMatrix.Models
{
	public enum PointerType
	{
		None,
		ActorData,
		Camera,
		Weather,
		GposeFilters,
		Territory,
		Time,
		Music,
		GposeAddress,
	}
	public class GameModel : IDisposable
	{
		private bool Disposed;

		public StringAddress ActorName = new StringAddress { Name = "ActorName", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.Name };
		public StringAddress FCTag = new StringAddress { Name = "FCTag", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.FCTag };
		public UInt16Address Title = new UInt16Address { Name = "Title", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.Title };

		public Int32Address ActorID = new Int32Address { Name = "ActorID", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorID };
		/*	public GameProperty<ObservableCollection<byte>> ActorAppearance { get; set; }
		= new GameProperty<ObservableCollection<byte>>() { PointerType = PointerType.ActorData, Address = 0x17E0, Length = 26 };
		*/
		public ByteAddress ActorType = new ByteAddress { Name = "ActorType", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorType };
		public ByteAddress ActorVoice = new ByteAddress { Name = "ActorVoice", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorVoice };
		public ByteArrayAddress ActorData = new ByteArrayAddress () { Name = "ActorData", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorAppearance, Length = 26 };
		public WeaponArray Mainhand = new WeaponArray() { Name = "Mainhand", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.MainHand, Length = 8 };
		public WeaponArray Offhand = new WeaponArray() { Name = "Offhand", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.OffHand, Length = 8 };
		public EquipmentArray Head = new EquipmentArray() { Name = "Head", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment, Length = 4 };
		public EquipmentArray Body = new EquipmentArray() { Name = "Body", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+4, Length = 4 };
		public EquipmentArray Hands = new EquipmentArray() { Name = "Hands", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+8, Length = 4 };
		public EquipmentArray Legs = new EquipmentArray() { Name = "Legs", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+12, Length = 4 };
		public EquipmentArray Feet = new EquipmentArray() { Name = "Feet", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+16, Length = 4 };
		public EquipmentArray Ears = new EquipmentArray() { Name = "Ears", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+20, Length = 4 };
		public EquipmentArray Neck = new EquipmentArray() { Name = "Neck", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+24, Length = 4 };
		public EquipmentArray Wrist = new EquipmentArray() { Name = "Wrist", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+28, Length = 4 };
		public EquipmentArray RRing = new EquipmentArray() { Name = "RRing", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+32, Length = 4 };
		public EquipmentArray LRing = new EquipmentArray() { Name = "LRing", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ActorEquipment+36, Length = 4 };
		public FloatAddress X  = new FloatAddress { Name = "X", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.PositionX };
		public FloatAddress Y  = new FloatAddress { Name = "Y", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.PositionY };
		public FloatAddress Z  = new FloatAddress { Name = "Z", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.PositionZ };
		public FloatAddress Wetness = new FloatAddress { Name = "Wetness", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.Wetness };
		public FloatAddress Drenched = new FloatAddress { Name = "Drenched", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.Drenched };
		public BustScale BustScale = new BustScale { Name = "BustScale", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.BustX };
		public FloatAddress BustX = new FloatAddress { Name = "BustX", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.BustX };
		public FloatAddress BustY = new FloatAddress { Name = "BustY", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.BustY };
		public FloatAddress BustZ = new FloatAddress { Name = "BustZ", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.BustZ };
		public FloatAddress Height = new FloatAddress { Name = "Height", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.Height };
		public FloatAddress Transparency = new FloatAddress { Name = "Transparency", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.Transparency };
		public FloatAddress UniqueFeatureScale = new FloatAddress { Name = "UniqueFeatureScale", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.UniqueFeatureScale };
		public FloatAddress MuscleTone = new FloatAddress { Name = "MuscleTone", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.MuscleTone };
		public FloatAddress CameraViewX = new FloatAddress { Name = "CameraViewX", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.CameraViewX };
		public FloatAddress CameraViewY = new FloatAddress { Name = "CameraViewY", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.CameraViewY };
		public FloatAddress CameraViewZ = new FloatAddress { Name = "CameraViewZ", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.CameraViewZ };
		public FloatAddress CameraX = new FloatAddress { Name = "CameraX", PointerType = PointerType.GposeAddress, Address = BaseModel.Offsets.CameraX };
		public FloatAddress CameraY = new FloatAddress { Name = "CameraY", PointerType = PointerType.GposeAddress, Address = BaseModel.Offsets.CameraY };
		public FloatAddress CameraZ = new FloatAddress { Name = "CameraZ", PointerType = PointerType.GposeAddress, Address = BaseModel.Offsets.CameraZ };
		public RotationAddress Rotation = new RotationAddress { Name = "Rotation", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.Rotation };
		public UInt16Address StatusEffect = new UInt16Address { Name = "StatusEffect", PointerType = PointerType.GposeAddress, Address = BaseModel.Offsets.StatusEffect };
		public UInt16Address DataPath = new UInt16Address { Name = "DataPath", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.DataPath };
		public UInt16Address ForceAnimation = new UInt16Address { Name = "ForceAnimation", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ForceAnimation };
		public UInt16Address IdleAnimation = new UInt16Address { Name = "IdleAnimation", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.IdleAnimation };
		public FloatAddress AnimationSpeed = new FloatAddress { Name = "AnimationSpeed", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.AnimationSpeed1 };
		public FloatAddress FreezeFacial = new FloatAddress { Name = "FreezeFacial", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.FreezeFacial };
		public FloatAddress CameraCurrentZoom = new FloatAddress { Name = "CameraCurrentZoom", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraCurrentZoom };
		public FloatAddress CameraMinZoom = new FloatAddress { Name = "CameraMinZoom", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraMinZoom };
		public FloatAddress CameraMaxZoom = new FloatAddress { Name = "CameraMaxZoom", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraMaxZoom };
		public FloatAddress FOVCurrent = new FloatAddress { Name = "FOVCurrent", PointerType = PointerType.Camera, Address = BaseModel.Offsets.FOVCurrent };
		public FloatAddress FOV2 = new FloatAddress { Name = "FOV2", PointerType = PointerType.Camera, Address = BaseModel.Offsets.FOV2 };
		public FloatAddress CameraAngleX = new FloatAddress { Name = "CameraAngleX", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraAngleX };
		public FloatAddress CameraAngleY = new FloatAddress { Name = "CameraAngleY", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraAngleY };
		public FloatAddress CameraYMin = new FloatAddress { Name = "CameraYMin", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraYMin };
		public FloatAddress CameraYMax = new FloatAddress { Name = "CameraYMax", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraYMax };
		public FloatAddress CameraRotation = new FloatAddress { Name = "CameraRotation", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraRotation };
		public FloatAddress CameraUpDown = new FloatAddress { Name = "CameraUpDown", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraUpDown };
		public FloatAddress CameraPanX = new FloatAddress { Name = "CameraPanX", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraPanX };
		public FloatAddress CameraPanY = new FloatAddress { Name = "CameraPanY", PointerType = PointerType.Camera, Address = BaseModel.Offsets.CameraPanY };
		public Int32Address TimeControl = new Int32Address { Name = "TimeControl", PointerType = PointerType.Time, AddressArray = BaseModel.Offsets.TimeControl };
		public ByteAddress Weather = new ByteAddress { Name = "Weather", PointerType = PointerType.Weather, Address = BaseModel.Offsets.Weather };
		public UInt16Address ForceWeather = new UInt16Address { Name = "ForceWeather", PointerType = PointerType.GposeFilters, Address = BaseModel.Offsets.ForceWeather };
		public Int32Address ModelChara = new Int32Address { Name = "ModelChara", PointerType = PointerType.ActorData, Address = BaseModel.Offsets.ModelChara };
		public FloatArrayAddress GposeFilterTable = new FloatArrayAddress { Name = "GposeFilterTable", PointerType = PointerType.GposeFilters, Address = BaseModel.Offsets.GposeFilterTable, Length = 60 };
		public FloatAddress SkinRed = new FloatAddress { Name = "SkinRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.SkinRed };
		public FloatAddress SkinGreen = new FloatAddress { Name = "SkinGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.SkinGreen };
		public FloatAddress SkinBlue = new FloatAddress { Name = "SkinBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.SkinBlue };
		public FloatAddress SkinRedGloss = new FloatAddress { Name = "SkinRedGloss", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.SkinRedGloss };
		public FloatAddress SkinGreenGloss = new FloatAddress { Name = "SkinGreenGloss", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.SkinGreenGloss };
		public FloatAddress SkinBlueGloss = new FloatAddress { Name = "SkinBlueGloss", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.SkinBlueGloss };
		public FloatAddress HairRed = new FloatAddress { Name = "HairRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HairRed };
		public FloatAddress HairGreen = new FloatAddress { Name = "HairGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HairGreen };
		public FloatAddress HairBlue = new FloatAddress { Name = "HairBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HairBlue };
		public FloatAddress HairRedGloss = new FloatAddress { Name = "HairRedGloss", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HairRedGloss };
		public FloatAddress HairGreenGloss = new FloatAddress { Name = "HairGreenGloss", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HairGreenGloss };
		public FloatAddress HairBlueGloss = new FloatAddress { Name = "HairBlueGloss", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HairBlueGloss };
		public FloatAddress HiglightRed = new FloatAddress { Name = "HiglightRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HiglightRed };
		public FloatAddress HiglightGreen = new FloatAddress { Name = "HiglightGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HiglightGreen };
		public FloatAddress HiglightBlue = new FloatAddress { Name = "HiglightBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.HiglightBlue };
		public FloatAddress LeftEyeRed = new FloatAddress { Name = "LeftEyeRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.LeftEyeRed };
		public FloatAddress LeftEyeGreen = new FloatAddress { Name = "LeftEyeGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.LeftEyeGreen };
		public FloatAddress LeftEyeBlue = new FloatAddress { Name = "LeftEyeBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.LeftEyeBlue };
		public FloatAddress RightEyeRed = new FloatAddress { Name = "RightEyeRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.RightEyeRed };
		public FloatAddress RightEyeGreen = new FloatAddress { Name = "RightEyeGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.RightEyeGreen };
		public FloatAddress RightEyeBlue = new FloatAddress { Name = "RightEyeBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.RightEyeBlue };
		public FloatAddress MouthRed = new FloatAddress { Name = "MouthRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.MouthRed };
		public FloatAddress MouthGreen = new FloatAddress { Name = "MouthGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.MouthGreen };
		public FloatAddress MouthBlue = new FloatAddress { Name = "MouthBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.MouthBlue };
		public FloatAddress MouthGloss = new FloatAddress { Name = "MouthGloss", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.MouthGloss };
		public FloatAddress LimbalRed = new FloatAddress { Name = "LimbalRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.LimbalRed };
		public FloatAddress LimbalGreen = new FloatAddress { Name = "LimbalGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.LimbalGreen };
		public FloatAddress LimbalBlue = new FloatAddress { Name = "LimbalBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.LimbalBlue };
		public FloatAddress ScaleX = new FloatAddress { Name = "ScaleX", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.ScaleX };
		public FloatAddress ScaleY = new FloatAddress { Name = "ScaleY", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.ScaleY };
		public FloatAddress ScaleZ = new FloatAddress { Name = "ScaleZ", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.ScaleZ };
		public FloatAddress WeaponX = new FloatAddress { Name = "WeaponX", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.WeaponX };
		public FloatAddress WeaponY = new FloatAddress { Name = "WeaponY", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.WeaponY };
		public FloatAddress WeaponZ = new FloatAddress { Name = "WeaponZ", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.WeaponZ };
		public FloatAddress WeaponRed = new FloatAddress { Name = "WeaponRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.WeaponRed };
		public FloatAddress WeaponGreen = new FloatAddress { Name = "WeaponGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.WeaponGreen };
		public FloatAddress WeaponBlue = new FloatAddress { Name = "WeaponBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.WeaponBlue };
		public FloatAddress OffhandX = new FloatAddress { Name = "OffhandX", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.OffhandX };
		public FloatAddress OffhandY = new FloatAddress { Name = "OffhandY", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.OffhandY };
		public FloatAddress OffhandZ = new FloatAddress { Name = "OffhandZ", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.OffhandZ };
		public FloatAddress OffhandRed = new FloatAddress { Name = "OffhandRed", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.OffhandRed };
		public FloatAddress OffhandGreen = new FloatAddress { Name = "OffhandGreen", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.OffhandGreen };
		public FloatAddress OffhandBlue = new FloatAddress { Name = "OffhandBlue", PointerType = PointerType.ActorData, AddressArray = BaseModel.Offsets.OffhandBlue };

		public GameModel()
		{
			var fields = GetType().GetFields(BindingFlags.Instance |
					   BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			{
				//	var AddressField = fields[i].GetValue(this).GetType();
				Type FieldType = fields[i].GetValue(this).GetType();
				if (FieldType == typeof(FloatAddress))
				{
					BaseModel.AddressList.Add(fields[i].Name, (FloatAddress)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(ByteArrayAddress))
				{
					BaseModel.AddressList.Add(fields[i].Name, (ByteArrayAddress)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(WeaponArray))
				{
					BaseModel.AddressList.Add(fields[i].Name, (WeaponArray)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(EquipmentArray))
				{
					BaseModel.AddressList.Add(fields[i].Name, (EquipmentArray)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(Int32Address))
				{
					BaseModel.AddressList.Add(fields[i].Name, (Int32Address)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(ByteAddress))
				{
					BaseModel.AddressList.Add(fields[i].Name, (ByteAddress)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(UInt16Address))
				{
					BaseModel.AddressList.Add(fields[i].Name, (UInt16Address)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(FloatArrayAddress))
				{
					BaseModel.AddressList.Add(fields[i].Name, (FloatArrayAddress)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(RotationAddress))
				{
					BaseModel.AddressList.Add(fields[i].Name, (RotationAddress)fields[i].GetValue(this));
				}
				else if (FieldType == typeof(BustScale))
				{
					BaseModel.AddressList.Add(fields[i].Name, (BustScale)fields[i].GetValue(this));
				}
				else BaseModel.AddressList.Add(fields[i].Name, (StringAddress)fields[i].GetValue(this));
			}
			Dispose();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (Disposed) return;
			if (disposing)
			{
				
			}
			Disposed = true;
		}
	}
}
