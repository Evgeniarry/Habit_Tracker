using Habit_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Habit_Tracker.View
{
    [QueryProperty(nameof(ItemID), nameof(ItemID))]
    public partial class EditPage : ContentPage
    { 
       
            public string ItemID
            {
                set
                {
                    LoadHabit(value);
                }
            }
            public EditPage()
        {
            InitializeComponent();

            BindingContext = new Habit();
        }

        private async void LoadHabit(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                Habit habit = await App.DB.GetHabitAsync(id);
                BindingContext = habit;
            }
            catch { }
        }

        string color = "#000000";
        private async void AddHabitButton(object sender, EventArgs e)
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

        }
    }
}