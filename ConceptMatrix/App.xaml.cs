using ConceptMatrix.Backend;
using ConceptMatrix.Views;
using ConceptMatrix.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ConceptMatrix
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    //    public static ARealmReversed Realm;
        private  SaintCoinach.Xiv.Item[] AllEquipment;
        public static List<ExdData.Item> AllEquipmentX = new List<ExdData.Item>();

        protected override void OnStartup(StartupEventArgs e)
        {
            Definitions.GetJson();

            base.OnStartup(e);

            this.Exit += App_Exit;
        }
        private void App_Exit(object sender, ExitEventArgs e)
        {
            //Utility.SaveSettings.Default.Save();
            if (PosingMatrixPage.PosingMatrix!=null) 
            { 
                if (PosingMatrixPage.PosingMatrix.EditModeButton.IsChecked == true) 
                    PosingMatrixPage.PosingMatrix.EditModeButton.IsChecked = false; 
            }
            // close all active threads
            Environment.Exit(0);
        }
    }
}
    