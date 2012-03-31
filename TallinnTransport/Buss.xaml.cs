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
    public partial class Buss : PhoneApplicationPage
    {
        public Buss()
        {
            InitializeComponent();
			createBussList();
        }
		
		private void createBussList(){
			var bussiliinid = new List<BussiLiin>();
			bussiliinid.Add(new BussiLiin("1A","Viru keskus - Viimsi haigla"));
			BussiList.ItemsSource = bussiliinid;
		}

    }
	
	public class BussiLiin {
		public string Number {get; set;}
		public string Pealkiri {get; set;}
		
		public BussiLiin(string Number, string Pealkiri){
			this.Number=Number;
			this.Pealkiri=Pealkiri;
		}
	}
}
