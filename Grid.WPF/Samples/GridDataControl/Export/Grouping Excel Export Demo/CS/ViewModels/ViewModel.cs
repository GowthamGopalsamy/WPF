﻿#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.XlsIO;
using Syncfusion.Windows.Controls.Grid.Converter;
using System.ComponentModel;
namespace GroupingExcelExportDemo
{
    class ViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            _orderCollection = new ObservableCollection<Orders>();
            this.GetOrders();
        }

        private ObservableCollection<Orders> _orderCollection;

        /// <summary>
        /// Gets or sets the order collection.
        /// </summary>
        /// <value>The order collection.</value>
        public ObservableCollection<Orders> OrderCollection
        {
            get
            {
                return _orderCollection;
            }
            set
            {
                _orderCollection = value;
                RaisePropertyChanged("OrderCollection");
            }
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        private void GetOrders()
        {
            Northwind northWind;

            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                //If number of records to be exported is high and when both the cell value and styles are exported, OutofMemoryException may occur
                var orders = northWind.Orders.Take(500).ToList();  
             
                foreach (var o in orders)
                {
                    _orderCollection.Add(o);
                }
            }
        }
    }
}
