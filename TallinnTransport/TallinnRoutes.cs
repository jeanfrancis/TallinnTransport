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
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using Microsoft.Phone.Net.NetworkInformation;
using System.Windows.Resources;

namespace TallinnTransport
{
    public class TallinnRoutes
    {
        private static string FILENAME = "routes.xml";

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

        //private void loadXml(){
        //    StreamResourceInfo xml = Application.GetResourceStream(new Uri("yourxmlfilename.xml", UriKind.Relative));
        //    XDocument doc = XDocument.Load(xml.Stream);
        //    var news = from n in doc.Descendants("TallinnRoutes").Descendants("TallinnRoutes.Tram")
        //               select new Route()
        //               {
        //                   Type = (string)n.Element("title").Value,
        //                   Number = (string)n.Element("description").Value,
        //                   Name = (string)n.Element("link").Value
        //               };

        //    // from 7.1 you can use this to create a new observablecollection
        //    // App.NewsCollection.News = new ObservableCollection<NewsItem>(news);

        //    // before that (7.0) you need to create the ObservableCollection by hand
        //    App.NewsCollection.News = toList(news);

        //}

    }
}
