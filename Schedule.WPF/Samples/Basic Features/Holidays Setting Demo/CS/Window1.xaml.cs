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
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Schedule;

namespace Basic_Schedule_Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
            schedule.MoveToDate(new DateTime(2010, 6, 21));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScheduleHolidays holiday = new ScheduleHolidays();
            holiday.StartTime = DatePicker.SelectedDate.Value;
            holiday.EndTime = DatePicker.SelectedDate.Value;
            holiday.AllDay = true;
            holiday.Subject = Subject.Text;
            schedule.Holidays = new ScheduleHolidaysCollection() { holiday };
        }



        private ScheduleType[] scheduleTypeCollection = { ScheduleType.Day, ScheduleType.WorkWeek, ScheduleType.Week, ScheduleType.ScheduleView, ScheduleType.Month };
        /// <summary>
        /// Gets the schedule type collection.
        /// </summary>
        /// <value>The schedule type collection.</value>
        public ScheduleType[] ScheduleTypeCollection
        {
            get
            {
                return scheduleTypeCollection;
            }
        }

        private Visibility[] scheduleCalendarVisibilityCollection = { Visibility.Visible, Visibility.Collapsed };
        /// <summary>
        /// Gets or sets the schedule calendar visibility collection.
        /// </summary>
        /// <value>The schedule calendar visibility collection.</value>
        public Visibility[] ScheduleCalendarVisibilityCollection
        {
            get
            {
                return scheduleCalendarVisibilityCollection;
            }
            internal set
            {
                scheduleCalendarVisibilityCollection = value;
            }
        }
        /// <summary>
        /// Handles the Checked event of the CalenderVisibilitySelection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void CalenderVisibilitySelection_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
            {
                schedule.CalendarVisibility = Visibility.Visible;
            }
            else
            {
                schedule.CalendarVisibility = Visibility.Collapsed;
            }
        }
    }
}
