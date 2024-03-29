﻿using System;
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

namespace TallinnTransport.ViewModels
{
    public partial class Times : PhoneApplicationPage
    {
        public Times()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
            //this.TimeList.SelectionChanged += new SelectionChangedEventHandler(TimeList_SelectionChanged);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            App.ViewModel.LoadTimes();
        }

    }
}