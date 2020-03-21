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
    /// Interaction logic for CMMenuPageSelector.xaml
    /// </summary>
    public partial class CMMenuPageSelector : UserControl
    {
        public CMMenuPageSelector()
        {
            InitializeComponent();
            SetBinding(BubbleTextProperty, new Binding()
            {
                Path = new PropertyPath("BubbleText"),
            });
            SetBinding(IsMarkedProperty, new Binding()
            {
                Path = new PropertyPath("IsMarked"),
            });
            bubbleTextPostCheck();
            isMarkedPostCheck();
        }
        public static readonly DependencyProperty BubbleTextProperty = 
            DependencyProperty.Register("BubbleText", typeof(string), typeof(CMMenuPageSelector),
                new PropertyMetadata("", new PropertyChangedCallback(OnBubbleTextChanged)));

        public static void OnBubbleTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CMMenuPageSelector self = d as CMMenuPageSelector;
            string value = (string)e.NewValue;
            self.bubbleTextPostCheck();
        }

        public string ForwaredBubbleText
        {
            get
            {
                return (string)GetValue(BubbleTextProperty);
            }
        }

        private void bubbleTextPostCheck()
        {
            bubbleText.Text = ForwaredBubbleText;
            if (bubbleText.Text == "")
            {
                bubbleBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                bubbleBox.Visibility = Visibility.Visible;
            }
        }

        public static readonly DependencyProperty IsMarkedProperty =
            DependencyProperty.Register("IsMarked", typeof(bool), typeof(CMMenuPageSelector),
                new PropertyMetadata(false, new PropertyChangedCallback(IsMarkedChanged)));

        public static void IsMarkedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CMMenuPageSelector self = d as CMMenuPageSelector;
            bool value = (bool)e.NewValue;
            self.isMarkedPostCheck();
        }

        public bool IsMarked
        {
            get
            {
                return (bool)GetValue(IsMarkedProperty);
            }
        }

        private void wholePanel_MouseEvent(object sender, MouseEventArgs e)
        {
            isMarkedPostCheck();
        }

        private void isMarkedPostCheck()
        {
            marker.Visibility = IsMarked ? Visibility.Visible : Visibility.Hidden;
            if (wholePanel.IsMouseOver || IsMarked)
            {
                VisualStateManager.GoToElementState(wholePanel, "HighLight", true);
            }
            else
            {
                VisualStateManager.GoToElementState(wholePanel, "NormalLight", true);
            }
        }

    }
}
