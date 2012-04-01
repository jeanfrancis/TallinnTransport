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

namespace TallinnTransport
{
    public partial class Routes : PhoneApplicationPage
    {
        public Routes()
        {
            InitializeComponent();
            this.RouteList.SelectionChanged += new SelectionChangedEventHandler(RouteList_SelectionChanged);
        }
		
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string routeType = "";
            if (NavigationContext.QueryString.TryGetValue("routeType", out routeType))
            {
                if (routeType.Equals("bus"))
                {
                    this.PageTitle.Text = "Tallinn:Bus";
                    this.RouteList.ItemsSource = App.TallinnRoutes.Bus;
                }
                else if (routeType.Equals("trolley"))
                {
                    this.PageTitle.Text = "Tallinn:Trolley";
                    this.RouteList.ItemsSource = App.TallinnRoutes.Trolley;
                }
                else if (routeType.Equals("tram"))
                {
                    this.PageTitle.Text = "Tallinn:Tram";
                    this.RouteList.ItemsSource = App.TallinnRoutes.Tram;
                }
            }
        }

        void RouteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            Route item = list.SelectedItem as Route;
            NavigationService.Navigate(new Uri("/Stops.xaml?routeType=trolley&route="+item.Number, UriKind.Relative));
        }
    }

	public class Route {
        public string Type { get; set; }
		public string Number {get; set;}
		public string Name {get; set;}
		
		public Route(string Number, string Name){
			this.Number=Number;
			this.Name=Name;
		}
	}
}
