﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace Habit_Tracker.Model
{
    public class DayModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool IsSelected { get; set; }

        public int Day { get; set; }

        public string Month { get; set; }

        public Habit Habit { get; set; } = new Habit();
    }
}