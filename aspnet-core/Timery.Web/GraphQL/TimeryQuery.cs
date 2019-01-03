using System.Linq;
using GraphQL.Types;
using Timery.EntityFrameworkCore;
using Timery.Web.GraphQL.Types.Categories;

namespace Timery.Web.GraphQL
{
    public class TimeryQuery : ObjectGraphType
    {
        public TimeryQuery()
        {
            // TODO: inject manager or repository
            var db = new TimeryDbContext();

            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: (context) =>
                {
                    var id = context.GetArgument<int>("id");
                    var data = db.Categories.Where(c => c.Id == id).FirstOrDefault();
                    return data;
                }
            );

            Field<ListGraphType<CategoryType>>(
                "categories",
                resolve: context => db.Categories.ToList()
            );
        }
    }
}
