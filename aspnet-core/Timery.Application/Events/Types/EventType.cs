using System.Linq;
using GraphQL.Types;
using Timery.Application.Categories.Types;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;

namespace Timery.Application.Events.Types
{
    public class EventType : ObjectGraphType<Event>
    {
        public EventType(TimeryDbContext dbContext)
        {
            Field(x => x.Id);

            Field(x => x.Date);

            Field(x => x.DurationInMinutes);

            Field(x => x.StartTime);

            Field(x => x.DueTime);

            Field(x => x.Comment, nullable: true);

            Field<CategoryType>(
                "category",
                resolve: context =>
                {
                    var categoryId = context.Source.CategoryId;

                    var category = dbContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

                    return category;
                }
            );
        }
    }
}
