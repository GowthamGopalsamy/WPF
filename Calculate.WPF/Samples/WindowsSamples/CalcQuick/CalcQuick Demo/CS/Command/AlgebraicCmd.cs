﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using Syncfusion.Calculate;

namespace FirstSample
{
    public class AlgebraicCmd : ICommand
    {

        public AlgebraicCmd()
        {
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            AlgebraicExpressions alg = new AlgebraicExpressions();              
            alg.Show();                 
        }

        
    }
}
