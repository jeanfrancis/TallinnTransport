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
            DataContext = App.ViewModel;
            this.RouteList.SelectionChanged += new SelectionChangedEventHandler(RouteList_SelectionChanged);
        }
		
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.PageTitle.Text = "Tallinn:" + App.ViewModel.RouteType;
            App.ViewModel.LoadRoutes();
        }

        void RouteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            RouteViewModel item = list.SelectedItem as RouteViewModel;
            App.ViewModel.RouteNumber = "1";
            NavigationService.Navigate(new Uri("/Stops.xaml", UriKind.Relative));
        }
    }
}
