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
        public Stops()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
            this.StopList.SelectionChanged += new SelectionChangedEventHandler(RouteList_SelectionChanged);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            App.ViewModel.LoadStops();
        }

        void RouteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            RouteViewModel item = list.SelectedItem as RouteViewModel;
            App.ViewModel.StopId = "1";
            NavigationService.Navigate(new Uri("/Times.xaml", UriKind.Relative));
        }
    }
}