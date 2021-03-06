﻿using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BubbleChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
    }

    public class Model
    {
        public double People { get; set; }

        public string FruitName { get; set; }

        public decimal Size { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Fruits = new ObservableCollection<Model>();

            Fruits.Add(new Model() { FruitName = "Apple", People = 27,Size=0.3m });
            Fruits.Add(new Model() { FruitName = "Orange", People = 33,Size=0.2m });
            Fruits.Add(new Model() { FruitName = "Grapes", People = 15, Size = 0.2m });
            Fruits.Add(new Model() { FruitName = "Banana", People = 5, Size = 0.3m });
            Fruits.Add(new Model() { FruitName = "Blueberry", People = 20, Size = 0.4m });
        }

        public ObservableCollection<Model> Fruits { get; set; }
    }
}
