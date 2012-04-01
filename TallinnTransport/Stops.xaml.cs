using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;

namespace TallinnTransport
{
    public partial class Stops : PhoneApplicationPage
    {
        public Collection<Stop> StopCollection { get; set; }

        public Stops()
        {
            InitializeComponent();
            StopCollection = new Collection<Stop>();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string route = "";
            string routeType = "";
            if (NavigationContext.QueryString.TryGetValue("route", out route) && NavigationContext.QueryString.TryGetValue("routeType", out routeType))
            {
                this.StopCollection.Add(new Stop("1231", "Kesklin"));
            }
        }
    }

    public class Stop
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Stop(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}