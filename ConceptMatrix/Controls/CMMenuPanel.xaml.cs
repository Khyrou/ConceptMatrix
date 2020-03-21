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

namespace ConceptMatrix.Controls
{
    /// <summary>
    /// Interaction logic for CMMenuPanel.xaml
    /// </summary>
    public partial class CMMenuPanel : UserControl
    {
        public CMMenuPanel()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> RefreshClicked;
        public event EventHandler<EventArgs> PageSelected;

        private void CMMenuPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (RefreshClicked != null)
            {
                RefreshClicked.Invoke(this, EventArgs.Empty);
            }
        }

        private void item_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PageSelected != null)
            {
                PageSelected.Invoke(sender, EventArgs.Empty);
            }
        }
    }
}
