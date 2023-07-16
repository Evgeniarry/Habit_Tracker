using Habit_Tracker.Model;
using Habit_Tracker.View;
using Habit_Tracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Habit_Tracker
{
    public partial class MainPage : ContentPage
    {
        private HabitViewModel habitViewModel;

        public MainPage()
        {
            InitializeComponent();
            labelDate.Text = DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("ru"));
        }

        List<Habit> hab;

        protected override async void OnAppearing()
        {
            hab = await App.DB.GetHabitsAsync();
            habitViewModel = new HabitViewModel(hab);
            BindingContext = habitViewModel;
        }
        
        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHabit());  
        }

        int selectedCount = 0;

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            DayModel model = new DayModel();
            Habit habit = (Habit)((Switch)sender).BindingContext;
            Switch switch1 = (Switch)sender;
            if (switch1.IsToggled)
            {
                model.Day = DateTime.Now.Day;
                model.Month = DateTime.Now.Month;
                habit.IsSelected = true;
                model.HabitID = habit.ID;
                await App.DB.SaveDayAsync(model);
                selectedCount++;
            }
            else
            {
                habit.IsSelected = false;
                selectedCount--;
            }
            await App.DB.SaveHabitAsync(habit);
            await DisplayAlert("mess", selectedCount.ToString(), "ok");
        }

        private void FavoriteCommand()
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
