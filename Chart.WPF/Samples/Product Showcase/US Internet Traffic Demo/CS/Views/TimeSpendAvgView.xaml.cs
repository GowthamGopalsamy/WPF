﻿#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USInternetTrafficDemo
{
    /// <summary>
    /// Interaction logic for TimeSpendAvgView.xaml
    /// </summary>
    public partial class TimeSpendAvgView : UserControl
    {
        public TimeSpendAvgView()
        {
            InitializeComponent();
            chart1.Loaded += new RoutedEventHandler(chart1_Loaded);
        }

        void chart1_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}