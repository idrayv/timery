using GraphQL;
using GraphQL.Types;

namespace Timery.Application.Events
{
    public class EventSchema : Schema
    {
        public EventSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<EventQuery>();
            Mutation = resolver.Resolve<EventMutation>();
        }
    }
}
