using Habit_Tracker.Model;
using Habit_Tracker.View;
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
            
            labelDate.Text = DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("ru"));
        }
        protected override async void OnAppearing()
        {
            List<Habit> hab= await App.DB.GetHabitsAsync();
            habitsCollection.ItemsSource = hab;
        }
        
        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHabit());  
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null) 
            {
                Habit habit = (Habit)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new EditPage(habit.ID));
            }
        }
    }
}
