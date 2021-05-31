using GraphQL_Prototype.GraphQL;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL_Prototype
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>().AddFiltering().AddSorting()
                .AddMutationType<Mutation>()
                .AddErrorFilter<GraphQlErrorFilter>()
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

            services.AddCors(o => o.AddPolicy("CurPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseHttpsRedirection();
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enables playground for GraphQL 
                app.UsePlayground();
            }

            // Enable CORS
            app.UseCors("CurPolicy");
            app.Use((context, next) =>
            {
                context.Items["__CorsMiddlewareInvoked"] = true;
                return next();
            });

            // Enable endpoints for GraphQL
            app.UseEndpoints(x => x.MapGraphQL());
        }
    }
}