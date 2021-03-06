﻿// -----------------------------------------------------------------------
// <copyright file="PrintingCommands.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PrintingDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using Syncfusion.Windows.Controls.Grid;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PrintingCommands
    {
        public static RoutedCommand ShowPrintDialogCommand = new RoutedCommand("ShowPrintDialogCommand", typeof(GridTreeControl));
        public static RoutedCommand PrintCommand = new RoutedCommand("PrintCommand", typeof(GridTreeControl));

        static PrintingCommands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(PrintCommand, OnExecutePrint, OnCanExecutePrint));
            CommandManager.RegisterClassCommandBinding(typeof(GridTreeControl), new CommandBinding(ShowPrintDialogCommand, OnExecuteShowPrintDialog, OnCanExecuteShowPrintDialog));
        }

        #region print
        private static void OnExecutePrint(object sender, ExecutedRoutedEventArgs args)
        {
            ScalingOptions option = ScalingOptions.NoScaling;
            if (args.Parameter != null)
                option = GetScaling(args.Parameter.ToString());

            GridTreeControl dataGrid = args.Source as GridTreeControl;
            dataGrid.Model.ActiveGridView.ScalingOptions = option;
            dataGrid.Print();
        }

        private static void OnCanExecutePrint(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion

        #region ShowprintDialog
        private static void OnExecuteShowPrintDialog(object sender, ExecutedRoutedEventArgs args)
        {
            ScalingOptions option = ScalingOptions.NoScaling;
            if (args.Parameter != null)
                option = GetScaling(args.Parameter.ToString());

            GridTreeControl dataGrid = args.Source as GridTreeControl;
            dataGrid.ShowPrintDialog((p) =>
                {
                    p.ScalingOptions = option;
                    dataGrid.Model.ActiveGridView.ScalingOptions = option;
                    p.ShowDialog();
                });
        }

        private static void OnCanExecuteShowPrintDialog(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion

        #region Helper

        private static ScalingOptions GetScaling(string selectedItem)
        {
            ScalingOptions option = ScalingOptions.NoScaling;
            switch (selectedItem)
            {
                case "NoScaling":
                    option = ScalingOptions.NoScaling;
                    break;
                case "FitAllColumnsonOnePage":
                    option = ScalingOptions.FitAllColumnsonOnePage;
                    break;
                case "FitAllRowsonOnePage":
                    option = ScalingOptions.FitAllRowsonOnePage;
                    break;
                case "FitGridonOnePage":
                    option = ScalingOptions.FitGridonOnePage;
                    break;
            }
            return option;
        }

        #endregion

    }



}
