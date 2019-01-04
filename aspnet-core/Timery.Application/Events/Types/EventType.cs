using System.Linq;
using GraphQL.Types;
using Timery.Application.Categories.Types;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;

namespace Timery.Application.Events.Types
{
    public class EventType : ObjectGraphType<Event>
    {
        public EventType()
        {
            Field(x => x.Id);

            Field<CategoryType>(
                "category",
                resolve: context =>
                {
                    var categoryId = context.Source.CategoryId;

                    // TODO: inject manager or repository
                    var db = new TimeryDbContext();
                    var category = db.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

                    return category;
                }
            );
        }
    }
}
