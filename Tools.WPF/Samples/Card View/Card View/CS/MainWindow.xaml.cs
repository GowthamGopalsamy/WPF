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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;


namespace CardViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is CardView)
            {
                var cardview = sender as CardView;
                if (cardview.SelectedItem != null)
                {
                    var cardviewItem = cardview.ItemsSource != null
                        ? (CardViewItem) cardview.ItemContainerGenerator.ContainerFromItem(cardview.SelectedItem)
                        : (CardViewItem) cardview.SelectedItem;
                    if (cardviewItem != null && cardviewItem.IsInEditMode)
                    {
                        if (e.Key == Key.Escape)
                        {
                            if (cardviewItem.DataContext is ViewModel)
                                e.Handled = !(cardviewItem.DataContext as ViewModel).ValidationSuccess;
                        }
                    }
                }
                
            }
        }

    }
     
}
