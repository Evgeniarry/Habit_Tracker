using System;
using Xamarin.Forms;
using System.IO;

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

        public App(int c)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HelloPage());
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
