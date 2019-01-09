using System;

namespace Timery.Core.Entities
{
    public class DailyNote : Entity<long>
    {
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan DueTime { get; set; }
    }
}
