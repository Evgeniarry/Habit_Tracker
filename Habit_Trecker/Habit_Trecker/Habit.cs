using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Tracker
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name {get; set;}
        public string Description { get; set;}
        public int Progress { get; set;}

    }

}
