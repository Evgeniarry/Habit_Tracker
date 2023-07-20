using Habit_Tracker.Model;
using System;
using System.Collections.Generic;
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
            int year = 0;
            int month = 0;
            int week = 0;
            List<DayModel> day = await App.DB.GetDaysAsync(value);
            foreach (DayModel dayModel in day)
            {
                if (dayModel.Day >= DateTime.Now.AddDays(-365).Day)
                {
                    year += 1;
                }
                if (dayModel.Day >= DateTime.Now.AddDays(-30).Day)
                {
                    month += 1;
                }
                if (dayModel.Day >= DateTime.Now.AddDays(-7).Day)
                {
                    week += 1;
                }
            }
            week = week * 100 / 7;
            WeekProgress.Text = $"{week}%";
            month = month * 100 / 30;
            MonthProgress.Text = $"{month}%";
            year = year * 100 / 365;
            YearProgress.Text = $"{year}%";
        }

        private async void SaveHabitButton(object sender, EventArgs e)
        {
            Habit habit = (Habit)BindingContext;
            if ((habit.Name == NameHabit.Text.Trim()) || (habit.Description == Description.Text.Trim()))
                return;
            habit.Name = NameHabit.Text.Trim();
            habit.Description = Description.Text.Trim();
            
            if ((!string.IsNullOrWhiteSpace(habit.Name)) && (!string.IsNullOrWhiteSpace(habit.Description)))
            {
                await App.DB.SaveHabitAsync(habit);
                await DisplayAlert("Привычка", "Изменения сохранены", "OK");
            }
            else
                await DisplayAlert("Привычка", "Добавьте название и описание", "OK");
        }

        private async void DeliteHabitButton(object sender, EventArgs e)
        {
            Habit habit = (Habit)BindingContext;
            await App.DB.DeliteHabitAsync(habit);
            await Navigation.PopAsync();
            await Navigation.PushAsync(new MainPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Habit habit = (Habit)BindingContext;
            await Navigation.PushAsync(new StatisticPage(habit.ID));
        }
    }
}