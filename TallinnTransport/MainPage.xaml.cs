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
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TramButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.ViewModel.RouteType = "Tram";
            NavigationService.Navigate(new Uri("/Routes.xaml", UriKind.Relative));
        }

        private void TrolleyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.ViewModel.RouteType = "Trolley";
        	NavigationService.Navigate(new Uri("/Routes.xaml", UriKind.Relative));
        }

        private void BusButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.ViewModel.RouteType = "Bus";
            NavigationService.Navigate(new Uri("/Routes.xaml", UriKind.Relative));
        }

        private void InfoButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Info.xaml", UriKind.Relative));
        }
    }
}
