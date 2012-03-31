using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TallinnTransport
{
    public class Route
    {
        public string Number { get; set; }
        public string Name { get; set; }

        public Route(string Number, string Name)
        {
            this.Number = Number;
            this.Name = Name;
        }
    }
}