using GraphQL.Types;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;
using Timery.Application.GraphQL;
using Timery.Application.Events.Types;

namespace Timery.Application.Events
{
    public class EventMutation : ObjectGraphType, IGraphMutationMarker
    {
        public EventMutation()
        {
            Name = "EventMutation";

            Field<EventType>(
                "createEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EventInputType>> { Name = "event" }
                ),
                resolve: context =>
                {
                    // TODO: inject manager or repository
                    // TODO: check how to async
                    var db = new TimeryDbContext();

                    var userEvent = context.GetArgument<Event>("event");

                    db.Events.Add(userEvent);
                    db.SaveChanges();

                    return userEvent;
                }
            );
        }
    }
}
