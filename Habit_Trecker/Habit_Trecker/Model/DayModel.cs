using SQLite;


namespace Habit_Tracker.Model
{
    public class DayModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        [Indexed]
        public int HabitID { get; set; }

    }
}
