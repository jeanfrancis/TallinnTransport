using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace TallinnTransport
{
    public class TallinnRoutes
    {
        public Collection<Route> Tram { get; set; }

        public Collection<Route> Trolley { get; set; }

        public Collection<Route> Bus { get; set; }


        public TallinnRoutes()
        {
            Bus = new Collection<Route>();
            Bus.Add(new Route("1A","Viru keskus - Viimsi haigla"));
            Trolley = new Collection<Route>();
            Trolley.Add(new Route("1", "Mustamäe - Kaubamaja"));
            Tram = new Collection<Route>();
            Tram.Add(new Route("1", "Kopli - Kadriorg"));
        }
    }
}
