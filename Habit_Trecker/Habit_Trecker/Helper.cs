using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms;
using Habit_Tracker.Model;
using System.Threading.Tasks;

namespace Habit_Tracker
{
    public class Helper : INotifyPropertyChanged
    {
        public ObservableCollection<Habit> source;
        //public ObservableCollection<PetProfile> PetInfo { get; private set; }
        public ObservableCollection<Habit> EmptyHabitInfo
        {
            get => source;
            private set
            {
                if (value != source)
                {
                    source = value;
                    OnPropertyChanged(nameof(EmptyHabitInfo));
                }
            }
        }

        int _count;
        public int Count
        {
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count));

                    Sel = "Amount of selected habits is : " + Convert.ToString(_count);
                }
            }
            get
            {
                return _count;
            }
        }

        public void updateCount(int count)
        {

        }

        String sel;
        public String Sel
        {
            set
            {
                if (sel != value)
                {
                    sel = value;
                    OnPropertyChanged(nameof(Sel));
                }
            }
            get
            {
                return sel;
            }
        }
        
        public Helper()
        {
            EmptyHabitInfo = new ObservableCollection<Habit>();
            
            //EmptyHabitInfo.Add(new PetProfile { PetName = "Pet1", IsSelected = false, ImageUrl = "cherry.png" });
            //EmptyHabitInfo.Add(new PetProfile { PetName = "Pet2", IsSelected = false, ImageUrl = "watermelon.png" });
            //EmptyHabitInfo.Add(new PetProfile { PetName = "Pet3", IsSelected = false, ImageUrl = "cherry.png" });
            //EmptyHabitInfo.Add(new PetProfile { PetName = "Pet4", IsSelected = false, ImageUrl = "watermelon.png" });
            //EmptyHabitInfo.Add(new PetProfile { PetName = "Pet5", IsSelected = false, ImageUrl = "cherry.png" });
            //EmptyHabitInfo.Add(new PetProfile { PetName = "Pet6", IsSelected = false, ImageUrl = "watermelon.png" });

            foreach (Habit hab in EmptyHabitInfo)
            {
                if (hab.IsSelected)
                {
                    Count++;
                }

            }
            Sel = "Amount of selected pets is : " + Convert.ToString(Count);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
