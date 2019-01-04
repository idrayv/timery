using System.Collections.Generic;
using GraphQL.Types;

namespace Timery.Application.GraphQL
{
    public class TimeryQuery : ObjectGraphType
    {
        public TimeryQuery(IEnumerable<IGraphQueryMarker> graphQueryMarkers)
        {
            Name = "TimeryQuery";

            foreach (var marker in graphQueryMarkers)
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
