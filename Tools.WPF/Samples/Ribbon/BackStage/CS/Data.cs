﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace BackStageSample
{
   internal class Data : ObservableCollection<Info>
    {
       public Info info { get; set; }

       private DelegateCommand infoCommand;

       public Data()
       {
           this.Add(new Info() { Heading = " Permissions ", Description = " Any one can open, copy and change any part of this document." , ButtonContent = "Protect Document" , ButtonIcon="protuctdoc.png"});
           this.Add(new Info() { Heading = " Prepare For Sharing", Description = "Document properties, printer path, author name and related dates.", ButtonContent = "Check For Issues", ButtonIcon = "checkforissues.png" });
       }
       public ICommand InfoCommand
       {
           get
           {
               if (infoCommand == null)
                   infoCommand = new DelegateCommand(new Action(InfoExecuted), new Func<bool>(InfoCanExecute));
               
               return infoCommand;
           }

       }
       public void InfoExecuted()
       {
       }
       public bool InfoCanExecute()
       {
           return true;
       }
    }
 
}
