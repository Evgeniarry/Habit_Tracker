using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Threading;
using Habit_Tracker.View;
using System.Collections.Generic;

namespace Habit_Tracker
{
    public partial class App : Application
    {
        private static DB db;
        public static DB DB
        {
            get
            {
                if (db == null)
                    db = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.sqlite3"));
                return db;
            }
        }
        //public int count;
        //public async void Count()
        //{
        //    List<Habit> hab = await DB.GetHabitsAsync();
        //    count = hab.Count;
        //}
        public App()
        {
            
            InitializeComponent();
            //Count();
            //if (count != 0)
            
                MainPage = new NavigationPage(new HelloPage());
            
            //else
            //    MainPage = new NavigationPage(new HelloPage());

        }
        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
