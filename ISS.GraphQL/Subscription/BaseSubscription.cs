using System;
using System.Diagnostics;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;

namespace ISS.GraphQL.Subscription
{
    public abstract class BaseSubscription : ObjectGraphType
    {
        #region Protected Methods
        /// <summary>
        /// Adicionar field para subscription.
        /// </summary>
        /// <typeparam name="TGraphType">O tipo do GraphQL a ser considerado na subscrição.</typeparam>
        /// <typeparam name="TReturn">O tipo do valor de retorno.</typeparam>
        /// <param name="fieldName">Nome do field a ser registrado.</param>
        /// <param name="func">Função de subscrição para um determinado tipo do GraphQL.</param>
        /// <returns></returns>
        protected FieldType AddField<TGraphqType, TReturn>(string fieldName = null,Func<ResolveEventStreamContext,IObservable<TReturn>> func = null)
            where TGraphqType: IObjectGraphType
            where TReturn:class
        {
            if (func == null)
                func = Subscribe<TReturn>;

            return AddField(new EventStreamFieldType
            {
                Name = fieldName ?? typeof(TReturn).Name,
                Arguments = new QueryArguments(Arg<StringGraphType>("id")),
                Type = typeof(TGraphqType),
                Resolver = new FuncFieldResolver<TReturn>(Resolve<TReturn>),
                Subscriber = new EventStreamResolver<TReturn>(func)
            });
        }

        public static QueryArgument Arg<T>(string name, object value = default(T)) where T : GraphType
            => new QueryArgument<T> { Name = name, DefaultValue = value };
        
        protected FieldType AddField<TGraphqType, TModel,TReturn>(string fieldName = null,Func<ResolveEventStreamContext,IObservable<TReturn>> func = null)
            where TGraphqType: IObjectGraphType
            where TReturn:class
            where TModel:class
        {
            if (func == null)
                func = Subscribe<TReturn>;

            return AddField(new EventStreamFieldType
            {
                Name = fieldName ?? typeof(TModel).Name,
                Type = typeof(TGraphqType),
                Resolver = new FuncFieldResolver<TReturn>(Resolve<TReturn>),
                Subscriber = new EventStreamResolver<TReturn>(func)
            });
        }
         

        /// <summary>
        /// Resolver o valor de um type baseado em um contexto.
        /// </summary>
        /// <typeparam name="TReturn">O tipo do valor de retorno.</typeparam>
        /// <param name="context">Context usado para obter o valor a ser resolvido.</param>
        /// <returns></returns>
        protected TReturn Resolve<TReturn>(ResolveFieldContext context)
            where TReturn : class
        {
            var value = context.Source as TReturn;

            Debug.Assert(value != null);

            return value;
        }

        /// <summary>
        /// Resolver a subscrição feita ao se adicionar fields, ou seja, retornar os dados certos
        /// como listeners
        /// </summary>
        /// <typeparam name="TReturn">O tipo do dado a ser retornado.</typeparam>
        /// <param name="context">Context para aceder informações de evento.</param>
        /// <returns></returns>
        protected abstract IObservable<TReturn> Subscribe<TReturn>(ResolveEventStreamContext context) where TReturn : class;
        #endregion
    }
}