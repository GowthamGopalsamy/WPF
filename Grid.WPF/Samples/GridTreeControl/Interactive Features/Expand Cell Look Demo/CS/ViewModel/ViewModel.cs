﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;

namespace ExpandCellLook
{
    public class ViewModel : NotificationObject
    {
        #region Private Properties

        private List<BitmapImage> images;

        private int _ComboBoxIndex;

        static int baseCount = -1;

        #endregion

        /// <summary>
        /// Gets or sets the index of the combo box.
        /// </summary>
        /// <value>The index of the combo box.</value>
        public int ComboBoxIndex
        {
            get
            {
                return _ComboBoxIndex;
            }
            set
            {
                _ComboBoxIndex = value;
                RaisePropertyChanged("ComboBoxIndex");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            ComboBoxIndex = 4;
            images = new List<BitmapImage>();

            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_argentina.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_belize.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_bermuda.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_brazil.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_canada.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_colombia.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_costa_rica.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_guatemala.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_mexico.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_panama.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_usa.png")));
            images.Add(new BitmapImage(new Uri("pack://application:,,/images/flag_venezuela.png")));

            this.PopulateWithSampleData(500);
        }
        /// <summary>
        /// Populates the with sample data.
        /// </summary>
        /// <param name="count">The count.</param>

        private List<EmployeeInfo> _Employeelist;

        /// <summary>
        /// Gets or sets the employeelist.
        /// </summary>
        /// <value>The employeelist.</value>
        public List<EmployeeInfo> Employeelist
        {
            get { return _Employeelist; }
            set { _Employeelist = value; }
        }

        /// <summary>
        /// Populates the with sample data.
        /// </summary>
        /// <param name="count">The count.</param>
        public void PopulateWithSampleData(int count)
        {
            PopulateWithSampleData(count, false);
        }

        /// <summary>
        /// Populates the with flat data.
        /// </summary>
        /// <param name="count">The count.</param>
        public void PopulateWithFlatData(int count)
        {
            baseCount++;

            Random r = new Random(12313);
            EmployeeInfo emp;
            //just generate to randon data in some manner - not really related to the TreeGrid itself...
            for (int i = 0; i < count; ++i)
            {
                emp = new EmployeeInfo();
                emp.ID = i;
                emp.FirstName = string.Format("first{0}_{1}", i, baseCount);
                emp.LastName = string.Format("last{0}", i);
                emp.Salary = 30000d + r.Next(9) * 10000;
                emp.Title = string.Format("title{0}", r.Next(5));
                emp.Department = string.Format("department{0}", r.Next(4));
                emp.Rating = r.Next(100);
                emp.ImageIndex = r.Next(images.Count);
                this.Employeelist.Add(emp);
            }
        }

        /// <summary>
        /// Gets the item bitmap.
        /// </summary>
        /// <param name="emp">The emp.</param>
        /// <returns></returns>
        public BitmapImage GetItemBitmap(EmployeeInfo emp)
        {
            return images[emp.ImageIndex];
        }

        //just generate some sample data...
        public void PopulateWithSampleData(int count, bool multipleRootNodes)
        {
            Random r = new Random(12313);
            this._Employeelist = new List<EmployeeInfo>();
            //just generate to randon data in some manner - not really related to the TreeGrid itself...
            PopulateWithFlatData(count);

            //now need to set up the reportsto property...
            // first create a list of all the employees
            List<int> all = new List<int>();
            for (int i = 0; i < count; ++i)
            {
                all.Add(i);
            }

            //choose 2 big bosses - with half the employees reporting to each...

            //first big boss
            int randonLocation = r.Next(all.Count);
            int parentID = all[randonLocation];
            EmployeeInfo bigBoss = this.Employeelist[parentID];
            bigBoss.FirstName = "BIGBOSS1";
            bigBoss.Salary = 200000d;
            bigBoss.ReportsTo = -1; //big boss reports to no one

            //remove boss for pool
            all.Remove(parentID);
            List<EmployeeInfo> employeesToProcess = new List<EmployeeInfo>();
            employeesToProcess.Add(bigBoss);

            //now loop through and set direct reports to this parent
            int half = multipleRootNodes ? all.Count / 2 : 0;
            while (all.Count > half)
            {
                List<EmployeeInfo> nextSetToProcess = new List<EmployeeInfo>();
                foreach (EmployeeInfo e in employeesToProcess)
                {
                    int numberOfReports = r.Next(6) + 1;
                    while (numberOfReports > 0 && all.Count > half)
                    {
                        randonLocation = r.Next(all.Count);
                        int childID = all[randonLocation];
                        EmployeeInfo child = this.Employeelist[childID];
                        nextSetToProcess.Add(child);
                        child.ReportsTo = e.ID;
                        numberOfReports--;
                        all.Remove(childID);
                    }
                    if (all.Count <= half)
                        break;
                }
                employeesToProcess = nextSetToProcess;
            }

            if (multipleRootNodes)
            {
                //second big boss
                randonLocation = r.Next(all.Count);
                parentID = all[randonLocation];
                bigBoss = this.Employeelist[parentID];
                bigBoss.FirstName = "BIGBOSS2";
                bigBoss.Salary = 200000d;
                bigBoss.ReportsTo = -1; //big boss reports to no one

                //remove boss for pool
                all.Remove(parentID);

                employeesToProcess = new List<EmployeeInfo>();
                employeesToProcess.Add(bigBoss);

                //now loop through and set direct reports to this parent

                while (all.Count > 0)
                {
                    List<EmployeeInfo> nextSetToProcess = new List<EmployeeInfo>();
                    //employeesToProcess.Sort();
                    foreach (EmployeeInfo e in employeesToProcess)
                    {
                        int numberOfReports = r.Next(6) + 1;
                        while (numberOfReports > 0 && all.Count > 0)
                        {
                            randonLocation = r.Next(all.Count);
                            int childID = all[randonLocation];
                            EmployeeInfo child = this.Employeelist[childID];
                            nextSetToProcess.Add(child);
                            child.ReportsTo = e.ID;
                            numberOfReports--;
                            all.Remove(childID);
                        }
                        if (all.Count == 0)
                            break;
                    }
                    employeesToProcess = nextSetToProcess;
                }
            }

            Employeelist.Sort();
        }

        /// <summary>
        /// Finds the ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public int FindID(int id)
        {
            int loc = -1;

            int top = 0;
            int bot = this.Employeelist.Count - 1;

            int mid;
            do
            {
                mid = (top + bot) / 2;
                if (this.Employeelist[mid].ReportsTo > id)
                {
                    bot = mid - 1;
                }
                else if (this.Employeelist[mid].ReportsTo < id)
                {
                    top = mid + 1;
                }
            }
            while (bot > -1 && top < this.Employeelist.Count && this.Employeelist[mid].ReportsTo != id && bot >= top);
            if (this.Employeelist[mid].ReportsTo == id)
            {
                while (mid > 0 && this.Employeelist[mid - 1].ReportsTo == id)
                    mid--;
                loc = mid;
            }
            return loc;
        }

        /// <summary>
        /// Gets the reportees.
        /// </summary>
        /// <param name="bossID">The boss ID.</param>
        /// <returns></returns>
        public IEnumerable<EmployeeInfo> GetReportees(int bossID)
        {
            //code using fact that collection is ordered on ReportsTo.
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            int loc = FindID(bossID);
            if (loc > -1)
            {
                while (loc < this.Employeelist.Count && this.Employeelist[loc].ReportsTo == bossID)
                    list.Add(this.Employeelist[loc++]);
            }

            return list;
        }
    }
}