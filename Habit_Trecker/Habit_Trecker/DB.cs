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
            _connection.CreateTableAsync<DayModel>().Wait();
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
        public async Task<int> GetNoDoneHabits()
        {
            int count = 0;
            List<Habit> list = new List<Habit>();
            list = await GetHabitsAsync();
            foreach (Habit hab in list) 
            {
                if (hab.IsSelected == false)
                    count++;
            }
            return count;
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

        public void SaveHabitsAsync (List<Habit> habits) 
        {
            foreach(Habit h in habits) 
            {
                if (h.ID != 0)
                {
                    _connection.UpdateAsync(h);
                }
                else
                {
                    _connection.InsertAsync(h);
                }
            }
        }

        public Task<int> DeliteHabitAsync(Habit habit)
        {
            return _connection.DeleteAsync(habit);
        }

        public Task<List<DayModel>> GetDaysAsync(int chosehabit)
        {
            return _connection.Table<DayModel>().Where(i => i.HabitID == chosehabit).ToListAsync();
        }
        public Task<int> GetDaysCount()
        {
            return _connection.Table<DayModel>().CountAsync();
        }
        public Task<int> GetHabitCount()
        {
            return _connection.Table<Habit>().CountAsync();
        }
        public Task<int> SaveDayAsync(DayModel day)
        {
            return _connection.InsertAsync(day);
        }
        public Task<int> DeliteDayAsync(DayModel day)
        {
            return _connection.DeleteAsync(day);
        }
        public Task<Habit> GetDayAsync(int id)
        {
            return _connection.Table<Habit>()
                .Where(i => i.ID == id).FirstOrDefaultAsync();
        }
    }
}
