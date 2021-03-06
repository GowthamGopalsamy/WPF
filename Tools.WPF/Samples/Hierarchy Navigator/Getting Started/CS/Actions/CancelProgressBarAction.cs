﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.Windows;

namespace HierarchyNavigator_2008
{
    public class CancelProgressBarAction : TargetedTriggerAction<Button>
    {


        

#if Framework3_5
        public FrameworkElement TargetObject
        {
            get { return (FrameworkElement)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(FrameworkElement), typeof(CancelProgressBarAction), new UIPropertyMetadata(null));

#endif

        protected override void Invoke(object parameter)
        {
            ((HierarchyNavigator)TargetObject).CancelProgressBar(new TimeSpan(0, 0, 0, 0,CancelValue));
        }



        public int CancelValue
        {
            get { return (int)GetValue(CancelValueProperty); }
            set { SetValue(CancelValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelValueProperty =
            DependencyProperty.Register("CancelValue", typeof(int), typeof(CancelProgressBarAction), new UIPropertyMetadata(null));

        
    }
}
