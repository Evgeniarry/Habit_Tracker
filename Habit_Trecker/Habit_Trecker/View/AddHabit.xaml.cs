using System;
using Habit_Tracker.Model;
using Xamarin.Forms;

namespace Habit_Tracker
{
    
    public partial class AddHabit : ContentPage
    {
        public AddHabit()
        {
            InitializeComponent();
            
        }
        string image;
        private async void AddHabitButton (object sender, EventArgs e)
        {
            Habit habit = new Habit();

            if (NameHabit.Text.Trim().Length < 1)
            {
                await DisplayAlert("Error", "Минимальная длина названия 1 символов", "OK");
                return;
            }
            else if (Description.Text.Trim().Length < 1)
            {
                await DisplayAlert("Error", "Минимальная длина описания 1 символов", "OK");
                return;
            }
            habit.Name = NameHabit.Text.Trim();
            habit.Description = Description.Text.Trim();
            habit.Image = image;
            habit.IsSelected = false;
            await App.DB.SaveHabitAsync(habit);

            NameHabit.Text = "";
            Description.Text = "";
        }

        private void ImageChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            image = $"{(string)radio.Value}.png";
        }
    }
}