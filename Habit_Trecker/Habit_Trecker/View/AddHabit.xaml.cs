using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Habit_Tracker.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            //Habit habit = (Habit)BindingContext;

            Habit habit = new Habit();

            if (NameHabit.Text.Trim().Length < 5)
            {
                await DisplayAlert("Error", "Минимальная длина названия 5 символов", "OK");
                return;
            }
            else if (Description.Text.Trim().Length < 5)
            {
                await DisplayAlert("Error", "Минимальная длина описания 10 символов", "OK");
                return;
            }
            habit.Name = NameHabit.Text.Trim();
            habit.Description = Description.Text.Trim();
            habit.Image = image;

            //if ((!string.IsNullOrWhiteSpace(habit.Name))&&(!string.IsNullOrWhiteSpace(habit.Description)))
            //{
            //    await App.DB.SaveHabitAsync(habit);
            //}
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