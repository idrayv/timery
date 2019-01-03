﻿using GraphQL;
using GraphQL.Types;
using Timery.Web.GraphQL;

namespace Timery.Application.GraphQL
{
    public class TimerySchema : Schema
    {
        public TimerySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TimeryQuery>();
            Mutation = resolver.Resolve<TimeryMutation>();
        }
    }
}
