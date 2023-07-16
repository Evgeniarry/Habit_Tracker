using SQLite;

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
        public bool IsSelected { get; set; }
    }
}
