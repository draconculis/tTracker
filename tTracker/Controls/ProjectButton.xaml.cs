﻿using System;
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
            BitmapImage enabledStar = new BitmapImage();
            enabledStar.BeginInit();
            enabledStar.UriSource = new Uri("pack://application:,,,/tTracker;tTracker/Resources/EnabledStar.png");
            enabledStar.EndInit();
            NormalImage = enabledStar;
            BitmapImage disabledStar = new BitmapImage();
            disabledStar.BeginInit();
            disabledStar.UriSource = new Uri("pack://application:,,,/tTracker;tTracker/Resources/DisabledStar.png");
            disabledStar.EndInit();
            DisabledImage = disabledStar;
        }

<<<<<<< HEAD
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
=======
        public string ProjectName
        {
            get => (string)GetValue(ProjectNameProperty);
            set => SetValue(ProjectNameProperty, value);
        }
        public const string NoProjectName = "---";
        public static readonly DependencyProperty ProjectNameProperty =
            DependencyProperty.Register("ProjectName", 
                typeof(string), 
                typeof(ProjectButton), 
                new UIPropertyMetadata(NoProjectName));

>>>>>>> 50a11074f6a35f11a398358acded203f3578ffe2

        public ImageSource DisabledImage
        {
            get { return (ImageSource)GetValue(DisabledImageProperty); }
            set { SetValue(DisabledImageProperty, value); }
        }
        public static readonly DependencyProperty DisabledImageProperty =
<<<<<<< HEAD
            DependencyProperty.Register("DisabledImage",
                typeof(ImageSource),
                typeof(ProjectButton),
                new UIPropertyMetadata(null));
=======
            DependencyProperty.Register("DisabledImage", 
                typeof(ImageSource), 
                typeof(ProjectButton), 
                new UIPropertyMetadata());
>>>>>>> 50a11074f6a35f11a398358acded203f3578ffe2

        public ImageSource EnabledImage
        {
            get { return (ImageSource)GetValue(EnabledImageProperty); }
            set { SetValue(EnabledImageProperty, value); }
        }
<<<<<<< HEAD
        public static readonly DependencyProperty EnabledImageProperty =
            DependencyProperty.Register("EnabledImage", 
=======
        public static readonly DependencyProperty NormalImageProperty =
            DependencyProperty.Register("NormalImage", 
>>>>>>> 50a11074f6a35f11a398358acded203f3578ffe2
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

