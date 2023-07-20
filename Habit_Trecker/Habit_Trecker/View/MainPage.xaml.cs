using Habit_Tracker.Model;
using Habit_Tracker.View;
using Habit_Tracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Habit_Tracker
{
    public partial class MainPage : ContentPage
    {
        private HabitViewModel habitViewModel;

        public MainPage()
        {

            InitializeComponent();
            labelDate.Text = DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("ru"));

        }

        List<Habit> hab;
        int count;
        protected override async void OnAppearing()
        {
            hab = await App.DB.GetHabitsAsync();
            habitViewModel = new HabitViewModel(hab);
            BindingContext = habitViewModel;
            count = await App.DB.GetNoDoneHabits();
            noneDone.Text = LabelCount(count);
        }

        public String LabelCount(int c)
        {
            if ((c == 0) && (hab.Count > 0))
                return "Все задачи выполнены!";
            else if (c == 0)
                return "У тебя ещё нет ни одной \nпривычки, самое время\nдобавить первую привычку.";
            else if ((c == 13) || (c == 14) || (c == 12) || (c == 11))
                return $"Привет, у тебя осталость \nвсего {c} задач на сегодня!";
            else if (c%10 == 1)
                return $"Привет, у тебя осталась \nвсего {c} задача на сегодня!";
            else if ((c % 10 == 2) || (c % 10 == 3) || (c % 10 == 4))
                return $"Привет, у тебя осталось \nвсего {c} задачи на сегодня!";
            else
                return $"Привет, у тебя осталость \nвсего {c} задач на сегодня!";
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHabit());  
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            DayModel model = new DayModel();
            Habit habit = (Habit)((Switch)sender).BindingContext;
            Switch switch1 = (Switch)sender;
            model.Day = DateTime.Now.Day;
            model.Month = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            habit.DateHabit = DateTime.Now;
            model.HabitID = habit.ID;
            List<DayModel> dayModels = await App.DB.GetDaysAsync(habit.ID);
            foreach (DayModel day in dayModels)
            {
                if ((day.Day == model.Day) &&
                    (day.Month == model.Month) &&
                    (day.Year == model.Year))
                {
                    await App.DB.DeliteDayAsync(day);
                }
            }
            if (switch1.IsToggled)
            {
                habit.IsSelected = true;
                await App.DB.SaveDayAsync(model);
            }
            else
            {
                habit.IsSelected = false;
                
            }
            await App.DB.SaveHabitAsync(habit);
            count = await App.DB.GetNoDoneHabits();
            noneDone.Text = LabelCount(count);
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null) 
            {
                Habit habit = (Habit)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new EditPage(habit.ID));
            }
        }
    }
}
