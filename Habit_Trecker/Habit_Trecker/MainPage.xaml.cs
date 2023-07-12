using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Habit_Tracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Load();
        }
        protected override void OnAppearing()
        {
            ShowHabits();
        }
        private void ShowHabits()
        {
            habitsCollection.ItemsSource = App.DB.GetHabit();
        }
        public void Load()
        {
            string s = DateTime.Now.ToString("MMMM yyyy", CultureInfo.GetCultureInfo("ru"));
            labelDate.Text = s[0].ToString().ToUpper() + s.Substring(1);
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHabit());
            
        }

    }
}
