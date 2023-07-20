using Habit_Tracker.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Habit_Tracker.View
{
    public partial class StatisticPage : ContentPage
    {
        int IDHabit;
        public StatisticPage(int ID)
        {
            InitializeComponent();
            IDHabit = ID;
            Load();
        }    
        public async void Load()
        {
            int year=0;
            int month = 0;
            int week = 0;
            List<DayModel> day= await App.DB.GetDaysAsync(IDHabit);
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
            week = week*100 / 7;
            WeekProgress.Text = $"{week} % Неделя";
            month = month * 100 / 30;
            MonthProgress.Text = $"{month} % Месяц";
            year = year * 100 / 365;
            YearProgress.Text = $"{year} % Год";

        }
    }
}