using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TallinnTransport
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        private string _hour;
        public string Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                if (value != _hour)
                {
                    _hour = value;
                    NotifyPropertyChanged("Hour");
                }
            }
        }

        private string _minutes;
        public string Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                if (value != _minutes)
                {
                    _minutes = value;
                    NotifyPropertyChanged("Minutes");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}