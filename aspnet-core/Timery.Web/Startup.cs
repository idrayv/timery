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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace Timery.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Take from appconfig.json settings
            services.AddCors(o => o.AddPolicy("TimeryCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // TODO: Optimize DI configuring
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            services.AddScoped<IGraphQueryMarker, EventQuery>();
            services.AddScoped<IGraphQueryMarker, CategoryQuery>();

            services.AddScoped<IGraphMutationMarker, EventMutation>();
            services.AddScoped<IGraphMutationMarker, CategoryMutation>();

            services.AddScoped<TimeryQuery>();
            services.AddScoped<TimeryMutation>();

            services.AddTransient<CategoryType>();
            services.AddTransient<CategoryInputType>();
            services.AddTransient<EventType>();
            services.AddTransient<EventInputType>();

            var provider = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new TimerySchema(new FuncDependencyResolver(provider.GetService)));

            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("TimeryCorsPolicy"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();

            app.UseCors("TimeryCorsPolicy");
        }
    }
}
