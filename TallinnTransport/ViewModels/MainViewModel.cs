using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Resources;
using System.Xml.Linq;
using System.Linq;


namespace TallinnTransport
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Trams = new ObservableCollection<ItemViewModel>();
            this.Trolleis = new ObservableCollection<ItemViewModel>();
            this.Busses = new ObservableCollection<ItemViewModel>();
        }

        public ObservableCollection<ItemViewModel> Trams { get; private set; }
        public ObservableCollection<ItemViewModel> Trolleis { get; private set; }
        public ObservableCollection<ItemViewModel> Busses { get; private set; }


        private string _routeType = "bus";
        public string RouteType
        {
            get
            {
                return _routeType;
            }
            set
            {
                if (value != _routeType)
                {
                    _routeType = value;
                    NotifyPropertyChanged("RouteType");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData(string RouteType)
        {            
           StreamResourceInfo xml = Application.GetResourceStream(new Uri("routes.xml", UriKind.Relative));
            XDocument doc = XDocument.Load(xml.Stream);
            var routes = from n in doc.Descendants(RouteType).Descendants("Route")
                       select new ItemViewModel()
                       {
                           Number = n.Attribute("Number").Value,
                           Name = n.Attribute("Name").Value
                       };
           //App.ViewModel.Trams = new ObservableCollection<ItemViewModel>(trams);
            App.ViewModel.Trams.Clear();
            foreach (var x in routes)
                App.ViewModel.Trams.Add(x);

            this.IsDataLoaded = true;
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