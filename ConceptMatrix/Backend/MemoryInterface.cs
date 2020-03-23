using ConceptMatrix.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.Backend
{
	public class MyByte : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool _Freeze;
		public bool Freeze { get {return _Freeze; } set { _Freeze = value; OnPropertyChanged("Freeze"); } }

		private byte _Value { get; set; }

		public ulong index;

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }
		public byte Value
		{
			get { return _Value; }
			set {_Value = value; OnPropertyChanged("Value"); }
		}
		public byte UserValue
		{
			get { return Value; }
			set {onChange(Value, value, true) ; OnPropertyChanged("UserValue"); }
		}

		public void onChange(byte storage, byte value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			_Value = value;
			Value = value;
			WriteMemory(value);
		}
		public void WriteMemory(byte value)
		{
			Value = value;
			_Value = value;
			UserValue = value;
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + (Address + index)), AddressArray);
		}

		void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	public class MyFloat : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool _Freeze;
		public bool Freeze { get { return _Freeze; } set { _Freeze = value; OnPropertyChanged("Freeze"); } }

		private string _Value { get; set; }

		public ulong index;

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }
		public string Value
		{
			get { return _Value; }
			set { _Value = value; OnPropertyChanged("Value"); }
		}
		public string UserValue
		{
			get { return Value; }
			set { onChange(Value, value, true); OnPropertyChanged("UserValue"); }
		}

		public void onChange(string storage, string value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			Value = value;
			WriteMemory(value);
		}
		public void WriteMemory(string value)
		{
			Value = value;
			MainWindow.GameProcess.Write(float.Parse(value), (BaseModel.GetPointerType(PointerType) + (Address + index)), AddressArray);
		}

		void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	public interface MemoryInterface : INotifyPropertyChanged
	{
		bool Freeze { get; set; }

		void Read();

		void WriteMemoryFrozen();

		void WriteMemory(string value);

		void WriteMemory(Single value);

		void WriteMemory(int value);
		void WriteMemory(params byte[] value);
	}

	#region EquipmentArray
	public class EquipmentArray : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public uint Length { get; set; }

		public PointerType PointerType { get; set; }

		public bool IsEditing { get; set; }


		public byte[] _Value;
		public byte[] Value // this is being set in the backend
		{
			get => _Value;
			set
			{
				_Value = value;
			}
		}

		public ushort Model
		{
			get => Convert.ToUInt16(Value[0] + Value[1] * 256);
			set
			{
				//onChange(Convert.ToInt16(Value[0] + Value[1] * 256), value, true, 0);
			}
		}

		public ushort Base;

		public ushort Variant;

		public ushort Dye;
		public void onChange(short storage, short value, bool IsEditing, ulong index)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			Value[0] = BitConverter.GetBytes(value)[0];
			Value[1] = BitConverter.GetBytes(value)[1];
			WriteMemory(value, index);
		//	BaseModel.MainhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
		}
		public void WriteMemory(int value, ulong index)
		{
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + Address + index), AddressArray);
		}
		public void WriteMemory(params byte[] value)
		{
			Value = value;
			Model = Convert.ToUInt16(value[0] + value[1] * 256);
			Base = value[2];
			Dye = value[3];
			MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, value);
			if (Name == "Head") BaseModel.HeadSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Body") BaseModel.BodySelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Hands") BaseModel.HandsSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Legs") BaseModel.LegsSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Feet") BaseModel.FeetSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Ears") BaseModel.EarsSelect.SetValues("", Model, Base, 0, false, 0);
			else if (Name == "Neck") BaseModel.NeckSelect.SetValues("", Model, Base, 0, false, 0);
			else if (Name == "Wrist") BaseModel.WristSelect.SetValues("", Model, Base, 0, false, 0);
			else if (Name == "RRing") BaseModel.RingRSelect.SetValues("", Model, Base, 0, false, 0);
			else if (Name == "LRing") BaseModel.RingLSelect.SetValues("", Model, Base, 0, false, 0);
		}
		public void WriteMemoryX(params byte[] value)
		{
			Value = value;
			Model = Convert.ToUInt16(value[0] + value[1] * 256);
			Base = value[2];
			Dye = value[3];
			MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, value);
			if (Name == "Head") BaseModel.HeadSelect.SetValuesX("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Body") BaseModel.BodySelect.SetValuesX("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Hands") BaseModel.HandsSelect.SetValuesX("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Legs") BaseModel.LegsSelect.SetValuesX("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Feet") BaseModel.FeetSelect.SetValuesX("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Ears") BaseModel.EarsSelect.SetValuesX("", Model, Base, 0, false, 0);
			else if (Name == "Neck") BaseModel.NeckSelect.SetValuesX("", Model, Base, 0, false, 0);
			else if (Name == "Wrist") BaseModel.WristSelect.SetValuesX("", Model, Base, 0, false, 0);
			else if (Name == "RRing") BaseModel.RingRSelect.SetValuesX("", Model, Base, 0, false, 0);
			else if (Name == "LRing") BaseModel.RingLSelect.SetValuesX("", Model, Base, 0, false, 0);
		}
		public void WriteMemoryFrozen()
		{
			if (Name == "Head") BaseModel.HeadSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
			else if (Name == "Body") BaseModel.BodySelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
			else if (Name == "Hands") BaseModel.HandsSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
			else if (Name == "Legs") BaseModel.LegsSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
			else if (Name == "Feet") BaseModel.FeetSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
			else if (Name == "Ears") BaseModel.EarsSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
			else if (Name == "Neck") BaseModel.NeckSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
			else if (Name == "Wrist") BaseModel.WristSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
			else if (Name == "RRing") BaseModel.RingRSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
			else if (Name == "LRing") BaseModel.RingLSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
			MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, Value);
		}

		#region Read
		public void Read()
		{
			var value = MainWindow.GameProcess.ReadBytes(BaseModel.GetPointerType(PointerType) + Address, Length);
			if (Value == null)
			{
				Value = value;
				Model = Convert.ToUInt16(value[0] + value[1] * 256);
				Base = value[2];
				Dye = value[3];
				if (Name == "Head") BaseModel.HeadSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Body") BaseModel.BodySelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Hands") BaseModel.HandsSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Legs") BaseModel.LegsSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Feet") BaseModel.FeetSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Ears") BaseModel.EarsSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "Neck") BaseModel.NeckSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "Wrist") BaseModel.WristSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "RRing") BaseModel.RingRSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "LRing") BaseModel.RingLSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				return;
			}
			bool equal = value.SequenceEqual(Value);
			if (!equal)
			{
				Value = value;
				Model = Convert.ToUInt16(value[0] + value[1] * 256);
				Base = value[2];
				Dye = value[3];
				if (Name == "Head") BaseModel.HeadSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Body") BaseModel.BodySelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Hands") BaseModel.HandsSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Legs") BaseModel.LegsSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Feet") BaseModel.FeetSelect.SetValues("", Convert.ToUInt16(Model), Base, Variant, Dye != 0, Dye);
				else if (Name == "Ears") BaseModel.EarsSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "Neck") BaseModel.NeckSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "Wrist") BaseModel.WristSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "RRing") BaseModel.RingRSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);
				else if (Name == "LRing") BaseModel.RingLSelect.SetValues("", Convert.ToUInt16(Model), Base, 0, false, 0);

			}
		}
		#endregion

		#region notimplemented
		public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(float value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}

		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}
	#endregion


	#region WeaponArray
	public class WeaponArray : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public uint Length { get; set; }

		public PointerType PointerType { get; set; }

		public bool IsEditing { get; set; }


		public byte[] _Value;
		public byte[] Value // this is being set in the backend
		{
			get => _Value;
			set
			{
				_Value = value;
			}
		}

		public ushort Model
		{
			get => Convert.ToUInt16(Value[0] + Value[1] * 256);
			set
			{
			//	onChange(Convert.ToInt16(Value[0] + Value[1] * 256), value, true, 0) ;
			}
		}

		public ushort Base;
		public ushort Variant;
		public ushort Dye;
		public void WriteMemory(int value, ulong index)
		{
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + Address + index), AddressArray);
		}
		public void WriteMemory(params byte[] value)
		{
		//	Console.WriteLine("[{0}]", string.Join(", ", value));
			Value = value;
			Model = Convert.ToUInt16(value[0] + value[1] * 256);
			Base = Convert.ToUInt16(value[2] + value[3] * 256);
			Variant = value[4];
			Dye = value[6];
			if (Name == "Mainhand") BaseModel.MainhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Offhand") BaseModel.OffhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, value);
		}
		public void WriteMemoryX(params byte[] value)
		{
			//	Console.WriteLine("[{0}]", string.Join(", ", value));
			Value = value;
			Model = Convert.ToUInt16(value[0] + value[1] * 256);
			Base = Convert.ToUInt16(value[2] + value[3] * 256);
			Variant = value[4];
			Dye = value[6];
			if (Name == "Mainhand") BaseModel.MainhandSelect.SetValuesX("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Offhand") BaseModel.OffhandSelect.SetValuesX("", Model, Base, Variant, Dye != 0, Dye);
			MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, value);
		}
		public void WriteMemoryFrozen()
		{
			if (Name == "Mainhand") BaseModel.MainhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			else if (Name == "Offhand") BaseModel.OffhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
			MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, Value);
		}
		#region Read
		public void Read()
		{
			var value = MainWindow.GameProcess.ReadBytes(BaseModel.GetPointerType(PointerType) + Address, Length);

			if (Value == null)
			{
				Value = value;
				Model = Convert.ToUInt16(value[0] + value[1] * 256);
				Base = Convert.ToUInt16(value[2] + value[3] * 256);
				Variant = value[4];
				Dye = value[6];
				if (Name=="Mainhand") BaseModel.MainhandSelect.SetValues("",Model, Base, Variant, Dye != 0, Dye);
				else if (Name == "Offhand") BaseModel.OffhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
				return;
			}
			bool equal = value.SequenceEqual(Value);
			if (!equal)
			{
				Value = value;
				Model = Convert.ToUInt16(value[0] + value[1] * 256);
				Base = Convert.ToUInt16(value[2] + value[3] * 256);
				Variant = value[4];
				Dye = value[6];
				if (Name == "Mainhand") BaseModel.MainhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);
				else if (Name == "Offhand") BaseModel.OffhandSelect.SetValues("", Model, Base, Variant, Dye != 0, Dye);

			}
		}
        #endregion

        #region notimplemented
        public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(float value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}
		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}
	#endregion

	public class ByteArrayAddress : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public uint Length { get; set; }

		public PointerType PointerType { get; set; }

		public bool IsEditing { get; set; }

		public byte[] _Value { get; set; }

		public byte[] OldValue { get; set; }
		public byte[] Value // this is being set in the backend
		{
			get => _Value;
			set
			{
				OldValue = _Value;
				_Value = value;
			}
		}
		public ObservableCollection<MyByte> ArrayValue { get; set; }
		public void WriteMemory(params byte[] value)
		{
			_Value = value;
			Value = value;
			ulong i = 0;
			// same as in below figure out better way how to handle arrays in future.
			foreach (var IndexAddress in ArrayValue)
			{
				IndexAddress.Value = value[i];
				IndexAddress.UserValue = value[i];
				IndexAddress.WriteMemory(value[i]);
				i++;
			}
		//	MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, value);
		}
		public void UnfreezeArray()
		{
			ulong i = 0;
			foreach (var IndexAddress in ArrayValue)
			{
				IndexAddress.Freeze = false;
				i++;
			}
		}
		public void FreezeArray()
		{
			ulong i = 0;
			foreach (var IndexAddress in ArrayValue)
			{
				IndexAddress.Freeze = true;
				i++;
			}
		}
		public void WriteMemoryFrozen()
		{
		}

		#region read
		public void Read()
		{
			if (Value == null)
			{
				var value = MainWindow.GameProcess.ReadBytes(BaseModel.GetPointerType(PointerType) + Address, Length);
				Value = value;
				ulong i = 0;
				ArrayValue = new ObservableCollection<MyByte>(value.Select(p => new MyByte
				{
					Value = p,
					index = i++,
					Address = Address,
					AddressArray = AddressArray,
					PointerType = PointerType
				}).ToArray());
				return;
			}
			//Have to figure out a better way so we don't read individual indexes in memory.
			foreach (var IndexAddress in ArrayValue)
			{
				if(IndexAddress.Freeze) IndexAddress.WriteMemory(IndexAddress.Value);
				else IndexAddress.Value = MainWindow.GameProcess.ReadByte(BaseModel.GetPointerType(PointerType) + Address + IndexAddress.index);
			}
		}
        #endregion

        #region NotImplemented
        public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(float value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}
		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class FloatArrayAddress : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public uint Length { get; set; }

		public PointerType PointerType { get; set; }

		public bool IsEditing { get; set; }

		public byte[] _Value { get; set; }

		public byte[] OldValue { get; set; }
		public byte[] Value // this is being set in the backend
		{
			get => _Value;
			set
			{
				OldValue = _Value;
				_Value = value;
			}
		}
		public string ArrayString { get; set; }

		public ObservableCollection<MyFloat> ArrayValue { get; set; }
		public void WriteMemory(params byte[] value)
		{
			Value = value;
			ulong i = 0;
			// same as in below figure out better way how to handle arrays in future.
			foreach (var IndexAddress in ArrayValue)
			{
				IndexAddress.Value = BitConverter.ToSingle(value, (int)i * 4).ToString();
				i++;
			}
			MainWindow.GameProcess.WriteBytes(BaseModel.GetPointerType(PointerType) + Address, value);
			ArrayString = Extensions.ByteArrayToStringU(value);
		}
		public void WriteMemoryFrozen()
		{
		}

		#region read
		public void Read()
		{
			if (Value == null)
			{
				ArrayValue = new ObservableCollection<MyFloat>();
				var value = MainWindow.GameProcess.ReadBytes(BaseModel.GetPointerType(PointerType) + Address, Length);
				ArrayString = Extensions.ByteArrayToStringU(value);
				Value = value;
				for (ulong i = 0; i < Length/4; i++)
				{
					ArrayValue.Add(new MyFloat()
					{
						index = i*4,
						Value = BitConverter.ToSingle(value, (int)i * 4).ToString(),
						Address = Address,
						AddressArray = AddressArray,
						PointerType = PointerType
					});
				}
				return;
			}
			//Have to figure out a better way so we don't read individual indexes in memory.
			foreach (var IndexAddress in ArrayValue)
			{
				if (IndexAddress.Freeze) IndexAddress.WriteMemory(IndexAddress.Value);
				else IndexAddress.Value = MainWindow.GameProcess.ReadFloat(BaseModel.GetPointerType(PointerType) + Address + IndexAddress.index).ToString();
			}
			var _value = MainWindow.GameProcess.ReadBytes(BaseModel.GetPointerType(PointerType) + Address, Length);
			ArrayString = Extensions.ByteArrayToStringU(_value);
		}
		#endregion

		#region NotImplemented
		public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(float value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}
		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class RotationAddress : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }

		public string _Value { get; set; }

		public string Value // this is being set in the backend
		{
			get => _Value;
			set => _Value = value;
		}
		public string UserValue
		{
			get => Value;
			set
			{
			}
		}
		public float _RotationX { get; set; }

		public float RotationX
		{
			get => _RotationX;
			set
			{
				_RotationX = value;
				RotChange();
			}
		}
		public float _RotationY { get; set; }
		public float RotationY
		{
			get => _RotationY;
			set
			{
				_RotationY = value;
				RotChange();
			}
		}
		public float _RotationZ { get; set; }
		public float RotationZ
		{
			get => _RotationZ;
			set
			{
				_RotationZ = value;
				RotChange();
			}
		}

		public float Rotation { get; set; }
		public float Rotation2 { get; set; }
		public float Rotation3 { get; set; }
		public float Rotation4 { get; set; }

		/// <summary>	
		/// Gets the euler angles from the UI elements.	
		/// </summary>	
		/// <returns>Vector3D representing euler angles.</returns>	
		private Vector3D GetEulerAngles() => new Vector3D(RotationX, RotationY, RotationZ);

		// I'm scared of the above being wrong sometimes (the GUI controls don't always match the real rotation).
		// Using this one based on the raw values until convinced it's safe.
		private Vector3D GetCurrenRotation() => new Quaternion(Rotation,
																Rotation2,
																Rotation3,
																Rotation4).ToEulerAngles();
		public void Read()
		{
			byte[] bytearray = MainWindow.GameProcess.ReadBytes(BaseModel.GetPointerType(PointerType) + Address, 16, AddressArray);
			Rotation = BitConverter.ToSingle(bytearray, 0);
			Rotation2 = BitConverter.ToSingle(bytearray, 4);
			Rotation3 = BitConverter.ToSingle(bytearray, 8);
			Rotation4 = BitConverter.ToSingle(bytearray, 12);

			// Create euler angles from the quaternion.
			var euler = new Quaternion(
				Rotation,
				Rotation2,
				Rotation3,
				Rotation4
			).ToEulerAngles();

			_RotationX = ((float)euler.X);
			_RotationY = ((float)euler.Y);
			_RotationZ = ((float)euler.Z);
		}
		public void onChange(string storage, string value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			_Value = value;
			WriteMemory(Single.Parse(value));
		}
		public void WriteMemory(Single value)
		{
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}
		private void RotChange()
		{
			// Get the euler angles from UI.	
			var quat = GetEulerAngles().ToQuaternion();
			Rotation = (float)quat.X;
			Rotation2 = (float)quat.Y;
			Rotation3 = (float)quat.Z;
			Rotation4 = (float)quat.W;
			MainWindow.GameProcess.Write(GetBytes(quat), (BaseModel.GetPointerType(PointerType) + Address), AddressArray);

		}
		public void WriteMemoryFrozen()
		{
			var quat = GetEulerAngles().ToQuaternion();
			Rotation = (float)quat.X;
			Rotation2 = (float)quat.Y;
			Rotation3 = (float)quat.Z;
			Rotation4 = (float)quat.W;
			MainWindow.GameProcess.Write(GetBytes(quat), (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}
		public  byte[] GetBytes(Quaternion q)
		{
			List<byte> bytes = new List<byte>(16);
			bytes.AddRange(BitConverter.GetBytes((float)q.X));
			bytes.AddRange(BitConverter.GetBytes((float)q.Y));
			bytes.AddRange(BitConverter.GetBytes((float)q.Z));
			bytes.AddRange(BitConverter.GetBytes((float)q.W));
			return bytes.ToArray();
		}
		#region notimplemented
		public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(byte[] value)
		{
			throw new NotImplementedException();
		}

		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class FloatAddress : MemoryInterface
    {
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }

		public string _Value { get; set; }

		public string Value // this is being set in the backend
		{
			get => _Value;
			set => _Value = value;
		}
		public string UserValue
		{
			get => Value;
			set
			{
				onChange(Value, value, true);
			}
		}
		public void Read()
		{
			var newvalue = MainWindow.GameProcess.ReadFloat(BaseModel.GetPointerType(PointerType)+Address, AddressArray).ToString();
		//	Console.WriteLine($"{Name},{newvalue}");
			if (!Equals(newvalue, Value)) Value = newvalue;
		}
		public void onChange(string storage, string value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			_Value = value;
			WriteMemory(Single.Parse(value));
		}

		public void WriteMemory(Single value)
		{
			_Value = value.ToString();
			Value = value.ToString();
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
			if (Name == "AnimationSpeed") MainWindow.GameProcess.Write((BaseModel.GetPointerType(PointerType) + BaseModel.Offsets.AnimationSpeed2), float.Parse(Value));
		}

		public void WriteMemoryFrozen()
		{
			MainWindow.GameProcess.Write(float.Parse(Value), (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
			if (Name == "AnimationSpeed") MainWindow.GameProcess.Write((BaseModel.GetPointerType(PointerType) + BaseModel.Offsets.AnimationSpeed2), float.Parse(Value));
			else if (Name == "FreezeFacial") MainWindow.GameProcess.Write((BaseModel.GetPointerType(PointerType) + Address), (float)0);
		}
			#region notimplemented
			public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(byte[] value)
		{
			throw new NotImplementedException();
		}

		#endregion

		public event PropertyChangedEventHandler PropertyChanged;
    }

	public class BustScale : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }

		public int _Value { get; set; }

		public int Value // this is being set in the backend
		{
			get => _Value;
			set => _Value = value;
		}
		public int UserValue
		{
			get => Value;
			set
			{
				userchanged = true;

				onChange(Value, value, true);
			}
		}
		public int Volume { get; set; }
		public int scalefactor;
		public int ScaleFactor
		{
			get => scalefactor;
			set
			{
				scalefactor = value;
			}
		}

		public int ScaleFactorX
		{
			get => ScaleFactor;
			set
			{
				userchanged = true;
				onChange(Value, value, true);
			}
		}
		public bool userchanged;

		public bool Userchanged
		{
			get => userchanged;
			set => userchanged = value;
		}
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }
		public void Read()
		{
			byte[] bytearray = MainWindow.GameProcess.ReadBytes(BaseModel.GetPointerType(PointerType) + Address, 12, AddressArray);
			X = BitConverter.ToSingle(bytearray, 0);
			Y = BitConverter.ToSingle(bytearray, 4);
			Z = BitConverter.ToSingle(bytearray, 8);
			//if(scale)
			//figure out better way than this. 
			Volume = ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[23].Value;
			if (!userchanged)
			{
				ScaleFactor = Volume;
			}
	//		var A = ((Volume + scalefactor))-100;
		//	var Max = Math.Round(1.200000048 * 1.184000015 * 1.080000043);
		//	var Min = Math.Round(0.8000000119 * 0.8159999847 * 0.9200000167);
		//	var ScaleValue = (Y * Z * X);
			//	Console.WriteLine($"ScaleFactor:{((scalefactor * (Math.Round((1.200000048 * 1.184000015 * 1.080000043) - Math.Round(0.8000000119 * 0.8159999847 * 0.9200000167))) / 1000) * 1000)}");
			//	Console.WriteLine($"A:{((A * (Math.Round((1.200000048 * 1.184000015 * 1.080000043) - Math.Round(0.8000000119 * 0.8159999847 * 0.9200000167))) / 1000) * 1000)}");
		//	Console.WriteLine($"A:{(((A * (Max - Min)) / 1000) * 1000)}");
			//Console.WriteLine( ((A * ((ScaleValue + (Max - Min))-ScaleValue)) / 1000) * 1000);
		}
		
		public void onChange(int storage, int value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			scalefactor = value;
			WriteMemory(value);
		}
		public void WriteMemory(int value)
		{
			float X = (value) * (float)0.00160000026 + (float)0.9200000167;

			float Y = (value) * (float)0.004000000361 + (float)0.8000000119;

			float Z = (value) * (float)0.003680000303 + (float)0.8159999847;

			BaseModel.AddressList["BustX"].WriteMemory(X);
			BaseModel.AddressList["BustY"].WriteMemory(Y);
			BaseModel.AddressList["BustZ"].WriteMemory(Z);
		}
		public void WriteMemoryFrozen()
		{
			float X = (ScaleFactor) * (float)0.00160000026 + (float)0.9200000167;

			float Y = (ScaleFactor) * (float)0.004000000361 + (float)0.8000000119;

			float Z = (ScaleFactor) * (float)0.003680000303 + (float)0.8159999847;

			BaseModel.AddressList["BustX"].WriteMemory(X);
			BaseModel.AddressList["BustY"].WriteMemory(Y);
			BaseModel.AddressList["BustZ"].WriteMemory(Z);

		}
		#region notimplemented
		public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}
		public void WriteMemory(Single value)
		{

			throw new NotImplementedException();
		}

		public void WriteMemory(byte[] value)
		{
			throw new NotImplementedException();
		}

		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class ByteAddress : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }

		public byte _Value { get; set; }

		public byte Value // this is being set in the backend
		{
			get => _Value;
			set => _Value = value;
		}
		public byte UserValue
		{
			get => Value;
			set
			{
				onChange(Value, value, true);
			}
		}
		public void Read()
		{
			byte newvalue = MainWindow.GameProcess.ReadByte(BaseModel.GetPointerType(PointerType) + Address, AddressArray);
			if (!Equals(newvalue, Value)) Value = newvalue;
		}
		public void onChange(byte storage, byte value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			_Value = value;
			WriteMemory(value);
		}

		public void WriteMemory(byte value)
		{
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}
		public void WriteMemoryFrozen()
		{
			MainWindow.GameProcess.Write(Value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}


		#region notimplemented
		public void WriteMemory(Single value)
		{
			throw new NotImplementedException();
		}
		public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(byte[] value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}

		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}
	public class UInt16Address : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }

		public string _Value { get; set; }

		public string Value // this is being set in the backend
		{
			get => _Value;
			set => _Value = value;
		}
		public string UserValue
		{
			get => Value;
			set => onChange(Value, value, true);
		}
		public void Read()
		{
			var newvalue = MainWindow.GameProcess.ReadUInt16(BaseModel.GetPointerType(PointerType) + Address, AddressArray).ToString();
			if (!Equals(newvalue, Value)) Value = newvalue;
		}
		public void onChange(string storage, string value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			_Value = value;
			WriteMemory(value);
		}

		public void WriteMemory(string value)
		{
			Value = value;
			MainWindow.GameProcess.Write(ushort.Parse(value), (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
			#region DataHead /Path
			if(Name=="DataPath")
			{
				var ClanValue = ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value;
				if (ClanValue == 1 || ClanValue == 3 || ClanValue == 5 || ClanValue == 7 || ClanValue == 9 || ClanValue == 11 || ClanValue == 13 || ClanValue == 15)
				{
					if (value == "301") MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					else if (value == "401") MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					else MainWindow.GameProcess.Write((byte)0x01, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
				}
				else
				{
					if (ClanValue == 2 || ClanValue == 4 || ClanValue == 6 || ClanValue == 8 || ClanValue == 10)
					{
						if (value == "101") MainWindow.GameProcess.Write((byte)0x01, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (value == "201") MainWindow.GameProcess.Write((byte)0x01, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					}
					else
					{
						if (value == "101")MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (value == "201") MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (value == "301") MainWindow.GameProcess.Write((byte)0xC9, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (value == "401") MainWindow.GameProcess.Write((byte)0xC9, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					}
				}
			}
            #endregion
        }

        public void WriteMemoryFrozen()
		{
			MainWindow.GameProcess.Write(ushort.Parse(Value), (BaseModel.GetPointerType(PointerType) + Address), AddressArray);

			#region DataHead /Path
			if (Name == "DataPath")
			{
				var ClanValue = ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[4].Value;
				if (ClanValue == 1 || ClanValue == 3 || ClanValue == 5 || ClanValue == 7 || ClanValue == 9 || ClanValue == 11 || ClanValue == 13 || ClanValue == 15)
				{
					if (Value == "301") MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					else if (Value == "401") MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					else MainWindow.GameProcess.Write((byte)0x01, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
				}
				else
				{
					if (ClanValue == 2 || ClanValue == 4 || ClanValue == 6 || ClanValue == 8 || ClanValue == 10)
					{
						if (Value == "101") MainWindow.GameProcess.Write((byte)0x01, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (Value == "201") MainWindow.GameProcess.Write((byte)0x01, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					}
					else
					{
						if (Value == "101") MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (Value == "201") MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (Value == "301") MainWindow.GameProcess.Write((byte)0xC9, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else if (Value == "401") MainWindow.GameProcess.Write((byte)0xC9, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
						else MainWindow.GameProcess.Write((byte)0x65, BaseModel.GetPointerType(PointerType), BaseModel.Offsets.DataHead);
					}
				}
			}
			#endregion
		}

		#region notimplemented
		public void WriteMemory(Single value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(byte[] value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}

		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class Int32Address : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }

		public int _Value { get; set; }

		public int Value // this is being set in the backend
		{
			get => _Value;
			set => _Value = value;
		}
		public int UserValue
		{
			get => Value;
			set
			{
				onChange(Value, value, true);
			}
		}
		public void Read()
		{
			int newvalue = MainWindow.GameProcess.ReadInt32(BaseModel.GetPointerType(PointerType) + Address, AddressArray);
			if (!Equals(newvalue, Value)) Value = newvalue;
		}
		public void onChange(int storage, int value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			_Value = value;
			WriteMemory(value);
		}

		public void WriteMemory(int value)
		{
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}

		public void WriteMemoryFrozen()
		{
			MainWindow.GameProcess.Write(Value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}

		#region notimplemented
		public void WriteMemory(Single value)
		{
			throw new NotImplementedException();
		}
		public void WriteMemory(string value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(byte[] value)
		{
			throw new NotImplementedException();
		}
		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class StringAddress : MemoryInterface
	{
		public string Name { get; set; }

		public bool Freeze { get; set; }

		public ulong Address { get; set; }

		public ulong[] AddressArray { get; set; }

		public PointerType PointerType { get; set; }

		public string _Value { get; set; }

		public string Value // this is being set in the backend
		{
			get => _Value;
			set => _Value = value;
		}
		public string UserValue
		{
			get => Value;
			set
			{
				onChange(Value, value, true);
			}
		}
		public void Read()
		{
			var newvalue = MainWindow.GameProcess.ReadString(BaseModel.GetPointerType(PointerType) + Address, AddressArray);
			if (!Equals(newvalue, Value)) Value = newvalue;
		}
		public void onChange(string storage, string value, bool IsEditing)
		{
			if (!IsEditing) { return; }
			if (Equals(Value, value))
			{
				return;
			}
			_Value = value;
			WriteMemory(value);
		}
		public void WriteMemory(string value)
		{
			MainWindow.GameProcess.Write(value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}
		public void WriteMemoryFrozen()
		{
			MainWindow.GameProcess.Write(Value, (BaseModel.GetPointerType(PointerType) + Address), AddressArray);
		}
		#region notimplemented
		public void WriteMemory(float value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(int value)
		{
			throw new NotImplementedException();
		}

		public void WriteMemory(byte[] value)
		{
			throw new NotImplementedException();
		}

		#endregion
		public event PropertyChangedEventHandler PropertyChanged;
    }
}
