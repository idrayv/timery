using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using GraphQL;
using GraphiQl;
using GraphQL.Types;
using Timery.Application.GraphQL;
using Timery.Application.Types.Categories;

namespace Timery.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<TimeryQuery>();
            services.AddSingleton<TimeryMutation>();

            services.AddSingleton<CategoryType>();
            services.AddSingleton<CategoryInputType>();

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
