using System;

namespace Timery.Core.Entities
{
    public class Event : Entity<long>
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan DueTime { get; set; }
        public string Comment { get; set; }
    }
}
