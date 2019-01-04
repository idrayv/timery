using GraphQL.Types;

namespace Timery.Application.Categories.Types
{
    public class CategoryInputType : InputObjectGraphType
    {
        public CategoryInputType()
        {
            Name = "CategoryInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
