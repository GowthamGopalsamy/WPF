﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace SparkLineGridCellDemo
{
    public class SparkViewModel
    {
        Random rand = new Random();
        public SparkViewModel()
        {
            viewModel = new ObservableCollection<SparkModel>();
            string[] cmpName = { "Daren Sys", "ICS Corp", "Ashe Group", "Crane Corp", "Infysi System", "Global Info", "Alfred Infomartics", "Rany Pharmaticals", "Exos Informatic System", "CISTED Inc", "EDS Sys",
                               "WestWoods Corp", "Ramiret Group", "JP Foundations", "Missy Master Group", "Jason System", "Electomatics", "Mac System", "Intellect Corp", "Aksa Group of companies", "SannSystem",
                               "Daren Sys", "Infysi System", "ICS Corp", "Ashe Group", "Aqua Liquids",  "Ashe Group", "Crane Corp","Fressi Big Market", "SYSCORP","Swan System","Deck Stocks", "Saun Machines",
                                "Lincoln Loss System", "Jason System", "Exos Informatic System", "Mac System", "Intellect Corp", "Aksa Group of companies","Daren Sys", "ICS Corp", "Ashe Group",
                               "WestWoods Corp", "Ramiret Group","JP Foundations", "Missy Master Group", "Jason System","Jason System", "Electomatics", "Mac System", "Global Info", "Alfred Infomartics",
                               "Fressi Big Market", "SYSCORP","Swan System","ICS Corp", "Ashe Group", "Aqua Liquids"};
           
            
            for (int i = 1; i < 50; i++)
            {
                SparkModel model = new SparkModel();
                model.CompanyName = cmpName[i];
                model.High = rand.Next(2500,10000);
                model.Low = rand.Next(1000, 2500);
                model.MarketCap = rand.Next(125, 300);
                model.Date = DateTime.Today.Date;
                model.Performance = rand.Next(10, 100);
                model.Start=rand.Next(0, 600);
                model.End= rand.Next(0, 600); 
                model.Transaction.Add(new DataModel() { Day = rand.Next(1000, 8500) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(2000, 9000) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(3000, 8500) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(4000, 9000) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(5000, 8000) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(6000, 13000) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(1120, 9000) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(2500, 12000) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(500, 3000) }); 
                model.Transaction.Add(new DataModel() { Day = rand.Next(1000, 12000) });
                model.Transaction.Add(new DataModel() { Day = rand.Next(3000, 9000) });
           
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(12, 580) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(0, 350) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(30, 450) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(40, 350) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(10, 600) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(20, 590) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(15, 450) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(11, 440) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(10, 600) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(20, 590) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(15, 450) });
                model.DayActivity.Add(new DataModel() { ShareHolders = rand.Next(11, 440) });

                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(-20, 100) });
                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(-20, 60) });
                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(-30, 150) });
                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(-20, 100) });
                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(-20, 100) });
                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(-20, 100) });
                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(0, 200) });
                model.OneYearPerformance.Add(new DataModel() { YearPerformance = (double)rand.Next(-20, 300) });

                viewModel.Add(model);
            }
        }

        public ObservableCollection<SparkModel> viewModel
        {
            get;
            set;
        }
       
    }
    public class RangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                SparkModel record = (SparkModel)((Syncfusion.Windows.Data.RecordEntry)(((Syncfusion.Windows.Controls.Grid.GridDataCellBoundWrapper)(value)).Record)).Data;
                Syncfusion.Windows.Chart.DoubleRange value1 = new Syncfusion.Windows.Chart.DoubleRange(record.Start, record.End);
                return value1;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}