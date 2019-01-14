using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Timery.Core.Entities;

namespace Timery.EntityFrameworkCore
{
    public class TimeryDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        public TimeryDbContext(DbContextOptions<TimeryDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.SetCommandTimeout(120);
        }
    }
}
