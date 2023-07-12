using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Tracker
{
    public class DayModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private bool IsSelected { get; set; }

        public int Day { get; set; }

        public string Month { get; set; }

        public override string ToString()
        {
            return $"{Day}-{Month}-{IsSelected}";
        }
    }
}
