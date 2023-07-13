using System;
using System.Collections.Generic;
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

        string color = "#000000";
        private void Red_Clicked(object sender, EventArgs e)
        {

        }

        private void Blue_Clicked(object sender, EventArgs e)
        {

        }

        private void Black_Clicked(object sender, EventArgs e)
        {

        }

        private void White_Clicked(object sender, EventArgs e)
        {

        }

        private void Yellow_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            color = "#FFB800";
        }

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
            habit.Color = color;

            //if ((!string.IsNullOrWhiteSpace(habit.Name))&&(!string.IsNullOrWhiteSpace(habit.Description)))
            //{
            //    await App.DB.SaveHabitAsync(habit);
            //}
            await App.DB.SaveHabitAsync(habit);

            NameHabit.Text = "";
            Description.Text = "";
        }

        

        
    }
}