using Habit_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Habit_Tracker.ViewModel
{
    class HabitViewModel : BaseViewModel
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
        protected List<Habit> h = new List<Habit>();
        public async void GetObsColl()
        {
            h = await App.DB.GetHabitsAsync();
        }
        public HabitViewModel()
        {
            HabitsList = new ObservableCollection<Habit>();
            foreach (Habit ha in h) 
            { 
                HabitsList.Add(ha);
            }
        }

        //internal string Serialize()
        //{
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(HabitsList);
        //}

        //internal void Deserialize(string list)
        //{
        //    HabitsList = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Habit>>(list);
        //}


        //public void CheckItem(Habit item)
        //{
        //    int index = HabitsList.IndexOf(item);
        //    HabitsList.Remove(item);
        //    HabitsList.Insert(index, new Habit
        //    {
        //        Name = item.Name,
        //        IsSelected = !item.IsSelected,
        //    });
        //}

        //public void DeleteItem(Habit item)
        //{
        //    HabitsList.Remove(item);
        //}

        //public void AddItem(string text)
        //{
        //    HabitsList.Add(new Habit
        //    {
        //        Name = text,
        //        IsSelected = false,
        //    });
        //}
    }
}
