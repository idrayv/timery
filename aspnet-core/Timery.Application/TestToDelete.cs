using System;
using System.Linq;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;

namespace Timery.Application
{
    public class TestToDelete
    {
        public void Test()
        {
            using (var db = new TimeryDbContext())
            {
                db.Categories.Add(new Category { Name = Guid.NewGuid().ToString()});
                db.SaveChanges();
                db.Categories.FirstOrDefault();
            }
        }
    }
}
