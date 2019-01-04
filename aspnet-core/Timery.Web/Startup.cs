using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using GraphQL;
using GraphiQl;
using GraphQL.Types;
using Timery.Application.Categories;
using Timery.Application.Events;
using Timery.Application.Categories.Types;
using Timery.Application.Events.Types;
using Timery.Application.GraphQL;

namespace Timery.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<IGraphQueryMarker, EventQuery>();
            services.AddSingleton<IGraphQueryMarker, CategoryQuery>();

            services.AddSingleton<TimeryQuery>();

            services.AddSingleton<CategoryQuery>();
            services.AddSingleton<CategoryMutation>();
            services.AddSingleton<CategoryType>();
            services.AddSingleton<CategoryInputType>();

            services.AddSingleton<EventQuery>();
            services.AddSingleton<EventMutation>();
            services.AddSingleton<EventType>();
            services.AddSingleton<EventInputType>();

            var provider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new TimerySchema(new FuncDependencyResolver(provider.GetService)));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
