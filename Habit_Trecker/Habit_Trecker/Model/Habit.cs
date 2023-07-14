using SQLite;
using System.Collections.Generic;
using System.Drawing;

namespace Habit_Tracker.Model
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public string Image { get; set; }

        [Ignore]
        public List<DayModel> Days { get; set; }=new List<DayModel>();

    }
}
