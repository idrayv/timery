using System.Linq;
using GraphQL.Types;
using Timery.EntityFrameworkCore;
using Timery.Application.Categories.Types;
using Timery.Application.GraphQL;

namespace Timery.Application.Categories
{
    public class CategoryQuery : ObjectGraphType, IGraphQueryMarker
    {
        public CategoryQuery(TimeryDbContext dbContext)
        {
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: (context) =>
                {
                    var id = context.GetArgument<int>("id");
                    var data = dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
                    return data;
                }
            );

            Field<ListGraphType<CategoryType>>(
                "categories",
                resolve: context => dbContext.Categories.ToList()
            );
        }
    }
}
