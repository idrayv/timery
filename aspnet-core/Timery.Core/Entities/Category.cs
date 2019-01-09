namespace Timery.Core.Entities
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
        public bool CanContainDuration { get; set; }
        public bool CanContainComment { get; set; }
    }
}
