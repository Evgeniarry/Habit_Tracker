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
        private async void AddHabitButton (object sender, EventArgs e)
        {
            string title = NameHabit.Text.Trim();
            string desc = Description.Text.Trim();
            if (title.Length < 5)
            {
                await DisplayAlert("Error", "Минимальная длина названия 5 символов", "OK");
                return;
            }
            else if (desc.Length < 5)
            {
                await DisplayAlert("Error", "Минимальная длина описания 10 символов", "OK");
                return;
            }
            Habit habit = new Habit
            {
                Name = title,
                Description = desc
            };
            App.DB.SaveHabit(habit);

            NameHabit.Text = "";
            Description.Text = "";
        }
    }
}