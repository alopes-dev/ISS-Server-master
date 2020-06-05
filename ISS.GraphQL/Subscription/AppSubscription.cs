using GraphQL.Subscription;
using GraphQL.Types;
using ISS.GraphQL.Repository;
using ISS.Application.Models;
using ISS.Application.Dto;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Reactive.Linq;
using System.Diagnostics;
using ISS.GraphQL.Type;

namespace ISS.GraphQL.Subscription
{
    public class AppSubscription : BaseSubscription
    {
        #region Private Members
        /// <summary>
        /// Repo como camada facilitadora para obtenção de dados.
        /// </summary>
        private readonly ISubscriptionRepository _repository;
        #endregion

        

        #region Constructor
        /// <summary>
        ///Constructor padrão.
        /// </summary>
        /// <returns></returns>
        public AppSubscription(ISubscriptionRepository repository)
        {

            _repository = repository;
        
            AddField<EstadoType, Estado>();
            AddField<AutomovelType, Automovel>();
            AddField<PlanoObjectivoComercialType, PlanoObjectivoComercial>();
            AddField<GetPlanoType,PlanoObjectivoCormecialDto>("GetPlano",_repository.PiPlanoObjectivoComercial);
            AddField<GetPlanoProdutoType,PlanoCormecialProdutoDto>("GetPlanoLinhaProduto",_repository.QuaPlanoObjectivoComercial);
            AddField<SinistroGraphicoType,Sinistrographico>("Sinistropessoa",_repository.Sinistropessoa);
            //AddField<SinistroGraphicoType,Sinistrographico>("Sinistroproduto",_repository.Sinistroproduto);
            AddField<ApoliceGraphicoType,ApoliceGraphico>("Apolicepessoa",_repository.Apolicepessoa);
            }

        private ListGraphType<SinistroGraphicoType> SinistroResolve(ResolveFieldContext context)
        {
            var value = context.Source as ListGraphType<SinistroGraphicoType>;

            Debug.Assert(value != null);

            return value;
        }

        public IObservable<Sinistrographico[]> Sinistroproduto(ResolveEventStreamContext context)
          {
            var conString = "Data Source=172.16.16.18;Initial Catalog=DBIS_DEV;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;";
            using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"select COUNT(*) as QtdSinistro,LinhaProduto.Designacao as Produto from Sinistro,Pessoa,LinhaProduto,PlanoProduto where Sinistro.ParticipanteSinistroID=Pessoa.IdPessoa and Sinistro.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto Group by LinhaProduto.Designacao";
                var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                var casted = Observable.ToArray(sinistrs.ToObservable());
                return casted;
            }
         }

        /// <summary>
        /// Padrão de subscrição para todos os fields adicionados.
          /// </summary>
        /// <typeparam name="TReturn">O tipo do dado a ser retornado.</typeparam>
        /// <param name="context">Context para subscrição.</param>
        /// <returns></returns>
        protected override IObservable<TReturn> Subscribe<TReturn>(ResolveEventStreamContext context)
        {
            var value = _repository.Get<TReturn>();
            return value;
        }
        
        #endregion

    }
}