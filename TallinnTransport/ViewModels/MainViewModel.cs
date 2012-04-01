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

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Trams { get; private set; }
        public ObservableCollection<ItemViewModel> Trolleis { get; private set; }
        public ObservableCollection<ItemViewModel> Busses { get; private set; }


        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Trams.Add(new ItemViewModel() { Name = "runtime one", Number = "Maecenas praesent accumsan bibendum"});
            this.Trolleis.Add(new ItemViewModel() { Name = "runtime one", Number = "Maecenas praesent accumsan bibendum" });
            this.Busses.Add(new ItemViewModel() { Name = "runtime one", Number = "Maecenas praesent accumsan bibendum" });
            
            StreamResourceInfo xml = Application.GetResourceStream(new Uri("routes.xml", UriKind.Relative));
            XDocument doc = XDocument.Load(xml.Stream);
            var trams = from n in doc.Descendants("Route")
                       select new ItemViewModel()
                       {
                           Number = n.Attribute("Number").Value,
                           Name = n.Attribute("Name").Value
                       };
            App.ViewModel.Trams = new ObservableCollection<ItemViewModel>(trams);

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