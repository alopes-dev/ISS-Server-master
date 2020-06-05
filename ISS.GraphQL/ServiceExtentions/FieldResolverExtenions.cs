using GraphQL;
using GraphQL.Types;
using System.Linq;
using ISS.GraphQL.Repository;

namespace ISS.GraphQL.ServiceExtentions
{
    public static class ResolverFieldExtenions
    {
        public static T Resolve<T, TObject>(this ResolveFieldContext<TObject> field, RepoResponse<T> response)
            where T : class
        {
            // Checking the errors
            if (response.Errors?.Count() > 0)
                // Looping them
                foreach (var e in response.Errors)
                    // Adding them
                    field.Errors.Add(new ExecutionError(e));

            // Returing the data
            return response.Data;
        }

        public static T Resolve<T, TObject>(this ResolveFieldContext<TObject> field, T data)
            where T : class,new()
        {
           return data;
        }

        public static IRepository GetRepository<T>(this ResolveFieldContext<T> field)
            where T : class
        {
            return (field.Schema as AppSchema)?.Repository;
        }
    }
}
