using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Tracker
{
    public class DB
    {
        private readonly SQLiteConnection _connection;
        public DB (string path)
        {
            _connection = new SQLiteConnection (path);
            _connection.CreateTable<Habit>();
        }
        public List<Habit> GetHabit() 
        {
            return _connection.Table<Habit>().ToList();
        }
        public int SaveHabit(Habit habit)
        {
            return _connection.Insert(habit);
        }
    }
}
