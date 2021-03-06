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
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using ComboBoxCellEditorsDemo;
using Syncfusion.Windows.Shared;

namespace ComboBoxCellEditorsDemo
{
    class ViewModel
    {
        #region Constructor
        public ViewModel()
        {
            OrderDetails = new OrderRepository();
        }
        #endregion

        #region Property

        private OrderRepository orderdetails;
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public OrderRepository OrderDetails
        {
            get
            {
                return orderdetails;
            }
            set
            {
                orderdetails = value;
            }
        }
        #endregion
    }
}