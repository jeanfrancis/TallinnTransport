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
        public ObservableCollection<RouteViewModel> Routes { get; private set; }
        public ObservableCollection<StopViewModel> Stops { get; private set; }
        public ObservableCollection<RouteViewModel> Times { get; private set; }

        public string RouteType { get; set; }
        public string RouteNumber { get; set; }
        public string StopId { get; set; }

        public MainViewModel()
        {
            this.Routes = new ObservableCollection<RouteViewModel>();
            this.Stops = new ObservableCollection<StopViewModel>();
            this.Times = new ObservableCollection<RouteViewModel>();
        }

        public void LoadRoutes()
        {            
            StreamResourceInfo xml = Application.GetResourceStream(new Uri("DataSource/routes.xml", UriKind.Relative));
            XDocument doc = XDocument.Load(xml.Stream);
            var routes = from n in doc.Descendants(this.RouteType).Descendants("Route")
                       select new RouteViewModel()
                       {
                           Number = n.Attribute("Number").Value,
                           Name = n.Attribute("Name").Value
                       };
            App.ViewModel.Routes.Clear();
            foreach (var x in routes)
            {
                App.ViewModel.Routes.Add(x);
            }
            xml.Stream.Close();
        }

        public void LoadStops()
        {
            StreamResourceInfo xml = Application.GetResourceStream(new Uri("DataSource/stops.xml", UriKind.Relative));
            XDocument doc = XDocument.Load(xml.Stream);
            var stops = from n in doc.Descendants("Stop")
                         select new StopViewModel()
                         {
                             //Number = n.Attribute("Number").Value,
                             Name = n.Attribute("Name").Value
                         };
            App.ViewModel.Stops.Clear();
            foreach (var x in stops)
            {
                App.ViewModel.Stops.Add(x);
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