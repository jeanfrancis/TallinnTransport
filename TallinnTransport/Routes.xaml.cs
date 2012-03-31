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
			createBussList();
        }
		
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string routeType = "";
            if (NavigationContext.QueryString.TryGetValue("routeType", out routeType))
            {
                this.PageTitle.Text = "Tallinn: " + routeType;
                //DataContext = App.NewsCollection.News[selectedNewsIndex];
            }
        }

		private void createBussList(){
			var bussiliinid = new List<Route>();
			bussiliinid.Add(new Route("1A","Viru keskus - Viimsi haigla"));
			this.RouteList.ItemsSource = bussiliinid;
		}

    }

	public class Route {
		public string Number {get; set;}
		public string Name {get; set;}
		
		public Route(string Number, string Name){
			this.Number=Number;
			this.Name=Name;
		}
	}
}
