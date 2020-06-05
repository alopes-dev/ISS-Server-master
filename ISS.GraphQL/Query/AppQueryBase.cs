using System;
using GraphQL.Types;
using ISS.Application.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using ISS.GraphQL.Repository;
using ISS.GraphQL.ServiceExtentions;

namespace ISS.GraphQL.Query
{
    public abstract class AppQueryBase : AppBase
    {
        protected AppQueryBase(IRepository repository) : base(repository) { }

        public void FieldAsync<TGraphType, TModel>(Func<ResolveFieldContext<object>, Task<RepoResponse<IEnumerable<TModel>>>> customResolve = null)
            where TGraphType : ObjectGraphType<TModel>
            where TModel : class
        {
            var typeName = typeof(TGraphType).Name.Replace("Type", string.Empty);
            // Get Field
            FieldAsync<ListGraphType<TGraphType>>(
                    $"all{typeName}",
                    arguments: new QueryArguments(
                        Arg<StringGraphType>("consts"),
                        Arg<StringGraphType>("id"),
                        Arg<BooleanGraphType>("search"),
                        Arg<StringGraphType>("orderby"),
                        Arg<BooleanGraphType>("asc", true)
                        ),
                    resolve: async context =>
                    {
                        if (customResolve != null)
                            return context.Resolve(await customResolve(context));

                        return context.Resolve(await Repo.GetWhereAsync<TModel>
                                                (context.GetArgument<string>("consts"), 
                                                context.GetArgument<string>("id"), 
                                                context.GetArgument<bool?>("search"), 
                                                context.GetArgument<string>("orderby"), 
                                                context.GetArgument<bool>("asc")));
                    });

            // Get One Field
            FieldAsync<TGraphType>(
                    typeName.ToLowerFirstChar(),
                    arguments: new QueryArguments(
                        Arg<NonNullGraphType<StringGraphType>>("id"),
                        Arg<StringGraphType>("consts")),
                    resolve: async context =>
                    {
                        return await Repo.GetAsync<TModel>
                                                (context.GetArgument<string>("id"), 
                                                context.GetArgument<string>("consts"));
                    });
        }

        public void FieldGenericAsync<TGraphType, TModel>()
            where TGraphType : ObjectGraphType<TModel>
            where TModel : class
            => FieldAsync<TGraphType, TModel>();

    }
   
}

