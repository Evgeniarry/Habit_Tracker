using Habit_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Habit_Tracker.ViewModel
{
    public class HabitViewModel : BaseViewModel
    {
        ObservableCollection<Habit> _habitList;
        public ObservableCollection<Habit> HabitsList
        {
            get { return _habitList; }
            set
            {
                _habitList = value;
                OnPropertyChanged();
            }
        }

        public HabitViewModel(List<Habit> habits)
        {
            HabitsList = new ObservableCollection<Habit>();
            foreach (Habit ha in habits) 
            { 
                if((ha.DateHabit.Year<DateTime.Now.Year) ||
                   (ha.DateHabit.Month < DateTime.Now.Month) ||
                   (ha.DateHabit.Day < DateTime.Now.Day))
                {
                    ha.DateHabit = DateTime.Now;
                    ha.IsSelected = false;
                    Upgrade(ha);
                }
                HabitsList.Add(ha);
            }
        }
        public async void Upgrade(Habit habit)
        {
            await App.DB.SaveHabitAsync(habit);
        }
    }
}
