using GraphQL.Types;
using ISS.GraphQL.Query;
using ISS.GraphQL.Subscription;
using System;
using Microsoft.Extensions.DependencyInjection;
using ISS.GraphQL.Repository;

namespace ISS.GraphQL
{
    public class AppSchema : Schema
    {
        public IRepository Repository { get; }
        public AppSchema(IServiceProvider service)
        {
            Query = service.GetService<AppQuery>();
            Mutation = service.GetService<AppMutation>();
            Subscription = service.GetService<AppSubscription>();
            Repository = service.GetService<IRepository>();
        }
    }
}
