using Microsoft.EntityFrameworkCore;
using Timery.Core.Entities;

namespace Timery.EntityFrameworkCore
{
    public class TimeryDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<DailyNote> DailyNotes { get; set; }

        public TimeryDbContext()
        {
            Database.EnsureCreated();
            Database.SetCommandTimeout(120);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Use appsettings.json
            optionsBuilder.UseMySql("server=localhost;user id=root;password=root;database=TimeryDb;Port=3306;");
        }
    }
}
