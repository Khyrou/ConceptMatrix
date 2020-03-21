using ConceptMatrix.Backend;
using ConceptMatrix.Models;
using ConceptMatrix.ViewModel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.Views
{
    /// <summary>
    /// Interaction logic for PosingMatrixPage.xaml
    /// </summary>
    public partial class PosingMatrixPage : UserControl
    {
        public static PosingMatrixPage PosingMatrix;
        public ToggleButton[] exhair_buttons, exmet_buttons, extop_buttons;
        public ToggleButton ToggleSave;
        #region Savestate01 Strings
        public string Race_Sav01;

        public string Root_Sav01;
        public string Abdomen_Sav01;
        public string Throw_Sav01;
        public string Waist_Sav01;
        public string SpineA_Sav01;
        public string LegLeft_Sav01;
        public string LegRight_Sav01;
        public string HolsterLeft_Sav01;
        public string HolsterRight_Sav01;
        public string SheatheLeft_Sav01;
        public string SheatheRight_Sav01;
        public string SpineB_Sav01;
        public string ClothBackALeft_Sav01;
        public string ClothBackARight_Sav01;
        public string ClothFrontALeft_Sav01;
        public string ClothFrontARight_Sav01;
        public string ClothSideALeft_Sav01;
        public string ClothSideARight_Sav01;
        public string KneeLeft_Sav01;
        public string KneeRight_Sav01;
        public string BreastLeft_Sav01;
        public string BreastRight_Sav01;
        public string SpineC_Sav01;
        public string ClothBackBLeft_Sav01;
        public string ClothBackBRight_Sav01;
        public string ClothFrontBLeft_Sav01;
        public string ClothFrontBRight_Sav01;
        public string ClothSideBLeft_Sav01;
        public string ClothSideBRight_Sav01;
        public string CalfLeft_Sav01;
        public string CalfRight_Sav01;
        public string ScabbardLeft_Sav01;
        public string ScabbardRight_Sav01;
        public string Neck_Sav01;
        public string ClavicleLeft_Sav01;
        public string ClavicleRight_Sav01;
        public string ClothBackCLeft_Sav01;
        public string ClothBackCRight_Sav01;
        public string ClothFrontCLeft_Sav01;
        public string ClothFrontCRight_Sav01;
        public string ClothSideCLeft_Sav01;
        public string ClothSideCRight_Sav01;
        public string PoleynLeft_Sav01;
        public string PoleynRight_Sav01;
        public string FootLeft_Sav01;
        public string FootRight_Sav01;
        public string Head_Sav01;
        public string ArmLeft_Sav01;
        public string ArmRight_Sav01;
        public string PauldronLeft_Sav01;
        public string PauldronRight_Sav01;
        public string Unknown00_Sav01;
        public string ToesLeft_Sav01;
        public string ToesRight_Sav01;
        public string HairA_Sav01;
        public string HairFrontLeft_Sav01;
        public string HairFrontRight_Sav01;
        public string EarLeft_Sav01;
        public string EarRight_Sav01;
        public string ForearmLeft_Sav01;
        public string ForearmRight_Sav01;
        public string ShoulderLeft_Sav01;
        public string ShoulderRight_Sav01;
        public string HairB_Sav01;
        public string HandLeft_Sav01;
        public string HandRight_Sav01;
        public string ShieldLeft_Sav01;
        public string ShieldRight_Sav01;
        public string EarringALeft_Sav01;
        public string EarringARight_Sav01;
        public string ElbowLeft_Sav01;
        public string ElbowRight_Sav01;
        public string CouterLeft_Sav01;
        public string CouterRight_Sav01;
        public string WristLeft_Sav01;
        public string WristRight_Sav01;
        public string IndexALeft_Sav01;
        public string IndexARight_Sav01;
        public string PinkyALeft_Sav01;
        public string PinkyARight_Sav01;
        public string RingALeft_Sav01;
        public string RingARight_Sav01;
        public string MiddleALeft_Sav01;
        public string MiddleARight_Sav01;
        public string ThumbALeft_Sav01;
        public string ThumbARight_Sav01;
        public string WeaponLeft_Sav01;
        public string WeaponRight_Sav01;
        public string EarringBLeft_Sav01;
        public string EarringBRight_Sav01;
        public string IndexBLeft_Sav01;
        public string IndexBRight_Sav01;
        public string PinkyBLeft_Sav01;
        public string PinkyBRight_Sav01;
        public string RingBLeft_Sav01;
        public string RingBRight_Sav01;
        public string MiddleBLeft_Sav01;
        public string MiddleBRight_Sav01;
        public string ThumbBLeft_Sav01;
        public string ThumbBRight_Sav01;
        public string TailA_Sav01;
        public string TailB_Sav01;
        public string TailC_Sav01;
        public string TailD_Sav01;
        public string TailE_Sav01;
        public string RootHead_Sav01;
        public string Jaw_Sav01;
        public string EyelidLowerLeft_Sav01;
        public string EyelidLowerRight_Sav01;
        public string EyeLeft_Sav01;
        public string EyeRight_Sav01;
        public string Nose_Sav01;
        public string CheekLeft_Sav01;
        public string HrothWhiskersLeft_Sav01;
        public string CheekRight_Sav01;
        public string HrothWhiskersRight_Sav01;
        public string LipsLeft_Sav01;
        public string HrothEyebrowLeft_Sav01;
        public string LipsRight_Sav01;
        public string HrothEyebrowRight_Sav01;
        public string EyebrowLeft_Sav01;
        public string HrothBridge_Sav01;
        public string EyebrowRight_Sav01;
        public string HrothBrowLeft_Sav01;
        public string Bridge_Sav01;
        public string HrothBrowRight_Sav01;
        public string BrowLeft_Sav01;
        public string HrothJawUpper_Sav01;
        public string BrowRight_Sav01;
        public string HrothLipUpper_Sav01;
        public string LipUpperA_Sav01;
        public string HrothEyelidUpperLeft_Sav01;
        public string EyelidUpperLeft_Sav01;
        public string HrothEyelidUpperRight_Sav01;
        public string EyelidUpperRight_Sav01;
        public string HrothLipsLeft_Sav01;
        public string LipLowerA_Sav01;
        public string HrothLipsRight_Sav01;
        public string VieraEar01ALeft_Sav01;
        public string LipUpperB_Sav01;
        public string HrothLipUpperLeft_Sav01;
        public string VieraEar01ARight_Sav01;
        public string LipLowerB_Sav01;
        public string HrothLipUpperRight_Sav01;
        public string VieraEar02ALeft_Sav01;
        public string HrothLipLower_Sav01;
        public string VieraEar02ARight_Sav01;
        public string VieraEar03ALeft_Sav01;
        public string VieraEar03ARight_Sav01;
        public string VieraEar04ALeft_Sav01;
        public string VieraEar04ARight_Sav01;
        public string VieraLipLowerA_Sav01;
        public string VieraLipUpperB_Sav01;
        public string VieraEar01BLeft_Sav01;
        public string VieraEar01BRight_Sav01;
        public string VieraEar02BLeft_Sav01;
        public string VieraEar02BRight_Sav01;
        public string VieraEar03BLeft_Sav01;
        public string VieraEar03BRight_Sav01;
        public string VieraEar04BLeft_Sav01;
        public string VieraEar04BRight_Sav01;
        public string VieraLipLowerB_Sav01;
        public string ExRootHair_Sav01;
        public string ExHairA_Sav01;
        public string ExHairB_Sav01;
        public string ExHairC_Sav01;
        public string ExHairD_Sav01;
        public string ExHairE_Sav01;
        public string ExHairF_Sav01;
        public string ExHairG_Sav01;
        public string ExHairH_Sav01;
        public string ExHairI_Sav01;
        public string ExHairJ_Sav01;
        public string ExHairK_Sav01;
        public string ExHairL_Sav01;
        public string ExRootMet_Sav01;
        public string ExMetA_Sav01;
        public string ExMetB_Sav01;
        public string ExMetC_Sav01;
        public string ExMetD_Sav01;
        public string ExMetE_Sav01;
        public string ExMetF_Sav01;
        public string ExMetG_Sav01;
        public string ExMetH_Sav01;
        public string ExMetI_Sav01;
        public string ExMetJ_Sav01;
        public string ExMetK_Sav01;
        public string ExMetL_Sav01;
        public string ExMetM_Sav01;
        public string ExMetN_Sav01;
        public string ExMetO_Sav01;
        public string ExMetP_Sav01;
        public string ExMetQ_Sav01;
        public string ExMetR_Sav01;
        public string ExRootTop_Sav01;
        public string ExTopA_Sav01;
        public string ExTopB_Sav01;
        public string ExTopC_Sav01;
        public string ExTopD_Sav01;
        public string ExTopE_Sav01;
        public string ExTopF_Sav01;
        public string ExTopG_Sav01;
        public string ExTopH_Sav01;
        public string ExTopI_Sav01;
        #endregion
        #region Savestate02 Strings
        public string Race_Sav02;

        public string Root_Sav02;
        public string Abdomen_Sav02;
        public string Throw_Sav02;
        public string Waist_Sav02;
        public string SpineA_Sav02;
        public string LegLeft_Sav02;
        public string LegRight_Sav02;
        public string HolsterLeft_Sav02;
        public string HolsterRight_Sav02;
        public string SheatheLeft_Sav02;
        public string SheatheRight_Sav02;
        public string SpineB_Sav02;
        public string ClothBackALeft_Sav02;
        public string ClothBackARight_Sav02;
        public string ClothFrontALeft_Sav02;
        public string ClothFrontARight_Sav02;
        public string ClothSideALeft_Sav02;
        public string ClothSideARight_Sav02;
        public string KneeLeft_Sav02;
        public string KneeRight_Sav02;
        public string BreastLeft_Sav02;
        public string BreastRight_Sav02;
        public string SpineC_Sav02;
        public string ClothBackBLeft_Sav02;
        public string ClothBackBRight_Sav02;
        public string ClothFrontBLeft_Sav02;
        public string ClothFrontBRight_Sav02;
        public string ClothSideBLeft_Sav02;
        public string ClothSideBRight_Sav02;
        public string CalfLeft_Sav02;
        public string CalfRight_Sav02;
        public string ScabbardLeft_Sav02;
        public string ScabbardRight_Sav02;
        public string Neck_Sav02;
        public string ClavicleLeft_Sav02;
        public string ClavicleRight_Sav02;
        public string ClothBackCLeft_Sav02;
        public string ClothBackCRight_Sav02;
        public string ClothFrontCLeft_Sav02;
        public string ClothFrontCRight_Sav02;
        public string ClothSideCLeft_Sav02;
        public string ClothSideCRight_Sav02;
        public string PoleynLeft_Sav02;
        public string PoleynRight_Sav02;
        public string FootLeft_Sav02;
        public string FootRight_Sav02;
        public string Head_Sav02;
        public string ArmLeft_Sav02;
        public string ArmRight_Sav02;
        public string PauldronLeft_Sav02;
        public string PauldronRight_Sav02;
        public string Unknown00_Sav02;
        public string ToesLeft_Sav02;
        public string ToesRight_Sav02;
        public string HairA_Sav02;
        public string HairFrontLeft_Sav02;
        public string HairFrontRight_Sav02;
        public string EarLeft_Sav02;
        public string EarRight_Sav02;
        public string ForearmLeft_Sav02;
        public string ForearmRight_Sav02;
        public string ShoulderLeft_Sav02;
        public string ShoulderRight_Sav02;
        public string HairB_Sav02;
        public string HandLeft_Sav02;
        public string HandRight_Sav02;
        public string ShieldLeft_Sav02;
        public string ShieldRight_Sav02;
        public string EarringALeft_Sav02;
        public string EarringARight_Sav02;
        public string ElbowLeft_Sav02;
        public string ElbowRight_Sav02;
        public string CouterLeft_Sav02;
        public string CouterRight_Sav02;
        public string WristLeft_Sav02;
        public string WristRight_Sav02;
        public string IndexALeft_Sav02;
        public string IndexARight_Sav02;
        public string PinkyALeft_Sav02;
        public string PinkyARight_Sav02;
        public string RingALeft_Sav02;
        public string RingARight_Sav02;
        public string MiddleALeft_Sav02;
        public string MiddleARight_Sav02;
        public string ThumbALeft_Sav02;
        public string ThumbARight_Sav02;
        public string WeaponLeft_Sav02;
        public string WeaponRight_Sav02;
        public string EarringBLeft_Sav02;
        public string EarringBRight_Sav02;
        public string IndexBLeft_Sav02;
        public string IndexBRight_Sav02;
        public string PinkyBLeft_Sav02;
        public string PinkyBRight_Sav02;
        public string RingBLeft_Sav02;
        public string RingBRight_Sav02;
        public string MiddleBLeft_Sav02;
        public string MiddleBRight_Sav02;
        public string ThumbBLeft_Sav02;
        public string ThumbBRight_Sav02;
        public string TailA_Sav02;
        public string TailB_Sav02;
        public string TailC_Sav02;
        public string TailD_Sav02;
        public string TailE_Sav02;
        public string RootHead_Sav02;
        public string Jaw_Sav02;
        public string EyelidLowerLeft_Sav02;
        public string EyelidLowerRight_Sav02;
        public string EyeLeft_Sav02;
        public string EyeRight_Sav02;
        public string Nose_Sav02;
        public string CheekLeft_Sav02;
        public string HrothWhiskersLeft_Sav02;
        public string CheekRight_Sav02;
        public string HrothWhiskersRight_Sav02;
        public string LipsLeft_Sav02;
        public string HrothEyebrowLeft_Sav02;
        public string LipsRight_Sav02;
        public string HrothEyebrowRight_Sav02;
        public string EyebrowLeft_Sav02;
        public string HrothBridge_Sav02;
        public string EyebrowRight_Sav02;
        public string HrothBrowLeft_Sav02;
        public string Bridge_Sav02;
        public string HrothBrowRight_Sav02;
        public string BrowLeft_Sav02;
        public string HrothJawUpper_Sav02;
        public string BrowRight_Sav02;
        public string HrothLipUpper_Sav02;
        public string LipUpperA_Sav02;
        public string HrothEyelidUpperLeft_Sav02;
        public string EyelidUpperLeft_Sav02;
        public string HrothEyelidUpperRight_Sav02;
        public string EyelidUpperRight_Sav02;
        public string HrothLipsLeft_Sav02;
        public string LipLowerA_Sav02;
        public string HrothLipsRight_Sav02;
        public string VieraEar01ALeft_Sav02;
        public string LipUpperB_Sav02;
        public string HrothLipUpperLeft_Sav02;
        public string VieraEar01ARight_Sav02;
        public string LipLowerB_Sav02;
        public string HrothLipUpperRight_Sav02;
        public string VieraEar02ALeft_Sav02;
        public string HrothLipLower_Sav02;
        public string VieraEar02ARight_Sav02;
        public string VieraEar03ALeft_Sav02;
        public string VieraEar03ARight_Sav02;
        public string VieraEar04ALeft_Sav02;
        public string VieraEar04ARight_Sav02;
        public string VieraLipLowerA_Sav02;
        public string VieraLipUpperB_Sav02;
        public string VieraEar01BLeft_Sav02;
        public string VieraEar01BRight_Sav02;
        public string VieraEar02BLeft_Sav02;
        public string VieraEar02BRight_Sav02;
        public string VieraEar03BLeft_Sav02;
        public string VieraEar03BRight_Sav02;
        public string VieraEar04BLeft_Sav02;
        public string VieraEar04BRight_Sav02;
        public string VieraLipLowerB_Sav02;
        public string ExRootHair_Sav02;
        public string ExHairA_Sav02;
        public string ExHairB_Sav02;
        public string ExHairC_Sav02;
        public string ExHairD_Sav02;
        public string ExHairE_Sav02;
        public string ExHairF_Sav02;
        public string ExHairG_Sav02;
        public string ExHairH_Sav02;
        public string ExHairI_Sav02;
        public string ExHairJ_Sav02;
        public string ExHairK_Sav02;
        public string ExHairL_Sav02;
        public string ExRootMet_Sav02;
        public string ExMetA_Sav02;
        public string ExMetB_Sav02;
        public string ExMetC_Sav02;
        public string ExMetD_Sav02;
        public string ExMetE_Sav02;
        public string ExMetF_Sav02;
        public string ExMetG_Sav02;
        public string ExMetH_Sav02;
        public string ExMetI_Sav02;
        public string ExMetJ_Sav02;
        public string ExMetK_Sav02;
        public string ExMetL_Sav02;
        public string ExMetM_Sav02;
        public string ExMetN_Sav02;
        public string ExMetO_Sav02;
        public string ExMetP_Sav02;
        public string ExMetQ_Sav02;
        public string ExMetR_Sav02;
        public string ExRootTop_Sav02;
        public string ExTopA_Sav02;
        public string ExTopB_Sav02;
        public string ExTopC_Sav02;
        public string ExTopD_Sav02;
        public string ExTopE_Sav02;
        public string ExTopF_Sav02;
        public string ExTopG_Sav02;
        public string ExTopH_Sav02;
        public string ExTopI_Sav02;
        #endregion
        #region Savestate Bools
        public bool HeadSaved01;
        public bool HairSaved01;
        public bool EarringsSaved01;
        public bool BodySaved01;
        public bool LeftArmSaved01;
        public bool RightArmSaved01;
        public bool ClothesSaved01;
        public bool WeaponsSaved01;
        public bool LeftHandSaved01;
        public bool RightHandSaved01;
        public bool WaistSaved01;
        public bool LeftLegSaved01;
        public bool RightLegSaved01;
        public bool HelmSaved01;
        public bool TopSaved01;

        public bool HeadSaved02;
        public bool HairSaved02;
        public bool EarringsSaved02;
        public bool BodySaved02;
        public bool LeftArmSaved02;
        public bool RightArmSaved02;
        public bool ClothesSaved02;
        public bool WeaponsSaved02;
        public bool LeftHandSaved02;
        public bool RightHandSaved02;
        public bool WaistSaved02;
        public bool LeftLegSaved02;
        public bool RightLegSaved02;
        public bool HelmSaved02;
        public bool TopSaved02;
        #endregion

        public PosingMatrixPage()
        {
            InitializeComponent();
            PosingMatrix = this;
            exhair_buttons = new ToggleButton[] { ExHairA, ExHairB, ExHairC, ExHairD, ExHairE, ExHairF, ExHairG, ExHairH, ExHairI, ExHairJ, ExHairK, ExHairL };
            exmet_buttons = new ToggleButton[] { ExMetA, ExMetB, ExMetC, ExMetD, ExMetE, ExMetF, ExMetG, ExMetH, ExMetI, ExMetJ, ExMetK, ExMetL, ExMetM, ExMetN, ExMetO, ExMetP, ExMetQ, ExMetR };
            extop_buttons = new ToggleButton[] { ExTopA, ExTopB, ExTopC, ExTopD, ExTopE, ExTopF, ExTopG, ExTopH, ExTopI };
        }
        private void EditModeButton_Checked(object sender, RoutedEventArgs e)
        {
            PoseMatrixViewModel.PoseVM.ReadTetriaryFromRunTime = false;
            EnableAll();
            PoseMatrixViewModel.PoseVM.Bone_Flag_Manager();
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton1.Adressed, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton2.Adressed, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton3.Adressed, 0x90, 0x90, 0x90, 0x90);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton4.Adressed, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton6.Adressed, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics1.Adressed, 0x90, 0x90, 0x90, 0x90);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics2.Adressed, 0x90, 0x90, 0x90);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics3.Adressed, 0x90, 0x90, 0x90, 0x90);
        }

        private void EditModeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            PhysicsButton.IsChecked = false;
            WeaponPoSToggle.IsChecked = false;
            ScaleToggle.IsChecked = false;
            HelmToggle.IsChecked = false;
            PoseMatrixViewModel.PoseVM.ReadTetriaryFromRunTime = false;
            UncheckAll();
            DisableAll();
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton1.Adressed, 0x41, 0x0F, 0x29, 0x5C, 0x12, 0x10);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton2.Adressed, 0x43, 0x0F, 0x29, 0x5C, 0x18, 0x10);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton3.Adressed, 0x0F, 0x29, 0x5E, 0x10);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton4.Adressed, 0x41, 0x0F, 0x29, 0x44, 0x12, 0x20);
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton6.Adressed, 0x43, 0x0F, 0x29, 0x44, 0x18, 0x20);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics1.Adressed, 0x0F, 0x29, 0x48, 0x10);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics2.Adressed, 0x0F, 0x29, 0x00);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics3.Adressed, 0x0F, 0x29, 0x40, 0x20);
        }

        private void PhysicsButton_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics1.Adressed, 0x0F, 0x29, 0x48, 0x10);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics2.Adressed, 0x0F, 0x29, 0x00);
            MainWindow.GameProcess.WriteBytes(BaseModel.Physics3.Adressed, 0x0F, 0x29, 0x40, 0x20);
        }

        private void PhysicsButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true)
            {
                MainWindow.GameProcess.WriteBytes(BaseModel.Physics1.Adressed, 0x90, 0x90, 0x90, 0x90);
                MainWindow.GameProcess.WriteBytes(BaseModel.Physics2.Adressed, 0x90, 0x90, 0x90);
                MainWindow.GameProcess.WriteBytes(BaseModel.Physics3.Adressed, 0x90, 0x90, 0x90, 0x90);
            }
        }

        private void Toggles_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender as ToggleButton == ToggleSave)
            {
                PoseMatrixViewModel.PoseVM.BNode = null;
                PoseMatrixViewModel.PoseVM.PointerPath = null;
                PoseMatrixViewModel.PoseVM.BoneX = 0;
                PoseMatrixViewModel.PoseVM.BoneY = 0;
                PoseMatrixViewModel.PoseVM.BoneZ = 0;
            }
        }

        private void Toggles_Checked(object sender, RoutedEventArgs e)
        {
            SwapToggles(sender as ToggleButton);
            GetPointers((sender as ToggleButton).Name);
            ToggleSave = sender as ToggleButton;
        }
        public void GetPointers(string newActive)
        {
            PoseMatrixViewModel.PoseVM.BNode = null;
            PoseMatrixViewModel.PoseVM.PointerPath = null;
            PoseMatrixViewModel.PoseVM.TheButton = newActive;
            PoseMatrixViewModel.PoseVM.PointerType = 0;
            XUpDown.Minimum = 0;
            XUpDown.Maximum = 360;
            YUpDown.Maximum = 360;
            YUpDown.Minimum = 0;
            ZUpDown.Maximum = 360;
            ZUpDown.Minimum = 0;
            BoneSliderX.Maximum = 360;
            BoneSliderX.Minimum = 0;
            BoneSliderY.Maximum = 360;
            BoneSliderY.Minimum = 0;
            BoneSliderZ.Maximum = 360;
            BoneSliderZ.Minimum = 0;
            //if(newActive == "JawSize")
            switch (newActive)
            {
                #region Head
                case "Head":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Head_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Head_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_face;
                    }
                    break;
                case "EyebrowLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyebrowLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyebrowLeft_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyebrowLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyebrowLeft_Bone;
                    }
                    break;
                case "EyebrowRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyebrowRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyebrowRight_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyebrowRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyebrowRight_Bone;
                    }
                    break;
                case "EyeLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyeLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_eye_l;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyeLeft_Bone;
                    }
                    break;
                case "EyeRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyeRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_eye_r;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyeRight_Bone;
                    }
                    break;
                case "Bridge":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothBridge_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Bridge_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothBridge_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Bridge_Bone;
                    }
                    break;
                case "BrowLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothBrowLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BrowLeft_Bone;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothBrowLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BrowLeft_Bone;
                    }
                    break;
                case "BrowRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothBrowRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BrowRight_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothBrowRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BrowRight_Bone;
                    }
                    break;
                case "EarLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarLeft_Bone;
                    }
                    break;
                case "EarRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarRight_Bone;
                    }
                    break;
                case "Nose":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Nose_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Nose_Bone;
                    break;
                case "EyelidUpperLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyelidUpperLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidUpperLeft_Bone;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyelidUpperLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidUpperLeft_Bone;
                    }
                    break;
                case "EyelidUpperRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyelidUpperRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidUpperRight_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothEyelidUpperRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidUpperRight_Bone;
                    }
                    break;
                case "Jaw":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Jaw_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Jaw_Bone;
                    break;
                case "EyelidLowerLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidLowerLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidLowerLeft_Bone;
                    break;
                case "EyelidLowerRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidLowerRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EyelidLowerRight_Bone;
                    break;
                case "CheekLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipUpperLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CheekLeft_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipUpperLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CheekLeft_Bone;
                    }
                    break;
                case "CheekRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipUpperRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CheekRight_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipUpperRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CheekRight_Bone;
                    }
                    break;
                case "LipUpperA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipUpper_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipUpperA_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipUpper_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipUpperA_Bone;
                    }
                    break;
                case "LipUpperB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothJawUpper_Size;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraLipUpperB_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipUpperB_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothJawUpper_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraLipUpperB_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipUpperB_Bone;
                    }
                    break;
                case "LipsLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipsLeft_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipsLeft_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipsLeft_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipsLeft_Bone;
                    }
                    break;
                case "LipsRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipsRight_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipsRight_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipsRight_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipsRight_Bone;
                    }
                    break;
                case "LipLowerA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipLower_Size;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraLipLowerA_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipLowerA_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothLipLower_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraLipLowerA_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipLowerA_Bone;
                    }
                    break;
                case "LipLowerB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraLipLowerB_Size;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipLowerB_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraLipLowerB_Bone;
                        else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LipLowerB_Bone;
                    }
                    break;
                case "VieraEarALeft":

                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ALeft_Size;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ALeft_Size;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02ALeft_Size;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03ALeft_Size;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04ALeft_Size;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ALeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ALeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02ALeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03ALeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04ALeft_Bone;
                    }
                    break;
                case "VieraEarBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04BLeft_Bone;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03BLeft_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04BLeft_Bone;
                    }
                    break;
                case "VieraEarARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04ARight_Bone;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03ARight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04ARight_Bone;
                    }
                    break;
                case "VieraEarBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04BRight_Bone;
                    }
                    else
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 0) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 1) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar01BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 2) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar02BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 3) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar03BRight_Bone;
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[22].Value == 4) PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.VieraEar04BRight_Bone;
                    }
                    break;

                #endregion

                #region Hair & Accessories
                case "HairFrontLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairFrontLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairFrontLeft_Bone;
                    break;

                case "HairFrontRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairFrontRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairFrontRight_Bone;
                    break;

                case "HairA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairA_Bone;
                    break;

                case "HairB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HairB_Bone;
                    break;

                case "HrothWhiskersLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothWhiskersLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothWhiskersLeft_Bone;
                    break;

                case "HrothWhiskersRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothWhiskersRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HrothWhiskersRight_Bone;
                    break;

                case "EarringALeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringALeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringALeft_Bone;
                    break;

                case "EarringARight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringARight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringARight_Bone;
                    break;

                case "EarringBLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringBLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringBLeft_Bone;
                    break;

                case "EarringBRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringBRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.EarringBRight_Bone;
                    break;

                case "ExHairA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairA_Bone;
                    break;
                case "ExHairB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairB_Bone;
                    break;
                case "ExHairC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairC_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairC_Bone;
                    break;
                case "ExHairD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairD_Bone;
                    break;
                case "ExHairE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairE_Bone;
                    break;
                case "ExHairF":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairF_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairF_Bone;
                    break;
                case "ExHairG":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairG_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairG_Bone;
                    break;
                case "ExHairH":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairH_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairH_Bone;
                    break;
                case "ExHairI":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairI_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairI_Bone;
                    break;
                case "ExHairJ":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairJ_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairJ_Bone;
                    break;
                case "ExHairK":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairK_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairK_Bone;
                    break;
                case "ExHairL":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairL_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExHairL_Bone;
                    break;
                #endregion

                #region Body
                case "Neck":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Neck_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Neck_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_neck;
                    }
                    break;
                case "SpineC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SpineC_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SpineC_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_cerv;
                    }
                    break;
                case "SpineB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SpineB_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SpineB_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_thora;
                    }
                    break;
                case "SpineA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SpineA_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SpineA_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_lumbar;
                    }
                    break;
                case "ScabbardLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ScabbardLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ScabbardLeft_Bone;
                    break;
                case "ScabbardRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ScabbardRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ScabbardRight_Bone;
                    break;
                case "ClavicleLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClavicleLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClavicleLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_clav_l;
                    }
                    break;
                case "ClavicleRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClavicleRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClavicleRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_clav_r;
                    }
                    break;
                case "BreastLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BreastLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BreastLeft_Bone;
                    break;
                case "BreastRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BreastRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.BreastRight_Bone;
                    break;
                case "PauldronLeft":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PauldronLeft_Bone;
                    break;
                case "PauldronRight":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PauldronRight_Bone;
                    break;
                case "ShieldLeft":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ShieldLeft_Bone;
                    break;
                case "ShieldRight":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ShieldRight_Bone;
                    break;
                case "ShoulderLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ShoulderLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ShoulderLeft_Bone;
                    break;
                case "ShoulderRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ShoulderRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ShoulderRight_Bone;
                    break;
                case "ArmLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ArmLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ArmLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_arm_l;
                    }
                    break;
                case "ArmRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ArmRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ArmRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_arm_r;
                    }
                    break;
                case "CouterLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CouterLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CouterLeft_Bone;
                    break;
                case "CouterRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CouterRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CouterRight_Bone;
                    break;
                case "ElbowLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ElbowLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ElbowLeft_Bone;
                    break;
                case "ElbowRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ElbowRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ElbowRight_Bone;
                    break;
                case "ForearmLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ForearmLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ForearmLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_forearm_l;
                    }
                    break;
                case "ForearmRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ForearmRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ForearmRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_forearm_r;
                    }
                    break;

                case "WristLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WristLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WristLeft_Bone;
                    break;
                case "WristRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WristRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WristRight_Bone;
                    break;
                #endregion

                #region Clothes
                case "ClothFrontALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontALeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontALeft_Bone;
                    break;
                case "ClothFrontBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontBLeft_Bone;
                    break;
                case "ClothFrontCLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontCLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontCLeft_Bone;
                    break;
                case "ClothFrontARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontARight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontARight_Bone;
                    break;
                case "ClothFrontBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontBRight_Bone;
                    break;
                case "ClothFrontCRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontCRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothFrontCRight_Bone;
                    break;

                case "ClothBackALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackALeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackALeft_Bone;
                    break;
                case "ClothBackBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackBLeft_Bone;
                    break;
                case "ClothBackCLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackCLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackCLeft_Bone;
                    break;

                case "ClothBackARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackARight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackARight_Bone;
                    break;
                case "ClothBackBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackBRight_Bone;
                    break;
                case "ClothBackCRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackCRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothBackCRight_Bone;
                    break;

                case "ClothSideALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideALeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideALeft_Bone;
                    break;
                case "ClothSideBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideBLeft_Bone;
                    break;
                case "ClothSideCLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideCLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideCLeft_Bone;
                    break;
                case "ClothSideARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideARight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideARight_Bone;
                    break;
                case "ClothSideBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideBRight_Bone;
                    break;
                case "ClothSideCRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideCRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ClothSideCRight_Bone;
                    break;
                #endregion

                #region Hands
                case "HandLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HandLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HandLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_hand_l;
                    }
                    break;
                case "HandRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HandRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HandRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_hand_r;
                    }
                    break;
                case "WeaponLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WeaponLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WeaponLeft_Bone;
                    break;
                case "WeaponRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WeaponRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.WeaponRight_Bone;
                    break;
                case "ThumbALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_thumb_l;
                    }
                    break;
                case "ThumbBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbBLeft_Bone;
                    break;
                case "ThumbARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_thumb_r;
                    }
                    break;
                case "ThumbBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ThumbBRight_Bone;
                    break;

                case "IndexALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_index_l;
                    }
                    break;
                case "IndexBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexBLeft_Bone;
                    break;
                case "IndexARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_index_r;
                    }
                    break;
                case "IndexBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.IndexBRight_Bone;
                    break;

                case "RingALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_ring_l;
                    }
                    break;
                case "RingBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingBLeft_Bone;
                    break;
                case "RingARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_ring_r;
                    }
                    break;
                case "RingBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RingBRight_Bone;
                    break;

                case "MiddleALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_middle_l;
                    }
                    break;
                case "MiddleBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleBLeft_Bone;
                    break;
                case "MiddleARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_middle_r;
                    }
                    break;
                case "MiddleBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.MiddleBRight_Bone;
                    break;

                case "PinkyALeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyALeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyALeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_pinky_l;
                    }
                    break;
                case "PinkyBLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyBLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyBLeft_Bone;
                    break;
                case "PinkyARight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyARight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyARight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_pinky_r;
                    }
                    break;
                case "PinkyBRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyBRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PinkyBRight_Bone;
                    break;
                #endregion

                #region Waist & Legs
                case "Waist":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Waist_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Waist_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_waist;
                    }
                    break;

                case "SheatheLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SheatheLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SheatheLeft_Bone;
                    break;
                case "SheatheRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SheatheRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.SheatheRight_Bone;
                    break;

                case "LegLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LegsLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LegsLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_leg_l;
                    }
                    break;
                case "LegRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LegsRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.LegsRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_leg_r;
                    }
                    break;
                case "PoleynLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PoleynLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PoleynLeft_Bone;
                    break;
                case "PoleynRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PoleynRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.PoleynRight_Bone;
                    break;
                case "FootLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.FootLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.FootLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_foot_l;
                    }
                    break;
                case "FootRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.FootRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.FootRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_foot_r;
                    }
                    break;

                case "TailA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailA_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailA_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_tail_a;
                    }
                    break;
                case "TailB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailB_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailB_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_tail_b;
                    }
                    break;
                case "TailC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailC_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailC_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_tail_c;
                    }
                    break;
                case "TailD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailD_Bone;
                    break;
                case "TailE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.TailE_Bone;
                    break;
                case "HolsterLeft":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HolsterLeft_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HolsterLeft_Bone;
                    break;
                case "HolsterRight":
                    if (WeaponPoSToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 2;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HolsterRight_PoS;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.HolsterRight_Bone;
                    break;
                case "KneeLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.KneeLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.KneeLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_knee_l;
                    }
                    break;
                case "KneeRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.KneeRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.KneeRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_knee_r;
                    }
                    break;
                case "CalfLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CalfLeft_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CalfLeft_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_calf_l;
                    }
                    break;
                case "CalfRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CalfRight_Size;
                    }
                    else
                    {
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.CalfRight_Bone;
                        PoseMatrixViewModel.PoseVM.BNode = PoseMatrixViewModel.PoseVM.bone_calf_r;
                    }
                    break;
                case "ToesLeft":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ToesLeft_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ToesLeft_Bone;
                    break;
                case "ToesRight":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ToesRight_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ToesRight_Bone;
                    break;
                #endregion

                #region Equipment
                case "ExMetA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetA_Bone;
                    break;
                case "ExMetB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetB_Bone;
                    break;
                case "ExMetC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetC_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetC_Bone;
                    break;
                case "ExMetD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetD_Bone;
                    break;
                case "ExMetE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetE_Bone;
                    break;
                case "ExMetF":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetF_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetF_Bone;
                    break;
                case "ExMetG":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetG_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetG_Bone;
                    break;
                case "ExMetH":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetH_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetH_Bone;
                    break;
                case "ExMetI":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetI_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetI_Bone;
                    break;
                case "ExMetJ":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetJ_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetJ_Bone;
                    break;
                case "ExMetK":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetK_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetK_Bone;
                    break;
                case "ExMetL":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetL_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetL_Bone;
                    break;
                case "ExMetM":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetM_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetM_Bone;
                    break;
                case "ExMetN":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetN_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetN_Bone;
                    break;
                case "ExMetO":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetO_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetO_Bone;
                    break;
                case "ExMetP":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetP_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetP_Bone;
                    break;
                case "ExMetQ":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetQ_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetQ_Bone;
                    break;
                case "ExMetR":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetR_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExMetR_Bone;
                    break;
                case "ExTopA":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopA_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopA_Bone;
                    break;
                case "ExTopB":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopB_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopB_Bone;
                    break;
                case "ExTopC":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopC_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopC_Bone;
                    break;
                case "ExTopD":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopD_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopD_Bone;
                    break;
                case "ExTopE":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopE_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopE_Bone;
                    break;
                case "ExTopF":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopF_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopF_Bone;
                    break;
                case "ExTopG":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopG_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopG_Bone;
                    break;
                case "ExTopH":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopH_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopH_Bone;
                    break;
                case "ExTopI":
                    if (ScaleToggle.IsChecked == true)
                    {
                        PoseMatrixViewModel.PoseVM.PointerType = 1;
                        PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopI_Size;
                    }
                    else PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.ExTopI_Bone;
                    break;
                #endregion

                #region Other
                case "Root":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Root_Bone;
                    break;

                case "Abdomen":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Abdomen_Bone;
                    break;

                case "Throw":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Throw_Bone;
                    break;

                case "RootHead":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.RootHead_Bone;
                    break;

                case "Unknown00":
                    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.Unknown00_Bone;
                    break;

                case "Weapon01":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.w;
                    break;
                case "Weapon02":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.w;
                    break;
                case "Weapon03":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.w;
                    break;
                case "Weapon04":
                    //    PoseMatrixViewModel.PoseVM.PointerPath = BaseModel.Offsets.w;
                    break;
                #endregion

                default:
                    PoseMatrixViewModel.PoseVM.TheButton = null;
                    PoseMatrixViewModel.PoseVM.PointerPath = null;
                    PoseMatrixViewModel.PoseVM.BNode = null;
                    PoseMatrixViewModel.PoseVM.PointerType = 0;
                    break;

            }
        }
        private void SwapToggles(ToggleButton newActive)
        {
            PoseMatrixViewModel.PoseVM.oldrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.newrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.PointerPath = null;
            PoseMatrixViewModel.PoseVM.PointerType = 0;
            BoneSliderX.IsEnabled = true;
            BoneSliderY.IsEnabled = true;
            BoneSliderZ.IsEnabled = true;
            XUpDown.Minimum = 0;
            XUpDown.Maximum = 360;
            YUpDown.Maximum = 360;
            YUpDown.Minimum = 0;
            ZUpDown.Maximum = 360;
            ZUpDown.Minimum = 0;
            BoneSliderX.Maximum = 360;
            BoneSliderX.Minimum = 0;
            BoneSliderY.Maximum = 360;
            BoneSliderY.Minimum = 0;
            BoneSliderZ.Maximum = 360;
            BoneSliderZ.Minimum = 0;
            #region ToggleButton Ischecked
            Root.IsChecked = (newActive == Root) ? true : false;
            Abdomen.IsChecked = (newActive == Abdomen) ? true : false;
            Throw.IsChecked = (newActive == Throw) ? true : false;
            Waist.IsChecked = (newActive == Waist) ? true : false;
            SpineA.IsChecked = (newActive == SpineA) ? true : false;
            LegLeft.IsChecked = (newActive == LegLeft) ? true : false;
            LegRight.IsChecked = (newActive == LegRight) ? true : false;
            HolsterLeft.IsChecked = (newActive == HolsterLeft) ? true : false;
            HolsterRight.IsChecked = (newActive == HolsterRight) ? true : false;
            SheatheLeft.IsChecked = (newActive == SheatheLeft) ? true : false;
            SheatheRight.IsChecked = (newActive == SheatheRight) ? true : false;
            SpineB.IsChecked = (newActive == SpineB) ? true : false;
            ClothBackALeft.IsChecked = (newActive == ClothBackALeft) ? true : false;
            ClothBackARight.IsChecked = (newActive == ClothBackARight) ? true : false;
            ClothFrontALeft.IsChecked = (newActive == ClothFrontALeft) ? true : false;
            ClothFrontARight.IsChecked = (newActive == ClothFrontARight) ? true : false;
            ClothSideALeft.IsChecked = (newActive == ClothSideALeft) ? true : false;
            ClothSideARight.IsChecked = (newActive == ClothSideARight) ? true : false;
            KneeLeft.IsChecked = (newActive == KneeLeft) ? true : false;
            KneeRight.IsChecked = (newActive == KneeRight) ? true : false;
            BreastLeft.IsChecked = (newActive == BreastLeft) ? true : false;
            BreastRight.IsChecked = (newActive == BreastRight) ? true : false;
            SpineC.IsChecked = (newActive == SpineC) ? true : false;
            ClothBackBLeft.IsChecked = (newActive == ClothBackBLeft) ? true : false;
            ClothBackBRight.IsChecked = (newActive == ClothBackBRight) ? true : false;
            ClothFrontBLeft.IsChecked = (newActive == ClothFrontBLeft) ? true : false;
            ClothFrontBRight.IsChecked = (newActive == ClothFrontBRight) ? true : false;
            ClothSideBLeft.IsChecked = (newActive == ClothSideBLeft) ? true : false;
            ClothSideBRight.IsChecked = (newActive == ClothSideBRight) ? true : false;
            CalfLeft.IsChecked = (newActive == CalfLeft) ? true : false;
            CalfRight.IsChecked = (newActive == CalfRight) ? true : false;
            ScabbardLeft.IsChecked = (newActive == ScabbardLeft) ? true : false;
            ScabbardRight.IsChecked = (newActive == ScabbardRight) ? true : false;
            Neck.IsChecked = (newActive == Neck) ? true : false;
            ClavicleLeft.IsChecked = (newActive == ClavicleLeft) ? true : false;
            ClavicleRight.IsChecked = (newActive == ClavicleRight) ? true : false;
            ClothBackCLeft.IsChecked = (newActive == ClothBackCLeft) ? true : false;
            ClothBackCRight.IsChecked = (newActive == ClothBackCRight) ? true : false;
            ClothFrontCLeft.IsChecked = (newActive == ClothFrontCLeft) ? true : false;
            ClothFrontCRight.IsChecked = (newActive == ClothFrontCRight) ? true : false;
            ClothSideCLeft.IsChecked = (newActive == ClothSideCLeft) ? true : false;
            ClothSideCRight.IsChecked = (newActive == ClothSideCRight) ? true : false;
            PoleynLeft.IsChecked = (newActive == PoleynLeft) ? true : false;
            PoleynRight.IsChecked = (newActive == PoleynRight) ? true : false;
            FootLeft.IsChecked = (newActive == FootLeft) ? true : false;
            FootRight.IsChecked = (newActive == FootRight) ? true : false;
            Head.IsChecked = (newActive == Head) ? true : false;
            ArmLeft.IsChecked = (newActive == ArmLeft) ? true : false;
            ArmRight.IsChecked = (newActive == ArmRight) ? true : false;
            PauldronLeft.IsChecked = (newActive == PauldronLeft) ? true : false;
            PauldronRight.IsChecked = (newActive == PauldronRight) ? true : false;
            Unknown00.IsChecked = (newActive == Unknown00) ? true : false;
            ToesLeft.IsChecked = (newActive == ToesLeft) ? true : false;
            ToesRight.IsChecked = (newActive == ToesRight) ? true : false;
            HairA.IsChecked = (newActive == HairA) ? true : false;
            HairFrontLeft.IsChecked = (newActive == HairFrontLeft) ? true : false;
            HairFrontRight.IsChecked = (newActive == HairFrontRight) ? true : false;
            EarLeft.IsChecked = (newActive == EarLeft) ? true : false;
            EarRight.IsChecked = (newActive == EarRight) ? true : false;
            ForearmLeft.IsChecked = (newActive == ForearmLeft) ? true : false;
            ForearmRight.IsChecked = (newActive == ForearmRight) ? true : false;
            ShoulderLeft.IsChecked = (newActive == ShoulderLeft) ? true : false;
            ShoulderRight.IsChecked = (newActive == ShoulderRight) ? true : false;
            HairB.IsChecked = (newActive == HairB) ? true : false;
            HandLeft.IsChecked = (newActive == HandLeft) ? true : false;
            HandRight.IsChecked = (newActive == HandRight) ? true : false;
            ShieldLeft.IsChecked = (newActive == ShieldLeft) ? true : false;
            ShieldRight.IsChecked = (newActive == ShieldRight) ? true : false;
            EarringALeft.IsChecked = (newActive == EarringALeft) ? true : false;
            EarringARight.IsChecked = (newActive == EarringARight) ? true : false;
            ElbowLeft.IsChecked = (newActive == ElbowLeft) ? true : false;
            ElbowRight.IsChecked = (newActive == ElbowRight) ? true : false;
            CouterLeft.IsChecked = (newActive == CouterLeft) ? true : false;
            CouterRight.IsChecked = (newActive == CouterRight) ? true : false;
            WristLeft.IsChecked = (newActive == WristLeft) ? true : false;
            WristRight.IsChecked = (newActive == WristRight) ? true : false;
            IndexALeft.IsChecked = (newActive == IndexALeft) ? true : false;
            IndexARight.IsChecked = (newActive == IndexARight) ? true : false;
            PinkyALeft.IsChecked = (newActive == PinkyALeft) ? true : false;
            PinkyARight.IsChecked = (newActive == PinkyARight) ? true : false;
            RingALeft.IsChecked = (newActive == RingALeft) ? true : false;
            RingARight.IsChecked = (newActive == RingARight) ? true : false;
            MiddleALeft.IsChecked = (newActive == MiddleALeft) ? true : false;
            MiddleARight.IsChecked = (newActive == MiddleARight) ? true : false;
            ThumbALeft.IsChecked = (newActive == ThumbALeft) ? true : false;
            ThumbARight.IsChecked = (newActive == ThumbARight) ? true : false;
            WeaponLeft.IsChecked = (newActive == WeaponLeft) ? true : false;
            WeaponRight.IsChecked = (newActive == WeaponRight) ? true : false;
            EarringBLeft.IsChecked = (newActive == EarringBLeft) ? true : false;
            EarringBRight.IsChecked = (newActive == EarringBRight) ? true : false;
            IndexBLeft.IsChecked = (newActive == IndexBLeft) ? true : false;
            IndexBRight.IsChecked = (newActive == IndexBRight) ? true : false;
            PinkyBLeft.IsChecked = (newActive == PinkyBLeft) ? true : false;
            PinkyBRight.IsChecked = (newActive == PinkyBRight) ? true : false;
            RingBLeft.IsChecked = (newActive == RingBLeft) ? true : false;
            RingBRight.IsChecked = (newActive == RingBRight) ? true : false;
            MiddleBLeft.IsChecked = (newActive == MiddleBLeft) ? true : false;
            MiddleBRight.IsChecked = (newActive == MiddleBRight) ? true : false;
            ThumbBLeft.IsChecked = (newActive == ThumbBLeft) ? true : false;
            ThumbBRight.IsChecked = (newActive == ThumbBRight) ? true : false;
            TailA.IsChecked = (newActive == TailA) ? true : false;
            TailB.IsChecked = (newActive == TailB) ? true : false;
            TailC.IsChecked = (newActive == TailC) ? true : false;
            TailD.IsChecked = (newActive == TailD) ? true : false;
            TailE.IsChecked = (newActive == TailE) ? true : false;
            RootHead.IsChecked = (newActive == RootHead) ? true : false;
            Jaw.IsChecked = (newActive == Jaw) ? true : false;
            EyelidLowerLeft.IsChecked = (newActive == EyelidLowerLeft) ? true : false;
            EyelidLowerRight.IsChecked = (newActive == EyelidLowerRight) ? true : false;
            EyeLeft.IsChecked = (newActive == EyeLeft) ? true : false;
            EyeRight.IsChecked = (newActive == EyeRight) ? true : false;
            Nose.IsChecked = (newActive == Nose) ? true : false;
            CheekLeft.IsChecked = (newActive == CheekLeft) ? true : false;
            CheekRight.IsChecked = (newActive == CheekRight) ? true : false;

            LipsLeft.IsChecked = (newActive == LipsLeft) ? true : false;
            LipsRight.IsChecked = (newActive == LipsRight) ? true : false;
            EyebrowLeft.IsChecked = (newActive == EyebrowLeft) ? true : false;
            EyebrowRight.IsChecked = (newActive == EyebrowRight) ? true : false;
            Bridge.IsChecked = (newActive == Bridge) ? true : false;
            BrowLeft.IsChecked = (newActive == BrowLeft) ? true : false;
            BrowRight.IsChecked = (newActive == BrowRight) ? true : false;
            LipUpperA.IsChecked = (newActive == LipUpperA) ? true : false;
            EyelidUpperLeft.IsChecked = (newActive == EyelidUpperLeft) ? true : false;
            EyelidUpperRight.IsChecked = (newActive == EyelidUpperRight) ? true : false;
            LipLowerA.IsChecked = (newActive == LipLowerA) ? true : false;
            LipUpperB.IsChecked = (newActive == LipUpperB) ? true : false;
            LipLowerB.IsChecked = (newActive == LipLowerB) ? true : false;
            HrothWhiskersLeft.IsChecked = (newActive == HrothWhiskersLeft) ? true : false;
            HrothWhiskersRight.IsChecked = (newActive == HrothWhiskersRight) ? true : false;
            VieraEarALeft.IsChecked = (newActive == VieraEarALeft) ? true : false;
            VieraEarARight.IsChecked = (newActive == VieraEarARight) ? true : false;
            VieraEarBLeft.IsChecked = (newActive == VieraEarBLeft) ? true : false;
            VieraEarBRight.IsChecked = (newActive == VieraEarBRight) ? true : false;
            ExHairA.IsChecked = (newActive == ExHairA) ? true : false;
            ExHairB.IsChecked = (newActive == ExHairB) ? true : false;
            ExHairC.IsChecked = (newActive == ExHairC) ? true : false;
            ExHairD.IsChecked = (newActive == ExHairD) ? true : false;
            ExHairE.IsChecked = (newActive == ExHairE) ? true : false;
            ExHairF.IsChecked = (newActive == ExHairF) ? true : false;
            ExHairG.IsChecked = (newActive == ExHairG) ? true : false;
            ExHairH.IsChecked = (newActive == ExHairH) ? true : false;
            ExHairI.IsChecked = (newActive == ExHairI) ? true : false;
            ExHairJ.IsChecked = (newActive == ExHairJ) ? true : false;
            ExHairK.IsChecked = (newActive == ExHairK) ? true : false;
            ExHairL.IsChecked = (newActive == ExHairL) ? true : false;
            ExMetA.IsChecked = (newActive == ExMetA) ? true : false;
            ExMetB.IsChecked = (newActive == ExMetB) ? true : false;
            ExMetC.IsChecked = (newActive == ExMetC) ? true : false;
            ExMetD.IsChecked = (newActive == ExMetD) ? true : false;
            ExMetE.IsChecked = (newActive == ExMetE) ? true : false;
            ExMetF.IsChecked = (newActive == ExMetF) ? true : false;
            ExMetG.IsChecked = (newActive == ExMetG) ? true : false;
            ExMetH.IsChecked = (newActive == ExMetH) ? true : false;
            ExMetI.IsChecked = (newActive == ExMetI) ? true : false;
            ExMetJ.IsChecked = (newActive == ExMetJ) ? true : false;
            ExMetK.IsChecked = (newActive == ExMetK) ? true : false;
            ExMetL.IsChecked = (newActive == ExMetL) ? true : false;
            ExMetM.IsChecked = (newActive == ExMetM) ? true : false;
            ExMetN.IsChecked = (newActive == ExMetN) ? true : false;
            ExMetO.IsChecked = (newActive == ExMetO) ? true : false;
            ExMetP.IsChecked = (newActive == ExMetP) ? true : false;
            ExMetQ.IsChecked = (newActive == ExMetQ) ? true : false;
            ExMetR.IsChecked = (newActive == ExMetR) ? true : false;
            ExTopA.IsChecked = (newActive == ExTopA) ? true : false;
            ExTopB.IsChecked = (newActive == ExTopB) ? true : false;
            ExTopC.IsChecked = (newActive == ExTopC) ? true : false;
            ExTopD.IsChecked = (newActive == ExTopD) ? true : false;
            ExTopE.IsChecked = (newActive == ExTopE) ? true : false;
            ExTopF.IsChecked = (newActive == ExTopF) ? true : false;
            ExTopG.IsChecked = (newActive == ExTopG) ? true : false;
            ExTopH.IsChecked = (newActive == ExTopH) ? true : false;
            ExTopI.IsChecked = (newActive == ExTopI) ? true : false;
            #endregion
        }

        public void UncheckAll()
        {
            PoseMatrixViewModel.PoseVM.oldrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.newrot = new Vector3D(0, 0, 0);
            PoseMatrixViewModel.PoseVM.PointerPath = null;
            PoseMatrixViewModel.PoseVM.PointerType = 0;
            PoseMatrixViewModel.PoseVM.BoneX = 0;
            PoseMatrixViewModel.PoseVM.BoneY = 0;
            PoseMatrixViewModel.PoseVM.BoneZ = 0;
            XUpDown.Minimum = 0;
            XUpDown.Maximum = 360;
            YUpDown.Maximum = 360;
            YUpDown.Minimum = 0;
            ZUpDown.Maximum = 360;
            ZUpDown.Minimum = 0;
            BoneSliderX.Maximum = 360;
            BoneSliderX.Minimum = 0;
            BoneSliderY.Maximum = 360;
            BoneSliderY.Minimum = 0;
            BoneSliderZ.Maximum = 360;
            BoneSliderZ.Minimum = 0;
            #region IsChecked = false
            Root.IsChecked = false;
            Abdomen.IsChecked = false;
            Throw.IsChecked = false;
            Waist.IsChecked = false;
            SpineA.IsChecked = false;
            LegLeft.IsChecked = false;
            LegRight.IsChecked = false;
            HolsterLeft.IsChecked = false;
            HolsterRight.IsChecked = false;
            SheatheLeft.IsChecked = false;
            SheatheRight.IsChecked = false;
            SpineB.IsChecked = false;
            ClothBackALeft.IsChecked = false;
            ClothBackARight.IsChecked = false;
            ClothFrontALeft.IsChecked = false;
            ClothFrontARight.IsChecked = false;
            ClothSideALeft.IsChecked = false;
            ClothSideARight.IsChecked = false;
            KneeLeft.IsChecked = false;
            KneeRight.IsChecked = false;
            BreastLeft.IsChecked = false;
            BreastRight.IsChecked = false;
            SpineC.IsChecked = false;
            ClothBackBLeft.IsChecked = false;
            ClothBackBRight.IsChecked = false;
            ClothFrontBLeft.IsChecked = false;
            ClothFrontBRight.IsChecked = false;
            ClothSideBLeft.IsChecked = false;
            ClothSideBRight.IsChecked = false;
            CalfLeft.IsChecked = false;
            CalfRight.IsChecked = false;
            ScabbardLeft.IsChecked = false;
            ScabbardRight.IsChecked = false;
            Neck.IsChecked = false;
            ClavicleLeft.IsChecked = false;
            ClavicleRight.IsChecked = false;
            ClothBackCLeft.IsChecked = false;
            ClothBackCRight.IsChecked = false;
            ClothFrontCLeft.IsChecked = false;
            ClothFrontCRight.IsChecked = false;
            ClothSideCLeft.IsChecked = false;
            ClothSideCRight.IsChecked = false;
            PoleynLeft.IsChecked = false;
            PoleynRight.IsChecked = false;
            FootLeft.IsChecked = false;
            FootRight.IsChecked = false;
            Head.IsChecked = false;
            ArmLeft.IsChecked = false;
            ArmRight.IsChecked = false;
            PauldronLeft.IsChecked = false;
            PauldronRight.IsChecked = false;
            Unknown00.IsChecked = false;
            ToesLeft.IsChecked = false;
            ToesRight.IsChecked = false;
            HairA.IsChecked = false;
            HairFrontLeft.IsChecked = false;
            HairFrontRight.IsChecked = false;
            EarLeft.IsChecked = false;
            EarRight.IsChecked = false;
            ForearmLeft.IsChecked = false;
            ForearmRight.IsChecked = false;
            ShoulderLeft.IsChecked = false;
            ShoulderRight.IsChecked = false;
            HairB.IsChecked = false;
            HandLeft.IsChecked = false;
            HandRight.IsChecked = false;
            ShieldLeft.IsChecked = false;
            ShieldRight.IsChecked = false;
            EarringALeft.IsChecked = false;
            EarringARight.IsChecked = false;
            ElbowLeft.IsChecked = false;
            ElbowRight.IsChecked = false;
            CouterLeft.IsChecked = false;
            CouterRight.IsChecked = false;
            WristLeft.IsChecked = false;
            WristRight.IsChecked = false;
            IndexALeft.IsChecked = false;
            IndexARight.IsChecked = false;
            PinkyALeft.IsChecked = false;
            PinkyARight.IsChecked = false;
            RingALeft.IsChecked = false;
            RingARight.IsChecked = false;
            MiddleALeft.IsChecked = false;
            MiddleARight.IsChecked = false;
            ThumbALeft.IsChecked = false;
            ThumbARight.IsChecked = false;
            WeaponLeft.IsChecked = false;
            WeaponRight.IsChecked = false;
            EarringBLeft.IsChecked = false;
            EarringBRight.IsChecked = false;
            IndexBLeft.IsChecked = false;
            IndexBRight.IsChecked = false;
            PinkyBLeft.IsChecked = false;
            PinkyBRight.IsChecked = false;
            RingBLeft.IsChecked = false;
            RingBRight.IsChecked = false;
            MiddleBLeft.IsChecked = false;
            MiddleBRight.IsChecked = false;
            ThumbBLeft.IsChecked = false;
            ThumbBRight.IsChecked = false;
            TailA.IsChecked = false;
            TailB.IsChecked = false;
            TailC.IsChecked = false;
            TailD.IsChecked = false;
            TailE.IsChecked = false;
            RootHead.IsChecked = false;
            Jaw.IsChecked = false;
            EyelidLowerLeft.IsChecked = false;
            EyelidLowerRight.IsChecked = false;
            EyeLeft.IsChecked = false;
            EyeRight.IsChecked = false;
            Nose.IsChecked = false;
            CheekLeft.IsChecked = false;
            HrothWhiskersLeft.IsChecked = false;
            CheekRight.IsChecked = false;
            HrothWhiskersRight.IsChecked = false;
            LipsLeft.IsChecked = false;
            LipsRight.IsChecked = false;
            EyebrowLeft.IsChecked = false;
            EyebrowRight.IsChecked = false;
            Bridge.IsChecked = false;
            BrowLeft.IsChecked = false;
            BrowRight.IsChecked = false;
            LipUpperA.IsChecked = false;
            EyelidUpperLeft.IsChecked = false;
            EyelidUpperRight.IsChecked = false;
            LipLowerA.IsChecked = false;
            LipUpperB.IsChecked = false;
            LipLowerB.IsChecked = false;
            HrothWhiskersLeft.IsChecked = false;
            HrothWhiskersRight.IsChecked = false;
            VieraEarALeft.IsChecked = false;
            VieraEarARight.IsChecked = false;
            VieraEarBLeft.IsChecked = false;
            VieraEarBRight.IsChecked = false;
            ExHairA.IsChecked = false;
            ExHairB.IsChecked = false;
            ExHairC.IsChecked = false;
            ExHairD.IsChecked = false;
            ExHairE.IsChecked = false;
            ExHairF.IsChecked = false;
            ExHairG.IsChecked = false;
            ExHairH.IsChecked = false;
            ExHairI.IsChecked = false;
            ExHairJ.IsChecked = false;
            ExHairK.IsChecked = false;
            ExHairL.IsChecked = false;
            ExMetA.IsChecked = false;
            ExMetB.IsChecked = false;
            ExMetC.IsChecked = false;
            ExMetD.IsChecked = false;
            ExMetE.IsChecked = false;
            ExMetF.IsChecked = false;
            ExMetG.IsChecked = false;
            ExMetH.IsChecked = false;
            ExMetI.IsChecked = false;
            ExMetJ.IsChecked = false;
            ExMetK.IsChecked = false;
            ExMetL.IsChecked = false;
            ExMetM.IsChecked = false;
            ExMetN.IsChecked = false;
            ExMetO.IsChecked = false;
            ExMetP.IsChecked = false;
            ExMetQ.IsChecked = false;
            ExMetR.IsChecked = false;
            ExTopA.IsChecked = false;
            ExTopB.IsChecked = false;
            ExTopC.IsChecked = false;
            ExTopD.IsChecked = false;
            ExTopE.IsChecked = false;
            ExTopF.IsChecked = false;
            ExTopG.IsChecked = false;
            ExTopH.IsChecked = false;
            ExTopI.IsChecked = false;
            #endregion
        }
        private void EnableAll()
        {
            #region Enable Controls
            PhysicsButton.IsEnabled = true;
            HelmToggle.IsEnabled = true;
            WeaponPoSToggle.IsEnabled = true;
            ScaleToggle.IsEnabled = true;
            // TertiaryButton.IsEnabled = true;
            //Root.IsEnabled = true;
            //Abdomen.IsEnabled = true;
            //Throw.IsEnabled = true;
            Waist.IsEnabled = true;
            SpineA.IsEnabled = true;
            LegLeft.IsEnabled = true;
            LegRight.IsEnabled = true;
            HolsterLeft.IsEnabled = true;
            HolsterRight.IsEnabled = true;
            SheatheLeft.IsEnabled = true;
            SheatheRight.IsEnabled = true;
            SpineB.IsEnabled = true;
            ClothBackALeft.IsEnabled = true;
            ClothBackARight.IsEnabled = true;
            ClothFrontALeft.IsEnabled = true;
            ClothFrontARight.IsEnabled = true;
            ClothSideALeft.IsEnabled = true;
            ClothSideARight.IsEnabled = true;
            KneeLeft.IsEnabled = true;
            KneeRight.IsEnabled = true;
            BreastLeft.IsEnabled = true;
            BreastRight.IsEnabled = true;
            SpineC.IsEnabled = true;
            ClothBackBLeft.IsEnabled = true;
            ClothBackBRight.IsEnabled = true;
            ClothFrontBLeft.IsEnabled = true;
            ClothFrontBRight.IsEnabled = true;
            ClothSideBLeft.IsEnabled = true;
            ClothSideBRight.IsEnabled = true;
            CalfLeft.IsEnabled = true;
            CalfRight.IsEnabled = true;
            ScabbardLeft.IsEnabled = true;
            ScabbardRight.IsEnabled = true;
            Neck.IsEnabled = true;
            ClavicleLeft.IsEnabled = true;
            ClavicleRight.IsEnabled = true;
            ClothBackCLeft.IsEnabled = true;
            ClothBackCRight.IsEnabled = true;
            ClothFrontCLeft.IsEnabled = true;
            ClothFrontCRight.IsEnabled = true;
            ClothSideCLeft.IsEnabled = true;
            ClothSideCRight.IsEnabled = true;
            PoleynLeft.IsEnabled = true;
            PoleynRight.IsEnabled = true;
            FootLeft.IsEnabled = true;
            FootRight.IsEnabled = true;
            Head.IsEnabled = true;
            ArmLeft.IsEnabled = true;
            ArmRight.IsEnabled = true;
            PauldronLeft.IsEnabled = true;
            PauldronRight.IsEnabled = true;
            Unknown00.IsEnabled = true;
            ToesLeft.IsEnabled = true;
            ToesRight.IsEnabled = true;
            HairA.IsEnabled = true;
            HairFrontLeft.IsEnabled = true;
            HairFrontRight.IsEnabled = true;
            EarLeft.IsEnabled = true;
            EarRight.IsEnabled = true;
            ForearmLeft.IsEnabled = true;
            ForearmRight.IsEnabled = true;
            ShoulderLeft.IsEnabled = true;
            ShoulderRight.IsEnabled = true;
            HairB.IsEnabled = true;
            HandLeft.IsEnabled = true;
            HandRight.IsEnabled = true;
            ShieldLeft.IsEnabled = true;
            ShieldRight.IsEnabled = true;
            EarringALeft.IsEnabled = true;
            EarringARight.IsEnabled = true;
            ElbowLeft.IsEnabled = true;
            ElbowRight.IsEnabled = true;
            CouterLeft.IsEnabled = true;
            CouterRight.IsEnabled = true;
            WristLeft.IsEnabled = true;
            WristRight.IsEnabled = true;
            IndexALeft.IsEnabled = true;
            IndexARight.IsEnabled = true;
            PinkyALeft.IsEnabled = true;
            PinkyARight.IsEnabled = true;
            RingALeft.IsEnabled = true;
            RingARight.IsEnabled = true;
            MiddleALeft.IsEnabled = true;
            MiddleARight.IsEnabled = true;
            ThumbALeft.IsEnabled = true;
            ThumbARight.IsEnabled = true;
            WeaponLeft.IsEnabled = true;
            WeaponRight.IsEnabled = true;
            EarringBLeft.IsEnabled = true;
            EarringBRight.IsEnabled = true;
            IndexBLeft.IsEnabled = true;
            IndexBRight.IsEnabled = true;
            PinkyBLeft.IsEnabled = true;
            PinkyBRight.IsEnabled = true;
            RingBLeft.IsEnabled = true;
            RingBRight.IsEnabled = true;
            MiddleBLeft.IsEnabled = true;
            MiddleBRight.IsEnabled = true;
            ThumbBLeft.IsEnabled = true;
            ThumbBRight.IsEnabled = true;
            //TailA.IsEnabled = true;
            //TailB.IsEnabled = true;
            //TailC.IsEnabled = true;
            //TailD.IsEnabled = true;
            //TailE.IsEnabled = true;
            //RootHead.IsEnabled = true;
            Jaw.IsEnabled = true;
            EyelidLowerLeft.IsEnabled = true;
            EyelidLowerRight.IsEnabled = true;
            EyeLeft.IsEnabled = true;
            EyeRight.IsEnabled = true;
            Nose.IsEnabled = true;
            CheekLeft.IsEnabled = true;
            CheekRight.IsEnabled = true;
            LipsLeft.IsEnabled = true;
            LipsRight.IsEnabled = true;
            EyebrowLeft.IsEnabled = true;
            EyebrowRight.IsEnabled = true;
            Bridge.IsEnabled = true;
            BrowLeft.IsEnabled = true;
            BrowRight.IsEnabled = true;
            LipUpperA.IsEnabled = true;
            EyelidUpperLeft.IsEnabled = true;
            EyelidUpperRight.IsEnabled = true;
            LipLowerA.IsEnabled = true;
            LipUpperB.IsEnabled = true;
            LipLowerB.IsEnabled = true;
            //HrothWhiskersLeft.IsEnabled = true;
            //HrothWhiskersRight.IsEnabled = true;
            //VieraEarALeft.IsEnabled = true;
            //VieraEarARight.IsEnabled = true;
            //VieraEarBLeft.IsEnabled = true;
            //VieraEarBRight.IsEnabled = true;
            //ExHairA.IsEnabled = true;
            //ExHairB.IsEnabled = true;
            //ExHairC.IsEnabled = true;
            //ExHairD.IsEnabled = true;
            //ExHairE.IsEnabled = true;
            //ExHairF.IsEnabled = true;
            //ExHairG.IsEnabled = true;
            //ExHairH.IsEnabled = true;
            //ExHairI.IsEnabled = true;
            //ExHairJ.IsEnabled = true;
            //ExHairK.IsEnabled = true;
            //ExHairL.IsEnabled = true;
            //ExMetA.IsEnabled = true;
            //ExMetB.IsEnabled = true;
            //ExMetC.IsEnabled = true;
            //ExMetD.IsEnabled = true;
            //ExMetE.IsEnabled = true;
            //ExMetF.IsEnabled = true;
            //ExMetG.IsEnabled = true;
            //ExMetH.IsEnabled = true;
            //ExMetI.IsEnabled = true;
            //ExMetJ.IsEnabled = true;
            //ExMetK.IsEnabled = true;
            //ExMetL.IsEnabled = true;
            //ExMetM.IsEnabled = true;
            //ExMetN.IsEnabled = true;
            //ExMetO.IsEnabled = true;
            //ExMetP.IsEnabled = true;
            //ExMetQ.IsEnabled = true;
            //ExMetR.IsEnabled = true;
            //ExTopA.IsEnabled = true;
            //ExTopB.IsEnabled = true;
            //ExTopC.IsEnabled = true;
            //ExTopD.IsEnabled = true;
            //ExTopE.IsEnabled = true;
            //ExTopF.IsEnabled = true;
            //ExTopG.IsEnabled = true;
            //ExTopH.IsEnabled = true;
            //ExTopI.IsEnabled = true;

            //if (HeadSaved) LoadHeadButton.IsEnabled = true;
            //if (TorsoSaved) LoadTorsoButton.IsEnabled = true;
            //if (LeftArmSaved) LoadLArmButton.IsEnabled = true;
            //if (RightArmSaved) LoadRArmButton.IsEnabled = true;
            //if (LeftLegSaved) LoadLLegButton.IsEnabled = true;
            //if (RightLegSaved) LoadRLegButton.IsEnabled = true;
            #endregion
        }

        private void DisableAll()
        {
            #region Disable Controls
            WeaponPoSToggle.IsEnabled = false;
            PhysicsButton.IsEnabled = false;
            ScaleToggle.IsEnabled = false;

            // TertiaryButton.IsEnabled = false;
            Root.IsEnabled = false;
            Abdomen.IsEnabled = false;
            Throw.IsEnabled = false;
            Waist.IsEnabled = false;
            SpineA.IsEnabled = false;
            LegLeft.IsEnabled = false;
            LegRight.IsEnabled = false;
            HolsterLeft.IsEnabled = false;
            HolsterRight.IsEnabled = false;
            SheatheLeft.IsEnabled = false;
            SheatheRight.IsEnabled = false;
            SpineB.IsEnabled = false;
            ClothBackALeft.IsEnabled = false;
            ClothBackARight.IsEnabled = false;
            ClothFrontALeft.IsEnabled = false;
            ClothFrontARight.IsEnabled = false;
            ClothSideALeft.IsEnabled = false;
            ClothSideARight.IsEnabled = false;
            KneeLeft.IsEnabled = false;
            KneeRight.IsEnabled = false;
            BreastLeft.IsEnabled = false;
            BreastRight.IsEnabled = false;
            SpineC.IsEnabled = false;
            ClothBackBLeft.IsEnabled = false;
            ClothBackBRight.IsEnabled = false;
            ClothFrontBLeft.IsEnabled = false;
            ClothFrontBRight.IsEnabled = false;
            ClothSideBLeft.IsEnabled = false;
            ClothSideBRight.IsEnabled = false;
            CalfLeft.IsEnabled = false;
            CalfRight.IsEnabled = false;
            ScabbardLeft.IsEnabled = false;
            ScabbardRight.IsEnabled = false;
            Neck.IsEnabled = false;
            ClavicleLeft.IsEnabled = false;
            ClavicleRight.IsEnabled = false;
            ClothBackCLeft.IsEnabled = false;
            ClothBackCRight.IsEnabled = false;
            ClothFrontCLeft.IsEnabled = false;
            ClothFrontCRight.IsEnabled = false;
            ClothSideCLeft.IsEnabled = false;
            ClothSideCRight.IsEnabled = false;
            PoleynLeft.IsEnabled = false;
            PoleynRight.IsEnabled = false;
            FootLeft.IsEnabled = false;
            FootRight.IsEnabled = false;
            Head.IsEnabled = false;
            ArmLeft.IsEnabled = false;
            ArmRight.IsEnabled = false;
            PauldronLeft.IsEnabled = false;
            PauldronRight.IsEnabled = false;
            Unknown00.IsEnabled = false;
            ToesLeft.IsEnabled = false;
            ToesRight.IsEnabled = false;
            HairA.IsEnabled = false;
            HairFrontLeft.IsEnabled = false;
            HairFrontRight.IsEnabled = false;
            EarLeft.IsEnabled = false;
            EarRight.IsEnabled = false;
            ForearmLeft.IsEnabled = false;
            ForearmRight.IsEnabled = false;
            ShoulderLeft.IsEnabled = false;
            ShoulderRight.IsEnabled = false;
            HairB.IsEnabled = false;
            HandLeft.IsEnabled = false;
            HandRight.IsEnabled = false;
            ShieldLeft.IsEnabled = false;
            ShieldRight.IsEnabled = false;
            EarringALeft.IsEnabled = false;
            EarringARight.IsEnabled = false;
            ElbowLeft.IsEnabled = false;
            ElbowRight.IsEnabled = false;
            CouterLeft.IsEnabled = false;
            CouterRight.IsEnabled = false;
            WristLeft.IsEnabled = false;
            WristRight.IsEnabled = false;
            IndexALeft.IsEnabled = false;
            IndexARight.IsEnabled = false;
            PinkyALeft.IsEnabled = false;
            PinkyARight.IsEnabled = false;
            RingALeft.IsEnabled = false;
            RingARight.IsEnabled = false;
            MiddleALeft.IsEnabled = false;
            MiddleARight.IsEnabled = false;
            ThumbALeft.IsEnabled = false;
            ThumbARight.IsEnabled = false;
            WeaponLeft.IsEnabled = false;
            WeaponRight.IsEnabled = false;
            EarringBLeft.IsEnabled = false;
            EarringBRight.IsEnabled = false;
            IndexBLeft.IsEnabled = false;
            IndexBRight.IsEnabled = false;
            PinkyBLeft.IsEnabled = false;
            PinkyBRight.IsEnabled = false;
            RingBLeft.IsEnabled = false;
            RingBRight.IsEnabled = false;
            MiddleBLeft.IsEnabled = false;
            MiddleBRight.IsEnabled = false;
            ThumbBLeft.IsEnabled = false;
            ThumbBRight.IsEnabled = false;
            RootHead.IsEnabled = false;
            Jaw.IsEnabled = false;
            EyelidLowerLeft.IsEnabled = false;
            EyelidLowerRight.IsEnabled = false;
            EyeLeft.IsEnabled = false;
            EyeRight.IsEnabled = false;
            Nose.IsEnabled = false;
            CheekLeft.IsEnabled = false;
            HrothWhiskersLeft.IsEnabled = false;
            CheekRight.IsEnabled = false;
            HrothWhiskersRight.IsEnabled = false;
            LipsLeft.IsEnabled = false;
            LipsRight.IsEnabled = false;
            EyebrowLeft.IsEnabled = false;
            EyebrowRight.IsEnabled = false;
            Bridge.IsEnabled = false;
            BrowLeft.IsEnabled = false;
            BrowRight.IsEnabled = false;
            LipUpperA.IsEnabled = false;
            EyelidUpperLeft.IsEnabled = false;
            EyelidUpperRight.IsEnabled = false;
            LipLowerA.IsEnabled = false;
            LipUpperB.IsEnabled = false;
            LipLowerB.IsEnabled = false;
            DisableTertiary();

            //LoadHeadButton.IsEnabled = false;
            //LoadTorsoButton.IsEnabled = false;
            //LoadLArmButton.IsEnabled = false;
            //LoadRArmButton.IsEnabled = false;
            //LoadLLegButton.IsEnabled = false;
            //LoadRLegButton.IsEnabled = false;
            #endregion
        }
        private void SaveCMP_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            if (dig.ShowDialog() == true)
            {
                string extension = Path.GetExtension(".cmp");
                string result = dig.SafeFileName.Substring(0, dig.SafeFileName.Length - extension.Length);
                BoneSaves BoneSaver = new BoneSaves();
                BoneSaver.Description = result;
                BoneSaver.DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
                BoneSaver.CMPVersion = "2.0";
                //  SaveSettings.Default.MatrixPoseSaveLoadDirectory = Path.GetDirectoryName(dig.FileName);
                var AppearanceArray = MainWindow.GameProcess.ReadBytes(BaseModel.ActorData + BaseModel.Offsets.ActorAppearance, 26);
                BoneSaver.Race = AppearanceArray[0].ToString("X2");
                BoneSaver.Clan = AppearanceArray[4].ToString("X2");
                BoneSaver.Body = AppearanceArray[2].ToString("X2");

                #region Head
                BoneSaver.Head = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Head_Bone));
                BoneSaver.EarLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarLeft_Bone));
                BoneSaver.EarRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarRight_Bone));
                BoneSaver.RootHead = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RootHead_Bone));
                BoneSaver.Jaw = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Jaw_Bone));
                BoneSaver.EyelidLowerLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerLeft_Bone));
                BoneSaver.EyelidLowerRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerRight_Bone));
                BoneSaver.EyeLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeLeft_Bone));
                BoneSaver.EyeRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeRight_Bone));
                BoneSaver.Nose = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Nose_Bone));
                BoneSaver.CheekLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekLeft_Bone));
                BoneSaver.HrothWhiskersLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersLeft_Bone));
                BoneSaver.CheekRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekRight_Bone));
                BoneSaver.HrothWhiskersRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersRight_Bone));
                BoneSaver.LipsLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsLeft_Bone));
                BoneSaver.HrothEyebrowLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowLeft_Bone));
                BoneSaver.LipsRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsRight_Bone));
                BoneSaver.HrothEyebrowRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowRight_Bone));
                BoneSaver.EyebrowLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowLeft_Bone));
                BoneSaver.HrothBridge = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBridge_Bone));
                BoneSaver.EyebrowRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowRight_Bone));
                BoneSaver.HrothBrowLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowLeft_Bone));
                BoneSaver.Bridge = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Bridge_Bone));
                BoneSaver.HrothBrowRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowRight_Bone));
                BoneSaver.BrowLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowLeft_Bone));
                BoneSaver.HrothJawUpper = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothJawUpper_Bone));
                BoneSaver.BrowRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowRight_Bone));
                BoneSaver.HrothLipUpper = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpper_Bone));
                BoneSaver.LipUpperA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperA_Bone));
                BoneSaver.HrothEyelidUpperLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperLeft_Bone));
                BoneSaver.EyelidUpperLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperLeft_Bone));
                BoneSaver.HrothEyelidUpperRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperRight_Bone));
                BoneSaver.EyelidUpperRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperRight_Bone));
                BoneSaver.HrothLipsLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsLeft_Bone));
                BoneSaver.LipLowerA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerA_Bone));
                BoneSaver.HrothLipsRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsRight_Bone));
                BoneSaver.VieraEar01ALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ALeft_Bone));
                BoneSaver.LipUpperB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperB_Bone));
                BoneSaver.HrothLipUpperLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperLeft_Bone));
                BoneSaver.VieraEar01ARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ARight_Bone));
                BoneSaver.LipLowerB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerB_Bone));
                BoneSaver.HrothLipUpperRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperRight_Bone));
                BoneSaver.VieraEar02ALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ALeft_Bone));
                if (AppearanceArray[0] == 7 || AppearanceArray[0] == 8)
                {
                    BoneSaver.HrothLipLower = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipLower_Bone));
                    BoneSaver.VieraEar02ARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ARight_Bone));
                }
                else
                {
                    BoneSaver.HrothLipLower = "null";
                    BoneSaver.VieraEar02ARight = "null";
                }
                if (AppearanceArray[0] == 8)
                {
                    BoneSaver.VieraEar03ALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ALeft_Bone));
                    BoneSaver.VieraEar03ARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ARight_Bone));
                    BoneSaver.VieraEar04ALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ALeft_Bone));
                    BoneSaver.VieraEar04ARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ARight_Bone));
                    BoneSaver.VieraLipLowerA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerA_Bone));
                    BoneSaver.VieraLipUpperB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipUpperB_Bone));
                    BoneSaver.VieraEar01BLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BLeft_Bone));
                    BoneSaver.VieraEar01BRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BRight_Bone));
                    BoneSaver.VieraEar02BLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BLeft_Bone));
                    BoneSaver.VieraEar02BRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Bone));
                    BoneSaver.VieraEar03BLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03BLeft_Bone));
                    BoneSaver.VieraEar03BRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Bone));
                    BoneSaver.VieraEar04BLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BLeft_Bone));
                    BoneSaver.VieraEar04BRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BRight_Bone));
                    BoneSaver.VieraLipLowerB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerB_Bone));
                }
                else
                {
                    BoneSaver.VieraEar03ALeft = "null";
                    BoneSaver.VieraEar03ARight = "null";
                    BoneSaver.VieraEar04ALeft = "null";
                    BoneSaver.VieraEar04ARight = "null";
                    BoneSaver.VieraLipLowerA = "null";
                    BoneSaver.VieraLipUpperB = "null";
                    BoneSaver.VieraEar01BLeft = "null";
                    BoneSaver.VieraEar01BRight = "null";
                    BoneSaver.VieraEar02BLeft = "null";
                    BoneSaver.VieraEar02BRight = "null";
                    BoneSaver.VieraEar03BLeft = "null";
                    BoneSaver.VieraEar03BRight = "null";
                    BoneSaver.VieraEar04BLeft = "null";
                    BoneSaver.VieraEar04BRight = "null";
                    BoneSaver.VieraLipLowerB = "null";
                }
                #endregion
                #region Hair

                BoneSaver.HairA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairA_Bone));
                BoneSaver.HairFrontLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontLeft_Bone));
                BoneSaver.HairFrontRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontRight_Bone));
                BoneSaver.HairB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairB_Bone));
                byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
                if (HairValue >= 1)
                {
                    BoneSaver.ExRootHair = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootHair_Bone));
                }
                if (HairValue >= 2)
                {
                    BoneSaver.ExHairA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairA_Bone));
                }
                else
                {
                    BoneSaver.ExHairA = "null";
                }
                if (HairValue >= 3)
                {
                    BoneSaver.ExHairB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairB_Bone));
                }
                else
                {
                    BoneSaver.ExHairB = "null";
                }
                if (HairValue >= 4)
                {
                    BoneSaver.ExHairC = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairC_Bone));
                }
                else
                {
                    BoneSaver.ExHairC = "null";
                }
                if (HairValue >= 5)
                {
                    BoneSaver.ExHairD = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairD_Bone));
                }
                else
                {
                    BoneSaver.ExHairD = "null";
                }
                if (HairValue >= 6)
                {
                    BoneSaver.ExHairE = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairE_Bone));
                }
                else
                {
                    BoneSaver.ExHairE = "null";
                }
                if (HairValue >= 7)
                {
                    BoneSaver.ExHairF = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairF_Bone));
                }
                else
                {
                    BoneSaver.ExHairF = "null";
                }
                if (HairValue >= 8)
                {
                    BoneSaver.ExHairG = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairG_Bone));
                }
                else
                {
                    BoneSaver.ExHairG = "null";
                }
                if (HairValue >= 9)
                {
                    BoneSaver.ExHairH = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairH_Bone));
                }
                else
                {
                    BoneSaver.ExHairH = "null";
                }
                if (HairValue >= 10)
                {
                    BoneSaver.ExHairI = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairI_Bone));
                }
                else
                {
                    BoneSaver.ExHairI = "null";
                }
                if (HairValue >= 11)
                {
                    BoneSaver.ExHairJ = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairJ_Bone));
                }
                else
                {
                    BoneSaver.ExHairJ = "null";
                }
                if (HairValue >= 12)
                {
                    BoneSaver.ExHairK = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairK_Bone));
                }
                else
                {
                    BoneSaver.ExHairK = "null";
                }
                if (HairValue >= 13)
                {
                    BoneSaver.ExHairL = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairL_Bone));
                }
                else
                {
                    BoneSaver.ExHairL = "null";
                }
                if (BoneSaver.ExRootHair == null)
                {
                    BoneSaver.ExRootHair = "null";
                    BoneSaver.ExHairA = "null";
                    BoneSaver.ExHairB = "null";
                    BoneSaver.ExHairC = "null";
                    BoneSaver.ExHairD = "null";
                    BoneSaver.ExHairE = "null";
                    BoneSaver.ExHairF = "null";
                    BoneSaver.ExHairG = "null";
                    BoneSaver.ExHairH = "null";
                    BoneSaver.ExHairI = "null";
                    BoneSaver.ExHairJ = "null";
                    BoneSaver.ExHairK = "null";
                    BoneSaver.ExHairL = "null";
                }
                #endregion
                #region Earrings
                BoneSaver.EarringALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringALeft_Bone));
                BoneSaver.EarringARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringARight_Bone));
                BoneSaver.EarringBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringBLeft_Bone));
                BoneSaver.EarringBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringBRight_Bone));
                #endregion
                #region Body
                BoneSaver.SpineA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineA_Bone));
                BoneSaver.SpineB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineB_Bone));
                BoneSaver.BreastLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastLeft_Bone));
                BoneSaver.BreastRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastRight_Bone));
                BoneSaver.SpineC = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineC_Bone));
                BoneSaver.ScabbardLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ScabbardLeft_Bone));
                BoneSaver.ScabbardRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ScabbardRight_Bone));
                BoneSaver.Neck = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Neck_Bone));
                #endregion
                #region LeftArm
                BoneSaver.ClavicleLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleLeft_Bone));
                BoneSaver.ArmLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmLeft_Bone));
                BoneSaver.PauldronLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PauldronLeft_Bone));
                BoneSaver.ForearmLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmLeft_Bone));
                BoneSaver.ShoulderLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderLeft_Bone));
                BoneSaver.ShieldLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShieldLeft_Bone));
                BoneSaver.ElbowLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowLeft_Bone));
                BoneSaver.CouterLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterLeft_Bone));
                BoneSaver.WristLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristLeft_Bone));
                #endregion
                #region RightArm
                BoneSaver.ClavicleRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleRight_Bone));
                BoneSaver.ArmRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmRight_Bone));
                BoneSaver.PauldronRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PauldronRight_Bone));
                BoneSaver.ForearmRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmRight_Bone));
                BoneSaver.ShoulderRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderRight_Bone));
                BoneSaver.ShieldRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShieldRight_Bone));
                BoneSaver.ElbowRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowRight_Bone));
                BoneSaver.CouterRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterRight_Bone));
                BoneSaver.WristRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristRight_Bone));
                #endregion
                #region Clothes
                BoneSaver.ClothBackALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackALeft_Bone));
                BoneSaver.ClothBackARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackARight_Bone));
                BoneSaver.ClothFrontALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontALeft_Bone));
                BoneSaver.ClothFrontARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontARight_Bone));
                BoneSaver.ClothSideALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideALeft_Bone));
                BoneSaver.ClothSideARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideARight_Bone));
                BoneSaver.ClothBackBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBLeft_Bone));
                BoneSaver.ClothBackBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBRight_Bone));
                BoneSaver.ClothFrontBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBLeft_Bone));
                BoneSaver.ClothFrontBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBRight_Bone));
                BoneSaver.ClothSideBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBLeft_Bone));
                BoneSaver.ClothSideBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBRight_Bone));
                BoneSaver.ClothBackCLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCLeft_Bone));
                BoneSaver.ClothBackCRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCRight_Bone));
                BoneSaver.ClothFrontCLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCLeft_Bone));
                BoneSaver.ClothFrontCRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCRight_Bone));
                BoneSaver.ClothSideCLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCLeft_Bone));
                BoneSaver.ClothSideCRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCRight_Bone));
                #endregion
                #region Weapons
                BoneSaver.WeaponLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WeaponLeft_Bone));
                BoneSaver.WeaponRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WeaponRight_Bone));
                #endregion
                #region LeftHand
                BoneSaver.HandLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandLeft_Bone));
                BoneSaver.IndexALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexALeft_Bone));
                BoneSaver.PinkyALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyALeft_Bone));
                BoneSaver.RingALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingALeft_Bone));
                BoneSaver.MiddleALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleALeft_Bone));
                BoneSaver.ThumbALeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbALeft_Bone));
                BoneSaver.IndexBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBLeft_Bone));
                BoneSaver.PinkyBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBLeft_Bone));
                BoneSaver.RingBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBLeft_Bone));
                BoneSaver.MiddleBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBLeft_Bone));
                BoneSaver.ThumbBLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBLeft_Bone));
                #endregion
                #region RightHand
                BoneSaver.HandRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandRight_Bone));
                BoneSaver.IndexARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexARight_Bone));
                BoneSaver.PinkyARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyARight_Bone));
                BoneSaver.RingARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingARight_Bone));
                BoneSaver.MiddleARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleARight_Bone));
                BoneSaver.ThumbARight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbARight_Bone));
                BoneSaver.IndexBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBRight_Bone));
                BoneSaver.PinkyBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBRight_Bone));
                BoneSaver.RingBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBRight_Bone));
                BoneSaver.MiddleBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBRight_Bone));
                BoneSaver.ThumbBRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBRight_Bone));
                #endregion
                #region Waist
                BoneSaver.Waist = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Waist_Bone));
                BoneSaver.HolsterLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HolsterLeft_Bone));
                BoneSaver.HolsterRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HolsterRight_Bone));
                BoneSaver.SheatheLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SheatheLeft_Bone));
                BoneSaver.SheatheRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SheatheRight_Bone));
                if (AppearanceArray[0] == 4 || AppearanceArray[0] == 6 || AppearanceArray[0] == 7)
                {
                    BoneSaver.TailA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailA_Bone));
                    BoneSaver.TailB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailB_Bone));
                    BoneSaver.TailC = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailC_Bone));
                    BoneSaver.TailD = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailD_Bone));
                    BoneSaver.TailE = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailE_Bone));
                }
                else
                {
                    BoneSaver.TailA = "null";
                    BoneSaver.TailB = "null";
                    BoneSaver.TailC = "null";
                    BoneSaver.TailD = "null";
                    BoneSaver.TailE = "null";
                }
                #endregion
                #region LeftLeg
                BoneSaver.LegLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsLeft_Bone));
                BoneSaver.KneeLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeLeft_Bone));
                BoneSaver.CalfLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfLeft_Bone));
                BoneSaver.PoleynLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynLeft_Bone));
                BoneSaver.FootLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootLeft_Bone));
                BoneSaver.ToesLeft = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesLeft_Bone));
                #endregion
                #region RightLeg
                BoneSaver.LegRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsRight_Bone));
                BoneSaver.KneeRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeRight_Bone));
                BoneSaver.CalfRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfRight_Bone));
                BoneSaver.PoleynRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynRight_Bone));
                BoneSaver.FootRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootRight_Bone));
                BoneSaver.ToesRight = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesRight_Bone));
                #endregion
                #region Helm
                byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);
                if (HelmValue >= 1)
                {
                    BoneSaver.ExRootMet = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootMet_Bone));
                }
                if (HelmValue >= 2)
                {
                    BoneSaver.ExMetA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetA_Bone));
                }
                else
                {
                    BoneSaver.ExMetA = "null";
                }
                if (HelmValue >= 3)
                {
                    BoneSaver.ExMetB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetB_Bone));
                }
                else
                {
                    BoneSaver.ExMetB = "null";
                }
                if (HelmValue >= 4)
                {
                    BoneSaver.ExMetC = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetC_Bone));
                }
                else
                {
                    BoneSaver.ExMetC = "null";
                }
                if (HelmValue >= 5)
                {
                    BoneSaver.ExMetD = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetD_Bone));
                }
                else
                {
                    BoneSaver.ExMetD = "null";
                }
                if (HelmValue >= 6)
                {
                    BoneSaver.ExMetE = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetE_Bone));
                }
                else
                {
                    BoneSaver.ExMetE = "null";
                }
                if (HelmValue >= 7)
                {
                    BoneSaver.ExMetF = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetF_Bone));
                }
                else
                {
                    BoneSaver.ExMetF = "null";
                }
                if (HelmValue >= 8)
                {
                    BoneSaver.ExMetG = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetG_Bone));
                }
                else
                {
                    BoneSaver.ExMetG = "null";
                }
                if (HelmValue >= 9)
                {
                    BoneSaver.ExMetH = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetH_Bone));
                }
                else
                {
                    BoneSaver.ExMetH = "null";
                }
                if (HelmValue >= 10)
                {
                    BoneSaver.ExMetI = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetI_Bone));
                }
                else
                {
                    BoneSaver.ExMetI = "null";
                }
                if (HelmValue >= 11)
                {
                    BoneSaver.ExMetJ = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetJ_Bone));
                }
                else
                {
                    BoneSaver.ExMetJ = "null";
                }
                if (HelmValue >= 12)
                {
                    BoneSaver.ExMetK = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetK_Bone));
                }
                else
                {
                    BoneSaver.ExMetK = "null";
                }
                if (HelmValue >= 13)
                {
                    BoneSaver.ExMetL = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetL_Bone));
                }
                else
                {
                    BoneSaver.ExMetL = "null";
                }
                if (HelmValue >= 14)
                {
                    BoneSaver.ExMetM = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetM_Bone));
                }
                else
                {
                    BoneSaver.ExMetM = "null";
                }
                if (HelmValue >= 15)
                {
                    BoneSaver.ExMetN = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetN_Bone));
                }
                else
                {
                    BoneSaver.ExMetN = "null";
                }
                if (HelmValue >= 16)
                {
                    BoneSaver.ExMetO = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetO_Bone));
                }
                else
                {
                    BoneSaver.ExMetO = "null";
                }
                if (HelmValue >= 17)
                {
                    BoneSaver.ExMetP = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetP_Bone));
                }
                else
                {
                    BoneSaver.ExMetP = "null";
                }
                if (HelmValue >= 18)
                {
                    BoneSaver.ExMetQ = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetQ_Bone));
                }
                else
                {
                    BoneSaver.ExMetQ = "null";
                }
                if (HelmValue >= 19)
                {
                    BoneSaver.ExMetR = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetR_Bone));
                }
                else
                {
                    BoneSaver.ExMetR = "null";
                }
                if (BoneSaver.ExRootMet == null)
                {
                    BoneSaver.ExRootMet = "null";
                    BoneSaver.ExMetA = "null";
                    BoneSaver.ExMetB = "null";
                    BoneSaver.ExMetC = "null";
                    BoneSaver.ExMetD = "null";
                    BoneSaver.ExMetE = "null";
                    BoneSaver.ExMetF = "null";
                    BoneSaver.ExMetG = "null";
                    BoneSaver.ExMetH = "null";
                    BoneSaver.ExMetI = "null";
                    BoneSaver.ExMetJ = "null";
                    BoneSaver.ExMetK = "null";
                    BoneSaver.ExMetL = "null";
                    BoneSaver.ExMetM = "null";
                    BoneSaver.ExMetN = "null";
                    BoneSaver.ExMetO = "null";
                    BoneSaver.ExMetP = "null";
                    BoneSaver.ExMetQ = "null";
                    BoneSaver.ExMetR = "null";
                }
                #endregion
                #region Top
                byte TopValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);
                if (TopValue >= 1)
                {
                    BoneSaver.ExRootTop = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootTop_Bone));
                }
                if (TopValue >= 2)
                {
                    BoneSaver.ExTopA = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopA_Bone));
                }
                else
                {
                    BoneSaver.ExTopA = "null";
                }
                if (TopValue >= 3)
                {
                    BoneSaver.ExTopB = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopB_Bone));
                }
                else
                {
                    BoneSaver.ExTopB = "null";
                }
                if (TopValue >= 4)
                {
                    BoneSaver.ExTopC = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopC_Bone));
                }
                else
                {
                    BoneSaver.ExTopC = "null";
                }
                if (TopValue >= 5)
                {
                    BoneSaver.ExTopD = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopD_Bone));
                }
                else
                {
                    BoneSaver.ExTopD = "null";
                }
                if (TopValue >= 6)
                {
                    BoneSaver.ExTopE = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopE_Bone));
                }
                else
                {
                    BoneSaver.ExTopE = "null";
                }
                if (TopValue >= 7)
                {
                    BoneSaver.ExTopF = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopF_Bone));
                }
                else
                {
                    BoneSaver.ExTopF = "null";
                }
                if (TopValue >= 8)
                {
                    BoneSaver.ExTopG = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopG_Bone));
                }
                else
                {
                    BoneSaver.ExTopG = "null";
                }
                if (TopValue >= 9)
                {
                    BoneSaver.ExTopH = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopH_Bone));
                }
                else
                {
                    BoneSaver.ExTopH = "null";
                }
                if (TopValue >= 10)
                {
                    BoneSaver.ExTopI = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopI_Bone));
                }
                else
                {
                    BoneSaver.ExTopI = "null";
                }
                if (BoneSaver.ExRootTop == null)
                {
                    BoneSaver.ExRootTop = "null";
                    BoneSaver.ExTopA = "null";
                    BoneSaver.ExTopB = "null";
                    BoneSaver.ExTopC = "null";
                    BoneSaver.ExTopD = "null";
                    BoneSaver.ExTopE = "null";
                    BoneSaver.ExTopF = "null";
                    BoneSaver.ExTopG = "null";
                    BoneSaver.ExTopH = "null";
                    BoneSaver.ExTopI = "null";
                }
                #endregion
                #region Other
                BoneSaver.Root = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Root_Bone));
                BoneSaver.Abdomen = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Abdomen_Bone));
                BoneSaver.Throw = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Throw_Bone));
                BoneSaver.Unknown00 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Unknown00_Bone));
                #endregion

                #region Scale Bones
                #region Head
                BoneSaver.HeadSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Head_Size));
                BoneSaver.EarLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarLeft_Size));
                BoneSaver.EarRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarRight_Size));
                BoneSaver.JawSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Jaw_Size));
                BoneSaver.EyelidLowerLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerLeft_Size));
                BoneSaver.EyelidLowerRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerRight_Size));
                BoneSaver.EyeLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeLeft_Size));
                BoneSaver.EyeRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeRight_Size));
                BoneSaver.NoseSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Nose_Size));
                BoneSaver.CheekLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekLeft_Size));
                BoneSaver.HrothWhiskersLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersLeft_Size));
                BoneSaver.CheekRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekRight_Size));
                BoneSaver.HrothWhiskersRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersRight_Size));
                BoneSaver.LipsLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsLeft_Size));
                BoneSaver.HrothEyebrowLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowLeft_Size));
                BoneSaver.LipsRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsRight_Size));
                BoneSaver.HrothEyebrowRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowRight_Size));
                BoneSaver.EyebrowLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowLeft_Size));
                BoneSaver.HrothBridgeSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBridge_Size));
                BoneSaver.EyebrowRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowRight_Size));
                BoneSaver.HrothBrowLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowLeft_Size));
                BoneSaver.BridgeSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Bridge_Size));
                BoneSaver.HrothBrowRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowRight_Size));
                BoneSaver.BrowLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowLeft_Size));
                BoneSaver.HrothJawUpperSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothJawUpper_Size));
                BoneSaver.BrowRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowRight_Size));
                BoneSaver.HrothLipUpperSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpper_Size));
                BoneSaver.LipUpperASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperA_Size));
                BoneSaver.HrothEyelidUpperLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperLeft_Size));
                BoneSaver.EyelidUpperLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperLeft_Size));
                BoneSaver.HrothEyelidUpperRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperRight_Size));
                BoneSaver.EyelidUpperRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperRight_Size));
                BoneSaver.HrothLipsLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsLeft_Size));
                BoneSaver.LipLowerASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerA_Size));
                BoneSaver.HrothLipsRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsRight_Size));
                BoneSaver.VieraEar01ALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ALeft_Size));
                BoneSaver.LipUpperBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperB_Size));
                BoneSaver.HrothLipUpperLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperLeft_Size));
                BoneSaver.VieraEar01ARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ARight_Size));
                BoneSaver.LipLowerBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerB_Size));
                BoneSaver.HrothLipUpperRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperRight_Size));
                BoneSaver.VieraEar02ALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ALeft_Size));
                if (AppearanceArray[0] == 7 || AppearanceArray[0] == 8)
                {
                    BoneSaver.HrothLipLowerSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipLower_Size));
                    BoneSaver.VieraEar02ARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ARight_Size));
                }
                else
                {
                    BoneSaver.HrothLipLowerSize = "null";
                    BoneSaver.VieraEar02ARightSize = "null";
                }
                if (AppearanceArray[0] == 8)
                {
                    BoneSaver.VieraEar03ALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ALeft_Size));
                    BoneSaver.VieraEar03ARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ARight_Size));
                    BoneSaver.VieraEar04ALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ALeft_Size));
                    BoneSaver.VieraEar04ARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ARight_Size));
                    BoneSaver.VieraLipLowerASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerA_Size));
                    BoneSaver.VieraLipUpperBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipUpperB_Size));
                    BoneSaver.VieraEar01BLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BLeft_Size));
                    BoneSaver.VieraEar01BRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BRight_Size));
                    BoneSaver.VieraEar02BLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BLeft_Size));
                    BoneSaver.VieraEar02BRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Size));
                    BoneSaver.VieraEar03BLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03BLeft_Size));
                    BoneSaver.VieraEar03BRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Size));
                    BoneSaver.VieraEar04BLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BLeft_Size));
                    BoneSaver.VieraEar04BRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BRight_Size));
                    BoneSaver.VieraLipLowerBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerB_Size));
                }
                else
                {
                    BoneSaver.VieraEar03ALeftSize = "null";
                    BoneSaver.VieraEar03ARightSize = "null";
                    BoneSaver.VieraEar04ALeftSize = "null";
                    BoneSaver.VieraEar04ARightSize = "null";
                    BoneSaver.VieraLipLowerASize = "null";
                    BoneSaver.VieraLipUpperBSize = "null";
                    BoneSaver.VieraEar01BLeftSize = "null";
                    BoneSaver.VieraEar01BRightSize = "null";
                    BoneSaver.VieraEar02BLeftSize = "null";
                    BoneSaver.VieraEar02BRightSize = "null";
                    BoneSaver.VieraEar03BLeftSize = "null";
                    BoneSaver.VieraEar03BRightSize = "null";
                    BoneSaver.VieraEar04BLeftSize = "null";
                    BoneSaver.VieraEar04BRightSize = "null";
                    BoneSaver.VieraLipLowerBSize = "null";
                }
                #endregion
                #region Hair

                BoneSaver.HairASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairA_Size));
                BoneSaver.HairFrontLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontLeft_Size));
                BoneSaver.HairFrontRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontRight_Size));
                BoneSaver.HairBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairB_Size));
                if (HairValue >= 1)
                {
                    // BoneSaver.ExRootHairSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootHair_Size));
                }
                if (HairValue >= 2)
                {
                    BoneSaver.ExHairASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairA_Size));
                }
                else
                {
                    BoneSaver.ExHairASize = "null";
                }
                if (HairValue >= 3)
                {
                    BoneSaver.ExHairBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairB_Size));
                }
                else
                {
                    BoneSaver.ExHairBSize = "null";
                }
                if (HairValue >= 4)
                {
                    BoneSaver.ExHairCSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairC_Size));
                }
                else
                {
                    BoneSaver.ExHairCSize = "null";
                }
                if (HairValue >= 5)
                {
                    BoneSaver.ExHairDSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairD_Size));
                }
                else
                {
                    BoneSaver.ExHairDSize = "null";
                }
                if (HairValue >= 6)
                {
                    BoneSaver.ExHairESize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairE_Size));
                }
                else
                {
                    BoneSaver.ExHairESize = "null";
                }
                if (HairValue >= 7)
                {
                    BoneSaver.ExHairFSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairF_Size));
                }
                else
                {
                    BoneSaver.ExHairFSize = "null";
                }
                if (HairValue >= 8)
                {
                    BoneSaver.ExHairGSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairG_Size));
                }
                else
                {
                    BoneSaver.ExHairGSize = "null";
                }
                if (HairValue >= 9)
                {
                    BoneSaver.ExHairHSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairH_Size));
                }
                else
                {
                    BoneSaver.ExHairHSize = "null";
                }
                if (HairValue >= 10)
                {
                    BoneSaver.ExHairISize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairI_Size));
                }
                else
                {
                    BoneSaver.ExHairISize = "null";
                }
                if (HairValue >= 11)
                {
                    BoneSaver.ExHairJSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairJ_Size));
                }
                else
                {
                    BoneSaver.ExHairJSize = "null";
                }
                if (HairValue >= 12)
                {
                    BoneSaver.ExHairKSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairK_Size));
                }
                else
                {
                    BoneSaver.ExHairKSize = "null";
                }
                if (HairValue >= 13)
                {
                    BoneSaver.ExHairLSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairL_Size));
                }
                else
                {
                    BoneSaver.ExHairLSize = "null";
                }
                if (BoneSaver.ExRootHair == null)
                {
                    BoneSaver.ExRootHairSize = "null";
                    BoneSaver.ExHairASize = "null";
                    BoneSaver.ExHairBSize = "null";
                    BoneSaver.ExHairCSize = "null";
                    BoneSaver.ExHairDSize = "null";
                    BoneSaver.ExHairESize = "null";
                    BoneSaver.ExHairFSize = "null";
                    BoneSaver.ExHairGSize = "null";
                    BoneSaver.ExHairHSize = "null";
                    BoneSaver.ExHairISize = "null";
                    BoneSaver.ExHairJSize = "null";
                    BoneSaver.ExHairKSize = "null";
                    BoneSaver.ExHairLSize = "null";
                }
                #endregion

                #region Body
                BoneSaver.SpineASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineA_Size));
                BoneSaver.SpineBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineB_Size));
                BoneSaver.BreastLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastLeft_Size));
                BoneSaver.BreastRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastRight_Size));
                BoneSaver.SpineCSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineC_Size));
                BoneSaver.NeckSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Neck_Size));
                #endregion

                #region LeftArm
                BoneSaver.ClavicleLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleLeft_Size));
                BoneSaver.ArmLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmLeft_Size));
                BoneSaver.ForearmLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmLeft_Size));
                BoneSaver.ShoulderLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderLeft_Size));
                BoneSaver.ElbowLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowLeft_Size));
                BoneSaver.CouterLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterLeft_Size));
                BoneSaver.WristLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristLeft_Size));
                #endregion

                #region RightArm
                BoneSaver.ClavicleRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleRight_Size));
                BoneSaver.ArmRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmRight_Size));
                BoneSaver.ForearmRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmRight_Size));
                BoneSaver.ShoulderRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderRight_Size));
                BoneSaver.ElbowRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowRight_Size));
                BoneSaver.CouterRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterRight_Size));
                BoneSaver.WristRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristRight_Size));
                #endregion

                #region Clothes
                BoneSaver.ClothBackALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackALeft_Size));
                BoneSaver.ClothBackARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackARight_Size));
                BoneSaver.ClothFrontALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontALeft_Size));
                BoneSaver.ClothFrontARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontARight_Size));
                BoneSaver.ClothSideALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideALeft_Size));
                BoneSaver.ClothSideARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideARight_Size));
                BoneSaver.ClothBackBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBLeft_Size));
                BoneSaver.ClothBackBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBRight_Size));
                BoneSaver.ClothFrontBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBLeft_Size));
                BoneSaver.ClothFrontBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBRight_Size));
                BoneSaver.ClothSideBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBLeft_Size));
                BoneSaver.ClothSideBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBRight_Size));
                BoneSaver.ClothBackCLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCLeft_Size));
                BoneSaver.ClothBackCRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCRight_Size));
                BoneSaver.ClothFrontCLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCLeft_Size));
                BoneSaver.ClothFrontCRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCRight_Size));
                BoneSaver.ClothSideCLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCLeft_Size));
                BoneSaver.ClothSideCRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCRight_Size));
                #endregion

                #region LeftHand
                BoneSaver.HandLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandLeft_Size));
                BoneSaver.IndexALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexALeft_Size));
                BoneSaver.PinkyALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyALeft_Size));
                BoneSaver.RingALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingALeft_Size));
                BoneSaver.MiddleALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleALeft_Size));
                BoneSaver.ThumbALeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbALeft_Size));
                BoneSaver.IndexBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBLeft_Size));
                BoneSaver.PinkyBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBLeft_Size));
                BoneSaver.RingBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBLeft_Size));
                BoneSaver.MiddleBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBLeft_Size));
                BoneSaver.ThumbBLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBLeft_Size));
                #endregion
                #region RightHand
                BoneSaver.HandRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandRight_Size));
                BoneSaver.IndexARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexARight_Size));
                BoneSaver.PinkyARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyARight_Size));
                BoneSaver.RingARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingARight_Size));
                BoneSaver.MiddleARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleARight_Size));
                BoneSaver.ThumbARightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbARight_Size));
                BoneSaver.IndexBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBRight_Size));
                BoneSaver.PinkyBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBRight_Size));
                BoneSaver.RingBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBRight_Size));
                BoneSaver.MiddleBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBRight_Size));
                BoneSaver.ThumbBRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBRight_Size));
                #endregion

                #region Waist
                BoneSaver.WaistSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Waist_Size));
                if (AppearanceArray[0] == 4 || AppearanceArray[0] == 6 || AppearanceArray[0] == 7)
                {
                    BoneSaver.TailASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailA_Size));
                    BoneSaver.TailBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailB_Size));
                    BoneSaver.TailCSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailC_Size));
                    BoneSaver.TailDSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailD_Size));
                    BoneSaver.TailESize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailE_Size));
                }
                else
                {
                    BoneSaver.TailASize = "null";
                    BoneSaver.TailBSize = "null";
                    BoneSaver.TailCSize = "null";
                    BoneSaver.TailDSize = "null";
                    BoneSaver.TailESize = "null";
                }
                #endregion
                #region LeftLeg
                BoneSaver.LegLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsLeft_Size));
                BoneSaver.KneeLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeLeft_Size));
                BoneSaver.CalfLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfLeft_Size));
                BoneSaver.PoleynLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynLeft_Size));
                BoneSaver.FootLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootLeft_Size));
                BoneSaver.ToesLeftSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesLeft_Size));
                #endregion
                #region RightLeg
                BoneSaver.LegRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsRight_Size));
                BoneSaver.KneeRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeRight_Size));
                BoneSaver.CalfRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfRight_Size));
                BoneSaver.PoleynRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynRight_Size));
                BoneSaver.FootRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootRight_Size));
                BoneSaver.ToesRightSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesRight_Size));
                #endregion
                #region Helm
                if (HelmValue >= 1)
                {
                    // BoneSaver.ExRootMetSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootMet_Size));
                }
                if (HelmValue >= 2)
                {
                    BoneSaver.ExMetASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetA_Size));
                }
                else
                {
                    BoneSaver.ExMetASize = "null";
                }
                if (HelmValue >= 3)
                {
                    BoneSaver.ExMetBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetB_Size));
                }
                else
                {
                    BoneSaver.ExMetBSize = "null";
                }
                if (HelmValue >= 4)
                {
                    BoneSaver.ExMetCSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetC_Size));
                }
                else
                {
                    BoneSaver.ExMetCSize = "null";
                }
                if (HelmValue >= 5)
                {
                    BoneSaver.ExMetDSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetD_Size));
                }
                else
                {
                    BoneSaver.ExMetDSize = "null";
                }
                if (HelmValue >= 6)
                {
                    BoneSaver.ExMetESize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetE_Size));
                }
                else
                {
                    BoneSaver.ExMetESize = "null";
                }
                if (HelmValue >= 7)
                {
                    BoneSaver.ExMetFSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetF_Size));
                }
                else
                {
                    BoneSaver.ExMetFSize = "null";
                }
                if (HelmValue >= 8)
                {
                    BoneSaver.ExMetGSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetG_Size));
                }
                else
                {
                    BoneSaver.ExMetGSize = "null";
                }
                if (HelmValue >= 9)
                {
                    BoneSaver.ExMetHSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetH_Size));
                }
                else
                {
                    BoneSaver.ExMetHSize = "null";
                }
                if (HelmValue >= 10)
                {
                    BoneSaver.ExMetISize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetI_Size));
                }
                else
                {
                    BoneSaver.ExMetISize = "null";
                }
                if (HelmValue >= 11)
                {
                    BoneSaver.ExMetJSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetJ_Size));
                }
                else
                {
                    BoneSaver.ExMetJSize = "null";
                }
                if (HelmValue >= 12)
                {
                    BoneSaver.ExMetKSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetK_Size));
                }
                else
                {
                    BoneSaver.ExMetKSize = "null";
                }
                if (HelmValue >= 13)
                {
                    BoneSaver.ExMetLSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetL_Size));
                }
                else
                {
                    BoneSaver.ExMetLSize = "null";
                }
                if (HelmValue >= 14)
                {
                    BoneSaver.ExMetMSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetM_Size));
                }
                else
                {
                    BoneSaver.ExMetMSize = "null";
                }
                if (HelmValue >= 15)
                {
                    BoneSaver.ExMetNSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetN_Size));
                }
                else
                {
                    BoneSaver.ExMetNSize = "null";
                }
                if (HelmValue >= 16)
                {
                    BoneSaver.ExMetOSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetO_Size));
                }
                else
                {
                    BoneSaver.ExMetOSize = "null";
                }
                if (HelmValue >= 17)
                {
                    BoneSaver.ExMetPSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetP_Size));
                }
                else
                {
                    BoneSaver.ExMetPSize = "null";
                }
                if (HelmValue >= 18)
                {
                    BoneSaver.ExMetQSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetQ_Size));
                }
                else
                {
                    BoneSaver.ExMetQSize = "null";
                }
                if (HelmValue >= 19)
                {
                    BoneSaver.ExMetRSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetR_Size));
                }
                else
                {
                    BoneSaver.ExMetRSize = "null";
                }
                if (BoneSaver.ExRootMet == null)
                {
                    BoneSaver.ExRootMetSize = "null";
                    BoneSaver.ExMetASize = "null";
                    BoneSaver.ExMetBSize = "null";
                    BoneSaver.ExMetCSize = "null";
                    BoneSaver.ExMetDSize = "null";
                    BoneSaver.ExMetESize = "null";
                    BoneSaver.ExMetFSize = "null";
                    BoneSaver.ExMetGSize = "null";
                    BoneSaver.ExMetHSize = "null";
                    BoneSaver.ExMetISize = "null";
                    BoneSaver.ExMetJSize = "null";
                    BoneSaver.ExMetKSize = "null";
                    BoneSaver.ExMetLSize = "null";
                    BoneSaver.ExMetMSize = "null";
                    BoneSaver.ExMetNSize = "null";
                    BoneSaver.ExMetOSize = "null";
                    BoneSaver.ExMetPSize = "null";
                    BoneSaver.ExMetQSize = "null";
                    BoneSaver.ExMetRSize = "null";
                }
                #endregion
                #region Top
                if (TopValue >= 1)
                {
                    // BoneSaver.ExRootTopSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootTop_Size));
                }
                if (TopValue >= 2)
                {
                    BoneSaver.ExTopASize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopA_Size));
                }
                else
                {
                    BoneSaver.ExTopASize = "null";
                }
                if (TopValue >= 3)
                {
                    BoneSaver.ExTopBSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopB_Size));
                }
                else
                {
                    BoneSaver.ExTopBSize = "null";
                }
                if (TopValue >= 4)
                {
                    BoneSaver.ExTopCSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopC_Size));
                }
                else
                {
                    BoneSaver.ExTopCSize = "null";
                }
                if (TopValue >= 5)
                {
                    BoneSaver.ExTopDSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopD_Size));
                }
                else
                {
                    BoneSaver.ExTopDSize = "null";
                }
                if (TopValue >= 6)
                {
                    BoneSaver.ExTopESize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopE_Size));
                }
                else
                {
                    BoneSaver.ExTopESize = "null";
                }
                if (TopValue >= 7)
                {
                    BoneSaver.ExTopFSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopF_Size));
                }
                else
                {
                    BoneSaver.ExTopFSize = "null";
                }
                if (TopValue >= 8)
                {
                    BoneSaver.ExTopGSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopG_Size));
                }
                else
                {
                    BoneSaver.ExTopGSize = "null";
                }
                if (TopValue >= 9)
                {
                    BoneSaver.ExTopHSize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopH_Size));
                }
                else
                {
                    BoneSaver.ExTopHSize = "null";
                }
                if (TopValue >= 10)
                {
                    BoneSaver.ExTopISize = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopI_Size));
                }
                else
                {
                    BoneSaver.ExTopISize = "null";
                }
                if (BoneSaver.ExRootTop == null)
                {
                    BoneSaver.ExRootTop = "null";
                    BoneSaver.ExTopASize = "null";
                    BoneSaver.ExTopBSize = "null";
                    BoneSaver.ExTopCSize = "null";
                    BoneSaver.ExTopDSize = "null";
                    BoneSaver.ExTopESize = "null";
                    BoneSaver.ExTopFSize = "null";
                    BoneSaver.ExTopGSize = "null";
                    BoneSaver.ExTopHSize = "null";
                    BoneSaver.ExTopISize = "null";
                }
                #endregion


                #endregion

                string details = JsonConvert.SerializeObject(BoneSaver, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                File.WriteAllText(dig.FileName, details);
            }
        }

        private void LoadCMP_Click(object sender, RoutedEventArgs e)
        {
            DisableTertiary();
            PoseMatrixViewModel.PoseVM.Bone_Flag_Manager();
            OpenFileDialog dig = new OpenFileDialog();
            //dig.InitialDirectory = SaveSettings.Default.MatrixPoseSaveLoadDirectory;
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            dig.DefaultExt = ".cmp";
            if (dig.ShowDialog() == true)
            {
                //SaveSettings.Default.MatrixPoseSaveLoadDirectory = Path.GetDirectoryName(dig.FileName);
                if (MainWindow.GameProcess.ReadByte(BaseModel.GposeCheckOffset.Adressed) == 1 && MainWindow.GameProcess.ReadByte(BaseModel.GposeCheckOffset2.Adressed) == 4)
                {
                    UncheckAll();
                    EditModeButton.IsChecked = true;
                    PhysicsButton.IsChecked = false;
                    BoneSaves BoneLoader = JsonConvert.DeserializeObject<BoneSaves>(File.ReadAllText(dig.FileName));

                    #region Head
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Head), BaseModel.ActorData, BaseModel.Offsets.Head_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarLeft), BaseModel.ActorData, BaseModel.Offsets.EarLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarRight), BaseModel.ActorData, BaseModel.Offsets.EarRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Jaw), BaseModel.ActorData, BaseModel.Offsets.Jaw_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerRight), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeLeft), BaseModel.ActorData, BaseModel.Offsets.EyeLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeRight), BaseModel.ActorData, BaseModel.Offsets.EyeRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Nose), BaseModel.ActorData, BaseModel.Offsets.Nose_Bone);

                    if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                    {
                        if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperB), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerA), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerB), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                        }
                        else if (BoneLoader.Race == "07")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                        }
                        else if (BoneLoader.Race == "08")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                            //   MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperB), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerA), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerB), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                        }
                    }
                    else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                    {
                        if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperB), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                        }
                        else if (BoneLoader.Race == "07")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeft), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRight), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpper), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                        }
                        else if (BoneLoader.Race == "08")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeft), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRight), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpper), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                        }
                    }
                    else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                    {
                        if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARight), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                        }
                        else if (BoneLoader.Race == "07")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                        }
                        else if (BoneLoader.Race == "08")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ALeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ARight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ALeft_Bone);
                        }
                    }
                    if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                        {
                            if (BoneLoader.Race == "07")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipLower), BaseModel.ActorData, BaseModel.Offsets.HrothLipLower_Bone);
                            }
                        }
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                        {
                            if (BoneLoader.Race == "08")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ARight_Bone);
                            }
                        }
                    }
                    if (BoneLoader.VieraEar03ALeft != "null")
                    {
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerA), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperB), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerB), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                        }
                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ALeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ARight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ALeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ARight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerA), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperB), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BLeft_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BRight_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerB), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                        }
                    }
                    #endregion

                    #region Hair
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairA), BaseModel.ActorData, BaseModel.Offsets.HairA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairB), BaseModel.ActorData, BaseModel.Offsets.HairB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontLeft), BaseModel.ActorData, BaseModel.Offsets.HairFrontLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontRight), BaseModel.ActorData, BaseModel.Offsets.HairFrontRight_Bone);
                    byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
                    if (HairValue >= 2)
                    {
                        if (BoneLoader.ExHairA != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairA), BaseModel.ActorData, BaseModel.Offsets.ExHairA_Bone);
                        }
                    }
                    if (HairValue >= 3)
                    {
                        if (BoneLoader.ExHairB != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairB), BaseModel.ActorData, BaseModel.Offsets.ExHairB_Bone);
                        }
                    }
                    if (HairValue >= 4)
                    {
                        if (BoneLoader.ExHairC != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairC), BaseModel.ActorData, BaseModel.Offsets.ExHairC_Bone);
                        }
                    }
                    if (HairValue >= 5)
                    {
                        if (BoneLoader.ExHairD != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairD), BaseModel.ActorData, BaseModel.Offsets.ExHairD_Bone);
                        }
                    }
                    if (HairValue >= 6)
                    {
                        if (BoneLoader.ExHairE != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairE), BaseModel.ActorData, BaseModel.Offsets.ExHairE_Bone);
                        }
                    }
                    if (HairValue >= 7)
                    {
                        if (BoneLoader.ExHairF != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairF), BaseModel.ActorData, BaseModel.Offsets.ExHairF_Bone);
                        }
                    }
                    if (HairValue >= 8)
                    {
                        if (BoneLoader.ExHairG != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairG), BaseModel.ActorData, BaseModel.Offsets.ExHairG_Bone);
                        }
                    }
                    if (HairValue >= 9)
                    {
                        if (BoneLoader.ExHairH != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairH), BaseModel.ActorData, BaseModel.Offsets.ExHairH_Bone);
                        }
                    }
                    if (HairValue >= 10)
                    {
                        if (BoneLoader.ExHairI != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairI), BaseModel.ActorData, BaseModel.Offsets.ExHairI_Bone);
                        }
                    }
                    if (HairValue >= 11)
                    {
                        if (BoneLoader.ExHairJ != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairJ), BaseModel.ActorData, BaseModel.Offsets.ExHairJ_Bone);
                        }
                    }
                    if (HairValue >= 12)
                    {
                        if (BoneLoader.ExHairK != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairK), BaseModel.ActorData, BaseModel.Offsets.ExHairK_Bone);
                        }
                    }
                    if (HairValue >= 13)
                    {
                        if (BoneLoader.ExHairL != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairL), BaseModel.ActorData, BaseModel.Offsets.ExHairL_Bone);
                        }
                    }

                    #endregion

                    #region Earrings
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringALeft), BaseModel.ActorData, BaseModel.Offsets.EarringALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringARight), BaseModel.ActorData, BaseModel.Offsets.EarringARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringBLeft), BaseModel.ActorData, BaseModel.Offsets.EarringBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringBRight), BaseModel.ActorData, BaseModel.Offsets.EarringBRight_Bone);
                    #endregion

                    #region Body
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineA), BaseModel.ActorData, BaseModel.Offsets.SpineA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineB), BaseModel.ActorData, BaseModel.Offsets.SpineB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineC), BaseModel.ActorData, BaseModel.Offsets.SpineC_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastLeft), BaseModel.ActorData, BaseModel.Offsets.BreastLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastRight), BaseModel.ActorData, BaseModel.Offsets.BreastRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ScabbardLeft), BaseModel.ActorData, BaseModel.Offsets.ScabbardLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ScabbardRight), BaseModel.ActorData, BaseModel.Offsets.ScabbardRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Neck), BaseModel.ActorData, BaseModel.Offsets.Neck_Bone);
                    #endregion

                    #region LeftArm
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleLeft), BaseModel.ActorData, BaseModel.Offsets.ClavicleLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmLeft), BaseModel.ActorData, BaseModel.Offsets.ArmLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PauldronLeft), BaseModel.ActorData, BaseModel.Offsets.PauldronLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmLeft), BaseModel.ActorData, BaseModel.Offsets.ForearmLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderLeft), BaseModel.ActorData, BaseModel.Offsets.ShoulderLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShieldLeft), BaseModel.ActorData, BaseModel.Offsets.ShieldLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowLeft), BaseModel.ActorData, BaseModel.Offsets.ElbowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterLeft), BaseModel.ActorData, BaseModel.Offsets.CouterLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristLeft), BaseModel.ActorData, BaseModel.Offsets.WristLeft_Bone);
                    #endregion

                    #region RightArm
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleRight), BaseModel.ActorData, BaseModel.Offsets.ClavicleRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmRight), BaseModel.ActorData, BaseModel.Offsets.ArmRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PauldronRight), BaseModel.ActorData, BaseModel.Offsets.PauldronRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmRight), BaseModel.ActorData, BaseModel.Offsets.ForearmRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderRight), BaseModel.ActorData, BaseModel.Offsets.ShoulderRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShieldRight), BaseModel.ActorData, BaseModel.Offsets.ShieldRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowRight), BaseModel.ActorData, BaseModel.Offsets.ElbowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterRight), BaseModel.ActorData, BaseModel.Offsets.CouterRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristRight), BaseModel.ActorData, BaseModel.Offsets.WristRight_Bone);
                    #endregion

                    #region Clothes
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackALeft), BaseModel.ActorData, BaseModel.Offsets.ClothBackALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackARight), BaseModel.ActorData, BaseModel.Offsets.ClothBackARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontALeft), BaseModel.ActorData, BaseModel.Offsets.ClothFrontALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontARight), BaseModel.ActorData, BaseModel.Offsets.ClothFrontARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideALeft), BaseModel.ActorData, BaseModel.Offsets.ClothSideALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideARight), BaseModel.ActorData, BaseModel.Offsets.ClothSideARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBLeft), BaseModel.ActorData, BaseModel.Offsets.ClothBackBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBRight), BaseModel.ActorData, BaseModel.Offsets.ClothBackBRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBLeft), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBRight), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBLeft), BaseModel.ActorData, BaseModel.Offsets.ClothSideBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBRight), BaseModel.ActorData, BaseModel.Offsets.ClothSideBRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCLeft), BaseModel.ActorData, BaseModel.Offsets.ClothBackCLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCRight), BaseModel.ActorData, BaseModel.Offsets.ClothBackCRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCLeft), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCRight), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCLeft), BaseModel.ActorData, BaseModel.Offsets.ClothSideCLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCRight), BaseModel.ActorData, BaseModel.Offsets.ClothSideCRight_Bone);
                    #endregion

                    #region Weapons

                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WeaponLeft), BaseModel.ActorData, BaseModel.Offsets.WeaponLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WeaponRight), BaseModel.ActorData, BaseModel.Offsets.WeaponRight_Bone);

                    #endregion

                    #region LeftHand
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandLeft), BaseModel.ActorData, BaseModel.Offsets.HandLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexALeft), BaseModel.ActorData, BaseModel.Offsets.IndexALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyALeft), BaseModel.ActorData, BaseModel.Offsets.PinkyALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingALeft), BaseModel.ActorData, BaseModel.Offsets.RingALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleALeft), BaseModel.ActorData, BaseModel.Offsets.MiddleALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbALeft), BaseModel.ActorData, BaseModel.Offsets.ThumbALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBLeft), BaseModel.ActorData, BaseModel.Offsets.IndexBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBLeft), BaseModel.ActorData, BaseModel.Offsets.PinkyBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBLeft), BaseModel.ActorData, BaseModel.Offsets.RingBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBLeft), BaseModel.ActorData, BaseModel.Offsets.MiddleBLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBLeft), BaseModel.ActorData, BaseModel.Offsets.ThumbBLeft_Bone);
                    #endregion

                    #region RightHand
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandRight), BaseModel.ActorData, BaseModel.Offsets.HandRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexARight), BaseModel.ActorData, BaseModel.Offsets.IndexARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyARight), BaseModel.ActorData, BaseModel.Offsets.PinkyARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingARight), BaseModel.ActorData, BaseModel.Offsets.RingARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleARight), BaseModel.ActorData, BaseModel.Offsets.MiddleARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbARight), BaseModel.ActorData, BaseModel.Offsets.ThumbARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBRight), BaseModel.ActorData, BaseModel.Offsets.IndexBRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBRight), BaseModel.ActorData, BaseModel.Offsets.PinkyBRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBRight), BaseModel.ActorData, BaseModel.Offsets.RingBRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBRight), BaseModel.ActorData, BaseModel.Offsets.MiddleBRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBRight), BaseModel.ActorData, BaseModel.Offsets.ThumbBRight_Bone);
                    #endregion

                    #region Waist

                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Waist), BaseModel.ActorData, BaseModel.Offsets.Waist_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HolsterLeft), BaseModel.ActorData, BaseModel.Offsets.HolsterLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HolsterRight), BaseModel.ActorData, BaseModel.Offsets.HolsterRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SheatheLeft), BaseModel.ActorData, BaseModel.Offsets.SheatheLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SheatheRight), BaseModel.ActorData, BaseModel.Offsets.SheatheRight_Bone);
                    if (BoneLoader.TailA != "null")
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailA), BaseModel.ActorData, BaseModel.Offsets.TailA_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailB), BaseModel.ActorData, BaseModel.Offsets.TailB_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailC), BaseModel.ActorData, BaseModel.Offsets.TailC_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailD), BaseModel.ActorData, BaseModel.Offsets.TailD_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailE), BaseModel.ActorData, BaseModel.Offsets.TailE_Bone);
                    }
                    #endregion

                    #region LeftLeg
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegLeft), BaseModel.ActorData, BaseModel.Offsets.LegsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeLeft), BaseModel.ActorData, BaseModel.Offsets.KneeLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfLeft), BaseModel.ActorData, BaseModel.Offsets.CalfLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynLeft), BaseModel.ActorData, BaseModel.Offsets.PoleynLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootLeft), BaseModel.ActorData, BaseModel.Offsets.FootLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesLeft), BaseModel.ActorData, BaseModel.Offsets.ToesLeft_Bone);
                    #endregion

                    #region RightLeg
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegRight), BaseModel.ActorData, BaseModel.Offsets.LegsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeRight), BaseModel.ActorData, BaseModel.Offsets.KneeRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfRight), BaseModel.ActorData, BaseModel.Offsets.CalfRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynRight), BaseModel.ActorData, BaseModel.Offsets.PoleynRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootRight), BaseModel.ActorData, BaseModel.Offsets.FootRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesRight), BaseModel.ActorData, BaseModel.Offsets.ToesRight_Bone);
                    #endregion

                    #region Helm
                    byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);
                    if (HelmValue >= 2)
                    {
                        if (BoneLoader.ExMetA != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetA), BaseModel.ActorData, BaseModel.Offsets.ExMetA_Bone);
                        }
                    }
                    if (HelmValue >= 3)
                    {
                        if (BoneLoader.ExMetB != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetB), BaseModel.ActorData, BaseModel.Offsets.ExMetB_Bone);
                        }
                    }
                    if (HelmValue >= 4)
                    {
                        if (BoneLoader.ExMetC != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetC), BaseModel.ActorData, BaseModel.Offsets.ExMetC_Bone);
                        }
                    }
                    if (HelmValue >= 5)
                    {
                        if (BoneLoader.ExMetD != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetD), BaseModel.ActorData, BaseModel.Offsets.ExMetD_Bone);
                        }
                    }
                    if (HelmValue >= 6)
                    {
                        if (BoneLoader.ExMetE != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetE), BaseModel.ActorData, BaseModel.Offsets.ExMetE_Bone);
                        }
                    }
                    if (HelmValue >= 7)
                    {
                        if (BoneLoader.ExMetF != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetF), BaseModel.ActorData, BaseModel.Offsets.ExMetF_Bone);
                        }
                    }
                    if (HelmValue >= 8)
                    {
                        if (BoneLoader.ExMetG != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetG), BaseModel.ActorData, BaseModel.Offsets.ExMetG_Bone);
                        }
                    }
                    if (HelmValue >= 9)
                    {
                        if (BoneLoader.ExMetH != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetH), BaseModel.ActorData, BaseModel.Offsets.ExMetH_Bone);
                        }
                    }
                    if (HelmValue >= 10)
                    {
                        if (BoneLoader.ExMetI != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetI), BaseModel.ActorData, BaseModel.Offsets.ExMetI_Bone);
                        }
                    }
                    if (HelmValue >= 11)
                    {
                        if (BoneLoader.ExMetJ != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetJ), BaseModel.ActorData, BaseModel.Offsets.ExMetJ_Bone);
                        }
                    }
                    if (HelmValue >= 12)
                    {
                        if (BoneLoader.ExMetK != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetK), BaseModel.ActorData, BaseModel.Offsets.ExMetK_Bone);
                        }
                    }
                    if (HelmValue >= 13)
                    {
                        if (BoneLoader.ExMetL != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetL), BaseModel.ActorData, BaseModel.Offsets.ExMetL_Bone);
                        }
                    }
                    if (HelmValue >= 14)
                    {
                        if (BoneLoader.ExMetM != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetM), BaseModel.ActorData, BaseModel.Offsets.ExMetM_Bone);
                        }
                    }
                    if (HelmValue >= 15)
                    {
                        if (BoneLoader.ExMetN != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetN), BaseModel.ActorData, BaseModel.Offsets.ExMetN_Bone);
                        }
                    }
                    if (HelmValue >= 16)
                    {
                        if (BoneLoader.ExMetO != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetO), BaseModel.ActorData, BaseModel.Offsets.ExMetO_Bone);
                        }
                    }
                    if (HelmValue >= 17)
                    {
                        if (BoneLoader.ExMetP != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetP), BaseModel.ActorData, BaseModel.Offsets.ExMetP_Bone);
                        }
                    }
                    if (HelmValue >= 18)
                    {
                        if (BoneLoader.ExMetQ != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetQ), BaseModel.ActorData, BaseModel.Offsets.ExMetQ_Bone);
                        }
                    }
                    if (HelmValue >= 19)
                    {
                        if (BoneLoader.ExMetR != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetR), BaseModel.ActorData, BaseModel.Offsets.ExMetR_Bone);
                        }
                    }
                    #endregion

                    #region Top
                    byte TopValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);

                    if (TopValue >= 2)
                    {
                        if (BoneLoader.ExTopA != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopA), BaseModel.ActorData, BaseModel.Offsets.ExTopA_Bone);
                        }
                    }
                    if (TopValue >= 3)
                    {
                        if (BoneLoader.ExTopB != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopB), BaseModel.ActorData, BaseModel.Offsets.ExTopB_Bone);
                        }
                    }
                    if (TopValue >= 4)
                    {
                        if (BoneLoader.ExTopC != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopC), BaseModel.ActorData, BaseModel.Offsets.ExTopC_Bone);
                        }
                    }
                    if (TopValue >= 5)
                    {
                        if (BoneLoader.ExTopD != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopD), BaseModel.ActorData, BaseModel.Offsets.ExTopD_Bone);
                        }
                    }
                    if (TopValue >= 6)
                    {
                        if (BoneLoader.ExTopE != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopE), BaseModel.ActorData, BaseModel.Offsets.ExTopE_Bone);
                        }
                    }
                    if (TopValue >= 7)
                    {
                        if (BoneLoader.ExTopF != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopF), BaseModel.ActorData, BaseModel.Offsets.ExTopF_Bone);
                        }
                    }
                    if (TopValue >= 8)
                    {
                        if (BoneLoader.ExTopG != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopG), BaseModel.ActorData, BaseModel.Offsets.ExTopG_Bone);
                        }
                    }
                    if (TopValue >= 9)
                    {
                        if (BoneLoader.ExTopH != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopH), BaseModel.ActorData, BaseModel.Offsets.ExTopH_Bone);
                        }
                    }
                    if (TopValue >= 10)
                    {
                        if (BoneLoader.ExTopI != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopI), BaseModel.ActorData, BaseModel.Offsets.ExTopI_Bone);
                        }
                    }
                    #endregion

                    #region Scale bones
                    if (BoneLoader.CMPVersion == "2.0")
                    {
                        if (ScaleSaveToggle.IsChecked == true)
                        {
                            #region Head
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HeadSize), BaseModel.ActorData, BaseModel.Offsets.Head_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarLeftSize), BaseModel.ActorData, BaseModel.Offsets.EarLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarRightSize), BaseModel.ActorData, BaseModel.Offsets.EarRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.JawSize), BaseModel.ActorData, BaseModel.Offsets.Jaw_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyeLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeRightSize), BaseModel.ActorData, BaseModel.Offsets.EyeRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.NoseSize), BaseModel.ActorData, BaseModel.Offsets.Nose_Size);

                            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                            {
                                if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerASize), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                }
                                else if (BoneLoader.Race == "07")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                }
                                else if (BoneLoader.Race == "08")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                    //   MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerASize), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                }
                            }
                            else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                            {
                                if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Size);
                                }
                                else if (BoneLoader.Race == "07")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpperSize), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Size);
                                }
                                else if (BoneLoader.Race == "08")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpperSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                }
                            }
                            else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                            {
                                if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                }
                                else if (BoneLoader.Race == "07")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                }
                                else if (BoneLoader.Race == "08")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ALeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ARight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ALeft_Size);
                                }
                            }
                            if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                            {
                                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                                {
                                    if (BoneLoader.Race == "07")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipLowerSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipLower_Size);
                                    }
                                }
                                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                                {
                                    if (BoneLoader.Race == "08")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ARight_Size);
                                    }
                                }
                            }
                            if (BoneLoader.VieraEar03ALeft != "null")
                            {
                                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerASize), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Size);
                                }
                                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ALeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ARight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ALeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ARight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerASize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BLeft_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BRight_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Size);
                                }
                            }
                            #endregion

                            #region Hair
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairASize), BaseModel.ActorData, BaseModel.Offsets.HairA_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairBSize), BaseModel.ActorData, BaseModel.Offsets.HairB_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontLeftSize), BaseModel.ActorData, BaseModel.Offsets.HairFrontLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontRightSize), BaseModel.ActorData, BaseModel.Offsets.HairFrontRight_Size);
                            if (HairValue >= 2)
                            {
                                if (BoneLoader.ExHairA != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairASize), BaseModel.ActorData, BaseModel.Offsets.ExHairA_Size);
                                }
                            }
                            if (HairValue >= 3)
                            {
                                if (BoneLoader.ExHairB != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairBSize), BaseModel.ActorData, BaseModel.Offsets.ExHairB_Size);
                                }
                            }
                            if (HairValue >= 4)
                            {
                                if (BoneLoader.ExHairC != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairCSize), BaseModel.ActorData, BaseModel.Offsets.ExHairC_Size);
                                }
                            }
                            if (HairValue >= 5)
                            {
                                if (BoneLoader.ExHairD != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairDSize), BaseModel.ActorData, BaseModel.Offsets.ExHairD_Size);
                                }
                            }
                            if (HairValue >= 6)
                            {
                                if (BoneLoader.ExHairE != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairESize), BaseModel.ActorData, BaseModel.Offsets.ExHairE_Size);
                                }
                            }
                            if (HairValue >= 7)
                            {
                                if (BoneLoader.ExHairF != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairFSize), BaseModel.ActorData, BaseModel.Offsets.ExHairF_Size);
                                }
                            }
                            if (HairValue >= 8)
                            {
                                if (BoneLoader.ExHairG != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairGSize), BaseModel.ActorData, BaseModel.Offsets.ExHairG_Size);
                                }
                            }
                            if (HairValue >= 9)
                            {
                                if (BoneLoader.ExHairH != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairHSize), BaseModel.ActorData, BaseModel.Offsets.ExHairH_Size);
                                }
                            }
                            if (HairValue >= 10)
                            {
                                if (BoneLoader.ExHairI != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairISize), BaseModel.ActorData, BaseModel.Offsets.ExHairI_Size);
                                }
                            }
                            if (HairValue >= 11)
                            {
                                if (BoneLoader.ExHairJ != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairJSize), BaseModel.ActorData, BaseModel.Offsets.ExHairJ_Size);
                                }
                            }
                            if (HairValue >= 12)
                            {
                                if (BoneLoader.ExHairK != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairKSize), BaseModel.ActorData, BaseModel.Offsets.ExHairK_Size);
                                }
                            }
                            if (HairValue >= 13)
                            {
                                if (BoneLoader.ExHairL != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairLSize), BaseModel.ActorData, BaseModel.Offsets.ExHairL_Size);
                                }
                            }

                            #endregion

                            #region Body
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineASize), BaseModel.ActorData, BaseModel.Offsets.SpineA_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineBSize), BaseModel.ActorData, BaseModel.Offsets.SpineB_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineCSize), BaseModel.ActorData, BaseModel.Offsets.SpineC_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastLeftSize), BaseModel.ActorData, BaseModel.Offsets.BreastLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastRightSize), BaseModel.ActorData, BaseModel.Offsets.BreastRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.NeckSize), BaseModel.ActorData, BaseModel.Offsets.Neck_Size);
                            #endregion

                            #region LeftArm
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClavicleLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmLeftSize), BaseModel.ActorData, BaseModel.Offsets.ArmLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmLeftSize), BaseModel.ActorData, BaseModel.Offsets.ForearmLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderLeftSize), BaseModel.ActorData, BaseModel.Offsets.ShoulderLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowLeftSize), BaseModel.ActorData, BaseModel.Offsets.ElbowLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterLeftSize), BaseModel.ActorData, BaseModel.Offsets.CouterLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristLeftSize), BaseModel.ActorData, BaseModel.Offsets.WristLeft_Size);
                            #endregion

                            #region RightArm
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleRightSize), BaseModel.ActorData, BaseModel.Offsets.ClavicleRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmRightSize), BaseModel.ActorData, BaseModel.Offsets.ArmRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmRightSize), BaseModel.ActorData, BaseModel.Offsets.ForearmRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderRightSize), BaseModel.ActorData, BaseModel.Offsets.ShoulderRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowRightSize), BaseModel.ActorData, BaseModel.Offsets.ElbowRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterRightSize), BaseModel.ActorData, BaseModel.Offsets.CouterRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristRightSize), BaseModel.ActorData, BaseModel.Offsets.WristRight_Size);
                            #endregion

                            #region Clothes
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackALeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackARightSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontALeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontARightSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideALeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideARightSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackBLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackBRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideBLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideBRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackCLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackCRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideCLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideCRight_Size);
                            #endregion

                            #region LeftHand
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandLeftSize), BaseModel.ActorData, BaseModel.Offsets.HandLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexALeftSize), BaseModel.ActorData, BaseModel.Offsets.IndexALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyALeftSize), BaseModel.ActorData, BaseModel.Offsets.PinkyALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingALeftSize), BaseModel.ActorData, BaseModel.Offsets.RingALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleALeftSize), BaseModel.ActorData, BaseModel.Offsets.MiddleALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbALeftSize), BaseModel.ActorData, BaseModel.Offsets.ThumbALeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBLeftSize), BaseModel.ActorData, BaseModel.Offsets.IndexBLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBLeftSize), BaseModel.ActorData, BaseModel.Offsets.PinkyBLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBLeftSize), BaseModel.ActorData, BaseModel.Offsets.RingBLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBLeftSize), BaseModel.ActorData, BaseModel.Offsets.MiddleBLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ThumbBLeft_Size);
                            #endregion

                            #region RightHand
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandRightSize), BaseModel.ActorData, BaseModel.Offsets.HandRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexARightSize), BaseModel.ActorData, BaseModel.Offsets.IndexARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyARightSize), BaseModel.ActorData, BaseModel.Offsets.PinkyARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingARightSize), BaseModel.ActorData, BaseModel.Offsets.RingARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleARightSize), BaseModel.ActorData, BaseModel.Offsets.MiddleARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbARightSize), BaseModel.ActorData, BaseModel.Offsets.ThumbARight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBRightSize), BaseModel.ActorData, BaseModel.Offsets.IndexBRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBRightSize), BaseModel.ActorData, BaseModel.Offsets.PinkyBRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBRightSize), BaseModel.ActorData, BaseModel.Offsets.RingBRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBRightSize), BaseModel.ActorData, BaseModel.Offsets.MiddleBRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBRightSize), BaseModel.ActorData, BaseModel.Offsets.ThumbBRight_Size);
                            #endregion

                            #region Waist

                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WaistSize), BaseModel.ActorData, BaseModel.Offsets.Waist_Size);
                            if (BoneLoader.TailA != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailASize), BaseModel.ActorData, BaseModel.Offsets.TailA_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailBSize), BaseModel.ActorData, BaseModel.Offsets.TailB_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailCSize), BaseModel.ActorData, BaseModel.Offsets.TailC_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailDSize), BaseModel.ActorData, BaseModel.Offsets.TailD_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailESize), BaseModel.ActorData, BaseModel.Offsets.TailE_Size);
                            }
                            #endregion

                            #region LeftLeg
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegLeftSize), BaseModel.ActorData, BaseModel.Offsets.LegsLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeLeftSize), BaseModel.ActorData, BaseModel.Offsets.KneeLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfLeftSize), BaseModel.ActorData, BaseModel.Offsets.CalfLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynLeftSize), BaseModel.ActorData, BaseModel.Offsets.PoleynLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootLeftSize), BaseModel.ActorData, BaseModel.Offsets.FootLeft_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesLeftSize), BaseModel.ActorData, BaseModel.Offsets.ToesLeft_Size);
                            #endregion

                            #region RightLeg
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegRightSize), BaseModel.ActorData, BaseModel.Offsets.LegsRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeRightSize), BaseModel.ActorData, BaseModel.Offsets.KneeRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfRightSize), BaseModel.ActorData, BaseModel.Offsets.CalfRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynRightSize), BaseModel.ActorData, BaseModel.Offsets.PoleynRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootRightSize), BaseModel.ActorData, BaseModel.Offsets.FootRight_Size);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesRightSize), BaseModel.ActorData, BaseModel.Offsets.ToesRight_Size);
                            #endregion

                            #region Helm
                            if (HelmValue >= 2)
                            {
                                if (BoneLoader.ExMetA != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetASize), BaseModel.ActorData, BaseModel.Offsets.ExMetA_Size);
                                }
                            }
                            if (HelmValue >= 3)
                            {
                                if (BoneLoader.ExMetB != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetBSize), BaseModel.ActorData, BaseModel.Offsets.ExMetB_Size);
                                }
                            }
                            if (HelmValue >= 4)
                            {
                                if (BoneLoader.ExMetC != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetCSize), BaseModel.ActorData, BaseModel.Offsets.ExMetC_Size);
                                }
                            }
                            if (HelmValue >= 5)
                            {
                                if (BoneLoader.ExMetD != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetDSize), BaseModel.ActorData, BaseModel.Offsets.ExMetD_Size);
                                }
                            }
                            if (HelmValue >= 6)
                            {
                                if (BoneLoader.ExMetE != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetESize), BaseModel.ActorData, BaseModel.Offsets.ExMetE_Size);
                                }
                            }
                            if (HelmValue >= 7)
                            {
                                if (BoneLoader.ExMetF != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetFSize), BaseModel.ActorData, BaseModel.Offsets.ExMetF_Size);
                                }
                            }
                            if (HelmValue >= 8)
                            {
                                if (BoneLoader.ExMetG != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetGSize), BaseModel.ActorData, BaseModel.Offsets.ExMetG_Size);
                                }
                            }
                            if (HelmValue >= 9)
                            {
                                if (BoneLoader.ExMetH != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetHSize), BaseModel.ActorData, BaseModel.Offsets.ExMetH_Size);
                                }
                            }
                            if (HelmValue >= 10)
                            {
                                if (BoneLoader.ExMetI != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetISize), BaseModel.ActorData, BaseModel.Offsets.ExMetI_Size);
                                }
                            }
                            if (HelmValue >= 11)
                            {
                                if (BoneLoader.ExMetJ != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetJSize), BaseModel.ActorData, BaseModel.Offsets.ExMetJ_Size);
                                }
                            }
                            if (HelmValue >= 12)
                            {
                                if (BoneLoader.ExMetK != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetKSize), BaseModel.ActorData, BaseModel.Offsets.ExMetK_Size);
                                }
                            }
                            if (HelmValue >= 13)
                            {
                                if (BoneLoader.ExMetL != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetLSize), BaseModel.ActorData, BaseModel.Offsets.ExMetL_Size);
                                }
                            }
                            if (HelmValue >= 14)
                            {
                                if (BoneLoader.ExMetM != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetMSize), BaseModel.ActorData, BaseModel.Offsets.ExMetM_Size);
                                }
                            }
                            if (HelmValue >= 15)
                            {
                                if (BoneLoader.ExMetN != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetNSize), BaseModel.ActorData, BaseModel.Offsets.ExMetN_Size);
                                }
                            }
                            if (HelmValue >= 16)
                            {
                                if (BoneLoader.ExMetO != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetOSize), BaseModel.ActorData, BaseModel.Offsets.ExMetO_Size);
                                }
                            }
                            if (HelmValue >= 17)
                            {
                                if (BoneLoader.ExMetP != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetPSize), BaseModel.ActorData, BaseModel.Offsets.ExMetP_Size);
                                }
                            }
                            if (HelmValue >= 18)
                            {
                                if (BoneLoader.ExMetQ != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetQSize), BaseModel.ActorData, BaseModel.Offsets.ExMetQ_Size);
                                }
                            }
                            if (HelmValue >= 19)
                            {
                                if (BoneLoader.ExMetR != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetRSize), BaseModel.ActorData, BaseModel.Offsets.ExMetR_Size);
                                }
                            }
                            #endregion

                            #region Top

                            if (TopValue >= 2)
                            {
                                if (BoneLoader.ExTopA != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopASize), BaseModel.ActorData, BaseModel.Offsets.ExTopA_Size);
                                }
                            }
                            if (TopValue >= 3)
                            {
                                if (BoneLoader.ExTopB != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopBSize), BaseModel.ActorData, BaseModel.Offsets.ExTopB_Size);
                                }
                            }
                            if (TopValue >= 4)
                            {
                                if (BoneLoader.ExTopC != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopCSize), BaseModel.ActorData, BaseModel.Offsets.ExTopC_Size);
                                }
                            }
                            if (TopValue >= 5)
                            {
                                if (BoneLoader.ExTopD != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopDSize), BaseModel.ActorData, BaseModel.Offsets.ExTopD_Size);
                                }
                            }
                            if (TopValue >= 6)
                            {
                                if (BoneLoader.ExTopE != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopESize), BaseModel.ActorData, BaseModel.Offsets.ExTopE_Size);
                                }
                            }
                            if (TopValue >= 7)
                            {
                                if (BoneLoader.ExTopF != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopFSize), BaseModel.ActorData, BaseModel.Offsets.ExTopF_Size);
                                }
                            }
                            if (TopValue >= 8)
                            {
                                if (BoneLoader.ExTopG != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopGSize), BaseModel.ActorData, BaseModel.Offsets.ExTopG_Size);
                                }
                            }
                            if (TopValue >= 9)
                            {
                                if (BoneLoader.ExTopH != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopHSize), BaseModel.ActorData, BaseModel.Offsets.ExTopH_Size);
                                }
                            }
                            if (TopValue >= 10)
                            {
                                if (BoneLoader.ExTopI != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopISize), BaseModel.ActorData, BaseModel.Offsets.ExTopI_Size);
                                }
                            }
                            #endregion
                        }
                    }

                    #endregion
                }
                else return;
            }
        }

        private void AdvLoadCMP_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            // dig.InitialDirectory = SaveSettings.Default.MatrixPoseSaveLoadDirectory;
            dig.Filter = "Concept Matrix Pose File(*.cmp)|*.cmp";
            dig.DefaultExt = ".cmp";
            if (dig.ShowDialog() == true)
            {
                if (MainWindow.GameProcess.ReadByte(BaseModel.GposeCheckOffset.Adressed) == 1 && MainWindow.GameProcess.ReadByte(BaseModel.GposeCheckOffset2.Adressed) == 4)
                {
                    UncheckAll();
                    EditModeButton.IsChecked = true;
                    PhysicsButton.IsChecked = false;
                    BoneSaves BoneLoader = JsonConvert.DeserializeObject<BoneSaves>(File.ReadAllText(dig.FileName));
                    #region Head
                    if (HeadAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Head), BaseModel.ActorData, BaseModel.Offsets.Head_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarLeft), BaseModel.ActorData, BaseModel.Offsets.EarLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarRight), BaseModel.ActorData, BaseModel.Offsets.EarRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Jaw), BaseModel.ActorData, BaseModel.Offsets.Jaw_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerRight), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeLeft), BaseModel.ActorData, BaseModel.Offsets.EyeLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeRight), BaseModel.ActorData, BaseModel.Offsets.EyeRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Nose), BaseModel.ActorData, BaseModel.Offsets.Nose_Bone);

                        if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperB), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerA), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerB), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                            }
                            else if (BoneLoader.Race == "07")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                            }
                            else if (BoneLoader.Race == "08")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                                //   MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperB), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerA), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerB), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                            }
                        }
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperB), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                            }
                            else if (BoneLoader.Race == "07")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeft), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRight), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpper), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                            }
                            else if (BoneLoader.Race == "08")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeft), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRight), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpper), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                            }
                        }
                        else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                        {
                            if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARight), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                            }
                            else if (BoneLoader.Race == "07")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpper), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                            }
                            else if (BoneLoader.Race == "08")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeft), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRight), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeft), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRight), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeft), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRight), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Bridge), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeft), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRight), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperA), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeft), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRight), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ALeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ARight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ALeft_Bone);
                            }
                        }
                        if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                        {
                            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                            {
                                if (BoneLoader.Race == "07")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipLower), BaseModel.ActorData, BaseModel.Offsets.HrothLipLower_Bone);
                                }
                            }
                            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                            {
                                if (BoneLoader.Race == "08")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ARight_Bone);
                                }
                            }
                        }
                        if (BoneLoader.VieraEar03ALeft != "null")
                        {
                            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerA), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperB), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerB), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                            }
                            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ALeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ARight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ALeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ALeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ARight), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ARight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerA), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperB), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BLeft), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BLeft_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BRight), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BRight_Bone);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerB), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                            }
                        }
                    }
                    #endregion
                    #region Hair
                    if (HairAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairA), BaseModel.ActorData, BaseModel.Offsets.HairA_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairB), BaseModel.ActorData, BaseModel.Offsets.HairB_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontLeft), BaseModel.ActorData, BaseModel.Offsets.HairFrontLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontRight), BaseModel.ActorData, BaseModel.Offsets.HairFrontRight_Bone);
                        byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
                        if (HairValue >= 2)
                        {
                            if (BoneLoader.ExHairA != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairA), BaseModel.ActorData, BaseModel.Offsets.ExHairA_Bone);
                            }
                        }
                        if (HairValue >= 3)
                        {
                            if (BoneLoader.ExHairB != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairB), BaseModel.ActorData, BaseModel.Offsets.ExHairB_Bone);
                            }
                        }
                        if (HairValue >= 4)
                        {
                            if (BoneLoader.ExHairC != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairC), BaseModel.ActorData, BaseModel.Offsets.ExHairC_Bone);
                            }
                        }
                        if (HairValue >= 5)
                        {
                            if (BoneLoader.ExHairD != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairD), BaseModel.ActorData, BaseModel.Offsets.ExHairD_Bone);
                            }
                        }
                        if (HairValue >= 6)
                        {
                            if (BoneLoader.ExHairE != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairE), BaseModel.ActorData, BaseModel.Offsets.ExHairE_Bone);
                            }
                        }
                        if (HairValue >= 7)
                        {
                            if (BoneLoader.ExHairF != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairF), BaseModel.ActorData, BaseModel.Offsets.ExHairF_Bone);
                            }
                        }
                        if (HairValue >= 8)
                        {
                            if (BoneLoader.ExHairG != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairG), BaseModel.ActorData, BaseModel.Offsets.ExHairG_Bone);
                            }
                        }
                        if (HairValue >= 9)
                        {
                            if (BoneLoader.ExHairH != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairH), BaseModel.ActorData, BaseModel.Offsets.ExHairH_Bone);
                            }
                        }
                        if (HairValue >= 10)
                        {
                            if (BoneLoader.ExHairI != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairI), BaseModel.ActorData, BaseModel.Offsets.ExHairI_Bone);
                            }
                        }
                        if (HairValue >= 11)
                        {
                            if (BoneLoader.ExHairJ != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairJ), BaseModel.ActorData, BaseModel.Offsets.ExHairJ_Bone);
                            }
                        }
                        if (HairValue >= 12)
                        {
                            if (BoneLoader.ExHairK != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairK), BaseModel.ActorData, BaseModel.Offsets.ExHairK_Bone);
                            }
                        }
                        if (HairValue >= 13)
                        {
                            if (BoneLoader.ExHairL != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairL), BaseModel.ActorData, BaseModel.Offsets.ExHairL_Bone);
                            }
                        }
                    }
                    #endregion
                    #region Earrings
                    if (EarringsAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringALeft), BaseModel.ActorData, BaseModel.Offsets.EarringALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringARight), BaseModel.ActorData, BaseModel.Offsets.EarringARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringBLeft), BaseModel.ActorData, BaseModel.Offsets.EarringBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarringBRight), BaseModel.ActorData, BaseModel.Offsets.EarringBRight_Bone);

                    }
                    #endregion
                    #region Body
                    if (BodyAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineA), BaseModel.ActorData, BaseModel.Offsets.SpineA_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineB), BaseModel.ActorData, BaseModel.Offsets.SpineB_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineC), BaseModel.ActorData, BaseModel.Offsets.SpineC_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastLeft), BaseModel.ActorData, BaseModel.Offsets.BreastLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastRight), BaseModel.ActorData, BaseModel.Offsets.BreastRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ScabbardLeft), BaseModel.ActorData, BaseModel.Offsets.ScabbardLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ScabbardRight), BaseModel.ActorData, BaseModel.Offsets.ScabbardRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Neck), BaseModel.ActorData, BaseModel.Offsets.Neck_Bone);
                    }
                    #endregion
                    #region Left Arm
                    if (LeftArmAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleLeft), BaseModel.ActorData, BaseModel.Offsets.ClavicleLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmLeft), BaseModel.ActorData, BaseModel.Offsets.ArmLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PauldronLeft), BaseModel.ActorData, BaseModel.Offsets.PauldronLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmLeft), BaseModel.ActorData, BaseModel.Offsets.ForearmLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderLeft), BaseModel.ActorData, BaseModel.Offsets.ShoulderLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShieldLeft), BaseModel.ActorData, BaseModel.Offsets.ShieldLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowLeft), BaseModel.ActorData, BaseModel.Offsets.ElbowLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterLeft), BaseModel.ActorData, BaseModel.Offsets.CouterLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristLeft), BaseModel.ActorData, BaseModel.Offsets.WristLeft_Bone);

                    }
                    #endregion
                    #region Right Arm
                    if (RightArmAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleRight), BaseModel.ActorData, BaseModel.Offsets.ClavicleRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmRight), BaseModel.ActorData, BaseModel.Offsets.ArmRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PauldronRight), BaseModel.ActorData, BaseModel.Offsets.PauldronRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmRight), BaseModel.ActorData, BaseModel.Offsets.ForearmRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderRight), BaseModel.ActorData, BaseModel.Offsets.ShoulderRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShieldRight), BaseModel.ActorData, BaseModel.Offsets.ShieldRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowRight), BaseModel.ActorData, BaseModel.Offsets.ElbowRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterRight), BaseModel.ActorData, BaseModel.Offsets.CouterRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristRight), BaseModel.ActorData, BaseModel.Offsets.WristRight_Bone);
                    }
                    #endregion
                    #region Clothes
                    if (ClothesAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackALeft), BaseModel.ActorData, BaseModel.Offsets.ClothBackALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackARight), BaseModel.ActorData, BaseModel.Offsets.ClothBackARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontALeft), BaseModel.ActorData, BaseModel.Offsets.ClothFrontALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontARight), BaseModel.ActorData, BaseModel.Offsets.ClothFrontARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideALeft), BaseModel.ActorData, BaseModel.Offsets.ClothSideALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideARight), BaseModel.ActorData, BaseModel.Offsets.ClothSideARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBLeft), BaseModel.ActorData, BaseModel.Offsets.ClothBackBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBRight), BaseModel.ActorData, BaseModel.Offsets.ClothBackBRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBLeft), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBRight), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBLeft), BaseModel.ActorData, BaseModel.Offsets.ClothSideBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBRight), BaseModel.ActorData, BaseModel.Offsets.ClothSideBRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCLeft), BaseModel.ActorData, BaseModel.Offsets.ClothBackCLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCRight), BaseModel.ActorData, BaseModel.Offsets.ClothBackCRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCLeft), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCRight), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCLeft), BaseModel.ActorData, BaseModel.Offsets.ClothSideCLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCRight), BaseModel.ActorData, BaseModel.Offsets.ClothSideCRight_Bone);
                    }
                    #endregion
                    #region Weapons
                    if (WeaponsAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WeaponLeft), BaseModel.ActorData, BaseModel.Offsets.WeaponLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WeaponRight), BaseModel.ActorData, BaseModel.Offsets.WeaponRight_Bone);
                    }
                    #endregion
                    #region Left Hand
                    if (LeftHandAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandLeft), BaseModel.ActorData, BaseModel.Offsets.HandLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexALeft), BaseModel.ActorData, BaseModel.Offsets.IndexALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyALeft), BaseModel.ActorData, BaseModel.Offsets.PinkyALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingALeft), BaseModel.ActorData, BaseModel.Offsets.RingALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleALeft), BaseModel.ActorData, BaseModel.Offsets.MiddleALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbALeft), BaseModel.ActorData, BaseModel.Offsets.ThumbALeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBLeft), BaseModel.ActorData, BaseModel.Offsets.IndexBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBLeft), BaseModel.ActorData, BaseModel.Offsets.PinkyBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBLeft), BaseModel.ActorData, BaseModel.Offsets.RingBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBLeft), BaseModel.ActorData, BaseModel.Offsets.MiddleBLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBLeft), BaseModel.ActorData, BaseModel.Offsets.ThumbBLeft_Bone);
                    }
                    #endregion
                    #region Right Hand
                    if (RightHandAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandRight), BaseModel.ActorData, BaseModel.Offsets.HandRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexARight), BaseModel.ActorData, BaseModel.Offsets.IndexARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyARight), BaseModel.ActorData, BaseModel.Offsets.PinkyARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingARight), BaseModel.ActorData, BaseModel.Offsets.RingARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleARight), BaseModel.ActorData, BaseModel.Offsets.MiddleARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbARight), BaseModel.ActorData, BaseModel.Offsets.ThumbARight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBRight), BaseModel.ActorData, BaseModel.Offsets.IndexBRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBRight), BaseModel.ActorData, BaseModel.Offsets.PinkyBRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBRight), BaseModel.ActorData, BaseModel.Offsets.RingBRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBRight), BaseModel.ActorData, BaseModel.Offsets.MiddleBRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBRight), BaseModel.ActorData, BaseModel.Offsets.ThumbBRight_Bone);
                    }
                    #endregion
                    #region Waist
                    if (WaistAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.Waist), BaseModel.ActorData, BaseModel.Offsets.Waist_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HolsterLeft), BaseModel.ActorData, BaseModel.Offsets.HolsterLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HolsterRight), BaseModel.ActorData, BaseModel.Offsets.HolsterRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SheatheLeft), BaseModel.ActorData, BaseModel.Offsets.SheatheLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SheatheRight), BaseModel.ActorData, BaseModel.Offsets.SheatheRight_Bone);
                        if (BoneLoader.TailA != "null")
                        {
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailA), BaseModel.ActorData, BaseModel.Offsets.TailA_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailB), BaseModel.ActorData, BaseModel.Offsets.TailB_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailC), BaseModel.ActorData, BaseModel.Offsets.TailC_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailD), BaseModel.ActorData, BaseModel.Offsets.TailD_Bone);
                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailE), BaseModel.ActorData, BaseModel.Offsets.TailE_Bone);
                        }
                    }
                    #endregion
                    #region Left Leg
                    if (LeftLegAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegLeft), BaseModel.ActorData, BaseModel.Offsets.LegsLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeLeft), BaseModel.ActorData, BaseModel.Offsets.KneeLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfLeft), BaseModel.ActorData, BaseModel.Offsets.CalfLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynLeft), BaseModel.ActorData, BaseModel.Offsets.PoleynLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootLeft), BaseModel.ActorData, BaseModel.Offsets.FootLeft_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesLeft), BaseModel.ActorData, BaseModel.Offsets.ToesLeft_Bone);
                    }
                    #endregion
                    #region Right Leg
                    if (RightLegAdvLoad.IsChecked == true)
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegRight), BaseModel.ActorData, BaseModel.Offsets.LegsRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeRight), BaseModel.ActorData, BaseModel.Offsets.KneeRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfRight), BaseModel.ActorData, BaseModel.Offsets.CalfRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynRight), BaseModel.ActorData, BaseModel.Offsets.PoleynRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootRight), BaseModel.ActorData, BaseModel.Offsets.FootRight_Bone);
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesRight), BaseModel.ActorData, BaseModel.Offsets.ToesRight_Bone);
                    }
                    #endregion
                    #region Helm
                    if (HelmAdvLoad.IsChecked == true)
                    {
                        byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);
                        if (HelmValue >= 2)
                        {
                            if (BoneLoader.ExMetA != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetA), BaseModel.ActorData, BaseModel.Offsets.ExMetA_Bone);
                            }
                        }
                        if (HelmValue >= 3)
                        {
                            if (BoneLoader.ExMetB != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetB), BaseModel.ActorData, BaseModel.Offsets.ExMetB_Bone);
                            }
                        }
                        if (HelmValue >= 4)
                        {
                            if (BoneLoader.ExMetC != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetC), BaseModel.ActorData, BaseModel.Offsets.ExMetC_Bone);
                            }
                        }
                        if (HelmValue >= 5)
                        {
                            if (BoneLoader.ExMetD != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetD), BaseModel.ActorData, BaseModel.Offsets.ExMetD_Bone);
                            }
                        }
                        if (HelmValue >= 6)
                        {
                            if (BoneLoader.ExMetE != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetE), BaseModel.ActorData, BaseModel.Offsets.ExMetE_Bone);
                            }
                        }
                        if (HelmValue >= 7)
                        {
                            if (BoneLoader.ExMetF != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetF), BaseModel.ActorData, BaseModel.Offsets.ExMetF_Bone);
                            }
                        }
                        if (HelmValue >= 8)
                        {
                            if (BoneLoader.ExMetG != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetG), BaseModel.ActorData, BaseModel.Offsets.ExMetG_Bone);
                            }
                        }
                        if (HelmValue >= 9)
                        {
                            if (BoneLoader.ExMetH != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetH), BaseModel.ActorData, BaseModel.Offsets.ExMetH_Bone);
                            }
                        }
                        if (HelmValue >= 10)
                        {
                            if (BoneLoader.ExMetI != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetI), BaseModel.ActorData, BaseModel.Offsets.ExMetI_Bone);
                            }
                        }
                        if (HelmValue >= 11)
                        {
                            if (BoneLoader.ExMetJ != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetJ), BaseModel.ActorData, BaseModel.Offsets.ExMetJ_Bone);
                            }
                        }
                        if (HelmValue >= 12)
                        {
                            if (BoneLoader.ExMetK != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetK), BaseModel.ActorData, BaseModel.Offsets.ExMetK_Bone);
                            }
                        }
                        if (HelmValue >= 13)
                        {
                            if (BoneLoader.ExMetL != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetL), BaseModel.ActorData, BaseModel.Offsets.ExMetL_Bone);
                            }
                        }
                        if (HelmValue >= 14)
                        {
                            if (BoneLoader.ExMetM != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetM), BaseModel.ActorData, BaseModel.Offsets.ExMetM_Bone);
                            }
                        }
                        if (HelmValue >= 15)
                        {
                            if (BoneLoader.ExMetN != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetN), BaseModel.ActorData, BaseModel.Offsets.ExMetN_Bone);
                            }
                        }
                        if (HelmValue >= 16)
                        {
                            if (BoneLoader.ExMetO != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetO), BaseModel.ActorData, BaseModel.Offsets.ExMetO_Bone);
                            }
                        }
                        if (HelmValue >= 17)
                        {
                            if (BoneLoader.ExMetP != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetP), BaseModel.ActorData, BaseModel.Offsets.ExMetP_Bone);
                            }
                        }
                        if (HelmValue >= 18)
                        {
                            if (BoneLoader.ExMetQ != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetQ), BaseModel.ActorData, BaseModel.Offsets.ExMetQ_Bone);
                            }
                        }
                        if (HelmValue >= 19)
                        {
                            if (BoneLoader.ExMetR != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetR), BaseModel.ActorData, BaseModel.Offsets.ExMetR_Bone);
                            }
                        }
                    }
                    #endregion
                    #region Top
                    if (TopAdvLoad.IsChecked == true)
                    {
                        byte TopValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);

                        if (TopValue >= 2)
                        {
                            if (BoneLoader.ExTopA != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopA), BaseModel.ActorData, BaseModel.Offsets.ExTopA_Bone);
                            }
                        }
                        if (TopValue >= 3)
                        {
                            if (BoneLoader.ExTopB != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopB), BaseModel.ActorData, BaseModel.Offsets.ExTopB_Bone);
                            }
                        }
                        if (TopValue >= 4)
                        {
                            if (BoneLoader.ExTopC != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopC), BaseModel.ActorData, BaseModel.Offsets.ExTopC_Bone);
                            }
                        }
                        if (TopValue >= 5)
                        {
                            if (BoneLoader.ExTopD != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopD), BaseModel.ActorData, BaseModel.Offsets.ExTopD_Bone);
                            }
                        }
                        if (TopValue >= 6)
                        {
                            if (BoneLoader.ExTopE != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopE), BaseModel.ActorData, BaseModel.Offsets.ExTopE_Bone);
                            }
                        }
                        if (TopValue >= 7)
                        {
                            if (BoneLoader.ExTopF != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopF), BaseModel.ActorData, BaseModel.Offsets.ExTopF_Bone);
                            }
                        }
                        if (TopValue >= 8)
                        {
                            if (BoneLoader.ExTopG != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopG), BaseModel.ActorData, BaseModel.Offsets.ExTopG_Bone);
                            }
                        }
                        if (TopValue >= 9)
                        {
                            if (BoneLoader.ExTopH != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopH), BaseModel.ActorData, BaseModel.Offsets.ExTopH_Bone);
                            }
                        }
                        if (TopValue >= 10)
                        {
                            if (BoneLoader.ExTopI != "null")
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopI), BaseModel.ActorData, BaseModel.Offsets.ExTopI_Bone);
                            }
                        }
                    }
                    #endregion

                    #region Scale bones
                    if (BoneLoader.CMPVersion == "2.0")
                    {
                        if (ScaleSaveToggle.IsChecked == true)
                        {
                            #region Head
                            if (HeadAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HeadSize), BaseModel.ActorData, BaseModel.Offsets.Head_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarLeftSize), BaseModel.ActorData, BaseModel.Offsets.EarLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EarRightSize), BaseModel.ActorData, BaseModel.Offsets.EarRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.JawSize), BaseModel.ActorData, BaseModel.Offsets.Jaw_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidLowerRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyeLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyeRightSize), BaseModel.ActorData, BaseModel.Offsets.EyeRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.NoseSize), BaseModel.ActorData, BaseModel.Offsets.Nose_Size);

                                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                                {
                                    if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerASize), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                    }
                                    else if (BoneLoader.Race == "07")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                    }
                                    else if (BoneLoader.Race == "08")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                        //   MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerASize), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                    }
                                }
                                else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                                {
                                    if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Size);
                                    }
                                    else if (BoneLoader.Race == "07")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpperSize), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Size);
                                    }
                                    else if (BoneLoader.Race == "08")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersLeftSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothWhiskersRightSize), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothJawUpperSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                    }
                                }
                                else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                                {
                                    if (BoneLoader.Race == "01" || BoneLoader.Race == "02" || BoneLoader.Race == "03" || BoneLoader.Race == "04" || BoneLoader.Race == "05" || BoneLoader.Race == "06")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                    }
                                    else if (BoneLoader.Race == "07")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothBrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipUpperSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                    }
                                    else if (BoneLoader.Race == "08")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekLeftSize), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CheekRightSize), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsLeftSize), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipsRightSize), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyebrowRightSize), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BridgeSize), BaseModel.ActorData, BaseModel.Offsets.Bridge_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowLeftSize), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BrowRightSize), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LipUpperASize), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.EyelidUpperLeftSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothEyelidUpperRightSize), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ALeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ARight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ALeft_Size);
                                    }
                                }
                                if (BoneLoader.HrothLipLower != "null" || BoneLoader.VieraEar02ARight != "null")
                                {
                                    if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                                    {
                                        if (BoneLoader.Race == "07")
                                        {
                                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HrothLipLowerSize), BaseModel.ActorData, BaseModel.Offsets.HrothLipLower_Size);
                                        }
                                    }
                                    if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                                    {
                                        if (BoneLoader.Race == "08")
                                        {
                                            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ARight_Size);
                                        }
                                    }
                                }
                                if (BoneLoader.VieraEar03ALeft != "null")
                                {
                                    if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerASize), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Size);
                                    }
                                    if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ALeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ARight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ALeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ALeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04ARightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ARight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerASize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipUpperBSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar01BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar02BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar03BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BLeftSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BLeft_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraEar04BRightSize), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BRight_Size);
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.VieraLipLowerBSize), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Size);
                                    }
                                }
                            }
                            #endregion

                            #region Hair
                            if (HairAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairASize), BaseModel.ActorData, BaseModel.Offsets.HairA_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairBSize), BaseModel.ActorData, BaseModel.Offsets.HairB_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontLeftSize), BaseModel.ActorData, BaseModel.Offsets.HairFrontLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HairFrontRightSize), BaseModel.ActorData, BaseModel.Offsets.HairFrontRight_Size);
                                byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
                                if (HairValue >= 2)
                                {
                                    if (BoneLoader.ExHairA != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairASize), BaseModel.ActorData, BaseModel.Offsets.ExHairA_Size);
                                    }
                                }
                                if (HairValue >= 3)
                                {
                                    if (BoneLoader.ExHairB != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairBSize), BaseModel.ActorData, BaseModel.Offsets.ExHairB_Size);
                                    }
                                }
                                if (HairValue >= 4)
                                {
                                    if (BoneLoader.ExHairC != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairCSize), BaseModel.ActorData, BaseModel.Offsets.ExHairC_Size);
                                    }
                                }
                                if (HairValue >= 5)
                                {
                                    if (BoneLoader.ExHairD != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairDSize), BaseModel.ActorData, BaseModel.Offsets.ExHairD_Size);
                                    }
                                }
                                if (HairValue >= 6)
                                {
                                    if (BoneLoader.ExHairE != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairESize), BaseModel.ActorData, BaseModel.Offsets.ExHairE_Size);
                                    }
                                }
                                if (HairValue >= 7)
                                {
                                    if (BoneLoader.ExHairF != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairFSize), BaseModel.ActorData, BaseModel.Offsets.ExHairF_Size);
                                    }
                                }
                                if (HairValue >= 8)
                                {
                                    if (BoneLoader.ExHairG != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairGSize), BaseModel.ActorData, BaseModel.Offsets.ExHairG_Size);
                                    }
                                }
                                if (HairValue >= 9)
                                {
                                    if (BoneLoader.ExHairH != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairHSize), BaseModel.ActorData, BaseModel.Offsets.ExHairH_Size);
                                    }
                                }
                                if (HairValue >= 10)
                                {
                                    if (BoneLoader.ExHairI != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairISize), BaseModel.ActorData, BaseModel.Offsets.ExHairI_Size);
                                    }
                                }
                                if (HairValue >= 11)
                                {
                                    if (BoneLoader.ExHairJ != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairJSize), BaseModel.ActorData, BaseModel.Offsets.ExHairJ_Size);
                                    }
                                }
                                if (HairValue >= 12)
                                {
                                    if (BoneLoader.ExHairK != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairKSize), BaseModel.ActorData, BaseModel.Offsets.ExHairK_Size);
                                    }
                                }
                                if (HairValue >= 13)
                                {
                                    if (BoneLoader.ExHairL != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExHairLSize), BaseModel.ActorData, BaseModel.Offsets.ExHairL_Size);
                                    }
                                }
                            }
                            #endregion

                            #region Body
                            if (BodyAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineASize), BaseModel.ActorData, BaseModel.Offsets.SpineA_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineBSize), BaseModel.ActorData, BaseModel.Offsets.SpineB_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.SpineCSize), BaseModel.ActorData, BaseModel.Offsets.SpineC_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastLeftSize), BaseModel.ActorData, BaseModel.Offsets.BreastLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.BreastRightSize), BaseModel.ActorData, BaseModel.Offsets.BreastRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.NeckSize), BaseModel.ActorData, BaseModel.Offsets.Neck_Size);
                            }
                            #endregion

                            #region LeftArm
                            if (LeftArmAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClavicleLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmLeftSize), BaseModel.ActorData, BaseModel.Offsets.ArmLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmLeftSize), BaseModel.ActorData, BaseModel.Offsets.ForearmLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderLeftSize), BaseModel.ActorData, BaseModel.Offsets.ShoulderLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowLeftSize), BaseModel.ActorData, BaseModel.Offsets.ElbowLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterLeftSize), BaseModel.ActorData, BaseModel.Offsets.CouterLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristLeftSize), BaseModel.ActorData, BaseModel.Offsets.WristLeft_Size);
                            }
                            #endregion

                            #region RightArm
                            if (RightArmAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClavicleRightSize), BaseModel.ActorData, BaseModel.Offsets.ClavicleRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ArmRightSize), BaseModel.ActorData, BaseModel.Offsets.ArmRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ForearmRightSize), BaseModel.ActorData, BaseModel.Offsets.ForearmRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ShoulderRightSize), BaseModel.ActorData, BaseModel.Offsets.ShoulderRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ElbowRightSize), BaseModel.ActorData, BaseModel.Offsets.ElbowRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CouterRightSize), BaseModel.ActorData, BaseModel.Offsets.CouterRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WristRightSize), BaseModel.ActorData, BaseModel.Offsets.WristRight_Size);
                            }
                            #endregion

                            #region Clothes
                            if (ClothesAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackALeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackARightSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontALeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontARightSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideALeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideARightSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackBLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackBRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackBRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontBRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideBLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideBRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideBRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackCLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothBackCRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothBackCRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothFrontCRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCLeftSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideCLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ClothSideCRightSize), BaseModel.ActorData, BaseModel.Offsets.ClothSideCRight_Size);
                            }
                            #endregion

                            #region LeftHand
                            if (LeftHandAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandLeftSize), BaseModel.ActorData, BaseModel.Offsets.HandLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexALeftSize), BaseModel.ActorData, BaseModel.Offsets.IndexALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyALeftSize), BaseModel.ActorData, BaseModel.Offsets.PinkyALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingALeftSize), BaseModel.ActorData, BaseModel.Offsets.RingALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleALeftSize), BaseModel.ActorData, BaseModel.Offsets.MiddleALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbALeftSize), BaseModel.ActorData, BaseModel.Offsets.ThumbALeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBLeftSize), BaseModel.ActorData, BaseModel.Offsets.IndexBLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBLeftSize), BaseModel.ActorData, BaseModel.Offsets.PinkyBLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBLeftSize), BaseModel.ActorData, BaseModel.Offsets.RingBLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBLeftSize), BaseModel.ActorData, BaseModel.Offsets.MiddleBLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBLeftSize), BaseModel.ActorData, BaseModel.Offsets.ThumbBLeft_Size);
                            }
                            #endregion

                            #region RightHand
                            if (RightHandAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.HandRightSize), BaseModel.ActorData, BaseModel.Offsets.HandRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexARightSize), BaseModel.ActorData, BaseModel.Offsets.IndexARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyARightSize), BaseModel.ActorData, BaseModel.Offsets.PinkyARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingARightSize), BaseModel.ActorData, BaseModel.Offsets.RingARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleARightSize), BaseModel.ActorData, BaseModel.Offsets.MiddleARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbARightSize), BaseModel.ActorData, BaseModel.Offsets.ThumbARight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.IndexBRightSize), BaseModel.ActorData, BaseModel.Offsets.IndexBRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PinkyBRightSize), BaseModel.ActorData, BaseModel.Offsets.PinkyBRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.RingBRightSize), BaseModel.ActorData, BaseModel.Offsets.RingBRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.MiddleBRightSize), BaseModel.ActorData, BaseModel.Offsets.MiddleBRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ThumbBRightSize), BaseModel.ActorData, BaseModel.Offsets.ThumbBRight_Size);
                            }
                            #endregion

                            #region Waist
                            if (WaistAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.WaistSize), BaseModel.ActorData, BaseModel.Offsets.Waist_Size);
                                if (BoneLoader.TailA != "null")
                                {
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailASize), BaseModel.ActorData, BaseModel.Offsets.TailA_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailBSize), BaseModel.ActorData, BaseModel.Offsets.TailB_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailCSize), BaseModel.ActorData, BaseModel.Offsets.TailC_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailDSize), BaseModel.ActorData, BaseModel.Offsets.TailD_Size);
                                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.TailESize), BaseModel.ActorData, BaseModel.Offsets.TailE_Size);
                                }
                            }
                            #endregion

                            #region LeftLeg
                            if (LeftLegAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegLeftSize), BaseModel.ActorData, BaseModel.Offsets.LegsLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeLeftSize), BaseModel.ActorData, BaseModel.Offsets.KneeLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfLeftSize), BaseModel.ActorData, BaseModel.Offsets.CalfLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynLeftSize), BaseModel.ActorData, BaseModel.Offsets.PoleynLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootLeftSize), BaseModel.ActorData, BaseModel.Offsets.FootLeft_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesLeftSize), BaseModel.ActorData, BaseModel.Offsets.ToesLeft_Size);
                            }
                            #endregion

                            #region RightLeg
                            if (RightLegAdvLoad.IsChecked == true)
                            {
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.LegRightSize), BaseModel.ActorData, BaseModel.Offsets.LegsRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.KneeRightSize), BaseModel.ActorData, BaseModel.Offsets.KneeRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.CalfRightSize), BaseModel.ActorData, BaseModel.Offsets.CalfRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.PoleynRightSize), BaseModel.ActorData, BaseModel.Offsets.PoleynRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.FootRightSize), BaseModel.ActorData, BaseModel.Offsets.FootRight_Size);
                                MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ToesRightSize), BaseModel.ActorData, BaseModel.Offsets.ToesRight_Size);
                            }
                            #endregion

                            #region Helm
                            if (HelmAdvLoad.IsChecked == true)
                            {
                                byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);

                                if (HelmValue >= 2)
                                {
                                    if (BoneLoader.ExMetA != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetASize), BaseModel.ActorData, BaseModel.Offsets.ExMetA_Size);
                                    }
                                }
                                if (HelmValue >= 3)
                                {
                                    if (BoneLoader.ExMetB != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetBSize), BaseModel.ActorData, BaseModel.Offsets.ExMetB_Size);
                                    }
                                }
                                if (HelmValue >= 4)
                                {
                                    if (BoneLoader.ExMetC != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetCSize), BaseModel.ActorData, BaseModel.Offsets.ExMetC_Size);
                                    }
                                }
                                if (HelmValue >= 5)
                                {
                                    if (BoneLoader.ExMetD != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetDSize), BaseModel.ActorData, BaseModel.Offsets.ExMetD_Size);
                                    }
                                }
                                if (HelmValue >= 6)
                                {
                                    if (BoneLoader.ExMetE != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetESize), BaseModel.ActorData, BaseModel.Offsets.ExMetE_Size);
                                    }
                                }
                                if (HelmValue >= 7)
                                {
                                    if (BoneLoader.ExMetF != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetFSize), BaseModel.ActorData, BaseModel.Offsets.ExMetF_Size);
                                    }
                                }
                                if (HelmValue >= 8)
                                {
                                    if (BoneLoader.ExMetG != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetGSize), BaseModel.ActorData, BaseModel.Offsets.ExMetG_Size);
                                    }
                                }
                                if (HelmValue >= 9)
                                {
                                    if (BoneLoader.ExMetH != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetHSize), BaseModel.ActorData, BaseModel.Offsets.ExMetH_Size);
                                    }
                                }
                                if (HelmValue >= 10)
                                {
                                    if (BoneLoader.ExMetI != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetISize), BaseModel.ActorData, BaseModel.Offsets.ExMetI_Size);
                                    }
                                }
                                if (HelmValue >= 11)
                                {
                                    if (BoneLoader.ExMetJ != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetJSize), BaseModel.ActorData, BaseModel.Offsets.ExMetJ_Size);
                                    }
                                }
                                if (HelmValue >= 12)
                                {
                                    if (BoneLoader.ExMetK != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetKSize), BaseModel.ActorData, BaseModel.Offsets.ExMetK_Size);
                                    }
                                }
                                if (HelmValue >= 13)
                                {
                                    if (BoneLoader.ExMetL != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetLSize), BaseModel.ActorData, BaseModel.Offsets.ExMetL_Size);
                                    }
                                }
                                if (HelmValue >= 14)
                                {
                                    if (BoneLoader.ExMetM != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetMSize), BaseModel.ActorData, BaseModel.Offsets.ExMetM_Size);
                                    }
                                }
                                if (HelmValue >= 15)
                                {
                                    if (BoneLoader.ExMetN != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetNSize), BaseModel.ActorData, BaseModel.Offsets.ExMetN_Size);
                                    }
                                }
                                if (HelmValue >= 16)
                                {
                                    if (BoneLoader.ExMetO != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetOSize), BaseModel.ActorData, BaseModel.Offsets.ExMetO_Size);
                                    }
                                }
                                if (HelmValue >= 17)
                                {
                                    if (BoneLoader.ExMetP != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetPSize), BaseModel.ActorData, BaseModel.Offsets.ExMetP_Size);
                                    }
                                }
                                if (HelmValue >= 18)
                                {
                                    if (BoneLoader.ExMetQ != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetQSize), BaseModel.ActorData, BaseModel.Offsets.ExMetQ_Size);
                                    }
                                }
                                if (HelmValue >= 19)
                                {
                                    if (BoneLoader.ExMetR != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExMetRSize), BaseModel.ActorData, BaseModel.Offsets.ExMetR_Size);
                                    }
                                }
                            }
                            #endregion

                            #region Top
                            if (TopAdvLoad.IsChecked == true)
                            {
                                byte TopValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);

                                if (TopValue >= 2)
                                {
                                    if (BoneLoader.ExTopA != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopASize), BaseModel.ActorData, BaseModel.Offsets.ExTopA_Size);
                                    }
                                }
                                if (TopValue >= 3)
                                {
                                    if (BoneLoader.ExTopB != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopBSize), BaseModel.ActorData, BaseModel.Offsets.ExTopB_Size);
                                    }
                                }
                                if (TopValue >= 4)
                                {
                                    if (BoneLoader.ExTopC != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopCSize), BaseModel.ActorData, BaseModel.Offsets.ExTopC_Size);
                                    }
                                }
                                if (TopValue >= 5)
                                {
                                    if (BoneLoader.ExTopD != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopDSize), BaseModel.ActorData, BaseModel.Offsets.ExTopD_Size);
                                    }
                                }
                                if (TopValue >= 6)
                                {
                                    if (BoneLoader.ExTopE != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopESize), BaseModel.ActorData, BaseModel.Offsets.ExTopE_Size);
                                    }
                                }
                                if (TopValue >= 7)
                                {
                                    if (BoneLoader.ExTopF != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopFSize), BaseModel.ActorData, BaseModel.Offsets.ExTopF_Size);
                                    }
                                }
                                if (TopValue >= 8)
                                {
                                    if (BoneLoader.ExTopG != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopGSize), BaseModel.ActorData, BaseModel.Offsets.ExTopG_Size);
                                    }
                                }
                                if (TopValue >= 9)
                                {
                                    if (BoneLoader.ExTopH != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopHSize), BaseModel.ActorData, BaseModel.Offsets.ExTopH_Size);
                                    }
                                }
                                if (TopValue >= 10)
                                {
                                    if (BoneLoader.ExTopI != "null")
                                    {
                                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(BoneLoader.ExTopISize), BaseModel.ActorData, BaseModel.Offsets.ExTopI_Size);
                                    }
                                }
                            }
                        }
                        #endregion
                    }

                    #endregion


                }
            }
            else return;
        }
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            HeadAdvLoad.IsChecked = true;
            HairAdvLoad.IsChecked = true;
            EarringsAdvLoad.IsChecked = true;
            BodyAdvLoad.IsChecked = true;
            LeftArmAdvLoad.IsChecked = true;
            RightArmAdvLoad.IsChecked = true;
            ClothesAdvLoad.IsChecked = true;
            WeaponsAdvLoad.IsChecked = true;
            LeftHandAdvLoad.IsChecked = true;
            RightHandAdvLoad.IsChecked = true;
            WaistAdvLoad.IsChecked = true;
            LeftLegAdvLoad.IsChecked = true;
            RightLegAdvLoad.IsChecked = true;
            HelmAdvLoad.IsChecked = true;
            TopAdvLoad.IsChecked = true;
        }
        private void SelectNone_Click(object sender, RoutedEventArgs e)
        {
            HeadAdvLoad.IsChecked = false;
            HairAdvLoad.IsChecked = false;
            EarringsAdvLoad.IsChecked = false;
            BodyAdvLoad.IsChecked = false;
            LeftArmAdvLoad.IsChecked = false;
            RightArmAdvLoad.IsChecked = false;
            ClothesAdvLoad.IsChecked = false;
            WeaponsAdvLoad.IsChecked = false;
            LeftHandAdvLoad.IsChecked = false;
            RightHandAdvLoad.IsChecked = false;
            WaistAdvLoad.IsChecked = false;
            LeftLegAdvLoad.IsChecked = false;
            RightLegAdvLoad.IsChecked = false;
            HelmAdvLoad.IsChecked = false;
            TopAdvLoad.IsChecked = false;
        }

        #region Savestate\Loadstate Head
        private void SavestateHead01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateHead01.IsEnabled = true;
            else return;
            HeadSaved01 = true;
            Race_Sav01 = ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value.ToString("X2");

            Head_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Head_Bone));
            EarLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarLeft_Bone));
            EarRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarRight_Bone));
            RootHead_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RootHead_Bone));
            Jaw_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Jaw_Bone));
            EyelidLowerLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerLeft_Bone));
            EyelidLowerRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerRight_Bone));
            EyeLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeLeft_Bone));
            EyeRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeRight_Bone));
            Nose_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Nose_Bone));
            CheekLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekLeft_Bone));
            HrothWhiskersLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersLeft_Bone));
            CheekRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekRight_Bone));
            HrothWhiskersRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersRight_Bone));
            LipsLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsLeft_Bone));
            HrothEyebrowLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowLeft_Bone));
            LipsRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsRight_Bone));
            HrothEyebrowRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowRight_Bone));
            EyebrowLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowLeft_Bone));
            HrothBridge_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBridge_Bone));
            EyebrowRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowRight_Bone));
            HrothBrowLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowLeft_Bone));
            Bridge_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Bridge_Bone));
            HrothBrowRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowRight_Bone));
            BrowLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowLeft_Bone));
            HrothJawUpper_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothJawUpper_Bone));
            BrowRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowRight_Bone));
            HrothLipUpper_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpper_Bone));
            LipUpperA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperA_Bone));
            HrothEyelidUpperLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperLeft_Bone));
            EyelidUpperLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperLeft_Bone));
            HrothEyelidUpperRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperRight_Bone));
            EyelidUpperRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperRight_Bone));
            HrothLipsLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsLeft_Bone));
            LipLowerA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerA_Bone));
            HrothLipsRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsRight_Bone));
            VieraEar01ALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ALeft_Bone));
            LipUpperB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperB_Bone));
            HrothLipUpperLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperLeft_Bone));
            VieraEar01ARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ARight_Bone));
            LipLowerB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerB_Bone));
            HrothLipUpperRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperRight_Bone));
            VieraEar02ALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ALeft_Bone));
            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
            {
                HrothLipLower_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipLower_Bone));
                VieraEar02ARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ARight_Bone));
            }
            else
            {
                HrothLipLower_Sav01 = "null";
                VieraEar02ARight_Sav01 = "null";
            }
            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
            {
                VieraEar03ALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ALeft_Bone));
                VieraEar03ARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ARight_Bone));
                VieraEar04ALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ALeft_Bone));
                VieraEar04ARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ARight_Bone));
                VieraLipLowerA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerA_Bone));
                VieraLipUpperB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipUpperB_Bone));
                VieraEar01BLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BLeft_Bone));
                VieraEar01BRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BRight_Bone));
                VieraEar02BLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BLeft_Bone));
                VieraEar02BRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Bone));
                VieraEar03BLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03BLeft_Bone));
                VieraEar03BRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Bone));
                VieraEar04BLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BLeft_Bone));
                VieraEar04BRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BRight_Bone));
                VieraLipLowerB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerB_Bone));
            }
            else
            {
                VieraEar03ALeft_Sav01 = "null";
                VieraEar03ARight_Sav01 = "null";
                VieraEar04ALeft_Sav01 = "null";
                VieraEar04ARight_Sav01 = "null";
                VieraLipLowerA_Sav01 = "null";
                VieraLipUpperB_Sav01 = "null";
                VieraEar01BLeft_Sav01 = "null";
                VieraEar01BRight_Sav01 = "null";
                VieraEar02BLeft_Sav01 = "null";
                VieraEar02BRight_Sav01 = "null";
                VieraEar03BLeft_Sav01 = "null";
                VieraEar03BRight_Sav01 = "null";
                VieraEar04BLeft_Sav01 = "null";
                VieraEar04BRight_Sav01 = "null";
                VieraLipLowerB_Sav01 = "null";
            }
        }

        private void SavestateHead02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateHead02.IsEnabled = true;
            else return;
            HeadSaved02 = true;
            Race_Sav02 = ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value.ToString("X2");

            Head_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Head_Bone));
            EarLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarLeft_Bone));
            EarRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarRight_Bone));
            RootHead_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RootHead_Bone));
            Jaw_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Jaw_Bone));
            EyelidLowerLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerLeft_Bone));
            EyelidLowerRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidLowerRight_Bone));
            EyeLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeLeft_Bone));
            EyeRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyeRight_Bone));
            Nose_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Nose_Bone));
            CheekLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekLeft_Bone));
            HrothWhiskersLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersLeft_Bone));
            CheekRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CheekRight_Bone));
            HrothWhiskersRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothWhiskersRight_Bone));
            LipsLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsLeft_Bone));
            HrothEyebrowLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowLeft_Bone));
            LipsRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipsRight_Bone));
            HrothEyebrowRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyebrowRight_Bone));
            EyebrowLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowLeft_Bone));
            HrothBridge_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBridge_Bone));
            EyebrowRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyebrowRight_Bone));
            HrothBrowLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowLeft_Bone));
            Bridge_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Bridge_Bone));
            HrothBrowRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothBrowRight_Bone));
            BrowLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowLeft_Bone));
            HrothJawUpper_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothJawUpper_Bone));
            BrowRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BrowRight_Bone));
            HrothLipUpper_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpper_Bone));
            LipUpperA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperA_Bone));
            HrothEyelidUpperLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperLeft_Bone));
            EyelidUpperLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperLeft_Bone));
            HrothEyelidUpperRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothEyelidUpperRight_Bone));
            EyelidUpperRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EyelidUpperRight_Bone));
            HrothLipsLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsLeft_Bone));
            LipLowerA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerA_Bone));
            HrothLipsRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipsRight_Bone));
            VieraEar01ALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ALeft_Bone));
            LipUpperB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipUpperB_Bone));
            HrothLipUpperLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperLeft_Bone));
            VieraEar01ARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01ARight_Bone));
            LipLowerB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LipLowerB_Bone));
            HrothLipUpperRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipUpperRight_Bone));
            VieraEar02ALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ALeft_Bone));
            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
            {
                HrothLipLower_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HrothLipLower_Bone));
                VieraEar02ARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02ARight_Bone));
            }
            else
            {
                HrothLipLower_Sav02 = "null";
                VieraEar02ARight_Sav02 = "null";
            }
            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
            {
                VieraEar03ALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ALeft_Bone));
                VieraEar03ARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03ARight_Bone));
                VieraEar04ALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ALeft_Bone));
                VieraEar04ARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04ARight_Bone));
                VieraLipLowerA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerA_Bone));
                VieraLipUpperB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipUpperB_Bone));
                VieraEar01BLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BLeft_Bone));
                VieraEar01BRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar01BRight_Bone));
                VieraEar02BLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BLeft_Bone));
                VieraEar02BRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Bone));
                VieraEar03BLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar03BLeft_Bone));
                VieraEar03BRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar02BRight_Bone));
                VieraEar04BLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BLeft_Bone));
                VieraEar04BRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraEar04BRight_Bone));
                VieraLipLowerB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.VieraLipLowerB_Bone));
            }
            else
            {
                VieraEar03ALeft_Sav02 = "null";
                VieraEar03ARight_Sav02 = "null";
                VieraEar04ALeft_Sav02 = "null";
                VieraEar04ARight_Sav02 = "null";
                VieraLipLowerA_Sav02 = "null";
                VieraLipUpperB_Sav02 = "null";
                VieraEar01BLeft_Sav02 = "null";
                VieraEar01BRight_Sav02 = "null";
                VieraEar02BLeft_Sav02 = "null";
                VieraEar02BRight_Sav02 = "null";
                VieraEar03BLeft_Sav02 = "null";
                VieraEar03BRight_Sav02 = "null";
                VieraEar04BLeft_Sav02 = "null";
                VieraEar04BRight_Sav02 = "null";
                VieraLipLowerB_Sav02 = "null";
            }
        }

        private void LoadstateHead01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Head_Sav01), BaseModel.ActorData, BaseModel.Offsets.Head_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EarLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EarRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Jaw_Sav01), BaseModel.ActorData, BaseModel.Offsets.Jaw_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidLowerLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidLowerRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyeLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyeLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyeRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyeRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Nose_Sav01), BaseModel.ActorData, BaseModel.Offsets.Nose_Bone);

            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
            {
                if (Race_Sav01 == "01" || Race_Sav01 == "02" || Race_Sav01 == "03" || Race_Sav01 == "04" || Race_Sav01 == "05" || Race_Sav01 == "06")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperB_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipLowerA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipLowerB_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav01 == "07")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpper_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothJawUpper_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav01 == "08")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerB_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
            }
            else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
            {
                if (Race_Sav01 == "01" || Race_Sav01 == "02" || Race_Sav01 == "03" || Race_Sav01 == "04" || Race_Sav01 == "05" || Race_Sav01 == "06")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperB_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                }
                else if (Race_Sav01 == "07")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothWhiskersLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothWhiskersRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothJawUpper_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpper_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                }
                else if (Race_Sav01 == "08")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                }
            }
            else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
            {
                if (Race_Sav01 == "01" || Race_Sav01 == "02" || Race_Sav01 == "03" || Race_Sav01 == "04" || Race_Sav01 == "05" || Race_Sav01 == "06")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02ALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav01 == "07")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpper_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav01 == "08")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav01), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02ALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ALeft_Bone);
                }
            }
            if (HrothLipLower_Sav01 != "null" || VieraEar02ARight_Sav01 != "null")
            {
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                {
                    if (Race_Sav01 == "07")
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipLower_Sav01), BaseModel.ActorData, BaseModel.Offsets.HrothLipLower_Bone);
                    }
                }
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                {
                    if (Race_Sav01 == "08")
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02ARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ARight_Bone);
                    }
                }
            }
            if (VieraEar03ALeft_Sav01 != "null")
            {
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerA_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerB_Sav01), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                }
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03ALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03ARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04ALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04ARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerA_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01BLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01BRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02BLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02BRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03BLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03BRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04BLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04BRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerB_Sav01), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                }
            }
        }

        private void LoadstateHead02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Head_Sav02), BaseModel.ActorData, BaseModel.Offsets.Head_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EarLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EarRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Jaw_Sav02), BaseModel.ActorData, BaseModel.Offsets.Jaw_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidLowerLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidLowerRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidLowerRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyeLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyeLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyeRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyeRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Nose_Sav02), BaseModel.ActorData, BaseModel.Offsets.Nose_Bone);

            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
            {
                if (Race_Sav02 == "01" || Race_Sav02 == "02" || Race_Sav02 == "03" || Race_Sav02 == "04" || Race_Sav02 == "05" || Race_Sav02 == "06")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperB_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipLowerA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipLowerB_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav02 == "07")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpper_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothJawUpper_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav02 == "08")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerB_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
            }
            else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
            {
                if (Race_Sav02 == "01" || Race_Sav02 == "02" || Race_Sav02 == "03" || Race_Sav02 == "04" || Race_Sav02 == "05" || Race_Sav02 == "06")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperB_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                }
                else if (Race_Sav02 == "07")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothWhiskersLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothWhiskersRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothWhiskersRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothEyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothBridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothBrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothBrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothJawUpper_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothJawUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpper_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpper_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothEyelidUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipUpperRight_Bone);
                }
                else if (Race_Sav02 == "08")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                }
            }
            else if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
            {
                if (Race_Sav02 == "01" || Race_Sav02 == "02" || Race_Sav02 == "03" || Race_Sav02 == "04" || Race_Sav02 == "05" || Race_Sav02 == "06")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02ALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav02 == "07")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothBrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipUpper_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothEyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                }
                else if (Race_Sav02 == "08")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(CheekRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CheekRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipsRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipsRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyebrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyebrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(Bridge_Sav02), BaseModel.ActorData, BaseModel.Offsets.Bridge_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(BrowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BrowRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(LipUpperA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(EyelidUpperRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EyelidUpperRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01ARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar01ARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02ALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ALeft_Bone);
                }
            }
            if (HrothLipLower_Sav02 != "null" || VieraEar02ARight_Sav02 != "null")
            {
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
                {
                    if (Race_Sav02 == "07")
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(HrothLipLower_Sav02), BaseModel.ActorData, BaseModel.Offsets.HrothLipLower_Bone);
                    }
                }
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                {
                    if (Race_Sav02 == "08")
                    {
                        MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02ARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar02ARight_Bone);
                    }
                }
            }
            if (VieraEar03ALeft_Sav02 != "null")
            {
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value < 7)
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerA_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerB_Sav02), BaseModel.ActorData, BaseModel.Offsets.LipLowerB_Bone);
                }
                if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 8)
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03ALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03ARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar03ARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04ALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ALeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04ARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar04ARight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerA_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerA_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipUpperB_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraLipUpperB_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01BLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar01BRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar01BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02BLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar02BRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar02BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03BLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar03BRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar03BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04BLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BLeft_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraEar04BRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraEar04BRight_Bone);
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(VieraLipLowerB_Sav02), BaseModel.ActorData, BaseModel.Offsets.VieraLipLowerB_Bone);
                }
            }
        }
        #endregion

        #region Savestate\Loadstate Hair
        private void SavestateHair01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateHair01.IsEnabled = true;
            else return;
            HairSaved01 = true;

            HairA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairA_Bone));
            HairFrontLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontLeft_Bone));
            HairFrontRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontRight_Bone));
            HairB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairB_Bone));
            byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
            if (HairValue >= 1)
            {
                ExRootHair_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootHair_Bone));
            }
            if (HairValue >= 2)
            {
                ExHairA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairA_Bone));
            }
            else
            {
                ExHairA_Sav01 = "null";
            }
            if (HairValue >= 3)
            {
                ExHairB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairB_Bone));
            }
            else
            {
                ExHairB_Sav01 = "null";
            }
            if (HairValue >= 4)
            {
                ExHairC_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairC_Bone));
            }
            else
            {
                ExHairC_Sav01 = "null";
            }
            if (HairValue >= 5)
            {
                ExHairD_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairD_Bone));
            }
            else
            {
                ExHairD_Sav01 = "null";
            }
            if (HairValue >= 6)
            {
                ExHairE_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairE_Bone));
            }
            else
            {
                ExHairE_Sav01 = "null";
            }
            if (HairValue >= 7)
            {
                ExHairF_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairF_Bone));
            }
            else
            {
                ExHairF_Sav01 = "null";
            }
            if (HairValue >= 8)
            {
                ExHairG_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairG_Bone));
            }
            else
            {
                ExHairG_Sav01 = "null";
            }
            if (HairValue >= 9)
            {
                ExHairH_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairH_Bone));
            }
            else
            {
                ExHairH_Sav01 = "null";
            }
            if (HairValue >= 10)
            {
                ExHairI_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairI_Bone));
            }
            else
            {
                ExHairI_Sav01 = "null";
            }
            if (HairValue >= 11)
            {
                ExHairJ_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairJ_Bone));
            }
            else
            {
                ExHairJ_Sav01 = "null";
            }
            if (HairValue >= 12)
            {
                ExHairK_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairK_Bone));
            }
            else
            {
                ExHairK_Sav01 = "null";
            }
            if (HairValue >= 13)
            {
                ExHairL_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairL_Bone));
            }
            else
            {
                ExHairL_Sav01 = "null";
            }
            if (ExRootHair_Sav01 == null)
            {
                ExRootHair_Sav01 = "null";
                ExHairA_Sav01 = "null";
                ExHairB_Sav01 = "null";
                ExHairC_Sav01 = "null";
                ExHairD_Sav01 = "null";
                ExHairE_Sav01 = "null";
                ExHairF_Sav01 = "null";
                ExHairG_Sav01 = "null";
                ExHairH_Sav01 = "null";
                ExHairI_Sav01 = "null";
                ExHairJ_Sav01 = "null";
                ExHairK_Sav01 = "null";
                ExHairL_Sav01 = "null";
            }
        }

        private void SavestateHair02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateHair02.IsEnabled = true;
            else return;
            HairSaved02 = true;

            HairA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairA_Bone));
            HairFrontLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontLeft_Bone));
            HairFrontRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairFrontRight_Bone));
            HairB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HairB_Bone));
            byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
            if (HairValue >= 1)
            {
                ExRootHair_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootHair_Bone));
            }
            if (HairValue >= 2)
            {
                ExHairA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairA_Bone));
            }
            else
            {
                ExHairA_Sav02 = "null";
            }
            if (HairValue >= 3)
            {
                ExHairB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairB_Bone));
            }
            else
            {
                ExHairB_Sav02 = "null";
            }
            if (HairValue >= 4)
            {
                ExHairC_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairC_Bone));
            }
            else
            {
                ExHairC_Sav02 = "null";
            }
            if (HairValue >= 5)
            {
                ExHairD_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairD_Bone));
            }
            else
            {
                ExHairD_Sav02 = "null";
            }
            if (HairValue >= 6)
            {
                ExHairE_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairE_Bone));
            }
            else
            {
                ExHairE_Sav02 = "null";
            }
            if (HairValue >= 7)
            {
                ExHairF_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairF_Bone));
            }
            else
            {
                ExHairF_Sav02 = "null";
            }
            if (HairValue >= 8)
            {
                ExHairG_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairG_Bone));
            }
            else
            {
                ExHairG_Sav02 = "null";
            }
            if (HairValue >= 9)
            {
                ExHairH_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairH_Bone));
            }
            else
            {
                ExHairH_Sav02 = "null";
            }
            if (HairValue >= 10)
            {
                ExHairI_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairI_Bone));
            }
            else
            {
                ExHairI_Sav02 = "null";
            }
            if (HairValue >= 11)
            {
                ExHairJ_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairJ_Bone));
            }
            else
            {
                ExHairJ_Sav02 = "null";
            }
            if (HairValue >= 12)
            {
                ExHairK_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairK_Bone));
            }
            else
            {
                ExHairK_Sav02 = "null";
            }
            if (HairValue >= 13)
            {
                ExHairL_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExHairL_Bone));
            }
            else
            {
                ExHairL_Sav02 = "null";
            }
            if (ExRootHair_Sav02 == null)
            {
                ExRootHair_Sav02 = "null";
                ExHairA_Sav02 = "null";
                ExHairB_Sav02 = "null";
                ExHairC_Sav02 = "null";
                ExHairD_Sav02 = "null";
                ExHairE_Sav02 = "null";
                ExHairF_Sav02 = "null";
                ExHairG_Sav02 = "null";
                ExHairH_Sav02 = "null";
                ExHairI_Sav02 = "null";
                ExHairJ_Sav02 = "null";
                ExHairK_Sav02 = "null";
                ExHairL_Sav02 = "null";
            }
        }

        private void LoadstateHair01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairA_Sav01), BaseModel.ActorData, BaseModel.Offsets.HairA_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairFrontLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HairB_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairFrontRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HairFrontLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairB_Sav01), BaseModel.ActorData, BaseModel.Offsets.HairFrontRight_Bone);
            byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
            if (HairValue >= 2)
            {
                if (ExHairA_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairA_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairA_Bone);
                }
            }
            if (HairValue >= 3)
            {
                if (ExHairB_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairB_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairB_Bone);
                }
            }
            if (HairValue >= 4)
            {
                if (ExHairC_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairC_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairC_Bone);
                }
            }
            if (HairValue >= 5)
            {
                if (ExHairD_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairD_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairD_Bone);
                }
            }
            if (HairValue >= 6)
            {
                if (ExHairE_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairE_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairE_Bone);
                }
            }
            if (HairValue >= 7)
            {
                if (ExHairF_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairF_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairF_Bone);
                }
            }
            if (HairValue >= 8)
            {
                if (ExHairG_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairG_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairG_Bone);
                }
            }
            if (HairValue >= 9)
            {
                if (ExHairH_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairH_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairH_Bone);
                }
            }
            if (HairValue >= 10)
            {
                if (ExHairI_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairI_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairI_Bone);
                }
            }
            if (HairValue >= 11)
            {
                if (ExHairJ_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairJ_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairJ_Bone);
                }
            }
            if (HairValue >= 12)
            {
                if (ExHairK_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairK_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairK_Bone);
                }
            }
            if (HairValue >= 13)
            {
                if (ExHairL_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairL_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExHairL_Bone);
                }
            }
        }

        private void LoadstateHair02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairA_Sav02), BaseModel.ActorData, BaseModel.Offsets.HairA_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairFrontLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HairB_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairFrontRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HairFrontLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HairB_Sav02), BaseModel.ActorData, BaseModel.Offsets.HairFrontRight_Bone);
            byte HairValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExHair_Value);
            if (HairValue >= 2)
            {
                if (ExHairA_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairA_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairA_Bone);
                }
            }
            if (HairValue >= 3)
            {
                if (ExHairB_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairB_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairB_Bone);
                }
            }
            if (HairValue >= 4)
            {
                if (ExHairC_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairC_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairC_Bone);
                }
            }
            if (HairValue >= 5)
            {
                if (ExHairD_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairD_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairD_Bone);
                }
            }
            if (HairValue >= 6)
            {
                if (ExHairE_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairE_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairE_Bone);
                }
            }
            if (HairValue >= 7)
            {
                if (ExHairF_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairF_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairF_Bone);
                }
            }
            if (HairValue >= 8)
            {
                if (ExHairG_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairG_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairG_Bone);
                }
            }
            if (HairValue >= 9)
            {
                if (ExHairH_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairH_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairH_Bone);
                }
            }
            if (HairValue >= 10)
            {
                if (ExHairI_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairI_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairI_Bone);
                }
            }
            if (HairValue >= 11)
            {
                if (ExHairJ_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairJ_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairJ_Bone);
                }
            }
            if (HairValue >= 12)
            {
                if (ExHairK_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairK_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairK_Bone);
                }
            }
            if (HairValue >= 13)
            {
                if (ExHairL_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExHairL_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExHairL_Bone);
                }
            }
        }
        #endregion

        #region Savestate\Loadstate Earrings
        private void SavestateEarrings01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateEarrings01.IsEnabled = true;
            else return;
            EarringsSaved01 = true;

            EarringALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringALeft_Bone));
            EarringARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringARight_Bone));
            EarringBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringBLeft_Bone));
            EarringBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringBRight_Bone));

        }

        private void SavestateEarrings02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateEarrings02.IsEnabled = true;
            else return;
            EarringsSaved02 = true;

            EarringALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringALeft_Bone));
            EarringARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringARight_Bone));
            EarringBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringBLeft_Bone));
            EarringBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.EarringBRight_Bone));
        }

        private void LoadstateEarrings01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EarringALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EarringARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.EarringBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.EarringBRight_Bone);
        }

        private void LoadstateEarrings02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EarringALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EarringARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.EarringBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(EarringBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.EarringBRight_Bone);
        }
        #endregion

        #region Savestate\Loadstate Body
        private void SavestateBody01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateBody01.IsEnabled = true;
            else return;

            BodySaved01 = true;

            SpineA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineA_Bone));
            SpineB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineB_Bone));
            BreastLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastLeft_Bone));
            BreastRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastRight_Bone));
            SpineC_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineC_Bone));
            ScabbardLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ScabbardLeft_Bone));
            ScabbardRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ScabbardRight_Bone));
            Neck_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Neck_Bone));
        }

        private void SavestateBody02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateBody02.IsEnabled = true;
            else return;

            BodySaved02 = true;

            SpineA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineA_Bone));
            SpineB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineB_Bone));
            BreastLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastLeft_Bone));
            BreastRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.BreastRight_Bone));
            SpineC_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SpineC_Bone));
            ScabbardLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ScabbardLeft_Bone));
            ScabbardRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ScabbardRight_Bone));
            Neck_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Neck_Bone));
        }

        private void LoadstateBody01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SpineA_Sav01), BaseModel.ActorData, BaseModel.Offsets.SpineA_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SpineB_Sav01), BaseModel.ActorData, BaseModel.Offsets.SpineB_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SpineC_Sav01), BaseModel.ActorData, BaseModel.Offsets.SpineC_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BreastLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.BreastLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BreastRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.BreastRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ScabbardLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ScabbardLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ScabbardRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ScabbardRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Neck_Sav01), BaseModel.ActorData, BaseModel.Offsets.Neck_Bone);
        }

        private void LoadstateBody02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SpineA_Sav02), BaseModel.ActorData, BaseModel.Offsets.SpineA_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SpineB_Sav02), BaseModel.ActorData, BaseModel.Offsets.SpineB_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SpineC_Sav02), BaseModel.ActorData, BaseModel.Offsets.SpineC_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BreastLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.BreastLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(BreastRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.BreastRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ScabbardLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ScabbardLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ScabbardRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ScabbardRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Neck_Sav02), BaseModel.ActorData, BaseModel.Offsets.Neck_Bone);
        }
        #endregion

        #region Savestate\Loadstate Left Arm
        private void SavestateLeftArm01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateLeftArm01.IsEnabled = true;
            else return;

            LeftArmSaved01 = true;

            ClavicleLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleLeft_Bone));
            ArmLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmLeft_Bone));
            PauldronLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PauldronLeft_Bone));
            ForearmLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmLeft_Bone));
            ShoulderLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderLeft_Bone));
            ShieldLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShieldLeft_Bone));
            ElbowLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowLeft_Bone));
            CouterLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterLeft_Bone));
            WristLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristLeft_Bone));
        }

        private void SavestateLeftArm02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateLeftArm02.IsEnabled = true;
            else return;

            LeftArmSaved02 = true;

            ClavicleLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleLeft_Bone));
            ArmLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmLeft_Bone));
            PauldronLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PauldronLeft_Bone));
            ForearmLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmLeft_Bone));
            ShoulderLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderLeft_Bone));
            ShieldLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShieldLeft_Bone));
            ElbowLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowLeft_Bone));
            CouterLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterLeft_Bone));
            WristLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristLeft_Bone));
        }

        private void LoadstateLeftArm01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClavicleLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClavicleLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ArmLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ArmLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PauldronLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.PauldronLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ForearmLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ForearmLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShoulderLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ShoulderLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShieldLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ShieldLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ElbowLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ElbowLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CouterLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CouterLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WristLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.WristLeft_Bone);
        }

        private void LoadstateLeftArm02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClavicleLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClavicleLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ArmLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ArmLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PauldronLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.PauldronLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ForearmLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ForearmLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShoulderLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ShoulderLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShieldLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ShieldLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ElbowLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ElbowLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CouterLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CouterLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WristLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.WristLeft_Bone);
        }
        #endregion

        #region Savestate\Loadstate Right Arm
        private void SavestateRightArm01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateRightArm01.IsEnabled = true;
            else return;

            RightArmSaved01 = true;

            ClavicleRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleRight_Bone));
            ArmRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmRight_Bone));
            PauldronRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PauldronRight_Bone));
            ForearmRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmRight_Bone));
            ShoulderRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderRight_Bone));
            ShieldRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShieldRight_Bone));
            ElbowRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowRight_Bone));
            CouterRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterRight_Bone));
            WristRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristRight_Bone));
        }

        private void SavestateRightArm02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateRightArm02.IsEnabled = true;
            else return;

            RightArmSaved02 = true;

            ClavicleRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClavicleRight_Bone));
            ArmRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ArmRight_Bone));
            PauldronRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PauldronRight_Bone));
            ForearmRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ForearmRight_Bone));
            ShoulderRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShoulderRight_Bone));
            ShieldRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ShieldRight_Bone));
            ElbowRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ElbowRight_Bone));
            CouterRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CouterRight_Bone));
            WristRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WristRight_Bone));
        }

        private void LoadstateRightArm01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClavicleRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClavicleRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ArmRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ArmRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PauldronRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.PauldronRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ForearmRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ForearmRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShoulderRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ShoulderRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShieldRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ShieldRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ElbowRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ElbowRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CouterRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CouterRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WristRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.WristRight_Bone);
        }

        private void LoadstateRightArm02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClavicleRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClavicleRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ArmRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ArmRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PauldronRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.PauldronRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ForearmRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ForearmRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShoulderRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ShoulderRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ShieldRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ShieldRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ElbowRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ElbowRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CouterRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CouterRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WristRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.WristRight_Bone);
        }
        #endregion

        #region Savestate\Loadstate Clothes
        private void SavestateClothes01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateClothes01.IsEnabled = true;
            else return;

            ClothesSaved01 = true;
            ClothBackALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackALeft_Bone));
            ClothBackARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackARight_Bone));
            ClothFrontALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontALeft_Bone));
            ClothFrontARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontARight_Bone));
            ClothSideALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideALeft_Bone));
            ClothSideARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideARight_Bone));
            ClothBackBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBLeft_Bone));
            ClothBackBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBRight_Bone));
            ClothFrontBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBLeft_Bone));
            ClothFrontBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBRight_Bone));
            ClothSideBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBLeft_Bone));
            ClothSideBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBRight_Bone));
            ClothBackCLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCLeft_Bone));
            ClothBackCRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCRight_Bone));
            ClothFrontCLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCLeft_Bone));
            ClothFrontCRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCRight_Bone));
            ClothSideCLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCLeft_Bone));
            ClothSideCRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCRight_Bone));
        }

        private void SavestateClothes02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateClothes02.IsEnabled = true;
            else return;

            ClothesSaved02 = true;
            ClothBackALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackALeft_Bone));
            ClothBackARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackARight_Bone));
            ClothFrontALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontALeft_Bone));
            ClothFrontARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontARight_Bone));
            ClothSideALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideALeft_Bone));
            ClothSideARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideARight_Bone));
            ClothBackBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBLeft_Bone));
            ClothBackBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackBRight_Bone));
            ClothFrontBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBLeft_Bone));
            ClothFrontBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontBRight_Bone));
            ClothSideBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBLeft_Bone));
            ClothSideBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideBRight_Bone));
            ClothBackCLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCLeft_Bone));
            ClothBackCRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothBackCRight_Bone));
            ClothFrontCLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCLeft_Bone));
            ClothFrontCRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothFrontCRight_Bone));
            ClothSideCLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCLeft_Bone));
            ClothSideCRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ClothSideCRight_Bone));
        }

        private void LoadstateClothes01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothBackALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothBackARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothFrontALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothFrontARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothSideALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothSideARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothBackBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothBackBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothSideBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothSideBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackCLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothBackCLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackCRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothBackCRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontCLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontCRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideCLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothSideCLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideCRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ClothSideCRight_Bone);
        }

        private void LoadstateClothes02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothBackALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothBackARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothFrontALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothFrontARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothSideALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothSideARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothBackBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothBackBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothFrontBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothSideBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothSideBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackCLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothBackCLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothBackCRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothBackCRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontCLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothFrontCRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothFrontCRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideCLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothSideCLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ClothSideCRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ClothSideCRight_Bone);
        }
        #endregion

        #region Savestate\Loadstate Weapons
        private void SavestateWeapons01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateWeapons01.IsEnabled = true;
            else return;

            WeaponsSaved01 = true;
            WeaponLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WeaponLeft_Bone));
            WeaponRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WeaponRight_Bone));
        }

        private void SavestateWeapons02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateWeapons02.IsEnabled = true;
            else return;

            WeaponsSaved02 = true;
            WeaponLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WeaponLeft_Bone));
            WeaponRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.WeaponRight_Bone));
        }

        private void LoadstateWeapons01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WeaponLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.WeaponLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WeaponRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.WeaponRight_Bone);
        }

        private void LoadstateWeapons02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WeaponLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.WeaponLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(WeaponRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.WeaponRight_Bone);
        }
        #endregion

        #region Savestate\Loadstate Left Hand
        private void SavestateLeftHand01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateLeftHand01.IsEnabled = true;
            else return;

            LeftHandSaved01 = true;

            HandLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandLeft_Bone));
            IndexALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexALeft_Bone));
            PinkyALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyALeft_Bone));
            RingALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingALeft_Bone));
            MiddleALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleALeft_Bone));
            ThumbALeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbALeft_Bone));
            IndexBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBLeft_Bone));
            PinkyBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBLeft_Bone));
            RingBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBLeft_Bone));
            MiddleBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBLeft_Bone));
            ThumbBLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBLeft_Bone));
        }

        private void SavestateLeftHand02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateLeftHand02.IsEnabled = true;
            else return;

            LeftHandSaved02 = true;

            HandLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandLeft_Bone));
            IndexALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexALeft_Bone));
            PinkyALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyALeft_Bone));
            RingALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingALeft_Bone));
            MiddleALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleALeft_Bone));
            ThumbALeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbALeft_Bone));
            IndexBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBLeft_Bone));
            PinkyBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBLeft_Bone));
            RingBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBLeft_Bone));
            MiddleBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBLeft_Bone));
            ThumbBLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBLeft_Bone));
        }

        private void LoadstateLeftHand01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HandLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HandLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.IndexALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.PinkyALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.RingALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.MiddleALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbALeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ThumbALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.IndexBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.PinkyBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.RingBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.MiddleBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbBLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ThumbBLeft_Bone);
        }

        private void LoadstateLeftHand02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HandLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HandLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.IndexALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.PinkyALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.RingALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.MiddleALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbALeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ThumbALeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.IndexBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.PinkyBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.RingBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.MiddleBLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbBLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ThumbBLeft_Bone);
        }
        #endregion

        #region Savestate\Loadstate Right Hand
        private void SavestateRightHand01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateRightHand01.IsEnabled = true;
            else return;

            RightHandSaved01 = true;

            HandRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandRight_Bone));
            IndexARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexARight_Bone));
            PinkyARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyARight_Bone));
            RingARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingARight_Bone));
            MiddleARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleARight_Bone));
            ThumbARight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbARight_Bone));
            IndexBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBRight_Bone));
            PinkyBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBRight_Bone));
            RingBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBRight_Bone));
            MiddleBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBRight_Bone));
            ThumbBRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBRight_Bone));
        }

        private void SavestateRightHand02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateRightHand02.IsEnabled = true;
            else return;

            RightHandSaved02 = true;

            HandRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HandRight_Bone));
            IndexARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexARight_Bone));
            PinkyARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyARight_Bone));
            RingARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingARight_Bone));
            MiddleARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleARight_Bone));
            ThumbARight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbARight_Bone));
            IndexBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.IndexBRight_Bone));
            PinkyBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PinkyBRight_Bone));
            RingBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.RingBRight_Bone));
            MiddleBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.MiddleBRight_Bone));
            ThumbBRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ThumbBRight_Bone));
        }

        private void LoadstateRightHand01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HandRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HandRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.IndexARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.PinkyARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.RingARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.MiddleARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbARight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ThumbARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.IndexBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.PinkyBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.RingBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.MiddleBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbBRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ThumbBRight_Bone);
        }

        private void LoadstateRightHand02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HandRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HandRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.IndexARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.PinkyARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.RingARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.MiddleARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbARight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ThumbARight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(IndexBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.IndexBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PinkyBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.PinkyBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(RingBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.RingBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(MiddleBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.MiddleBRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ThumbBRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ThumbBRight_Bone);
        }
        #endregion

        #region Savestate\Loadstate Waist
        private void SavestateWaist01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateWaist01.IsEnabled = true;
            else return;
            WaistSaved01 = true;
            Waist_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Waist_Bone));
            HolsterLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HolsterLeft_Bone));
            HolsterRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HolsterRight_Bone));
            SheatheLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SheatheLeft_Bone));
            SheatheRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SheatheRight_Bone));
            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 4 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 6 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
            {
                TailA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailA_Bone));
                TailB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailB_Bone));
                TailC_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailC_Bone));
                TailD_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailD_Bone));
                TailE_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailE_Bone));
            }
            else
            {
                TailA_Sav01 = "null";
                TailB_Sav01 = "null";
                TailC_Sav01 = "null";
                TailD_Sav01 = "null";
                TailE_Sav01 = "null";
            }
        }

        private void SavestateWaist02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateWaist02.IsEnabled = true;
            else return;
            WaistSaved02 = true;
            Waist_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.Waist_Bone));
            HolsterLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HolsterLeft_Bone));
            HolsterRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.HolsterRight_Bone));
            SheatheLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SheatheLeft_Bone));
            SheatheRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.SheatheRight_Bone));
            if (((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 4 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 6 || ((ByteArrayAddress)BaseModel.AddressList["ActorData"]).ArrayValue[0].Value == 7)
            {
                TailA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailA_Bone));
                TailB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailB_Bone));
                TailC_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailC_Bone));
                TailD_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailD_Bone));
                TailE_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.TailE_Bone));
            }
            else
            {
                TailA_Sav02 = "null";
                TailB_Sav02 = "null";
                TailC_Sav02 = "null";
                TailD_Sav02 = "null";
                TailE_Sav02 = "null";
            }
        }

        private void LoadstateWaist01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Waist_Sav01), BaseModel.ActorData, BaseModel.Offsets.Waist_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HolsterLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.HolsterLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HolsterRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.HolsterRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SheatheLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.SheatheLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SheatheRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.SheatheRight_Bone);
            if (TailA_Sav01 != "null")
            {
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailA_Sav01), BaseModel.ActorData, BaseModel.Offsets.TailA_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailB_Sav01), BaseModel.ActorData, BaseModel.Offsets.TailB_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailC_Sav01), BaseModel.ActorData, BaseModel.Offsets.TailC_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailD_Sav01), BaseModel.ActorData, BaseModel.Offsets.TailD_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailE_Sav01), BaseModel.ActorData, BaseModel.Offsets.TailE_Bone);
            }
        }

        private void LoadstateWaist02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(Waist_Sav02), BaseModel.ActorData, BaseModel.Offsets.Waist_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HolsterLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.HolsterLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(HolsterRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.HolsterRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SheatheLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.SheatheLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(SheatheRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.SheatheRight_Bone);
            if (TailA_Sav02 != "null")
            {
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailA_Sav02), BaseModel.ActorData, BaseModel.Offsets.TailA_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailB_Sav02), BaseModel.ActorData, BaseModel.Offsets.TailB_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailC_Sav02), BaseModel.ActorData, BaseModel.Offsets.TailC_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailD_Sav02), BaseModel.ActorData, BaseModel.Offsets.TailD_Bone);
                MainWindow.GameProcess.Write(Extensions.StringToByteArray(TailE_Sav02), BaseModel.ActorData, BaseModel.Offsets.TailE_Bone);
            }
        }
        #endregion

        #region Savestate\Loadstate Left Leg
        private void SavestateLeftLeg01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateLeftLeg01.IsEnabled = true;
            else return;
            LeftLegSaved01 = true;

            LegLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsLeft_Bone));
            KneeLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeLeft_Bone));
            CalfLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfLeft_Bone));
            PoleynLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynLeft_Bone));
            FootLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootLeft_Bone));
            ToesLeft_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesLeft_Bone));
        }

        private void SavestateLeftLeg02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateLeftLeg02.IsEnabled = true;
            else return;
            LeftLegSaved02 = true;

            LegLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsLeft_Bone));
            KneeLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeLeft_Bone));
            CalfLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfLeft_Bone));
            PoleynLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynLeft_Bone));
            FootLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootLeft_Bone));
            ToesLeft_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesLeft_Bone));
        }

        private void LoadstateLeftLeg01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(LegLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.LegsLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(KneeLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.KneeLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CalfLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.CalfLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PoleynLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.PoleynLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(FootLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.FootLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ToesLeft_Sav01), BaseModel.ActorData, BaseModel.Offsets.ToesLeft_Bone);
        }

        private void LoadstateLeftLeg02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(LegLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.LegsLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(KneeLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.KneeLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CalfLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.CalfLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PoleynLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.PoleynLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(FootLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.FootLeft_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ToesLeft_Sav02), BaseModel.ActorData, BaseModel.Offsets.ToesLeft_Bone);
        }
        #endregion

        #region Savestate\Loadstate Right Leg
        private void SavestateRightLeg01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateRightLeg01.IsEnabled = true;
            else return;
            RightLegSaved01 = true;

            LegRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsRight_Bone));
            KneeRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeRight_Bone));
            CalfRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfRight_Bone));
            PoleynRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynRight_Bone));
            FootRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootRight_Bone));
            ToesRight_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesRight_Bone));
        }

        private void SavestateRightLeg02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateRightLeg02.IsEnabled = true;
            else return;
            RightLegSaved02 = true;

            LegRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.LegsRight_Bone));
            KneeRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.KneeRight_Bone));
            CalfRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.CalfRight_Bone));
            PoleynRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.PoleynRight_Bone));
            FootRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.FootRight_Bone));
            ToesRight_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ToesRight_Bone));
        }

        private void LoadstateRightLeg01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(LegRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.LegsRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(KneeRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.KneeRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CalfRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.CalfRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PoleynRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.PoleynRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(FootRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.FootRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ToesRight_Sav01), BaseModel.ActorData, BaseModel.Offsets.ToesRight_Bone);
        }

        private void LoadstateRightLeg02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();

            MainWindow.GameProcess.Write(Extensions.StringToByteArray(LegRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.LegsRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(KneeRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.KneeRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(CalfRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.CalfRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(PoleynRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.PoleynRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(FootRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.FootRight_Bone);
            MainWindow.GameProcess.Write(Extensions.StringToByteArray(ToesRight_Sav02), BaseModel.ActorData, BaseModel.Offsets.ToesRight_Bone);
        }
        #endregion

        #region Savestate\Loadstate Helm
        private void SavestateHelm01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateHelm01.IsEnabled = true;
            else return;
            HelmSaved01 = true;
            byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);

            if (HelmValue >= 1)
            {
                ExRootMet_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootMet_Bone));
            }

            if (HelmValue >= 2)
            {
                ExMetA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetA_Bone));
            }
            else
            {
                ExMetA_Sav01 = "null";
            }
            if (HelmValue >= 3)
            {
                ExMetB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetB_Bone));
            }
            else
            {
                ExMetB_Sav01 = "null";
            }
            if (HelmValue >= 4)
            {
                ExMetC_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetC_Bone));
            }
            else
            {
                ExMetC_Sav01 = "null";
            }
            if (HelmValue >= 5)
            {
                ExMetD_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetD_Bone));
            }
            else
            {
                ExMetD_Sav01 = "null";
            }
            if (HelmValue >= 6)
            {
                ExMetE_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetE_Bone));
            }
            else
            {
                ExMetE_Sav01 = "null";
            }
            if (HelmValue >= 7)
            {
                ExMetF_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetF_Bone));
            }
            else
            {
                ExMetF_Sav01 = "null";
            }
            if (HelmValue >= 8)
            {
                ExMetG_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetG_Bone));
            }
            else
            {
                ExMetG_Sav01 = "null";
            }
            if (HelmValue >= 9)
            {
                ExMetH_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetH_Bone));
            }
            else
            {
                ExMetH_Sav01 = "null";
            }
            if (HelmValue >= 10)
            {
                ExMetI_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetI_Bone));
            }
            else
            {
                ExMetI_Sav01 = "null";
            }
            if (HelmValue >= 11)
            {
                ExMetJ_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetJ_Bone));
            }
            else
            {
                ExMetJ_Sav01 = "null";
            }
            if (HelmValue >= 12)
            {
                ExMetK_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetK_Bone));
            }
            else
            {
                ExMetK_Sav01 = "null";
            }
            if (HelmValue >= 13)
            {
                ExMetL_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetL_Bone));
            }
            else
            {
                ExMetL_Sav01 = "null";
            }
            if (HelmValue >= 14)
            {
                ExMetM_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetM_Bone));
            }
            else
            {
                ExMetM_Sav01 = "null";
            }
            if (HelmValue >= 15)
            {
                ExMetN_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetN_Bone));
            }
            else
            {
                ExMetN_Sav01 = "null";
            }
            if (HelmValue >= 16)
            {
                ExMetO_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetO_Bone));
            }
            else
            {
                ExMetO_Sav01 = "null";
            }
            if (HelmValue >= 17)
            {
                ExMetP_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetP_Bone));
            }
            else
            {
                ExMetP_Sav01 = "null";
            }
            if (HelmValue >= 18)
            {
                ExMetQ_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetQ_Bone));
            }
            else
            {
                ExMetQ_Sav01 = "null";
            }
            if (HelmValue >= 19)
            {
                ExMetR_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetR_Bone));
            }
            else
            {
                ExMetR_Sav01 = "null";
            }
            if (ExRootMet_Sav01 == null)
            {
                ExRootMet_Sav01 = "null";
                ExMetA_Sav01 = "null";
                ExMetB_Sav01 = "null";
                ExMetC_Sav01 = "null";
                ExMetD_Sav01 = "null";
                ExMetE_Sav01 = "null";
                ExMetF_Sav01 = "null";
                ExMetG_Sav01 = "null";
                ExMetH_Sav01 = "null";
                ExMetI_Sav01 = "null";
                ExMetJ_Sav01 = "null";
                ExMetK_Sav01 = "null";
                ExMetL_Sav01 = "null";
                ExMetM_Sav01 = "null";
                ExMetN_Sav01 = "null";
                ExMetO_Sav01 = "null";
                ExMetP_Sav01 = "null";
                ExMetQ_Sav01 = "null";
                ExMetR_Sav01 = "null";
            }
        }

        private void SavestateHelm02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateHelm02.IsEnabled = true;
            else return;
            HelmSaved02 = true;
            byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);

            if (HelmValue >= 1)
            {
                ExRootMet_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootMet_Bone));
            }

            if (HelmValue >= 2)
            {
                ExMetA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetA_Bone));
            }
            else
            {
                ExMetA_Sav02 = "null";
            }
            if (HelmValue >= 3)
            {
                ExMetB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetB_Bone));
            }
            else
            {
                ExMetB_Sav02 = "null";
            }
            if (HelmValue >= 4)
            {
                ExMetC_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetC_Bone));
            }
            else
            {
                ExMetC_Sav02 = "null";
            }
            if (HelmValue >= 5)
            {
                ExMetD_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetD_Bone));
            }
            else
            {
                ExMetD_Sav02 = "null";
            }
            if (HelmValue >= 6)
            {
                ExMetE_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetE_Bone));
            }
            else
            {
                ExMetE_Sav02 = "null";
            }
            if (HelmValue >= 7)
            {
                ExMetF_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetF_Bone));
            }
            else
            {
                ExMetF_Sav02 = "null";
            }
            if (HelmValue >= 8)
            {
                ExMetG_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetG_Bone));
            }
            else
            {
                ExMetG_Sav02 = "null";
            }
            if (HelmValue >= 9)
            {
                ExMetH_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetH_Bone));
            }
            else
            {
                ExMetH_Sav02 = "null";
            }
            if (HelmValue >= 10)
            {
                ExMetI_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetI_Bone));
            }
            else
            {
                ExMetI_Sav02 = "null";
            }
            if (HelmValue >= 11)
            {
                ExMetJ_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetJ_Bone));
            }
            else
            {
                ExMetJ_Sav02 = "null";
            }
            if (HelmValue >= 12)
            {
                ExMetK_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetK_Bone));
            }
            else
            {
                ExMetK_Sav02 = "null";
            }
            if (HelmValue >= 13)
            {
                ExMetL_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetL_Bone));
            }
            else
            {
                ExMetL_Sav02 = "null";
            }
            if (HelmValue >= 14)
            {
                ExMetM_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetM_Bone));
            }
            else
            {
                ExMetM_Sav02 = "null";
            }
            if (HelmValue >= 15)
            {
                ExMetN_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetN_Bone));
            }
            else
            {
                ExMetN_Sav02 = "null";
            }
            if (HelmValue >= 16)
            {
                ExMetO_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetO_Bone));
            }
            else
            {
                ExMetO_Sav02 = "null";
            }
            if (HelmValue >= 17)
            {
                ExMetP_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetP_Bone));
            }
            else
            {
                ExMetP_Sav02 = "null";
            }
            if (HelmValue >= 18)
            {
                ExMetQ_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetQ_Bone));
            }
            else
            {
                ExMetQ_Sav02 = "null";
            }
            if (HelmValue >= 19)
            {
                ExMetR_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExMetR_Bone));
            }
            else
            {
                ExMetR_Sav02 = "null";
            }
            if (ExRootMet_Sav02 == null)
            {
                ExRootMet_Sav02 = "null";
                ExMetA_Sav02 = "null";
                ExMetB_Sav02 = "null";
                ExMetC_Sav02 = "null";
                ExMetD_Sav02 = "null";
                ExMetE_Sav02 = "null";
                ExMetF_Sav02 = "null";
                ExMetG_Sav02 = "null";
                ExMetH_Sav02 = "null";
                ExMetI_Sav02 = "null";
                ExMetJ_Sav02 = "null";
                ExMetK_Sav02 = "null";
                ExMetL_Sav02 = "null";
                ExMetM_Sav02 = "null";
                ExMetN_Sav02 = "null";
                ExMetO_Sav02 = "null";
                ExMetP_Sav02 = "null";
                ExMetQ_Sav02 = "null";
                ExMetR_Sav02 = "null";
            }
        }

        private void LoadstateHelm01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);

            if (HelmValue >= 2)
            {
                if (ExMetA_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetA_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetA_Bone);
                }
            }
            if (HelmValue >= 3)
            {
                if (ExMetB_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetB_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetB_Bone);
                }
            }
            if (HelmValue >= 4)
            {
                if (ExMetC_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetC_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetC_Bone);
                }
            }
            if (HelmValue >= 5)
            {
                if (ExMetD_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetD_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetD_Bone);
                }
            }
            if (HelmValue >= 6)
            {
                if (ExMetE_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetE_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetE_Bone);
                }
            }
            if (HelmValue >= 7)
            {
                if (ExMetF_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetF_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetF_Bone);
                }
            }
            if (HelmValue >= 8)
            {
                if (ExMetG_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetG_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetG_Bone);
                }
            }
            if (HelmValue >= 9)
            {
                if (ExMetH_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetH_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetH_Bone);
                }
            }
            if (HelmValue >= 10)
            {
                if (ExMetI_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetI_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetI_Bone);
                }
            }
            if (HelmValue >= 11)
            {
                if (ExMetJ_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetJ_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetJ_Bone);
                }
            }
            if (HelmValue >= 12)
            {
                if (ExMetK_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetK_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetK_Bone);
                }
            }
            if (HelmValue >= 13)
            {
                if (ExMetL_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetL_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetL_Bone);
                }
            }
            if (HelmValue >= 14)
            {
                if (ExMetM_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetM_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetM_Bone);
                }
            }
            if (HelmValue >= 15)
            {
                if (ExMetN_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetN_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetN_Bone);
                }
            }
            if (HelmValue >= 16)
            {
                if (ExMetO_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetO_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetO_Bone);
                }
            }
            if (HelmValue >= 17)
            {
                if (ExMetP_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetP_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetP_Bone);
                }
            }
            if (HelmValue >= 18)
            {
                if (ExMetQ_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetQ_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetQ_Bone);
                }
            }
            if (HelmValue >= 19)
            {
                if (ExMetR_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetR_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExMetR_Bone);
                }
            }
        }

        private void LoadstateHelm02_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);

            if (HelmValue >= 2)
            {
                if (ExMetA_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetA_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetA_Bone);
                }
            }
            if (HelmValue >= 3)
            {
                if (ExMetB_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetB_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetB_Bone);
                }
            }
            if (HelmValue >= 4)
            {
                if (ExMetC_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetC_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetC_Bone);
                }
            }
            if (HelmValue >= 5)
            {
                if (ExMetD_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetD_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetD_Bone);
                }
            }
            if (HelmValue >= 6)
            {
                if (ExMetE_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetE_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetE_Bone);
                }
            }
            if (HelmValue >= 7)
            {
                if (ExMetF_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetF_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetF_Bone);
                }
            }
            if (HelmValue >= 8)
            {
                if (ExMetG_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetG_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetG_Bone);
                }
            }
            if (HelmValue >= 9)
            {
                if (ExMetH_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetH_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetH_Bone);
                }
            }
            if (HelmValue >= 10)
            {
                if (ExMetI_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetI_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetI_Bone);
                }
            }
            if (HelmValue >= 11)
            {
                if (ExMetJ_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetJ_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetJ_Bone);
                }
            }
            if (HelmValue >= 12)
            {
                if (ExMetK_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetK_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetK_Bone);
                }
            }
            if (HelmValue >= 13)
            {
                if (ExMetL_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetL_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetL_Bone);
                }
            }
            if (HelmValue >= 14)
            {
                if (ExMetM_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetM_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetM_Bone);
                }
            }
            if (HelmValue >= 15)
            {
                if (ExMetN_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetN_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetN_Bone);
                }
            }
            if (HelmValue >= 16)
            {
                if (ExMetO_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetO_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetO_Bone);
                }
            }
            if (HelmValue >= 17)
            {
                if (ExMetP_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetP_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetP_Bone);
                }
            }
            if (HelmValue >= 18)
            {
                if (ExMetQ_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetQ_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetQ_Bone);
                }
            }
            if (HelmValue >= 19)
            {
                if (ExMetR_Sav02 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExMetR_Sav02), BaseModel.ActorData, BaseModel.Offsets.ExMetR_Bone);
                }
            }
        }
        #endregion

        #region Savestate\Loadstate Top
        private void SavestateTop01_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateTop01.IsEnabled = true;
            else return;
            TopSaved01 = true;

            byte TopValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);

            if (TopValue >= 1)
            {
                ExRootTop_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootTop_Bone));
            }
            if (TopValue >= 2)
            {
                ExTopA_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopA_Bone));
            }
            else
            {
                ExTopA_Sav01 = "null";
            }
            if (TopValue >= 3)
            {
                ExTopB_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopB_Bone));
            }
            else
            {
                ExTopB_Sav01 = "null";
            }
            if (TopValue >= 4)
            {
                ExTopC_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopC_Bone));
            }
            else
            {
                ExTopC_Sav01 = "null";
            }
            if (TopValue >= 5)
            {
                ExTopD_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopD_Bone));
            }
            else
            {
                ExTopD_Sav01 = "null";
            }
            if (TopValue >= 6)
            {
                ExTopE_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopE_Bone));
            }
            else
            {
                ExTopE_Sav01 = "null";
            }
            if (TopValue >= 7)
            {
                ExTopF_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopF_Bone));
            }
            else
            {
                ExTopF_Sav01 = "null";
            }
            if (TopValue >= 8)
            {
                ExTopG_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopG_Bone));
            }
            else
            {
                ExTopG_Sav01 = "null";
            }
            if (TopValue >= 9)
            {
                ExTopH_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopH_Bone));
            }
            else
            {
                ExTopH_Sav01 = "null";
            }
            if (TopValue >= 10)
            {
                ExTopI_Sav01 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopI_Bone));
            }
            else
            {
                ExTopI_Sav01 = "null";
            }
            if (ExRootTop_Sav01 == null)
            {
                ExRootTop_Sav01 = "null";
                ExTopA_Sav01 = "null";
                ExTopB_Sav01 = "null";
                ExTopC_Sav01 = "null";
                ExTopD_Sav01 = "null";
                ExTopE_Sav01 = "null";
                ExTopF_Sav01 = "null";
                ExTopG_Sav01 = "null";
                ExTopH_Sav01 = "null";
                ExTopI_Sav01 = "null";
            }
        }

        private void SavestateTop02_Click(object sender, RoutedEventArgs e)
        {
            if (EditModeButton.IsChecked == true) LoadstateTop02.IsEnabled = true;
            else return;
            TopSaved02 = true;

            byte TopValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);

            if (TopValue >= 1)
            {
                ExRootTop_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExRootTop_Bone));
            }
            if (TopValue >= 2)
            {
                ExTopA_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopA_Bone));
            }
            else
            {
                ExTopA_Sav02 = "null";
            }
            if (TopValue >= 3)
            {
                ExTopB_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopB_Bone));
            }
            else
            {
                ExTopB_Sav02 = "null";
            }
            if (TopValue >= 4)
            {
                ExTopC_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopC_Bone));
            }
            else
            {
                ExTopC_Sav02 = "null";
            }
            if (TopValue >= 5)
            {
                ExTopD_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopD_Bone));
            }
            else
            {
                ExTopD_Sav02 = "null";
            }
            if (TopValue >= 6)
            {
                ExTopE_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopE_Bone));
            }
            else
            {
                ExTopE_Sav02 = "null";
            }
            if (TopValue >= 7)
            {
                ExTopF_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopF_Bone));
            }
            else
            {
                ExTopF_Sav02 = "null";
            }
            if (TopValue >= 8)
            {
                ExTopG_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopG_Bone));
            }
            else
            {
                ExTopG_Sav02 = "null";
            }
            if (TopValue >= 9)
            {
                ExTopH_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopH_Bone));
            }
            else
            {
                ExTopH_Sav02 = "null";
            }
            if (TopValue >= 10)
            {
                ExTopI_Sav02 = Extensions.ByteArrayToStringU(MainWindow.GameProcess.ReadBytes(BaseModel.ActorData, 16, BaseModel.Offsets.ExTopI_Bone));
            }
            else
            {
                ExTopI_Sav02 = "null";
            }
            if (ExRootTop_Sav02 == null)
            {
                ExRootTop_Sav02 = "null";
                ExTopA_Sav02 = "null";
                ExTopB_Sav02 = "null";
                ExTopC_Sav02 = "null";
                ExTopD_Sav02 = "null";
                ExTopE_Sav02 = "null";
                ExTopF_Sav02 = "null";
                ExTopG_Sav02 = "null";
                ExTopH_Sav02 = "null";
                ExTopI_Sav02 = "null";
            }
        }

        private void LoadstateTop01_Click(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            byte TopValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExTop_Value);

            if (TopValue >= 2)
            {
                if (ExTopA_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopA_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopA_Bone);
                }
            }
            if (TopValue >= 3)
            {
                if (ExTopB_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopB_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopB_Bone);
                }
            }
            if (TopValue >= 4)
            {
                if (ExTopC_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopC_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopC_Bone);
                }
            }
            if (TopValue >= 5)
            {
                if (ExTopD_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopD_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopD_Bone);
                }
            }
            if (TopValue >= 6)
            {
                if (ExTopE_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopE_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopE_Bone);
                }
            }
            if (TopValue >= 7)
            {
                if (ExTopF_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopF_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopF_Bone);
                }
            }
            if (TopValue >= 8)
            {
                if (ExTopG_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopG_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopG_Bone);
                }
            }
            if (TopValue >= 9)
            {
                if (ExTopH_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopH_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopH_Bone);
                }
            }
            if (TopValue >= 10)
            {
                if (ExTopI_Sav01 != "null")
                {
                    MainWindow.GameProcess.Write(Extensions.StringToByteArray(ExTopI_Sav01), BaseModel.ActorData, BaseModel.Offsets.ExTopI_Bone);
                }
            }
        }

        #endregion

        public void EnableTertiary()
        {
            DisableTertiary();
            PoseMatrixViewModel.PoseVM.Bone_Flag_Manager();
        }

        private void WeaponPoSToggle_Checked(object sender, RoutedEventArgs e)
        {
            ScaleToggle.IsChecked = false;
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton5.Adressed, 0x90, 0x90, 0x90, 0x90, 0x90);
            if (WeaponPoSToggle.IsKeyboardFocusWithin || WeaponPoSToggle.IsMouseOver)
            {
                UncheckAll();
                EnableAll();

                #region Disable Controls

                // TertiaryButton.IsEnabled = false;
                Root.IsEnabled = false;
                Abdomen.IsEnabled = false;
                Throw.IsEnabled = false;
                Waist.IsEnabled = false;
                SpineA.IsEnabled = false;
                LegLeft.IsEnabled = false;
                LegRight.IsEnabled = false;
                SpineB.IsEnabled = false;
                ClothBackALeft.IsEnabled = false;
                ClothBackARight.IsEnabled = false;
                ClothFrontALeft.IsEnabled = false;
                ClothFrontARight.IsEnabled = false;
                ClothSideALeft.IsEnabled = false;
                ClothSideARight.IsEnabled = false;
                KneeLeft.IsEnabled = false;
                KneeRight.IsEnabled = false;
                BreastLeft.IsEnabled = false;
                BreastRight.IsEnabled = false;
                SpineC.IsEnabled = false;
                ClothBackBLeft.IsEnabled = false;
                ClothBackBRight.IsEnabled = false;
                ClothFrontBLeft.IsEnabled = false;
                ClothFrontBRight.IsEnabled = false;
                ClothSideBLeft.IsEnabled = false;
                ClothSideBRight.IsEnabled = false;
                CalfLeft.IsEnabled = false;
                CalfRight.IsEnabled = false;
                Neck.IsEnabled = false;
                ClavicleLeft.IsEnabled = false;
                ClavicleRight.IsEnabled = false;
                ClothBackCLeft.IsEnabled = false;
                ClothBackCRight.IsEnabled = false;
                ClothFrontCLeft.IsEnabled = false;
                ClothFrontCRight.IsEnabled = false;
                ClothSideCLeft.IsEnabled = false;
                ClothSideCRight.IsEnabled = false;
                PoleynLeft.IsEnabled = false;
                PoleynRight.IsEnabled = false;
                FootLeft.IsEnabled = false;
                FootRight.IsEnabled = false;
                Head.IsEnabled = false;
                ArmLeft.IsEnabled = false;
                ArmRight.IsEnabled = false;
                PauldronLeft.IsEnabled = false;
                PauldronRight.IsEnabled = false;
                Unknown00.IsEnabled = false;
                ToesLeft.IsEnabled = false;
                ToesRight.IsEnabled = false;
                HairA.IsEnabled = false;
                HairFrontLeft.IsEnabled = false;
                HairFrontRight.IsEnabled = false;
                EarLeft.IsEnabled = false;
                EarRight.IsEnabled = false;
                ForearmLeft.IsEnabled = false;
                ForearmRight.IsEnabled = false;
                ShoulderLeft.IsEnabled = false;
                ShoulderRight.IsEnabled = false;
                HairB.IsEnabled = false;
                HandLeft.IsEnabled = false;
                HandRight.IsEnabled = false;
                ShieldLeft.IsEnabled = false;
                ShieldRight.IsEnabled = false;
                //     EarringALeft.IsEnabled = false;
                //      EarringARight.IsEnabled = false;
                ElbowLeft.IsEnabled = false;
                ElbowRight.IsEnabled = false;
                CouterLeft.IsEnabled = false;
                CouterRight.IsEnabled = false;
                WristLeft.IsEnabled = false;
                WristRight.IsEnabled = false;
                IndexALeft.IsEnabled = false;
                IndexARight.IsEnabled = false;
                PinkyALeft.IsEnabled = false;
                PinkyARight.IsEnabled = false;
                RingALeft.IsEnabled = false;
                RingARight.IsEnabled = false;
                MiddleALeft.IsEnabled = false;
                MiddleARight.IsEnabled = false;
                ThumbALeft.IsEnabled = false;
                ThumbARight.IsEnabled = false;
                //    EarringBLeft.IsEnabled = false;
                //   EarringBRight.IsEnabled = false;
                IndexBLeft.IsEnabled = false;
                IndexBRight.IsEnabled = false;
                PinkyBLeft.IsEnabled = false;
                PinkyBRight.IsEnabled = false;
                RingBLeft.IsEnabled = false;
                RingBRight.IsEnabled = false;
                MiddleBLeft.IsEnabled = false;
                MiddleBRight.IsEnabled = false;
                ThumbBLeft.IsEnabled = false;
                ThumbBRight.IsEnabled = false;
                RootHead.IsEnabled = false;
                Jaw.IsEnabled = false;
                EyelidLowerLeft.IsEnabled = false;
                EyelidLowerRight.IsEnabled = false;
                EyeLeft.IsEnabled = false;
                EyeRight.IsEnabled = false;
                Nose.IsEnabled = false;
                CheekLeft.IsEnabled = false;
                HrothWhiskersLeft.IsEnabled = false;
                CheekRight.IsEnabled = false;
                HrothWhiskersRight.IsEnabled = false;
                LipsLeft.IsEnabled = false;
                LipsRight.IsEnabled = false;
                EyebrowLeft.IsEnabled = false;
                EyebrowRight.IsEnabled = false;
                Bridge.IsEnabled = false;
                BrowLeft.IsEnabled = false;
                BrowRight.IsEnabled = false;
                LipUpperA.IsEnabled = false;
                EyelidUpperLeft.IsEnabled = false;
                EyelidUpperRight.IsEnabled = false;
                LipLowerA.IsEnabled = false;
                LipUpperB.IsEnabled = false;
                LipLowerB.IsEnabled = false;
                DisableTertiary();

                //LoadHeadButton.IsEnabled = false;
                //LoadTorsoButton.IsEnabled = false;
                //LoadLArmButton.IsEnabled = false;
                //LoadRArmButton.IsEnabled = false;
                //LoadLLegButton.IsEnabled = false;
                //LoadRLegButton.IsEnabled = false;
                #endregion
            }
        }

        private void WeaponPoSToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            MainWindow.GameProcess.WriteBytes(BaseModel.Skeleton5.Adressed, 0x41, 0x0F, 0x29, 0x24, 0x12);
            if (WeaponPoSToggle.IsKeyboardFocusWithin || WeaponPoSToggle.IsMouseOver)
            {
                UncheckAll();
                #region Enable Controls
                // TertiaryButton.IsEnabled = true;
                //Root.IsEnabled = true;
                //Abdomen.IsEnabled = true;
                //Throw.IsEnabled = true;
                Waist.IsEnabled = true;
                SpineA.IsEnabled = true;
                LegLeft.IsEnabled = true;
                LegRight.IsEnabled = true;
                HolsterLeft.IsEnabled = true;
                HolsterRight.IsEnabled = true;
                SheatheLeft.IsEnabled = true;
                SheatheRight.IsEnabled = true;
                SpineB.IsEnabled = true;
                ClothBackALeft.IsEnabled = true;
                ClothBackARight.IsEnabled = true;
                ClothFrontALeft.IsEnabled = true;
                ClothFrontARight.IsEnabled = true;
                ClothSideALeft.IsEnabled = true;
                ClothSideARight.IsEnabled = true;
                KneeLeft.IsEnabled = true;
                KneeRight.IsEnabled = true;
                BreastLeft.IsEnabled = true;
                BreastRight.IsEnabled = true;
                SpineC.IsEnabled = true;
                ClothBackBLeft.IsEnabled = true;
                ClothBackBRight.IsEnabled = true;
                ClothFrontBLeft.IsEnabled = true;
                ClothFrontBRight.IsEnabled = true;
                ClothSideBLeft.IsEnabled = true;
                ClothSideBRight.IsEnabled = true;
                CalfLeft.IsEnabled = true;
                CalfRight.IsEnabled = true;
                ScabbardLeft.IsEnabled = true;
                ScabbardRight.IsEnabled = true;
                Neck.IsEnabled = true;
                ClavicleLeft.IsEnabled = true;
                ClavicleRight.IsEnabled = true;
                ClothBackCLeft.IsEnabled = true;
                ClothBackCRight.IsEnabled = true;
                ClothFrontCLeft.IsEnabled = true;
                ClothFrontCRight.IsEnabled = true;
                ClothSideCLeft.IsEnabled = true;
                ClothSideCRight.IsEnabled = true;
                PoleynLeft.IsEnabled = true;
                PoleynRight.IsEnabled = true;
                FootLeft.IsEnabled = true;
                FootRight.IsEnabled = true;
                Head.IsEnabled = true;
                ArmLeft.IsEnabled = true;
                ArmRight.IsEnabled = true;
                PauldronLeft.IsEnabled = true;
                PauldronRight.IsEnabled = true;
                Unknown00.IsEnabled = true;
                ToesLeft.IsEnabled = true;
                ToesRight.IsEnabled = true;
                HairA.IsEnabled = true;
                HairFrontLeft.IsEnabled = true;
                HairFrontRight.IsEnabled = true;
                EarLeft.IsEnabled = true;
                EarRight.IsEnabled = true;
                ForearmLeft.IsEnabled = true;
                ForearmRight.IsEnabled = true;
                ShoulderLeft.IsEnabled = true;
                ShoulderRight.IsEnabled = true;
                HairB.IsEnabled = true;
                HandLeft.IsEnabled = true;
                HandRight.IsEnabled = true;
                ShieldLeft.IsEnabled = true;
                ShieldRight.IsEnabled = true;
                EarringALeft.IsEnabled = true;
                EarringARight.IsEnabled = true;
                ElbowLeft.IsEnabled = true;
                ElbowRight.IsEnabled = true;
                CouterLeft.IsEnabled = true;
                CouterRight.IsEnabled = true;
                WristLeft.IsEnabled = true;
                WristRight.IsEnabled = true;
                IndexALeft.IsEnabled = true;
                IndexARight.IsEnabled = true;
                PinkyALeft.IsEnabled = true;
                PinkyARight.IsEnabled = true;
                RingALeft.IsEnabled = true;
                RingARight.IsEnabled = true;
                MiddleALeft.IsEnabled = true;
                MiddleARight.IsEnabled = true;
                ThumbALeft.IsEnabled = true;
                ThumbARight.IsEnabled = true;
                WeaponLeft.IsEnabled = true;
                WeaponRight.IsEnabled = true;
                EarringBLeft.IsEnabled = true;
                EarringBRight.IsEnabled = true;
                IndexBLeft.IsEnabled = true;
                IndexBRight.IsEnabled = true;
                PinkyBLeft.IsEnabled = true;
                PinkyBRight.IsEnabled = true;
                RingBLeft.IsEnabled = true;
                RingBRight.IsEnabled = true;
                MiddleBLeft.IsEnabled = true;
                MiddleBRight.IsEnabled = true;
                ThumbBLeft.IsEnabled = true;
                ThumbBRight.IsEnabled = true;
                //TailA.IsEnabled = true;
                //TailB.IsEnabled = true;
                //TailC.IsEnabled = true;
                //TailD.IsEnabled = true;
                //TailE.IsEnabled = true;
                //RootHead.IsEnabled = true;
                Jaw.IsEnabled = true;
                EyelidLowerLeft.IsEnabled = true;
                EyelidLowerRight.IsEnabled = true;
                EyeLeft.IsEnabled = true;
                EyeRight.IsEnabled = true;
                Nose.IsEnabled = true;
                CheekLeft.IsEnabled = true;
                CheekRight.IsEnabled = true;
                LipsLeft.IsEnabled = true;
                LipsRight.IsEnabled = true;
                EyebrowLeft.IsEnabled = true;
                EyebrowRight.IsEnabled = true;
                Bridge.IsEnabled = true;
                BrowLeft.IsEnabled = true;
                BrowRight.IsEnabled = true;
                LipUpperA.IsEnabled = true;
                EyelidUpperLeft.IsEnabled = true;
                EyelidUpperRight.IsEnabled = true;
                LipLowerA.IsEnabled = true;
                LipUpperB.IsEnabled = true;
                LipLowerB.IsEnabled = true;
                //HrothWhiskersLeft.IsEnabled = true;
                //HrothWhiskersRight.IsEnabled = true;
                //VieraEarALeft.IsEnabled = true;
                //VieraEarARight.IsEnabled = true;
                //VieraEarBLeft.IsEnabled = true;
                //VieraEarBRight.IsEnabled = true;
                //ExHairA.IsEnabled = true;
                //ExHairB.IsEnabled = true;
                //ExHairC.IsEnabled = true;
                //ExHairD.IsEnabled = true;
                //ExHairE.IsEnabled = true;
                //ExHairF.IsEnabled = true;
                //ExHairG.IsEnabled = true;
                //ExHairH.IsEnabled = true;
                //ExHairI.IsEnabled = true;
                //ExHairJ.IsEnabled = true;
                //ExHairK.IsEnabled = true;
                //ExHairL.IsEnabled = true;
                //ExMetA.IsEnabled = true;
                //ExMetB.IsEnabled = true;
                //ExMetC.IsEnabled = true;
                //ExMetD.IsEnabled = true;
                //ExMetE.IsEnabled = true;
                //ExMetF.IsEnabled = true;
                //ExMetG.IsEnabled = true;
                //ExMetH.IsEnabled = true;
                //ExMetI.IsEnabled = true;
                //ExMetJ.IsEnabled = true;
                //ExMetK.IsEnabled = true;
                //ExMetL.IsEnabled = true;
                //ExMetM.IsEnabled = true;
                //ExMetN.IsEnabled = true;
                //ExMetO.IsEnabled = true;
                //ExMetP.IsEnabled = true;
                //ExMetQ.IsEnabled = true;
                //ExMetR.IsEnabled = true;
                //ExTopA.IsEnabled = true;
                //ExTopB.IsEnabled = true;
                //ExTopC.IsEnabled = true;
                //ExTopD.IsEnabled = true;
                //ExTopE.IsEnabled = true;
                //ExTopF.IsEnabled = true;
                //ExTopG.IsEnabled = true;
                //ExTopH.IsEnabled = true;
                //ExTopI.IsEnabled = true;

                //if (HeadSaved) LoadHeadButton.IsEnabled = true;
                //if (TorsoSaved) LoadTorsoButton.IsEnabled = true;
                //if (LeftArmSaved) LoadLArmButton.IsEnabled = true;
                //if (RightArmSaved) LoadRArmButton.IsEnabled = true;
                //if (LeftLegSaved) LoadLLegButton.IsEnabled = true;
                //if (RightLegSaved) LoadRLegButton.IsEnabled = true;

                EnableTertiary();
                #endregion
            }
        }

        private void ScaleToggle_Checked(object sender, RoutedEventArgs e)
        {
            WeaponPoSToggle.IsChecked = false;
            if (ScaleToggle.IsKeyboardFocusWithin || ScaleToggle.IsMouseOver)
            {
                UncheckAll();
                EnableAll();

                #region Disable Controls
                Root.IsEnabled = false;
                Abdomen.IsEnabled = false;
                Throw.IsEnabled = false;
                //        Waist.IsEnabled = false;
                //   SpineA.IsEnabled = false;
                //    LegLeft.IsEnabled = false;
                //     LegRight.IsEnabled = false;
                HolsterLeft.IsEnabled = false;
                HolsterRight.IsEnabled = false;
                SheatheLeft.IsEnabled = false;
                SheatheRight.IsEnabled = false;
                //     SpineB.IsEnabled = false;
                /*    ClothBackALeft.IsEnabled = false;
                    ClothBackARight.IsEnabled = false;
                    ClothFrontALeft.IsEnabled = false;
                    ClothFrontARight.IsEnabled = false;
                    ClothSideALeft.IsEnabled = false;
                    ClothSideARight.IsEnabled = false;*/
                //     KneeLeft.IsEnabled = false;
                //     KneeRight.IsEnabled = false;
                //      BreastLeft.IsEnabled = false;
                //      BreastRight.IsEnabled = false;
                //      SpineC.IsEnabled = false;
                /*    ClothBackBLeft.IsEnabled = false;
                    ClothBackBRight.IsEnabled = false;
                    ClothFrontBLeft.IsEnabled = false;
                    ClothFrontBRight.IsEnabled = false;
                    ClothSideBLeft.IsEnabled = false;
                    ClothSideBRight.IsEnabled = false;*/
                //    CalfLeft.IsEnabled = false;
                //     CalfRight.IsEnabled = false;
                ScabbardLeft.IsEnabled = false;
                ScabbardRight.IsEnabled = false;
                //      Neck.IsEnabled = false;
                //     ClavicleLeft.IsEnabled = false;
                //      ClavicleRight.IsEnabled = false;
                /*     ClothBackCLeft.IsEnabled = false;
                     ClothBackCRight.IsEnabled = false;
                     ClothFrontCLeft.IsEnabled = false;
                     ClothFrontCRight.IsEnabled = false;
                     ClothSideCLeft.IsEnabled = false;
                     ClothSideCRight.IsEnabled = false;*/
                // PoleynLeft.IsEnabled = false;
                //   PoleynRight.IsEnabled = false;
                //  FootLeft.IsEnabled = false;
                //   FootRight.IsEnabled = false;
                //            Head.IsEnabled = false;
                //    ArmLeft.IsEnabled = false;
                //     ArmRight.IsEnabled = false;
                //  PauldronLeft.IsEnabled = false;
                // PauldronRight.IsEnabled = false;
                Unknown00.IsEnabled = false;
                //  ToesLeft.IsEnabled = false;
                //   ToesRight.IsEnabled = false;
                //     HairA.IsEnabled = false;
                //  HairFrontLeft.IsEnabled = false;
                //  HairFrontRight.IsEnabled = false;
                //   EarLeft.IsEnabled = false;
                //  EarRight.IsEnabled = false;
                //    ForearmLeft.IsEnabled = false;
                //    ForearmRight.IsEnabled = false;
                //   ShoulderLeft.IsEnabled = false;
                //   ShoulderRight.IsEnabled = false;
                //     HairB.IsEnabled = false;
                //    HandLeft.IsEnabled = false;
                //   HandRight.IsEnabled = false;
                //     ShieldLeft.IsEnabled = false;
                //     ShieldRight.IsEnabled = false;
                EarringALeft.IsEnabled = false;
                EarringARight.IsEnabled = false;
                //   ElbowLeft.IsEnabled = false;
                //    ElbowRight.IsEnabled = false;
                //  CouterLeft.IsEnabled = false;
                //      CouterRight.IsEnabled = false;
                //    WristLeft.IsEnabled = false;
                //    WristRight.IsEnabled = false;
                //    IndexALeft.IsEnabled = false;
                //     IndexARight.IsEnabled = false;
                //    PinkyALeft.IsEnabled = false;
                //    PinkyARight.IsEnabled = false;
                //    RingALeft.IsEnabled = false;
                //RingARight.IsEnabled = false;
                //       MiddleALeft.IsEnabled = false;
                //      MiddleARight.IsEnabled = false;
                //  ThumbALeft.IsEnabled = false;
                // ThumbARight.IsEnabled = false;
                WeaponLeft.IsEnabled = false;
                WeaponRight.IsEnabled = false;
                EarringBLeft.IsEnabled = false;
                EarringBRight.IsEnabled = false;
                /*  IndexBLeft.IsEnabled = false;
                  IndexBRight.IsEnabled = false;
                  PinkyBLeft.IsEnabled = false;
                  PinkyBRight.IsEnabled = false;
                  RingBLeft.IsEnabled = false;
                  RingBRight.IsEnabled = false;
                  MiddleBLeft.IsEnabled = false;
                  MiddleBRight.IsEnabled = false;
                  ThumbBLeft.IsEnabled = false;
                  ThumbBRight.IsEnabled = false;*/
                RootHead.IsEnabled = false;
                //   Jaw.IsEnabled = false;
                //   EyelidLowerLeft.IsEnabled = false;
                //   EyelidLowerRight.IsEnabled = false;
                //   EyeLeft.IsEnabled = false;
                //   EyeRight.IsEnabled = false;
                //   Nose.IsEnabled = false;
                //   CheekLeft.IsEnabled = false;
                //  HrothWhiskersLeft.IsEnabled = false;
                //   CheekRight.IsEnabled = false;
                //   HrothWhiskersRight.IsEnabled = false;
                //LipsLeft.IsEnabled = false;
                // LipsRight.IsEnabled = false;
                // EyebrowLeft.IsEnabled = false;
                // EyebrowRight.IsEnabled = false;
                //   Bridge.IsEnabled = false;
                //  BrowLeft.IsEnabled = false;
                //  BrowRight.IsEnabled = false;
                // LipUpperA.IsEnabled = false;
                //    EyelidUpperLeft.IsEnabled = false;
                //   EyelidUpperRight.IsEnabled = false;
                //LipLowerA.IsEnabled = false;
                //  LipUpperB.IsEnabled = false;
                // LipLowerB.IsEnabled = false;
                EnableTertiary();
                #endregion
            }
        }

        private void ScaleToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ScaleToggle.IsKeyboardFocusWithin || ScaleToggle.IsMouseOver)
            {
                UncheckAll();

                #region Enable Controls
                // TertiaryButton.IsEnabled = true;
                //Root.IsEnabled = true;
                //Abdomen.IsEnabled = true;
                //Throw.IsEnabled = true;
                Waist.IsEnabled = true;
                SpineA.IsEnabled = true;
                LegLeft.IsEnabled = true;
                LegRight.IsEnabled = true;
                HolsterLeft.IsEnabled = true;
                HolsterRight.IsEnabled = true;
                SheatheLeft.IsEnabled = true;
                SheatheRight.IsEnabled = true;
                SpineB.IsEnabled = true;
                ClothBackALeft.IsEnabled = true;
                ClothBackARight.IsEnabled = true;
                ClothFrontALeft.IsEnabled = true;
                ClothFrontARight.IsEnabled = true;
                ClothSideALeft.IsEnabled = true;
                ClothSideARight.IsEnabled = true;
                KneeLeft.IsEnabled = true;
                KneeRight.IsEnabled = true;
                BreastLeft.IsEnabled = true;
                BreastRight.IsEnabled = true;
                SpineC.IsEnabled = true;
                ClothBackBLeft.IsEnabled = true;
                ClothBackBRight.IsEnabled = true;
                ClothFrontBLeft.IsEnabled = true;
                ClothFrontBRight.IsEnabled = true;
                ClothSideBLeft.IsEnabled = true;
                ClothSideBRight.IsEnabled = true;
                CalfLeft.IsEnabled = true;
                CalfRight.IsEnabled = true;
                ScabbardLeft.IsEnabled = true;
                ScabbardRight.IsEnabled = true;
                Neck.IsEnabled = true;
                ClavicleLeft.IsEnabled = true;
                ClavicleRight.IsEnabled = true;
                ClothBackCLeft.IsEnabled = true;
                ClothBackCRight.IsEnabled = true;
                ClothFrontCLeft.IsEnabled = true;
                ClothFrontCRight.IsEnabled = true;
                ClothSideCLeft.IsEnabled = true;
                ClothSideCRight.IsEnabled = true;
                PoleynLeft.IsEnabled = true;
                PoleynRight.IsEnabled = true;
                FootLeft.IsEnabled = true;
                FootRight.IsEnabled = true;
                Head.IsEnabled = true;
                ArmLeft.IsEnabled = true;
                ArmRight.IsEnabled = true;
                PauldronLeft.IsEnabled = true;
                PauldronRight.IsEnabled = true;
                Unknown00.IsEnabled = true;
                ToesLeft.IsEnabled = true;
                ToesRight.IsEnabled = true;
                HairA.IsEnabled = true;
                HairFrontLeft.IsEnabled = true;
                HairFrontRight.IsEnabled = true;
                EarLeft.IsEnabled = true;
                EarRight.IsEnabled = true;
                ForearmLeft.IsEnabled = true;
                ForearmRight.IsEnabled = true;
                ShoulderLeft.IsEnabled = true;
                ShoulderRight.IsEnabled = true;
                HairB.IsEnabled = true;
                HandLeft.IsEnabled = true;
                HandRight.IsEnabled = true;
                ShieldLeft.IsEnabled = true;
                ShieldRight.IsEnabled = true;
                EarringALeft.IsEnabled = true;
                EarringARight.IsEnabled = true;
                ElbowLeft.IsEnabled = true;
                ElbowRight.IsEnabled = true;
                CouterLeft.IsEnabled = true;
                CouterRight.IsEnabled = true;
                WristLeft.IsEnabled = true;
                WristRight.IsEnabled = true;
                IndexALeft.IsEnabled = true;
                IndexARight.IsEnabled = true;
                PinkyALeft.IsEnabled = true;
                PinkyARight.IsEnabled = true;
                RingALeft.IsEnabled = true;
                RingARight.IsEnabled = true;
                MiddleALeft.IsEnabled = true;
                MiddleARight.IsEnabled = true;
                ThumbALeft.IsEnabled = true;
                ThumbARight.IsEnabled = true;
                WeaponLeft.IsEnabled = true;
                WeaponRight.IsEnabled = true;
                EarringBLeft.IsEnabled = true;
                EarringBRight.IsEnabled = true;
                IndexBLeft.IsEnabled = true;
                IndexBRight.IsEnabled = true;
                PinkyBLeft.IsEnabled = true;
                PinkyBRight.IsEnabled = true;
                RingBLeft.IsEnabled = true;
                RingBRight.IsEnabled = true;
                MiddleBLeft.IsEnabled = true;
                MiddleBRight.IsEnabled = true;
                ThumbBLeft.IsEnabled = true;
                ThumbBRight.IsEnabled = true;
                //TailA.IsEnabled = true;
                //TailB.IsEnabled = true;
                //TailC.IsEnabled = true;
                //TailD.IsEnabled = true;
                //TailE.IsEnabled = true;
                //RootHead.IsEnabled = true;
                Jaw.IsEnabled = true;
                EyelidLowerLeft.IsEnabled = true;
                EyelidLowerRight.IsEnabled = true;
                EyeLeft.IsEnabled = true;
                EyeRight.IsEnabled = true;
                Nose.IsEnabled = true;
                CheekLeft.IsEnabled = true;
                CheekRight.IsEnabled = true;
                LipsLeft.IsEnabled = true;
                LipsRight.IsEnabled = true;
                EyebrowLeft.IsEnabled = true;
                EyebrowRight.IsEnabled = true;
                Bridge.IsEnabled = true;
                BrowLeft.IsEnabled = true;
                BrowRight.IsEnabled = true;
                LipUpperA.IsEnabled = true;
                EyelidUpperLeft.IsEnabled = true;
                EyelidUpperRight.IsEnabled = true;
                LipLowerA.IsEnabled = true;
                LipUpperB.IsEnabled = true;
                LipLowerB.IsEnabled = true;
                //HrothWhiskersLeft.IsEnabled = true;
                //HrothWhiskersRight.IsEnabled = true;
                //VieraEarALeft.IsEnabled = true;
                //VieraEarARight.IsEnabled = true;
                //VieraEarBLeft.IsEnabled = true;
                //VieraEarBRight.IsEnabled = true;
                //ExHairA.IsEnabled = true;
                //ExHairB.IsEnabled = true;
                //ExHairC.IsEnabled = true;
                //ExHairD.IsEnabled = true;
                //ExHairE.IsEnabled = true;
                //ExHairF.IsEnabled = true;
                //ExHairG.IsEnabled = true;
                //ExHairH.IsEnabled = true;
                //ExHairI.IsEnabled = true;
                //ExHairJ.IsEnabled = true;
                //ExHairK.IsEnabled = true;
                //ExHairL.IsEnabled = true;
                //ExMetA.IsEnabled = true;
                //ExMetB.IsEnabled = true;
                //ExMetC.IsEnabled = true;
                //ExMetD.IsEnabled = true;
                //ExMetE.IsEnabled = true;
                //ExMetF.IsEnabled = true;
                //ExMetG.IsEnabled = true;
                //ExMetH.IsEnabled = true;
                //ExMetI.IsEnabled = true;
                //ExMetJ.IsEnabled = true;
                //ExMetK.IsEnabled = true;
                //ExMetL.IsEnabled = true;
                //ExMetM.IsEnabled = true;
                //ExMetN.IsEnabled = true;
                //ExMetO.IsEnabled = true;
                //ExMetP.IsEnabled = true;
                //ExMetQ.IsEnabled = true;
                //ExMetR.IsEnabled = true;
                //ExTopA.IsEnabled = true;
                //ExTopB.IsEnabled = true;
                //ExTopC.IsEnabled = true;
                //ExTopD.IsEnabled = true;
                //ExTopE.IsEnabled = true;
                //ExTopF.IsEnabled = true;
                //ExTopG.IsEnabled = true;
                //ExTopH.IsEnabled = true;
                //ExTopI.IsEnabled = true;

                //if (HeadSaved) LoadHeadButton.IsEnabled = true;
                //if (TorsoSaved) LoadTorsoButton.IsEnabled = true;
                //if (LeftArmSaved) LoadLArmButton.IsEnabled = true;
                //if (RightArmSaved) LoadRArmButton.IsEnabled = true;
                //if (LeftLegSaved) LoadLLegButton.IsEnabled = true;
                //if (RightLegSaved) LoadRLegButton.IsEnabled = true;

                EnableTertiary();
                #endregion

            }
        }

        private void HelmToggle_Checked(object sender, RoutedEventArgs e)
        {
            byte HelmValue = MainWindow.GameProcess.ReadByte(BaseModel.ActorData, BaseModel.Offsets.ExMet_Value);
            for (byte i = 0; i < HelmValue - 1; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Add(PoseMatrixViewModel.PoseVM.bone_exmet[i]);
            }
        }

        private void HelmToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_exmet.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Remove(PoseMatrixViewModel.PoseVM.bone_exmet[i]);
            }
        }

        private void DisableTertiary()
        {
            #region Disable Tertiary
            TailA.IsEnabled = false;
            TailB.IsEnabled = false;
            TailC.IsEnabled = false;
            TailD.IsEnabled = false;
            TailE.IsEnabled = false;
            HrothWhiskersLeft.IsEnabled = false;
            HrothWhiskersRight.IsEnabled = false;
            VieraEarALeft.IsEnabled = false;
            VieraEarARight.IsEnabled = false;
            VieraEarBLeft.IsEnabled = false;
            VieraEarBRight.IsEnabled = false;
            ExHairA.IsEnabled = false;
            ExHairB.IsEnabled = false;
            ExHairC.IsEnabled = false;
            ExHairD.IsEnabled = false;
            ExHairE.IsEnabled = false;
            ExHairF.IsEnabled = false;
            ExHairG.IsEnabled = false;
            ExHairH.IsEnabled = false;
            ExHairI.IsEnabled = false;
            ExHairJ.IsEnabled = false;
            ExHairK.IsEnabled = false;
            ExHairL.IsEnabled = false;
            ExMetA.IsEnabled = false;
            ExMetB.IsEnabled = false;
            ExMetC.IsEnabled = false;
            ExMetD.IsEnabled = false;
            ExMetE.IsEnabled = false;
            ExMetF.IsEnabled = false;
            ExMetG.IsEnabled = false;
            ExMetH.IsEnabled = false;
            ExMetI.IsEnabled = false;
            ExMetJ.IsEnabled = false;
            ExMetK.IsEnabled = false;
            ExMetL.IsEnabled = false;
            ExMetM.IsEnabled = false;
            ExMetN.IsEnabled = false;
            ExMetO.IsEnabled = false;
            ExMetP.IsEnabled = false;
            ExMetQ.IsEnabled = false;
            ExMetR.IsEnabled = false;
            ExTopA.IsEnabled = false;
            ExTopB.IsEnabled = false;
            ExTopC.IsEnabled = false;
            ExTopD.IsEnabled = false;
            ExTopE.IsEnabled = false;
            ExTopF.IsEnabled = false;
            ExTopG.IsEnabled = false;
            ExTopH.IsEnabled = false;
            ExTopI.IsEnabled = false;
            TailA.IsChecked = false;
            TailB.IsChecked = false;
            TailC.IsChecked = false;
            TailD.IsChecked = false;
            TailE.IsChecked = false;
            HrothWhiskersLeft.IsChecked = false;
            HrothWhiskersRight.IsChecked = false;
            VieraEarALeft.IsChecked = false;
            VieraEarARight.IsChecked = false;
            VieraEarBLeft.IsChecked = false;
            VieraEarBRight.IsChecked = false;
            ExHairA.IsChecked = false;
            ExHairB.IsChecked = false;
            ExHairC.IsChecked = false;
            ExHairD.IsChecked = false;
            ExHairE.IsChecked = false;
            ExHairF.IsChecked = false;
            ExHairG.IsChecked = false;
            ExHairH.IsChecked = false;
            ExHairI.IsChecked = false;
            ExHairJ.IsChecked = false;
            ExHairK.IsChecked = false;
            ExHairL.IsChecked = false;
            ExMetA.IsChecked = false;
            ExMetB.IsChecked = false;
            ExMetC.IsChecked = false;
            ExMetD.IsChecked = false;
            ExMetE.IsChecked = false;
            ExMetF.IsChecked = false;
            ExMetG.IsChecked = false;
            ExMetH.IsChecked = false;
            ExMetI.IsChecked = false;
            ExMetJ.IsChecked = false;
            ExMetK.IsChecked = false;
            ExMetL.IsChecked = false;
            ExMetM.IsChecked = false;
            ExMetN.IsChecked = false;
            ExMetO.IsChecked = false;
            ExMetP.IsChecked = false;
            ExMetQ.IsChecked = false;
            ExMetR.IsChecked = false;
            ExTopA.IsChecked = false;
            ExTopB.IsChecked = false;
            ExTopC.IsChecked = false;
            ExTopD.IsChecked = false;
            ExTopE.IsChecked = false;
            ExTopF.IsChecked = false;
            ExTopG.IsChecked = false;
            ExTopH.IsChecked = false;
            ExTopI.IsChecked = false;
            PoseMatrixViewModel.PoseVM.bone_waist.Remove(PoseMatrixViewModel.PoseVM.bone_tail_a);
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_exhair.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Remove(PoseMatrixViewModel.PoseVM.bone_exhair[i]);
            }
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_viera_ear_l.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face_viera.Remove(PoseMatrixViewModel.PoseVM.bone_viera_ear_l[i]);
                PoseMatrixViewModel.PoseVM.bone_face_viera.Remove(PoseMatrixViewModel.PoseVM.bone_viera_ear_r[i]);
            }
            for (int i = 0; i < PoseMatrixViewModel.PoseVM.bone_exmet.Length; i++)
            {
                PoseMatrixViewModel.PoseVM.bone_face.Remove(PoseMatrixViewModel.PoseVM.bone_exmet[i]);
            }
            PoseMatrixViewModel.PoseVM.ReadTetriaryFromRunTime = false;
            #endregion
        }
        public class BoneSaves
        {
            #region BoneSaves
            public string Description { get; set; }
            public string DateCreated { get; set; }
            public string CMPVersion { get; set; }

            public string Race { get; set; }
            public string Clan { get; set; }
            public string Body { get; set; }

            #region Regular Bones
            public string Root { get; set; }
            public string Abdomen { get; set; }
            public string Throw { get; set; }
            public string Waist { get; set; }
            public string SpineA { get; set; }
            public string LegLeft { get; set; }
            public string LegRight { get; set; }
            public string HolsterLeft { get; set; }
            public string HolsterRight { get; set; }
            public string SheatheLeft { get; set; }
            public string SheatheRight { get; set; }
            public string SpineB { get; set; }
            public string ClothBackALeft { get; set; }
            public string ClothBackARight { get; set; }
            public string ClothFrontALeft { get; set; }
            public string ClothFrontARight { get; set; }
            public string ClothSideALeft { get; set; }
            public string ClothSideARight { get; set; }
            public string KneeLeft { get; set; }
            public string KneeRight { get; set; }
            public string BreastLeft { get; set; }
            public string BreastRight { get; set; }
            public string SpineC { get; set; }
            public string ClothBackBLeft { get; set; }
            public string ClothBackBRight { get; set; }
            public string ClothFrontBLeft { get; set; }
            public string ClothFrontBRight { get; set; }
            public string ClothSideBLeft { get; set; }
            public string ClothSideBRight { get; set; }
            public string CalfLeft { get; set; }
            public string CalfRight { get; set; }
            public string ScabbardLeft { get; set; }
            public string ScabbardRight { get; set; }
            public string Neck { get; set; }
            public string ClavicleLeft { get; set; }
            public string ClavicleRight { get; set; }
            public string ClothBackCLeft { get; set; }
            public string ClothBackCRight { get; set; }
            public string ClothFrontCLeft { get; set; }
            public string ClothFrontCRight { get; set; }
            public string ClothSideCLeft { get; set; }
            public string ClothSideCRight { get; set; }
            public string PoleynLeft { get; set; }
            public string PoleynRight { get; set; }
            public string FootLeft { get; set; }
            public string FootRight { get; set; }
            public string Head { get; set; }
            public string ArmLeft { get; set; }
            public string ArmRight { get; set; }
            public string PauldronLeft { get; set; }
            public string PauldronRight { get; set; }
            public string Unknown00 { get; set; }
            public string ToesLeft { get; set; }
            public string ToesRight { get; set; }
            public string HairA { get; set; }
            public string HairFrontLeft { get; set; }
            public string HairFrontRight { get; set; }
            public string EarLeft { get; set; }
            public string EarRight { get; set; }
            public string ForearmLeft { get; set; }
            public string ForearmRight { get; set; }
            public string ShoulderLeft { get; set; }
            public string ShoulderRight { get; set; }
            public string HairB { get; set; }
            public string HandLeft { get; set; }
            public string HandRight { get; set; }
            public string ShieldLeft { get; set; }
            public string ShieldRight { get; set; }
            public string EarringALeft { get; set; }
            public string EarringARight { get; set; }
            public string ElbowLeft { get; set; }
            public string ElbowRight { get; set; }
            public string CouterLeft { get; set; }
            public string CouterRight { get; set; }
            public string WristLeft { get; set; }
            public string WristRight { get; set; }
            public string IndexALeft { get; set; }
            public string IndexARight { get; set; }
            public string PinkyALeft { get; set; }
            public string PinkyARight { get; set; }
            public string RingALeft { get; set; }
            public string RingARight { get; set; }
            public string MiddleALeft { get; set; }
            public string MiddleARight { get; set; }
            public string ThumbALeft { get; set; }
            public string ThumbARight { get; set; }
            public string WeaponLeft { get; set; }
            public string WeaponRight { get; set; }
            public string EarringBLeft { get; set; }
            public string EarringBRight { get; set; }
            public string IndexBLeft { get; set; }
            public string IndexBRight { get; set; }
            public string PinkyBLeft { get; set; }
            public string PinkyBRight { get; set; }
            public string RingBLeft { get; set; }
            public string RingBRight { get; set; }
            public string MiddleBLeft { get; set; }
            public string MiddleBRight { get; set; }
            public string ThumbBLeft { get; set; }
            public string ThumbBRight { get; set; }
            public string TailA { get; set; }
            public string TailB { get; set; }
            public string TailC { get; set; }
            public string TailD { get; set; }
            public string TailE { get; set; }
            public string RootHead { get; set; }
            public string Jaw { get; set; }
            public string EyelidLowerLeft { get; set; }
            public string EyelidLowerRight { get; set; }
            public string EyeLeft { get; set; }
            public string EyeRight { get; set; }
            public string Nose { get; set; }
            public string CheekLeft { get; set; }
            public string HrothWhiskersLeft { get; set; }
            public string CheekRight { get; set; }
            public string HrothWhiskersRight { get; set; }
            public string LipsLeft { get; set; }
            public string HrothEyebrowLeft { get; set; }
            public string LipsRight { get; set; }
            public string HrothEyebrowRight { get; set; }
            public string EyebrowLeft { get; set; }
            public string HrothBridge { get; set; }
            public string EyebrowRight { get; set; }
            public string HrothBrowLeft { get; set; }
            public string Bridge { get; set; }
            public string HrothBrowRight { get; set; }
            public string BrowLeft { get; set; }
            public string HrothJawUpper { get; set; }
            public string BrowRight { get; set; }
            public string HrothLipUpper { get; set; }
            public string LipUpperA { get; set; }
            public string HrothEyelidUpperLeft { get; set; }
            public string EyelidUpperLeft { get; set; }
            public string HrothEyelidUpperRight { get; set; }
            public string EyelidUpperRight { get; set; }
            public string HrothLipsLeft { get; set; }
            public string LipLowerA { get; set; }
            public string HrothLipsRight { get; set; }
            public string VieraEar01ALeft { get; set; }
            public string LipUpperB { get; set; }
            public string HrothLipUpperLeft { get; set; }
            public string VieraEar01ARight { get; set; }
            public string LipLowerB { get; set; }
            public string HrothLipUpperRight { get; set; }
            public string VieraEar02ALeft { get; set; }
            public string HrothLipLower { get; set; }
            public string VieraEar02ARight { get; set; }
            public string VieraEar03ALeft { get; set; }
            public string VieraEar03ARight { get; set; }
            public string VieraEar04ALeft { get; set; }
            public string VieraEar04ARight { get; set; }
            public string VieraLipLowerA { get; set; }
            public string VieraLipUpperB { get; set; }
            public string VieraEar01BLeft { get; set; }
            public string VieraEar01BRight { get; set; }
            public string VieraEar02BLeft { get; set; }
            public string VieraEar02BRight { get; set; }
            public string VieraEar03BLeft { get; set; }
            public string VieraEar03BRight { get; set; }
            public string VieraEar04BLeft { get; set; }
            public string VieraEar04BRight { get; set; }
            public string VieraLipLowerB { get; set; }
            public string ExRootHair { get; set; }
            public string ExHairA { get; set; }
            public string ExHairB { get; set; }
            public string ExHairC { get; set; }
            public string ExHairD { get; set; }
            public string ExHairE { get; set; }
            public string ExHairF { get; set; }
            public string ExHairG { get; set; }
            public string ExHairH { get; set; }
            public string ExHairI { get; set; }
            public string ExHairJ { get; set; }
            public string ExHairK { get; set; }
            public string ExHairL { get; set; }
            public string ExRootMet { get; set; }
            public string ExMetA { get; set; }
            public string ExMetB { get; set; }
            public string ExMetC { get; set; }
            public string ExMetD { get; set; }
            public string ExMetE { get; set; }
            public string ExMetF { get; set; }
            public string ExMetG { get; set; }
            public string ExMetH { get; set; }
            public string ExMetI { get; set; }
            public string ExMetJ { get; set; }
            public string ExMetK { get; set; }
            public string ExMetL { get; set; }
            public string ExMetM { get; set; }
            public string ExMetN { get; set; }
            public string ExMetO { get; set; }
            public string ExMetP { get; set; }
            public string ExMetQ { get; set; }
            public string ExMetR { get; set; }
            public string ExRootTop { get; set; }
            public string ExTopA { get; set; }
            public string ExTopB { get; set; }
            public string ExTopC { get; set; }
            public string ExTopD { get; set; }
            public string ExTopE { get; set; }
            public string ExTopF { get; set; }
            public string ExTopG { get; set; }
            public string ExTopH { get; set; }
            public string ExTopI { get; set; }
            #endregion

            #region Scale Bones
            public string RootSize { get; set; }
            public string AbdomenSize { get; set; }
            public string ThrowSize { get; set; }
            public string WaistSize { get; set; }
            public string SpineASize { get; set; }
            public string LegLeftSize { get; set; }
            public string LegRightSize { get; set; }
            public string HolsterLeftSize { get; set; }
            public string HolsterRightSize { get; set; }
            public string SheatheLeftSize { get; set; }
            public string SheatheRightSize { get; set; }
            public string SpineBSize { get; set; }
            public string ClothBackALeftSize { get; set; }
            public string ClothBackARightSize { get; set; }
            public string ClothFrontALeftSize { get; set; }
            public string ClothFrontARightSize { get; set; }
            public string ClothSideALeftSize { get; set; }
            public string ClothSideARightSize { get; set; }
            public string KneeLeftSize { get; set; }
            public string KneeRightSize { get; set; }
            public string BreastLeftSize { get; set; }
            public string BreastRightSize { get; set; }
            public string SpineCSize { get; set; }
            public string ClothBackBLeftSize { get; set; }
            public string ClothBackBRightSize { get; set; }
            public string ClothFrontBLeftSize { get; set; }
            public string ClothFrontBRightSize { get; set; }
            public string ClothSideBLeftSize { get; set; }
            public string ClothSideBRightSize { get; set; }
            public string CalfLeftSize { get; set; }
            public string CalfRightSize { get; set; }
            public string ScabbardLeftSize { get; set; }
            public string ScabbardRightSize { get; set; }
            public string NeckSize { get; set; }
            public string ClavicleLeftSize { get; set; }
            public string ClavicleRightSize { get; set; }
            public string ClothBackCLeftSize { get; set; }
            public string ClothBackCRightSize { get; set; }
            public string ClothFrontCLeftSize { get; set; }
            public string ClothFrontCRightSize { get; set; }
            public string ClothSideCLeftSize { get; set; }
            public string ClothSideCRightSize { get; set; }
            public string PoleynLeftSize { get; set; }
            public string PoleynRightSize { get; set; }
            public string FootLeftSize { get; set; }
            public string FootRightSize { get; set; }
            public string HeadSize { get; set; }
            public string ArmLeftSize { get; set; }
            public string ArmRightSize { get; set; }
            public string PauldronLeftSize { get; set; }
            public string PauldronRightSize { get; set; }
            public string Unknown00Size { get; set; }
            public string ToesLeftSize { get; set; }
            public string ToesRightSize { get; set; }
            public string HairASize { get; set; }
            public string HairFrontLeftSize { get; set; }
            public string HairFrontRightSize { get; set; }
            public string EarLeftSize { get; set; }
            public string EarRightSize { get; set; }
            public string ForearmLeftSize { get; set; }
            public string ForearmRightSize { get; set; }
            public string ShoulderLeftSize { get; set; }
            public string ShoulderRightSize { get; set; }
            public string HairBSize { get; set; }
            public string HandLeftSize { get; set; }
            public string HandRightSize { get; set; }
            public string ShieldLeftSize { get; set; }
            public string ShieldRightSize { get; set; }
            public string EarringALeftSize { get; set; }
            public string EarringARightSize { get; set; }
            public string ElbowLeftSize { get; set; }
            public string ElbowRightSize { get; set; }
            public string CouterLeftSize { get; set; }
            public string CouterRightSize { get; set; }
            public string WristLeftSize { get; set; }
            public string WristRightSize { get; set; }
            public string IndexALeftSize { get; set; }
            public string IndexARightSize { get; set; }
            public string PinkyALeftSize { get; set; }
            public string PinkyARightSize { get; set; }
            public string RingALeftSize { get; set; }
            public string RingARightSize { get; set; }
            public string MiddleALeftSize { get; set; }
            public string MiddleARightSize { get; set; }
            public string ThumbALeftSize { get; set; }
            public string ThumbARightSize { get; set; }
            public string WeaponLeftSize { get; set; }
            public string WeaponRightSize { get; set; }
            public string EarringBLeftSize { get; set; }
            public string EarringBRightSize { get; set; }
            public string IndexBLeftSize { get; set; }
            public string IndexBRightSize { get; set; }
            public string PinkyBLeftSize { get; set; }
            public string PinkyBRightSize { get; set; }
            public string RingBLeftSize { get; set; }
            public string RingBRightSize { get; set; }
            public string MiddleBLeftSize { get; set; }
            public string MiddleBRightSize { get; set; }
            public string ThumbBLeftSize { get; set; }
            public string ThumbBRightSize { get; set; }
            public string TailASize { get; set; }
            public string TailBSize { get; set; }
            public string TailCSize { get; set; }
            public string TailDSize { get; set; }
            public string TailESize { get; set; }
            public string RootHeadSize { get; set; }
            public string JawSize { get; set; }
            public string EyelidLowerLeftSize { get; set; }
            public string EyelidLowerRightSize { get; set; }
            public string EyeLeftSize { get; set; }
            public string EyeRightSize { get; set; }
            public string NoseSize { get; set; }
            public string CheekLeftSize { get; set; }
            public string HrothWhiskersLeftSize { get; set; }
            public string CheekRightSize { get; set; }
            public string HrothWhiskersRightSize { get; set; }
            public string LipsLeftSize { get; set; }
            public string HrothEyebrowLeftSize { get; set; }
            public string LipsRightSize { get; set; }
            public string HrothEyebrowRightSize { get; set; }
            public string EyebrowLeftSize { get; set; }
            public string HrothBridgeSize { get; set; }
            public string EyebrowRightSize { get; set; }
            public string HrothBrowLeftSize { get; set; }
            public string BridgeSize { get; set; }
            public string HrothBrowRightSize { get; set; }
            public string BrowLeftSize { get; set; }
            public string HrothJawUpperSize { get; set; }
            public string BrowRightSize { get; set; }
            public string HrothLipUpperSize { get; set; }
            public string LipUpperASize { get; set; }
            public string HrothEyelidUpperLeftSize { get; set; }
            public string EyelidUpperLeftSize { get; set; }
            public string HrothEyelidUpperRightSize { get; set; }
            public string EyelidUpperRightSize { get; set; }
            public string HrothLipsLeftSize { get; set; }
            public string LipLowerASize { get; set; }
            public string HrothLipsRightSize { get; set; }
            public string VieraEar01ALeftSize { get; set; }
            public string LipUpperBSize { get; set; }
            public string HrothLipUpperLeftSize { get; set; }
            public string VieraEar01ARightSize { get; set; }
            public string LipLowerBSize { get; set; }
            public string HrothLipUpperRightSize { get; set; }
            public string VieraEar02ALeftSize { get; set; }
            public string HrothLipLowerSize { get; set; }
            public string VieraEar02ARightSize { get; set; }
            public string VieraEar03ALeftSize { get; set; }
            public string VieraEar03ARightSize { get; set; }
            public string VieraEar04ALeftSize { get; set; }
            public string VieraEar04ARightSize { get; set; }
            public string VieraLipLowerASize { get; set; }
            public string VieraLipUpperBSize { get; set; }
            public string VieraEar01BLeftSize { get; set; }
            public string VieraEar01BRightSize { get; set; }
            public string VieraEar02BLeftSize { get; set; }
            public string VieraEar02BRightSize { get; set; }
            public string VieraEar03BLeftSize { get; set; }
            public string VieraEar03BRightSize { get; set; }
            public string VieraEar04BLeftSize { get; set; }
            public string VieraEar04BRightSize { get; set; }
            public string VieraLipLowerBSize { get; set; }
            public string ExRootHairSize { get; set; }
            public string ExHairASize { get; set; }
            public string ExHairBSize { get; set; }
            public string ExHairCSize { get; set; }
            public string ExHairDSize { get; set; }
            public string ExHairESize { get; set; }
            public string ExHairFSize { get; set; }
            public string ExHairGSize { get; set; }
            public string ExHairHSize { get; set; }
            public string ExHairISize { get; set; }
            public string ExHairJSize { get; set; }
            public string ExHairKSize { get; set; }
            public string ExHairLSize { get; set; }
            public string ExRootMetSize { get; set; }
            public string ExMetASize { get; set; }
            public string ExMetBSize { get; set; }
            public string ExMetCSize { get; set; }
            public string ExMetDSize { get; set; }
            public string ExMetESize { get; set; }
            public string ExMetFSize { get; set; }
            public string ExMetGSize { get; set; }
            public string ExMetHSize { get; set; }
            public string ExMetISize { get; set; }
            public string ExMetJSize { get; set; }
            public string ExMetKSize { get; set; }
            public string ExMetLSize { get; set; }
            public string ExMetMSize { get; set; }
            public string ExMetNSize { get; set; }
            public string ExMetOSize { get; set; }
            public string ExMetPSize { get; set; }
            public string ExMetQSize { get; set; }
            public string ExMetRSize { get; set; }
            public string ExRootTopSize { get; set; }
            public string ExTopASize { get; set; }
            public string ExTopBSize { get; set; }
            public string ExTopCSize { get; set; }
            public string ExTopDSize { get; set; }
            public string ExTopESize { get; set; }
            public string ExTopFSize { get; set; }
            public string ExTopGSize { get; set; }
            public string ExTopHSize { get; set; }
            public string ExTopISize { get; set; }
            #endregion 
        }
        #endregion
    }
}