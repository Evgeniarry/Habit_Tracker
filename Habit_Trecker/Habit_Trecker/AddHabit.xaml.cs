using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Habit_Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
            string title = NameHabit.Text.Trim();
            string desc = Description.Text.Trim();
            
            if (title.Length < 3)
            {
                await DisplayAlert("Error", "Введите название", "OK");
                return;
            }
            if (desc.Length < 10)
            {
                await DisplayAlert("Error", "Введите описание", "OK");
                return;
            }
            Habit habit = new Habit
            {
                Name = title,
                Description = desc,
                Color = color
                
            };
            App.DB.SaveHabit(habit);

            NameHabit.Text = "";
            Description.Text = "";
        }

        
    }
}