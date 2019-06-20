using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dek.Wpf.UserControls
{
    class TextboxWithLabelViewModel : INotifyPropertyChanged
    {
        public string Text
        {
            //get => (string)GetValue(TextProperty);
            //set SetValue(TextProperty, value);
            get;set;
        }

    public string LabelText
    {
        //get => (string)GetValue(LabelTextProperty);
        //set => SetValue(LabelTextProperty, value);
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
