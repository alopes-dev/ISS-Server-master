using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using ISS.GraphQL.Identity;
using ISS.GraphQL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISS.GraphQL.ServiceExtentions
{
    public static class ISSGraphQLSetupExtensions
    {
        public static IServiceCollection AddISSGraphQL(this IServiceCollection services,IConfiguration configuration,bool isDevelopment = true)
        {
            services.AddSingleton<IRepository, Repository.Repository>()
                    .AddSingleton<ISubscriptionRepository, SubscriptionRepository>()
                    .AddSingleton<ISchema,AppSchema>()
                    .AddGraphQL(options =>
                    {
                        options.EnableMetrics = true;
                        options.ExposeExceptions = isDevelopment;
                    })
                    .AddUserContextBuilder(context =>
                    {
                        var user = context.User;
                        return new GraphQLUserContext { User = user };
                    })
                    .AddDataLoader()
                    .AddGraphTypes()
                    .AddWebSockets();
            return services;
        }

        public static IApplicationBuilder UseISSGraphQL(this IApplicationBuilder app)
        {
            app.UseGraphQLWebSockets<ISchema>("/api/graphql");

            app.UseGraphQL<ISchema>("/api/graphql");

            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphQLEndPoint = "/api/graphql"
            });

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions 
            {
                GraphQLEndPoint = "/api/graphql"
            });

            return app;
        }
    }
}