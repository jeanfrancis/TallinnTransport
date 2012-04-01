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
            //if(!App.ViewModel.IsDataLoaded)
            //    App.ViewModel.LoadData();
            DataContext = App.ViewModel;
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
                    App.ViewModel.LoadData("Bus");
                }
                else if (routeType.Equals("trolley"))
                {
                    this.PageTitle.Text = "Tallinn:Trolley";
                    App.ViewModel.LoadData("Trolley");
                }
                else if (routeType.Equals("tram"))
                {
                    this.PageTitle.Text = "Tallinn:Tram";
                    App.ViewModel.LoadData("Tram");
                }
            }
        }

        void RouteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            ItemViewModel item = list.SelectedItem as ItemViewModel;
            NavigationService.Navigate(new Uri("/Stops.xaml?routeType=trolley&route="+item.Number, UriKind.Relative));
        }
    }
}
