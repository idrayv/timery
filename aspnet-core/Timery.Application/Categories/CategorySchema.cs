using GraphQL;
using GraphQL.Types;

namespace Timery.Application.Categories
{
    public class CategorySchema : Schema
    {
        public CategorySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CategoryQuery>();
            Mutation = resolver.Resolve<CategoryMutation>();
        }
    }
}
