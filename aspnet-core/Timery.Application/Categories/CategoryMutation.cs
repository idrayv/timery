using GraphQL.Types;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;
using Timery.Application.GraphQL;
using Timery.Application.Categories.Types;

namespace Timery.Application.Categories
{
    public class CategoryMutation : ObjectGraphType, IGraphMutationMarker
    {
        public CategoryMutation()
        {
            Name = "CategoryMutation";

            Field<CategoryType>(
                "createCategory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }
                ),
                resolve: context =>
                {
                    // TODO: inject manager or repository
                    // TODO: check how to async
                    var db = new TimeryDbContext();

                    var category = context.GetArgument<Category>("category");

                    db.Categories.Add(category);
                    db.SaveChanges();

                    return category;
                }
            );
        }
    }
}
