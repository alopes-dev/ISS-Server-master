using System;
using System.Linq;
using GraphQL.Types;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using ISS.GraphQL.Type.Base;
using ISS.GraphQL.Repository;
using ISS.GraphQL.Subscription;
using ISS.GraphQL.Type;

namespace ISS.GraphQL.Query
{
    public abstract class AppBase : ObjectGraphType
    {
        protected IRepository Repo { get; }

        // Variavel auxiliar partilhada para que certas classes sejam ignoradas quando.
        protected readonly System.Type[] ignoreTypesShared =
        {
            typeof(LoginType),
            typeof(UsuarioType),
            typeof(RegisterType),
            typeof(DataHoraType),
            typeof(CambioModelType),
            typeof(CambioModelType),
            typeof(PessoaSingularType),
            typeof(PessoaColectivaType),
            typeof(AppQuery),
            typeof(AppMutation),
            typeof(AppSubscription)
        };

        protected AppBase(IRepository repository)
        {
            Repo = repository;
        }

        public List<System.Type> GetGraphTypes()
        {
            // Getting the assembly
            Assembly @this = Assembly.GetExecutingAssembly();
            // Getting the types
            var res = @this.ExportedTypes.Where(x => !x.IsAbstract &&
                                                     typeof(IGraphType).IsAssignableFrom(x) &&
                                                    !x.IsSubclassOf(typeof(InputObjectGraphType)) &&
                                                    !typeof(IInputObjectGraphType).IsAssignableFrom(x)).ToList();
            return res;
        }

        public static List<(System.Type, System.Type)> GetGraphTypesAndInputTypes()
        {

            var res = new List<(System.Type, System.Type)>();

            // Getting the assembly
            Assembly @this = Assembly.GetExecutingAssembly();
            // Getting the types
            var _res_ = @this.ExportedTypes.Where(x => x.FullName.StartsWith("ISS.GraphQL") &&
                                                    x.Name.EndsWith("Type")).ToList();

            // Percorrendo todos os objectos
            for (int i = 0; i < _res_.Count; i++)
            {
                var item = _res_[i];

                // Verificando se é um input para que seja ignorado
                if (item.Name.EndsWith("InputType"))
                    continue;

                System.Type input = null;
                // Pegando o input type do objecto corrente
                for (int k = (i + 1); k < _res_.Count; k++)
                {
                    var x = _res_[k];
                    if (x.Name == item.Name.Replace("Type", "InputType"))
                    {
                        input = x;
                        break;
                    }
                }

                // Verificando se ele foi encontrado
                if (input == null)
                    continue;

                // Adicionando no objecto de retorno
                res.Add((item, input));

            }

            return res;
        }

        public static QueryArgument Arg<T>(string name, object value = default(T)) where T : GraphType
            => new QueryArgument<T> { Name = name, DefaultValue = value };

        public void FieldAsync<TGraphType, TModel>(string name,
            Func<ResolveFieldContext<object>, IRepository, ResolveFieldContext<TModel>> fun, params QueryArgument[] queries)
            where TGraphType : ObjectGraphType<TModel>
            where TModel : class
        {
            // Get Field
            FieldAsync<TGraphType>(
                    name,
                    arguments: queries != null ? new QueryArguments(queries) : null,
                    resolve: async context =>
                    {
                        return await Task.FromResult(fun.Invoke(context, Repo));
                    });
        }

        public void FieldListAsync<TGraphType, TModel>(string name,
            Func<ResolveFieldContext<object>, IRepository, Task<IEnumerable<TModel>>> fun, params QueryArgument[] queries)
            where TGraphType : ObjectGraphType<TModel>
            where TModel : class
        {
            // Get Field
            FieldAsync<ListGraphType<TGraphType>>(
                    name,
                    arguments: queries != null ? new QueryArguments(queries) : null,
                    resolve: async context =>
                    {
                        return await fun.Invoke(context, Repo);
                    });
        }

    }

}