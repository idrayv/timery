namespace Timery.Core.Entities
{
    public class Event : Entity<long>
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
