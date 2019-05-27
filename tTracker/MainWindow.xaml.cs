using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
using BeijerElectronics.CommonSystemServices.Registry;
using BeijerElectronics.PackageBuilder.Tool;

namespace tTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool initialized = false;
        DateTime DateTimeError = DateTime.MaxValue;
        TimeSpan TimeSpanError = TimeSpan.MaxValue;

        public MinimizeState MainWindowMinimizeState = MinimizeState.None;

        ICommand MinimizeLeftCommand = new RoutedCommand(nameof(MinimizeLeftCommand), typeof(MainWindow));
        ICommand MinimizeRightCommand = new RoutedCommand(nameof(MinimizeRightCommand), typeof(MainWindow));

        public enum MinimizeState
        {
            None,
            Left,
            Right,

        }

        public ICommand MinimizeLeft = new RoutedCommand(nameof(MinimizeLeft), typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();

            Bootstrap();
            initialized = true;
        }

        private static void Bootstrap()
        {
            using (var bootstrapper = new Bootstrapper())
            {
            }
        }


        public void TimeCalculator_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!initialized)
                return;

            TimeSpan res = CalculateTime();
            if(!Error(res))
                Textbox_Result.Text = res.ToString(@"hh\:mm");
            else
                Textbox_Result.Text = "---";
        }

        public TimeSpan CalculateTime()
        {
            DateTime from = GetDateTimeFromText(Textbox_TimeFrom.Text);
            DateTime to = GetDateTimeFromText(Textbox_TimeTo.Text);
            if (Error(to) || Error((from)))
                return TimeSpanError;

            TimeSpan total = to - from;

            TimeSpan lunch = GetTimeSpanFromText(Textbox_Lunch.Text);
            if (Error(lunch))
                return TimeSpanError;

            TimeSpan s1 = GetTimeSpanFromText(Textbox_Sub1.Text);
            if (Error(s1))
                return s1 = new TimeSpan(0);

            TimeSpan s2 = GetTimeSpanFromText(Textbox_Sub2.Text);
            if (Error(s2))
                return s2 = new TimeSpan(0);

            TimeSpan s3 = GetTimeSpanFromText(Textbox_Sub3.Text);
            if (Error(s3))
                return s3 = new TimeSpan(0);

            TimeSpan result = total - (lunch + s1 + s2 + s3);

            return result;
        }

        public DateTime GetDateTimeFromText(string timeText)
        {
            string text = PolishTimeText(timeText);

            DateTime error = DateTime.MaxValue;

            DateTime time;
            try
            {
                time = DateTime.Parse(text);
            }
            catch
            {
                return error;
            }

            return time;
        }

        public TimeSpan GetTimeSpanFromText(string timeSpanText)
        {
            string text = PolishTimeText(timeSpanText);
            if (text == null)
                return TimeSpanError;

            string[] parts = text.Split(':');

            TimeSpan error = TimeSpan.MaxValue;

            TimeSpan span;
            try
            {
                span = new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
            }
            catch
            {
                return error;
            }

            return span;
        }

        public string PolishTimeText(string timeText)
        {
            string error = null;
            string text = timeText.Trim();
            Regex regex = new Regex(@"^\d+:?\d\d$");
            if (!regex.IsMatch(text))
                return error;

            if (text.IndexOf(":", StringComparison.Ordinal) < 0)
            {
                if (text.Length < 3 || text.Length > 4)
                    return error;

                if (text.Length == 3)
                    text = "0" + text[0] + ":" + text.Substring(1);
                else
                    text = text.Substring(0, 1) + ":" + text.Substring(2);
            }
            else
            {
                if (text.Length < 4 || text.Length > 5)
                    return error;

                if (text.Length == 4 && text[1] != ':')
                    return error;

                if (text.Length == 5 && text[2] != ':')
                    return error;

                if (text.Length == 4)
                    text = "0" + text;
            }

            Regex strictRegex = new Regex(@"^\d\d:\d\d$");
            if (!regex.IsMatch(text))
                return error;

            return text;

        }

        public bool Error(DateTime val)
        {
            return val == DateTimeError;
        }
        public bool Error(TimeSpan val)
        {
            return val == TimeSpanError;
        }

        private void MinimizeLeft_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
        }


        private void MinimizeLeft_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
