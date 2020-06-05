using System;
using GraphQL.Types;
using System.Threading.Tasks;
using ISS.GraphQL.Repository;

namespace ISS.GraphQL.Query
{
    public class Param<TModel> where TModel : class
    {
        public Func<TModel, ResolveFieldContext<object>, Task<RepoResponse<TModel>>> Add { get; set; } = null;
        public Func<TModel, string, ResolveFieldContext<object>, Task<RepoResponse<TModel>>> Update { get; set; } = null;
        public Func<string, ResolveFieldContext<object>, Task<RepoResponse<TModel>>> Remove { get; set; } = null;
    }

}