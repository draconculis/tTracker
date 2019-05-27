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
    /// Interaction logic for TextboxWithLabel.xaml
    /// </summary>
    public partial class TextBoxWithLabel : UserControl
    {
        public TextBoxWithLabel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text", typeof(string), typeof(TextBoxWithLabel),
                new FrameworkPropertyMetadata("", 
                    new PropertyChangedCallback(OnTextChanged),
                    new CoerceValueCallback(CoerceTextValue)));

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText", typeof(string), typeof(TextBoxWithLabel),
                new FrameworkPropertyMetadata("", 
                    new PropertyChangedCallback(OnLabelTextChanged),
                    new CoerceValueCallback(CoerceLabelTextValue)));

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        private static void OnTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBoxWithLabel control = (TextBoxWithLabel)obj;

            RoutedPropertyChangedEventArgs<string> e = new RoutedPropertyChangedEventArgs<string>(
                (string)args.OldValue, (string)args.NewValue, TextChangedEvent);

            control.OnTextChanged(e);
        }

        private static void OnLabelTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBoxWithLabel control = obj as TextBoxWithLabel;
            if (control == null)
                return;

            RoutedPropertyChangedEventArgs<string> e = new RoutedPropertyChangedEventArgs<string>(
                (string)args.OldValue, (string)args.NewValue, LabelTextChangedEvent);

            control.OnLabelTextChanged(e);
        }

        public static readonly RoutedEvent TextChangedEvent = EventManager.RegisterRoutedEvent(
            "TextChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<string>), typeof(TextBoxWithLabel));

        public static readonly RoutedEvent LabelTextChangedEvent = EventManager.RegisterRoutedEvent(
            "LabelTextChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<string>), typeof(TextBoxWithLabel));

        protected virtual void OnTextChanged(RoutedPropertyChangedEventArgs<string> args)
        {
            RaiseEvent(args);
        }

        protected virtual void OnLabelTextChanged(RoutedPropertyChangedEventArgs<string> args)
        {
            RaiseEvent(args);
        }

        private static object CoerceTextValue(DependencyObject element, object value)
        {
            string newValue = (string)value;
            //TextBoxWithLabel control = (TextBoxWithLabel)element;

            //newValue = value;

            return newValue;
        }
        private static object CoerceLabelTextValue(DependencyObject element, object value)
        {
            string newValue = (string)value;
            //TextBoxWithLabel control = (TextBoxWithLabel)element;

            newValue = string.IsNullOrWhiteSpace(newValue) ? "Label" : newValue;

            return newValue;
        }
    }
}
