using GraphQL.Types;
using Timery.Core.Entities;
using Timery.EntityFrameworkCore;
using Timery.Application.Types.Categories;

namespace Timery.Application.GraphQL
{
    public class TimeryMutation : ObjectGraphType
    {
        public TimeryMutation()
        {
            Name = "CreateCategoryMutation";

            Field<CategoryType>(
                "createCategory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }
                ),
                resolve: context =>
                {
                    // TODO: inject manager or repository
                    var db = new TimeryDbContext();

                    var category = context.GetArgument<Category>("category");

                    return db.Categories.AddAsync(category);
                }
            );
        }
    }
}
