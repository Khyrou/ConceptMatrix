using System;
using System.Collections.Generic;
using ConceptMatrix.Backend;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media.Media3D;
using ConceptMatrix.Models;
using ConceptMatrix.Views;
using System.Windows.Controls.Primitives;

namespace ConceptMatrix.ViewModel
{
    public class PoseMatrixViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BoneNodes bonetree = null;

        public BoneNodes BNode = null;

        public string TheButton = null;
        public int PointerType { get; set; } = 0;
        public float BoneX { get; set; }
        public float UserBoneX
        {
            get => BoneX;
            set
            {
                BoneX = value;
                RotateHelper();
            }
        }

        public float BoneY { get; set; }
        public float UserBoneY
        {
            get => BoneY;
            set
            {
                BoneY = value;
                RotateHelper();
            }
        }

        public float BoneZ { get; set; }
        public float UserBoneZ
        {
            get => BoneZ;
            set
            {
                BoneZ = value;
                RotateHelper();
            }
        }
        private ulong[] pointerPath;
        public ulong[] PointerPath
        {
            get => pointerPath;
            set
            {
                pointerPath = value;
                BoneX = 0;
                BoneY = 0;
                BoneZ = 0;
                if (value != null)
                {
                    byte[] bytearray = MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, value);
                    if (PointerType > 0)
                    {
                        if (PointerType == 1)
                        {
                            PosingMatrixPage.PosingMatrix.XUpDown.Minimum = -10;
                            PosingMatrixPage.PosingMatrix.XUpDown.Maximum = 10;
                            PosingMatrixPage.PosingMatrix.YUpDown.Maximum = 10;
                            PosingMatrixPage.PosingMatrix.YUpDown.Minimum = -10;
                            PosingMatrixPage.PosingMatrix.ZUpDown.Maximum = 10;
                            PosingMatrixPage.PosingMatrix.ZUpDown.Minimum = -10;
                            PosingMatrixPage.PosingMatrix.BoneSliderX.Maximum = 10;
                            PosingMatrixPage.PosingMatrix.BoneSliderX.Minimum = -10;
                            PosingMatrixPage.PosingMatrix.BoneSliderY.Maximum = 10;
                            PosingMatrixPage.PosingMatrix.BoneSliderY.Minimum = -10;
                            PosingMatrixPage.PosingMatrix.BoneSliderZ.Maximum = 10;
                            PosingMatrixPage.PosingMatrix.BoneSliderZ.Minimum = -10;
                        }
                        else
                        {
                            PosingMatrixPage.PosingMatrix.XUpDown.Minimum = float.MinValue;
                            PosingMatrixPage.PosingMatrix.XUpDown.Maximum = float.MaxValue;
                            PosingMatrixPage.PosingMatrix.YUpDown.Maximum = float.MaxValue;
                            PosingMatrixPage.PosingMatrix.YUpDown.Minimum = float.MinValue;
                            PosingMatrixPage.PosingMatrix.ZUpDown.Maximum = float.MaxValue;
                            PosingMatrixPage.PosingMatrix.ZUpDown.Minimum = float.MinValue;
                            PosingMatrixPage.PosingMatrix.BoneSliderX.IsEnabled = false;
                            PosingMatrixPage.PosingMatrix.BoneSliderY.IsEnabled = false;
                            PosingMatrixPage.PosingMatrix.BoneSliderZ.IsEnabled = false;
                        }
                        BoneX = BitConverter.ToSingle(bytearray, 0);
                        BoneY = BitConverter.ToSingle(bytearray, 4);
                        BoneZ = BitConverter.ToSingle(bytearray, 8);
                    }
                    else
                    {
                        var euler = new Quaternion(
                        BitConverter.ToSingle(bytearray, 0),
                        BitConverter.ToSingle(bytearray, 4),
                        BitConverter.ToSingle(bytearray, 8),
                        BitConverter.ToSingle(bytearray, 12)).ToEulerAngles();
                        newrot = new Vector3D((float)euler.X, (float)euler.Y, (float)euler.Z);
                        BoneX = (float)euler.X;
                        BoneY = (float)euler.Y;
                        BoneZ = (float)euler.Z;
                    }
                }
            }
        }
        public bool ParentingToggle { get; set; }

        public bool ReadTetriaryFromRunTime = false;

        public static PoseMatrixViewModel PoseVM;

        public Definitions Offsets { get; set; }
        enum FaceRace
        {
            Middy,
            Hroth,
            Viera
        }
        private FaceRace face_check = FaceRace.Middy;

        public PoseMatrixViewModel()
        {
            PoseVM = this;
            Offsets = BaseModel.Offsets;
            InitBonetree();
        }

        public Vector3D oldrot = new Vector3D(0, 0, 0);
        public Vector3D newrot = new Vector3D(0, 0, 0);

        public Vector3D GetEulerAngles() => new Vector3D(BoneX, BoneY, BoneZ);

        #region Rotation Methods
        public void RotateHelper()
        {
            if (PointerPath == null) return;
            if (PointerType > 0)
            {
                MainWindow.GameProcess.Write(GetBytesX(UserBoneX,UserBoneY,UserBoneZ), BaseModel.ActorData, PointerPath);
            }
            else
            {
                Quaternion quat = GetEulerAngles().ToQuaternion();
                //     Console.WriteLine($"{(float)quat.X}, {(float)quat.Y}, {(float)quat.Z}, {(float)quat.W}");
                MainWindow.GameProcess.Write(GetBytes(quat), BaseModel.ActorData, PointerPath);
                oldrot = newrot;
                newrot = new Vector3D(BoneX, BoneY, BoneZ);
                if (ParentingToggle == true && BNode != null)
                {
                    Bone_Flag_Manager();
                    Quaternion q1_inv = Extensions.QInv(oldrot.ToQuaternion());
                    Quaternion q1_new = newrot.ToQuaternion();
                    Rotate_ChildBone(BNode, q1_inv, q1_new);
                }
            }
        }
        public void Rotate_ChildBone(BoneNodes boneParent, Quaternion q1_inv, Quaternion q1_new)
        {
            foreach (BoneNodes boneNode in boneParent)
            {
                ChildBone_Propagator(boneNode, q1_inv, q1_new);
            }
        }
        private void Rotate_UnitBone(ulong[] boneOffset, Quaternion q1_inv, Quaternion q1_new)
        {
            byte[] bytearray = MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, boneOffset);
            if (bytearray == null) return;
            int ctr = 0;
            while (bytearray.All(singleByte => singleByte == 0) && ctr < 100)
            {
                bytearray = MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, boneOffset);
                ctr++;
            }
            Quaternion q2 = new Quaternion(BitConverter.ToSingle(bytearray, 0), BitConverter.ToSingle(bytearray, 4), BitConverter.ToSingle(bytearray, 8), BitConverter.ToSingle(bytearray, 12));
            Quaternion q2_new = Extensions.QuatMult(Extensions.QuatMult(q2, q1_inv), q1_new);
            //  QuatCheck(q2, "q2");
            //  QuatCheck(q1_inv, "q1_inv");
            //  QuatCheck(q1_new, "q1_new");
            MainWindow.GameProcess.Write(GetBytes(q2_new), BaseModel.ActorData, boneOffset);
        }
        private void ChildBone_Propagator(BoneNodes boneParent, Quaternion q1_inv, Quaternion q1_new)
        {
            Rotate_UnitBone(boneParent.Get(), q1_inv, q1_new);
            Rotate_ChildBone(boneParent, q1_inv, q1_new);
        }

        #endregion

        public void Bone_Flag_Manager()
        {
            if (face_check != FaceRace.Middy && ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
            {
                face_check = FaceRace.Middy;
                bone_face = bone_face_middy;
                bone_neck.Remove(bone_face_hroth);
                bone_neck.Remove(bone_face_viera);
                bone_neck.Add(bone_face_middy);
            }
            else if (face_check != FaceRace.Hroth && ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
            {
                face_check = FaceRace.Hroth;
                bone_face = bone_face_hroth;
                bone_neck.Remove(bone_face_middy);
                bone_neck.Remove(bone_face_viera);
                bone_neck.Add(bone_face_hroth);
            }
            else if (face_check != FaceRace.Viera && ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
            {
                face_check = FaceRace.Viera;
                bone_face = bone_face_viera;
                bone_neck.Remove(bone_face_middy);
                bone_neck.Remove(bone_face_hroth);
                bone_neck.Add(bone_face_viera);
            }
            EnableTertiaryFlags();
        }

        public static byte[] GetBytes(Quaternion q)
        {
            List<byte> bytes = new List<byte>(16);
            bytes.AddRange(BitConverter.GetBytes((float)q.X));
            bytes.AddRange(BitConverter.GetBytes((float)q.Y));
            bytes.AddRange(BitConverter.GetBytes((float)q.Z));
            bytes.AddRange(BitConverter.GetBytes((float)q.W));
            return bytes.ToArray();
        }
        public static byte[] GetBytesX(float X, float Y, float Z)
        {
            List<byte> bytes = new List<byte>(12);
            bytes.AddRange(BitConverter.GetBytes(X));
            bytes.AddRange(BitConverter.GetBytes(Y));
            bytes.AddRange(BitConverter.GetBytes(Z));
            return bytes.ToArray();
        }
        public void EnableTertiaryFlags()
        {
            if (!ReadTetriaryFromRunTime)
            {
                ReadTetriaryFromRunTime = true;
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 4 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 6 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                {
                    PosingMatrixPage.PosingMatrix.TailA.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.TailB.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.TailC.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.TailD.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.TailE.IsEnabled = true;
                    bone_waist.Add(bone_tail_a);
                }
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                {
                    PosingMatrixPage.PosingMatrix.HrothWhiskersLeft.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.HrothWhiskersRight.IsEnabled = true;
                }
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                {
                    PosingMatrixPage.PosingMatrix.VieraEarALeft.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.VieraEarARight.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.VieraEarBLeft.IsEnabled = true;
                    PosingMatrixPage.PosingMatrix.VieraEarBRight.IsEnabled = true;
                    for (int i = 0; i < bone_viera_ear_l.Length; i++)
                    {
                        bone_face_viera.Remove(bone_viera_ear_l[i]);
                        bone_face_viera.Remove(bone_viera_ear_r[i]);
                    }
                    bone_face_viera.Add(bone_viera_ear_l[((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value]);
                    bone_face_viera.Add(bone_viera_ear_r[((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value]);
                }
                #region Exhair
                
                int exhair_value = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
                for (int i = 0; i < exhair_value - 1; i++)
                {
                    if (i > 12) break;
                    bone_face.Add(bone_exhair[i]);
                    PosingMatrixPage.PosingMatrix.exhair_buttons[i].IsEnabled = true;
                }
                #endregion
                #region ExMet
                int exmet_value = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);
                for (int i = 0; i < exmet_value - 1; i++)
                {
                    if (i > 17) break; // for now keep it like this
                    if (PosingMatrixPage.PosingMatrix.HelmToggle.IsChecked == true) bone_face.Add(bone_exmet[i]);
                    
                    PosingMatrixPage.PosingMatrix.exmet_buttons[i].IsEnabled = true;
                }
                #endregion
                #region ExTop
                int extop_value = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);
                for (int i = 0; i < extop_value - 1; i++)
                {
                    if (i > 9) break;
                    PosingMatrixPage.PosingMatrix.extop_buttons[i].IsEnabled = true;
                }
                #endregion
            }
        }

        #region Bone Tree
        public class BoneNodes
        {
            private readonly ulong[] BonesOffset;
            private HashSet<BoneNodes> children;
            public BoneNodes(ulong[] offset)
            {
                BonesOffset = offset;
                children = new HashSet<BoneNodes>();
            }

            public ulong[] Get()
            {
                return BonesOffset;
            }
            public BoneNodes Child(ulong[] offset)
            {
                BoneNodes childnode = new BoneNodes(offset);
                children.Add(childnode);
                return childnode;
            }
            public void Add(BoneNodes bnode)
            {
                children.Add(bnode);
            }
            public void Remove(BoneNodes bnode)
            {
                children.Remove(bnode);
            }
            public IEnumerator<BoneNodes> GetEnumerator()
            {
                return children.GetEnumerator();
            }
        }
        public BoneNodes
              bone_lumbar,
              bone_thora,
              bone_cerv,
              bone_neck,
              bone_face,
              bone_face_middy,
              bone_face_viera,
              bone_face_hroth,
              bone_clav_l,
              bone_clav_r,
              bone_arm_l,
              bone_arm_r,
              bone_forearm_l,
              bone_forearm_r,
              bone_hand_l,
              bone_hand_r,
              bone_thumb_l,
              bone_thumb_r,
              bone_index_l,
              bone_index_r,
              bone_middle_l,
              bone_middle_r,
              bone_ring_l,
              bone_ring_r,
              bone_pinky_l,
              bone_pinky_r,
              bone_waist,
              bone_leg_l,
              bone_leg_r,
              bone_knee_l,
              bone_knee_r,
              bone_calf_l,
              bone_calf_r,
              bone_foot_l,
              bone_foot_r,
              bone_tail_waist,
              bone_tail_a,
              bone_tail_b,
              bone_tail_c,
              bone_tail_d,
              bone_eye_l,
              bone_eye_r;
        public BoneNodes[] bone_exhair;
        public BoneNodes[] bone_exmet;
        public BoneNodes[] bone_viera_ear_l;
        public BoneNodes[] bone_viera_ear_r;
        public BoneNodes InitBonetree()
        {
            BoneNodes root_tree = new BoneNodes(BaseModel.Offsets.Root_Bone);
            #region torso tree
            bone_lumbar = root_tree.Child(BaseModel.Offsets.SpineA_Bone);
            bone_thora = bone_lumbar.Child(BaseModel.Offsets.SpineB_Bone);
            bone_cerv = bone_thora.Child(BaseModel.Offsets.SpineC_Bone);
            bone_thora.Child(BaseModel.Offsets.BreastLeft_Bone);
            bone_thora.Child(BaseModel.Offsets.BreastRight_Bone);
            bone_thora.Child(BaseModel.Offsets.ScabbardLeft_Bone);
            bone_thora.Child(BaseModel.Offsets.ScabbardRight_Bone);
            bone_neck = bone_cerv.Child(BaseModel.Offsets.Neck_Bone);
            #endregion

            #region clothes tree
            /*
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothBackALeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothBackBLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothBackCLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothBackARight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothBackBRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothBackCRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothSideALeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothSideBLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothSideCLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothSideARight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothSideBRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothSideCRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothFrontALeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothFrontBLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothFrontCLeft_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothFrontARight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothFrontBRight_X);
            bone_lumbar.Child(Settings.Instance.Character.Body.Bones.ClothFrontCRight_X);
            */
            #endregion

            #region facebone (middy) tree
            bone_face = bone_neck.Child(BaseModel.Offsets.Head_Bone);
            bone_face.Child(BaseModel.Offsets.Nose_Bone);
            bone_face.Child(BaseModel.Offsets.Jaw_Bone);
            bone_face.Child(BaseModel.Offsets.EyelidLowerLeft_Bone);
            bone_face.Child(BaseModel.Offsets.EyelidLowerRight_Bone);
            bone_eye_l = bone_face.Child(BaseModel.Offsets.EyeLeft_Bone);
            bone_eye_l.Child(BaseModel.Offsets.EyeRight_Bone);
            bone_face.Child(BaseModel.Offsets.EarLeft_Bone);
            bone_face.Child(BaseModel.Offsets.EarRight_Bone);
            bone_face.Child(BaseModel.Offsets.EarringALeft_Bone);
            bone_face.Child(BaseModel.Offsets.EarringBLeft_Bone);
            bone_face.Child(BaseModel.Offsets.EarringARight_Bone);
            bone_face.Child(BaseModel.Offsets.EarringBRight_Bone);
            bone_face.Child(BaseModel.Offsets.HairFrontLeft_Bone);
            bone_face.Child(BaseModel.Offsets.HairFrontRight_Bone);
            bone_face.Child(BaseModel.Offsets.HairA_Bone);
            bone_face.Child(BaseModel.Offsets.HairB_Bone);
            bone_face.Child(BaseModel.Offsets.CheekLeft_Bone);
            bone_face.Child(BaseModel.Offsets.CheekRight_Bone);
            bone_face.Child(BaseModel.Offsets.LipsLeft_Bone);
            bone_face.Child(BaseModel.Offsets.LipsRight_Bone);
            bone_face.Child(BaseModel.Offsets.EyebrowLeft_Bone);
            bone_face.Child(BaseModel.Offsets.EyebrowRight_Bone);
            bone_face.Child(BaseModel.Offsets.Bridge_Bone);
            bone_face.Child(BaseModel.Offsets.BrowLeft_Bone);
            bone_face.Child(BaseModel.Offsets.BrowRight_Bone);
            bone_face.Child(BaseModel.Offsets.LipUpperA_Bone);
            bone_face.Child(BaseModel.Offsets.EyelidUpperLeft_Bone);
            bone_face.Child(BaseModel.Offsets.EyelidUpperRight_Bone);
            bone_face.Child(BaseModel.Offsets.LipLowerA_Bone);
            bone_face.Child(BaseModel.Offsets.LipUpperB_Bone);
            bone_face.Child(BaseModel.Offsets.LipLowerB_Bone);
            bone_face_middy = bone_face;
            #endregion

            #region facebone hroth tree
            bone_face_hroth = new BoneNodes(BaseModel.Offsets.Head_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.Nose_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.Jaw_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.EyelidLowerLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.EyelidLowerRight_Bone);
            bone_face_hroth.Add(bone_eye_l);
            bone_face_hroth.Child(BaseModel.Offsets.EarLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.EarRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.EarringALeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.EarringBLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.EarringARight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.EarringBRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HairFrontLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HairFrontRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HairA_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HairB_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothEyebrowLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothEyebrowRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothBridge_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothBrowLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothBrowRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothJawUpper_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothLipUpper_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothEyelidUpperRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothLipsLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothLipsRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothLipUpperLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothLipUpperRight_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothLipLower_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothWhiskersLeft_Bone);
            bone_face_hroth.Child(BaseModel.Offsets.HrothWhiskersRight_Bone);
            #endregion

            #region facebone viera tree
            bone_face_viera = new BoneNodes(BaseModel.Offsets.Head_Bone);
            bone_face_viera.Child(BaseModel.Offsets.Nose_Bone);
            bone_face_viera.Child(BaseModel.Offsets.Jaw_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EyelidLowerLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EyelidLowerRight_Bone);
            bone_face_viera.Add(bone_eye_l);
            bone_face_viera.Child(BaseModel.Offsets.EarLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EarRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EarringALeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EarringBLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EarringARight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EarringBRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.HairFrontLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.HairFrontRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.HairA_Bone);
            bone_face_viera.Child(BaseModel.Offsets.HairB_Bone);
            bone_face_viera.Child(BaseModel.Offsets.CheekLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.CheekRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.LipsLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.LipsRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EyebrowLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EyebrowRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.Bridge_Bone);
            bone_face_viera.Child(BaseModel.Offsets.BrowLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.BrowRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.LipUpperA_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EyelidUpperLeft_Bone);
            bone_face_viera.Child(BaseModel.Offsets.EyelidUpperRight_Bone);
            bone_face_viera.Child(BaseModel.Offsets.VieraLipLowerA_Bone);
            bone_face_viera.Child(BaseModel.Offsets.VieraLipUpperB_Bone);
            bone_face_viera.Child(BaseModel.Offsets.VieraLipLowerB_Bone);
            bone_viera_ear_l = new BoneNodes[5];
            bone_viera_ear_r = new BoneNodes[5];
            bone_viera_ear_l[0] = new BoneNodes(BaseModel.Offsets.VieraEar01ALeft_Bone);
            bone_viera_ear_r[0] = new BoneNodes(BaseModel.Offsets.VieraEar01ARight_Bone);
            bone_viera_ear_l[1] = new BoneNodes(BaseModel.Offsets.VieraEar01ALeft_Bone);
            bone_viera_ear_r[1] = new BoneNodes(BaseModel.Offsets.VieraEar01ARight_Bone);
            bone_viera_ear_l[2] = new BoneNodes(BaseModel.Offsets.VieraEar02ALeft_Bone);
            bone_viera_ear_r[2] = new BoneNodes(BaseModel.Offsets.VieraEar02ARight_Bone);
            bone_viera_ear_l[3] = new BoneNodes(BaseModel.Offsets.VieraEar03ALeft_Bone);
            bone_viera_ear_r[3] = new BoneNodes(BaseModel.Offsets.VieraEar03ARight_Bone);
            bone_viera_ear_l[4] = new BoneNodes(BaseModel.Offsets.VieraEar04ALeft_Bone);
            bone_viera_ear_r[4] = new BoneNodes(BaseModel.Offsets.VieraEar04ARight_Bone);
            bone_viera_ear_l[0].Child(BaseModel.Offsets.VieraEar01BLeft_Bone);
            bone_viera_ear_r[0].Child(BaseModel.Offsets.VieraEar01BRight_Bone);
            bone_viera_ear_l[1].Child(BaseModel.Offsets.VieraEar01BLeft_Bone);
            bone_viera_ear_r[1].Child(BaseModel.Offsets.VieraEar01BRight_Bone);
            bone_viera_ear_l[2].Child(BaseModel.Offsets.VieraEar02BLeft_Bone);
            bone_viera_ear_r[2].Child(BaseModel.Offsets.VieraEar02BRight_Bone);
            bone_viera_ear_l[3].Child(BaseModel.Offsets.VieraEar03BLeft_Bone);
            bone_viera_ear_r[3].Child(BaseModel.Offsets.VieraEar03BRight_Bone);
            bone_viera_ear_l[4].Child(BaseModel.Offsets.VieraEar04BLeft_Bone);
            bone_viera_ear_r[4].Child(BaseModel.Offsets.VieraEar04BRight_Bone);
            #endregion

            #region special handler for eyes
            bone_eye_r = new BoneNodes(BaseModel.Offsets.EyeRight_Bone);
            bone_eye_r.Child(BaseModel.Offsets.EyeLeft_Bone);
            #endregion

            #region armbone tree
            bone_clav_l = bone_cerv.Child(BaseModel.Offsets.ClavicleLeft_Bone);
            bone_arm_l = bone_clav_l.Child(BaseModel.Offsets.ArmLeft_Bone);
            bone_arm_l.Child(BaseModel.Offsets.ShoulderLeft_Bone);
            bone_arm_l.Child(BaseModel.Offsets.PauldronLeft_Bone);
            bone_forearm_l = bone_arm_l.Child(BaseModel.Offsets.ForearmLeft_Bone);
            bone_forearm_l.Child(BaseModel.Offsets.ElbowLeft_Bone);
            bone_forearm_l.Child(BaseModel.Offsets.WristLeft_Bone);
            bone_forearm_l.Child(BaseModel.Offsets.ShieldLeft_Bone);
            bone_forearm_l.Child(BaseModel.Offsets.CouterLeft_Bone);
            bone_hand_l = bone_forearm_l.Child(BaseModel.Offsets.HandLeft_Bone);
            bone_hand_l.Child(BaseModel.Offsets.WeaponLeft_Bone);
            bone_thumb_l = bone_hand_l.Child(BaseModel.Offsets.ThumbALeft_Bone);
            bone_thumb_l.Child(BaseModel.Offsets.ThumbBLeft_Bone);
            bone_index_l = bone_hand_l.Child(BaseModel.Offsets.IndexALeft_Bone);
            bone_index_l.Child(BaseModel.Offsets.IndexBLeft_Bone);
            bone_middle_l = bone_hand_l.Child(BaseModel.Offsets.MiddleALeft_Bone);
            bone_middle_l.Child(BaseModel.Offsets.MiddleBLeft_Bone);
            bone_ring_l = bone_hand_l.Child(BaseModel.Offsets.RingALeft_Bone);
            bone_ring_l.Child(BaseModel.Offsets.RingBLeft_Bone);
            bone_pinky_l = bone_hand_l.Child(BaseModel.Offsets.PinkyALeft_Bone);
            bone_pinky_l.Child(BaseModel.Offsets.PinkyBLeft_Bone);

            bone_clav_r = bone_cerv.Child(BaseModel.Offsets.ClavicleRight_Bone);
            bone_arm_r = bone_clav_r.Child(BaseModel.Offsets.ArmRight_Bone);
            bone_arm_r.Child(BaseModel.Offsets.ShoulderRight_Bone);
            bone_arm_r.Child(BaseModel.Offsets.PauldronRight_Bone);
            bone_forearm_r = bone_arm_r.Child(BaseModel.Offsets.ForearmRight_Bone);
            bone_forearm_r.Child(BaseModel.Offsets.ElbowRight_Bone);
            bone_forearm_r.Child(BaseModel.Offsets.WristRight_Bone);
            bone_forearm_r.Child(BaseModel.Offsets.ShieldRight_Bone);
            bone_forearm_r.Child(BaseModel.Offsets.CouterRight_Bone);
            bone_hand_r = bone_forearm_r.Child(BaseModel.Offsets.HandRight_Bone);
            bone_hand_r.Child(BaseModel.Offsets.WeaponRight_Bone);
            bone_thumb_r = bone_hand_r.Child(BaseModel.Offsets.ThumbARight_Bone);
            bone_thumb_r.Child(BaseModel.Offsets.ThumbBRight_Bone);
            bone_index_r = bone_hand_r.Child(BaseModel.Offsets.IndexARight_Bone);
            bone_index_r.Child(BaseModel.Offsets.IndexBRight_Bone);
            bone_middle_r = bone_hand_r.Child(BaseModel.Offsets.MiddleARight_Bone);
            bone_middle_r.Child(BaseModel.Offsets.MiddleBRight_Bone);
            bone_ring_r = bone_hand_r.Child(BaseModel.Offsets.RingARight_Bone);
            bone_ring_r.Child(BaseModel.Offsets.RingBRight_Bone);
            bone_pinky_r = bone_hand_r.Child(BaseModel.Offsets.PinkyARight_Bone);
            bone_pinky_r.Child(BaseModel.Offsets.PinkyBRight_Bone);
            #endregion

            #region lower half bones tree
            bone_waist = root_tree.Child(BaseModel.Offsets.Waist_Bone);
            bone_waist.Child(BaseModel.Offsets.SheatheLeft_Bone);
            bone_waist.Child(BaseModel.Offsets.SheatheRight_Bone);
            bone_waist.Child(BaseModel.Offsets.HolsterLeft_Bone);
            bone_waist.Child(BaseModel.Offsets.HolsterRight_Bone);
            bone_leg_l = bone_waist.Child(BaseModel.Offsets.LegsLeft_Bone);
            bone_knee_l = bone_leg_l.Child(BaseModel.Offsets.KneeLeft_Bone);
            bone_knee_l.Child(BaseModel.Offsets.PoleynLeft_Bone);
            bone_calf_l = bone_knee_l.Child(BaseModel.Offsets.CalfLeft_Bone);
            bone_foot_l = bone_calf_l.Child(BaseModel.Offsets.FootLeft_Bone);
            bone_foot_l.Child(BaseModel.Offsets.ToesLeft_Bone);

            bone_leg_r = bone_waist.Child(BaseModel.Offsets.LegsRight_Bone);
            bone_knee_r = bone_leg_r.Child(BaseModel.Offsets.KneeRight_Bone);
            bone_knee_r.Child(BaseModel.Offsets.PoleynRight_Bone);
            bone_calf_r = bone_knee_r.Child(BaseModel.Offsets.CalfRight_Bone);
            bone_foot_r = bone_calf_r.Child(BaseModel.Offsets.FootRight_Bone);
            bone_foot_r.Child(BaseModel.Offsets.ToesRight_Bone);
            #endregion

            #region tail bones tree
            bone_tail_a = new BoneNodes(BaseModel.Offsets.TailA_Bone);
            bone_tail_b = bone_tail_a.Child(BaseModel.Offsets.TailB_Bone);
            bone_tail_c = bone_tail_b.Child(BaseModel.Offsets.TailC_Bone);
            bone_tail_c.Child(BaseModel.Offsets.TailD_Bone);
            #endregion

            #region exhair
            bone_exhair = new BoneNodes[12];
            bone_exhair[0] = new BoneNodes(BaseModel.Offsets.ExHairA_Bone);
            bone_exhair[1] = new BoneNodes(BaseModel.Offsets.ExHairB_Bone);
            bone_exhair[2] = new BoneNodes(BaseModel.Offsets.ExHairC_Bone);
            bone_exhair[3] = new BoneNodes(BaseModel.Offsets.ExHairD_Bone);
            bone_exhair[4] = new BoneNodes(BaseModel.Offsets.ExHairE_Bone);
            bone_exhair[5] = new BoneNodes(BaseModel.Offsets.ExHairF_Bone);
            bone_exhair[6] = new BoneNodes(BaseModel.Offsets.ExHairG_Bone);
            bone_exhair[7] = new BoneNodes(BaseModel.Offsets.ExHairH_Bone);
            bone_exhair[8] = new BoneNodes(BaseModel.Offsets.ExHairI_Bone);
            bone_exhair[9] = new BoneNodes(BaseModel.Offsets.ExHairJ_Bone);
            bone_exhair[10] = new BoneNodes(BaseModel.Offsets.ExHairK_Bone);
            bone_exhair[11] = new BoneNodes(BaseModel.Offsets.ExHairL_Bone);
            #endregion

            #region exmet
            bone_exmet = new BoneNodes[18];
            bone_exmet[0] = new BoneNodes(BaseModel.Offsets.ExMetA_Bone);
            bone_exmet[1] = new BoneNodes(BaseModel.Offsets.ExMetB_Bone);
            bone_exmet[2] = new BoneNodes(BaseModel.Offsets.ExMetC_Bone);
            bone_exmet[3] = new BoneNodes(BaseModel.Offsets.ExMetD_Bone);
            bone_exmet[4] = new BoneNodes(BaseModel.Offsets.ExMetE_Bone);
            bone_exmet[5] = new BoneNodes(BaseModel.Offsets.ExMetF_Bone);
            bone_exmet[6] = new BoneNodes(BaseModel.Offsets.ExMetG_Bone);
            bone_exmet[7] = new BoneNodes(BaseModel.Offsets.ExMetH_Bone);
            bone_exmet[8] = new BoneNodes(BaseModel.Offsets.ExMetI_Bone);
            bone_exmet[9] = new BoneNodes(BaseModel.Offsets.ExMetJ_Bone);
            bone_exmet[10] = new BoneNodes(BaseModel.Offsets.ExMetK_Bone);
            bone_exmet[11] = new BoneNodes(BaseModel.Offsets.ExMetL_Bone);
            bone_exmet[12] = new BoneNodes(BaseModel.Offsets.ExMetM_Bone);
            bone_exmet[13] = new BoneNodes(BaseModel.Offsets.ExMetN_Bone);
            bone_exmet[14] = new BoneNodes(BaseModel.Offsets.ExMetO_Bone);
            bone_exmet[15] = new BoneNodes(BaseModel.Offsets.ExMetP_Bone);
            bone_exmet[16] = new BoneNodes(BaseModel.Offsets.ExMetQ_Bone);
            bone_exmet[17] = new BoneNodes(BaseModel.Offsets.ExMetR_Bone);
            #endregion

            return root_tree;
        }
        #endregion
    }
}
