using GraphQL.Types;
using Timery.Core.Entities;

namespace Timery.Application.Categories.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
