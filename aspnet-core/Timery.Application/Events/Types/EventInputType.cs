using GraphQL.Types;

namespace Timery.Application.Events.Types
{
    public class EventInputType : InputObjectGraphType
    {
        public EventInputType()
        {
            Name = "EventInput";
            Field<NonNullGraphType<IntGraphType>>("categoryId");
        }
    }
}
