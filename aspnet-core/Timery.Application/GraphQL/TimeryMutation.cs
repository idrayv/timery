using System.Collections.Generic;
using GraphQL.Types;

namespace Timery.Application.GraphQL
{
    public class TimeryMutation : ObjectGraphType
    {
        public TimeryMutation(IEnumerable<IGraphMutationMarker> graphMutationMarkers)
        {
            Name = "TimeryMutation";

            foreach (var marker in graphMutationMarkers)
            {
                var q = marker as ObjectGraphType;
                foreach (var f in q.Fields)
                {
                    AddField(f);
                }
            }
        }
    }
}
