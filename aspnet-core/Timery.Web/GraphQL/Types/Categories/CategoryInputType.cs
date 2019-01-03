using GraphQL.Types;

namespace Timery.Web.GraphQL.Types.Categories
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
