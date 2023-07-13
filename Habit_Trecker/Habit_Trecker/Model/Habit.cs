﻿using SQLite;
using System.Collections.Generic;

namespace Habit_Tracker.Model
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public string Color { get; set; }
        
    }
}