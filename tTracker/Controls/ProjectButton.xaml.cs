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

namespace Dek.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for ProjectButton.xaml
    /// </summary>
    public partial class ProjectButton : UserControl
    {
        public ProjectButton()
        {
            InitializeComponent();
        }

        public static string TitleNotSet = "---";
        public string ProjectTitle
        {
            get { return (string)GetValue(ProjectTitleProperty); }
            set { SetValue(ProjectTitleProperty, value); }
        }
        public static readonly DependencyProperty ProjectTitleProperty =
            DependencyProperty.Register("ProjectTitleImage",
                typeof(string),
                typeof(ProjectButton),
                new UIPropertyMetadata(TitleNotSet));

        public ImageSource DisabledImage
        {
            get { return (ImageSource)GetValue(DisabledImageProperty); }
            set { SetValue(DisabledImageProperty, value); }
        }
        public static readonly DependencyProperty DisabledImageProperty =
            DependencyProperty.Register("DisabledImage",
                typeof(ImageSource),
                typeof(ProjectButton),
                new UIPropertyMetadata(null));

        public ImageSource EnabledImage
        {
            get { return (ImageSource)GetValue(EnabledImageProperty); }
            set { SetValue(EnabledImageProperty, value); }
        }
        public static readonly DependencyProperty EnabledImageProperty =
            DependencyProperty.Register("EnabledImage", 
                typeof(ImageSource), 
                typeof(ProjectButton), 
                new UIPropertyMetadata(null));

        public event RoutedEventHandler Click;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }
    }
}

