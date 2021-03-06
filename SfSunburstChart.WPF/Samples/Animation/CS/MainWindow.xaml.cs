﻿using Syncfusion.UI.Xaml.SunburstChart;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class ToolTipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return Math.Round((double)value / 1000000) + " M";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return value;
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Population_Data = new ObservableCollection<Model>
            {
                new Model { State = "Ontario", Continent = "North America", Country = "Canada", Population = 13210600 },
                new Model { State = "New York", Continent = "North America", Country = "United States", Population = 19378102 },
                new Model { State = "Pennsylvania", Continent = "North America", Country = "United States", Population = 12702379 },
                new Model { State = "Ohio", Continent = "North America", Country = "United States", Population = 11536504 },
                new Model { State = "Buenos Aires", Continent = "South America", Country = "Argentina", Population = 15594428 },
                new Model { State = "Minas Gerais", Continent = "South America", Country = "Brazil", Population = 20593366 },
                new Model { State = "Rio de Janeiro", Continent = "South America", Country = "Brazil", Population = 16369178 },
                new Model { State = "Bahia", Continent = "South America", Country = "Brazil", Population = 15044127 },
                new Model { State = "Rio Grande do Sul", Continent = "South America", Country = "Brazil", Population = 11164050 },
                new Model { State = "Parana", Continent = "South America", Country = "Brazil", Population = 10997462 },
                new Model { State = "Chittagong", Continent = "Asia", Country = "Bangladesh", Population = 28079000 },
                new Model { State = "Rajshahi", Continent = "Asia", Country = "Bangladesh", Population = 18329000 },
                new Model { State = "Khulna", Continent = "Asia", Country = "Bangladesh", Population = 15563000 },
                new Model { State = "Liaoning", Continent = "Asia", Country = "China", Population = 43746323 },
                new Model { State = "Shaanxi", Continent = "Asia", Country = "China", Population = 37327378 },
                new Model { State = "Fujian", Continent = "Asia", Country = "China", Population = 36894216 },
                new Model { State = "Shanxi", Continent = "Asia", Country = "China", Population = 35712111 },
                new Model { State = "Kerala", Continent = "Asia", Country = "India", Population = 33387677 },
                new Model { State = "Punjab", Continent = "Asia", Country = "India", Population = 27704236 },
                new Model { State = "Haryana", Continent = "Asia", Country = "India", Population = 25353081 },
                new Model { State = "Delhi", Continent = "Asia", Country = "India", Population = 16753235 },
                new Model { State = "Jammu", Continent = "Asia", Country = "India", Population = 12548926 },
                new Model { State = "West Java", Continent = "Asia", Country = "Indonesia", Population = 43021826 },
                new Model { State = "East Java", Continent = "Asia", Country = "Indonesia", Population = 37476011 },
                new Model { State = "Banten", Continent = "Asia", Country = "Indonesia", Population = 10644030 },
                new Model { State = "Jakarta", Continent = "Asia", Country = "Indonesia", Population = 10187595 },
                new Model { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 24000200 },
                new Model { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 15042531 },
                new Model { State = "Rift Valley", Continent = "Africa", Country = "Kenya", Population = 10006805 },
                new Model { State = "Lagos", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new Model { State = "Kano", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                new Model { State = "Gauteng", Continent = "Africa", Country = "South Africa", Population = 12728400 },
                new Model { State = "KwaZulu-Natal", Continent = "Africa", Country = "South Africa", Population = 10456900 },
                new Model { State = "Ile-de- France", Continent = "Europe", Country = "France", Population = 11694000 },
                new Model { State = "North Rhine-Westphalia", Continent = "Europe", Country = "Germany", Population = 17872863 },
                new Model { State = "Bavaria", Continent = "Europe", Country = "Germany", Population = 12510331 },
                new Model { State = "NBaden-Wurttemberg", Continent = "Europe", Country = "Germany", Population = 10747479 },
                new Model { State = "England", Continent = "Europe", Country = "United Kingdom", Population = 51446600 }
            };
            
        }

        public ObservableCollection<Model> Population_Data { get; set; }

        public Array AnimationType
        {
            get { return Enum.GetValues(typeof(AnimationType)); }
        }
    }

    public class Model
    {
        public string Continent { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public double Population { get; set; }
    }
}
