using GraphQL.Types;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;
using Timery.Application.GraphQL;
using Timery.Application.Categories.Types;

namespace Timery.Application.Categories
{
    public class CategoryMutation : ObjectGraphType, IGraphMutationMarker
    {
        public CategoryMutation(TimeryDbContext dbContext)
        {
            Name = "CategoryMutation";

            Field<CategoryType>(
                "createCategory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }
                ),
                resolve: context =>
                {
                    var category = context.GetArgument<Category>("category");

                    dbContext.Categories.Add(category);
                    dbContext.SaveChanges();

                    return category;
                }
            );
        }
    }
}
