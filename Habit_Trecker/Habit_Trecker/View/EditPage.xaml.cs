using Habit_Tracker.Model;
using System;
using Xamarin.Forms;

namespace Habit_Tracker.View
{
    public partial class EditPage : ContentPage
    { 
        public EditPage(int ID)
        {
            InitializeComponent();

            LoadHabit(ID);
        }

        private async void LoadHabit(int value)
        {
            try
            {
                Habit habit = await App.DB.GetHabitAsync(value);
                BindingContext = habit;
            }
            catch { }
        }

        string color = "#000000";
        private async void SaveHabitButton(object sender, EventArgs e)
        {
            Habit habit = (Habit)BindingContext;

            habit.Name = NameHabit.Text.Trim();
            habit.Description = Description.Text.Trim();
            habit.Color = color;

            if ((!string.IsNullOrWhiteSpace(habit.Name)) && (!string.IsNullOrWhiteSpace(habit.Description)))
            {
                await App.DB.SaveHabitAsync(habit);
            }
        }

        private async void DeliteHabitButton(object sender, EventArgs e)
        {
            Habit habit = (Habit)BindingContext;
            await App.DB.DeliteHabitAsync(habit);
            await Navigation.PopAsync();
            await Navigation.PushAsync(new MainPage());
        }
    }
}