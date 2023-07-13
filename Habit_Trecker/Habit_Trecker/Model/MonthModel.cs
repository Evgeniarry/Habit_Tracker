using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Tracker.Model
{
    public class MonthModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Month { get; set; }
        public List<DayModel> Days { get; set; } = new List<DayModel>();

    }
}
