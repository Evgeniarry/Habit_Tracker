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

            if (string.IsNullOrWhiteSpace(NameHabit.Text))
            {
                await DisplayAlert("Ошибка", "Введите название", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(Description.Text))
            {
                await DisplayAlert("Ошибка", "Введите описание", "OK");
                return;
            }

                habit.Description = Description.Text.Trim();
                habit.Name = NameHabit.Text.Trim();
                habit.Image = image;
                habit.DateHabit = DateTime.Now;
                habit.IsSelected = false;
                await App.DB.SaveHabitAsync(habit);
                await DisplayAlert("Привычка", "Новая привычка добавлена", "OK");

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