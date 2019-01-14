using GraphQL.Types;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;
using Timery.Application.GraphQL;
using Timery.Application.Events.Types;

namespace Timery.Application.Events
{
    public class EventMutation : ObjectGraphType, IGraphMutationMarker
    {
        public EventMutation(TimeryDbContext dbContext)
        {
            Name = "EventMutation";

            Field<EventType>(
                "createEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EventInputType>> { Name = "event" }
                ),
                resolve: context =>
                {
                    var userEvent = context.GetArgument<Event>("event");

                    dbContext.Events.Add(userEvent);
                    dbContext.SaveChanges();

                    return userEvent;
                }
            );
        }
    }
}
