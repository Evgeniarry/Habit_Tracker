using Habit_Tracker.Model;
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
                HabitsList.Add(ha);
            }
        }
    }
}
