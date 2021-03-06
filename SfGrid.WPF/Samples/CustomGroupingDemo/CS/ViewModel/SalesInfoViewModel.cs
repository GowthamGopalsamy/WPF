﻿#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
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
using System.Threading.Tasks;

namespace CustomGroupingDemo
{
    class SalesInfoViewModel 
    {
        public SalesInfoViewModel()
        {
            
        }

        private ObservableCollection<SalesByDate> _DailySalesDetails = null;

        public ObservableCollection<SalesByDate> DailySalesDetails
        {
            get
            {
                if (_DailySalesDetails == null)
                    return new SalesInfoRepository().GetSalesDetailsByDay(60);
                else
                    return _DailySalesDetails;
            }

        }
    }
}
