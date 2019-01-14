using System.Linq;
using GraphQL.Types;
using Timery.EntityFrameworkCore;
using Timery.Application.Events.Types;
using Timery.Application.GraphQL;

namespace Timery.Application.Events
{
    public class EventQuery : ObjectGraphType, IGraphQueryMarker
    {
        public EventQuery(TimeryDbContext dbContext)
        {
            Field<EventType>(
                "event",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: (context) =>
                {
                    var id = context.GetArgument<int>("id");
                    var data = dbContext.Events.Where(c => c.Id == id).FirstOrDefault();
                    return data;
                }
            );

            Field<ListGraphType<EventType>>(
                "events",
                resolve: context => dbContext.Events.ToList()
            );
        }
    }
}
