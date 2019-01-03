using GraphQL.Types;

namespace Timery.Application.Types.Categories
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
