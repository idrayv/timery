using System.Linq;
using GraphQL.Types;
using Timery.EntityFrameworkCore;
using Timery.Application.Events.Types;
using Timery.Application.GraphQL;

namespace Timery.Application.Events
{
    public class EventQuery : ObjectGraphType, IGraphQueryMarker
    {
        public EventQuery()
        {
            // TODO: inject manager or repository
            var db = new TimeryDbContext();

            Field<EventType>(
                "event",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: (context) =>
                {
                    var id = context.GetArgument<int>("id");
                    var data = db.Events.Where(c => c.Id == id).FirstOrDefault();
                    return data;
                }
            );

            Field<ListGraphType<EventType>>(
                "events",
                resolve: context => db.Events.ToList()
            );
        }
    }
}
