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
    /// Interaction logic for CMMenuLabel.xaml
    /// </summary>
    public partial class CMMenuLabel : UserControl
    {
        public CMMenuLabel()
        {
            InitializeComponent();
        }


        public double IconFontSize
        {
            get
            {
                return iconBox.FontSize;
            }
            set
            {
                iconBox.FontSize = value;
            }
        }

        public string IconText
        {
            get
            {
                return iconBox.Text;
            }
            set
            {
                iconBox.Text = value;
            }
        }

        public string ContentText
        {
            get
            {
                return contentBox.Text;
            }
            set
            {
                contentBox.Text = value;
            }
        }
    }
}
