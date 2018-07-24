﻿using System;
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
using System.Windows.Controls.Primitives;
using System.Collections;
using Syncfusion.Windows.Diagram;
using Syncfusion.Windows.Shared;

namespace XMLDataBindingDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            //Assigning the tree spacing properties.
            diagramModel.SpaceBetweenSubTrees = 200;
            diagramModel.VerticalSpacing = 70;
            diagramModel.HorizontalSpacing = 90;
        }
    }
}
