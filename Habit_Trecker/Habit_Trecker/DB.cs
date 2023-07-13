using Habit_Tracker.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habit_Tracker
{
    public class DB
    {
        private readonly SQLiteAsyncConnection _connection;
        public DB (string path)
        {
            _connection = new SQLiteAsyncConnection (path);
            _connection.CreateTableAsync<Habit>().Wait();
        }

        public Task<List<Habit>> GetHabitsAsync()
        {
            return _connection.Table<Habit>().ToListAsync();
        }

        public Task<Habit> GetHabitAsync(int id)
        {
            return _connection.Table<Habit>()
                .Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveHabitAsync(Habit habit)
        {
            if (habit.ID != 0)
            {
                return _connection.UpdateAsync(habit);
            }
            else
            {
                return _connection.InsertAsync(habit);
            }
        }

        public Task<int> DeliteHabitAsync(Habit habit)
        {
            return _connection.DeleteAsync(habit);
        }
        //public List<Habit> GetHabit() 
        //{
        //    return _connection.Table<Habit>().ToList();
        //}
        //public int SaveHabit(Habit habit)
        //{
        //    return _connection.Insert(habit);
        //}
    }
}
