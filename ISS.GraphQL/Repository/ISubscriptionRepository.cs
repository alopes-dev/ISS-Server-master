using System.Data.SqlClient;
using ISS.Application.Models;
using ISS.Application.Dto;
using System;
using Dapper;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using GraphQL.Subscription;
using System.Collections.ObjectModel;

namespace ISS.GraphQL.Repository
{
    public interface ISubscriptionRepository
    {
        IObservable<TReturn> Get<TReturn>() where TReturn : class;
        IObservable<PlanoCormecialProdutoDto> QuaPlanoObjectivoComercial(ResolveEventStreamContext context);
        IObservable<PlanoObjectivoCormecialDto> PiPlanoObjectivoComercial(ResolveEventStreamContext context);
        IObservable<Sinistrographico>  Sinistropessoa(ResolveEventStreamContext context);
        IObservable<Sinistrographico>  Sinistroproduto(ResolveEventStreamContext context);
        IObservable<ApoliceGraphico> Apolicepessoa(ResolveEventStreamContext context);
        IObservable<ApoliceGraphico> Apoliceproduto(ResolveEventStreamContext context);
        Task<IObservable<TReturn>> GetAsync<TReturn>() where TReturn : class;

        void Push<TModel>(TModel model) where TModel : class;
    }

    public class SubscriptionRepository : ISubscriptionRepository
    {
        #region Membros Privados
        /// <summary>
        /// Para manter uma lista de objectos subscritos baseados em uma chave.
        /// </summary>
        private readonly ConcurrentDictionary<string, ISubject<object>> _stream;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Padrão.
        /// </summary>
        public SubscriptionRepository(IConfiguration configuration)
        {
            _stream = new ConcurrentDictionary<string, ISubject<object>>();
            _configuration = configuration;
        }

        public SubscriptionRepository()
        {
        }
        #endregion

        public IObservable<TReturn> Get<TReturn>() 
            where TReturn : class
        {
                var value = _stream.GetValueOrDefault(typeof(TReturn).Name);

                if (value == null)
                {
                    value = new ReplaySubject<object>(1);
                    if(typeof(TReturn) == typeof(PlanoObjectivoComercial))
                    {
                        var plano = GetObjectivoComercial().First();
                        value.OnNext(plano);
                    }

                    _stream.TryAdd(typeof(TReturn).Name, value);
                }

                return value.AsObservable().Cast<TReturn>();
        }

        public Task<IObservable<TReturn>> GetAsync<TReturn>() where TReturn : class
        {
            var value = _stream.GetValueOrDefault(typeof(TReturn).Name);

            if (value == null)
            {
                value = new ReplaySubject<object>(1);
                _stream.TryAdd(typeof(TReturn).Name, value);
            }

            return Task.FromResult(value.AsObservable().Cast<TReturn>());
        }

        public void Push<TModel>(TModel model) where TModel : class
        {
            var container = _stream.GetValueOrDefault(typeof(TModel).Name);
            if(typeof(TModel) == typeof(PlanoObjectivoComercial))
            {
                var newModel = model as PlanoObjectivoComercial;
                var plano = GetObjectivoComercial()?.FirstOrDefault(x => x.PlanoProdutoId == newModel.PlanoProdutoId && x.PlanoProdutoId == newModel.PlanoProdutoId) ?? newModel;
                
                plano.LinhaProduto = GetLinhaProduto(newModel.LinhaProdutoId);
                plano.PlanoProduto = GetPlano(newModel.PlanoProdutoId);
                


                container?.OnNext(plano);
            }
            else
            {
                container?.OnNext(model);
            }
        }

            /// <summary>
            /// TODO: Criar um store procedure
            /// </summary>
            /// <returns></returns>        
         private IEnumerable<PlanoObjectivoComercial> GetObjectivoComercial()
         {
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
                using(var con = new SqlConnection(conString))
                {
                    var sqlQuery = $"SELECT LinhaProdutoId,PlanoProdutoId,SUM(Quantidade) AS Quantidade,SUM(PrecoMedio) AS PrecoMedio, SUM(ValorPlaneado) AS ValorPlaneado,SUM(ValorProposto) AS ValorProposto,MIN(DataPlanoInicio) AS DataPlanoInicio,MAX(DataPlanoFim) AS DataPlanoFim FROM {nameof(PlanoObjectivoComercial)} GROUP BY LinhaProdutoId,PlanoProdutoId";
                    var planos = con.Query<PlanoObjectivoComercial>(sqlQuery);
                    
                    return planos;
                }
            }
           public IObservable<PlanoObjectivoCormecialDto> PiPlanoObjectivoComercial(ResolveEventStreamContext context)
          {
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
             using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"select sum(Quantidade) as Quantidade,month(DataPlanoFim) as Mes from PlanoObjectivoComercial GROUP BY  month(DataPlanoFim),Quantidade";
                var planos = con.Query<PlanoObjectivoCormecialDto>(sqlQuery);
                
                return planos.ToObservable();
            }
          }
          public IObservable<PlanoCormecialProdutoDto> QuaPlanoObjectivoComercial(ResolveEventStreamContext context)
          {
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
             using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"SELECT sum(Quantidade) as Quantidade,LinhaProduto.Designacao as Produto from PlanoObjectivoComercial ,LinhaProduto  WHERE PlanoObjectivoComercial.LinhaProdutoId=LinhaProduto.IdLinhaProduto   GROUP BY  LinhaProduto.Designacao";
                var planos = con.Query<PlanoCormecialProdutoDto>(sqlQuery);
                
                return planos.ToObservable();
            }
          }
          public IObservable<Sinistrographico> Sinistropessoa(ResolveEventStreamContext context)
          {
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
            using(var con = new SqlConnection(conString))
            {
              string id = context.Arguments["id"] as string;
                var sqlQuery = $"select COUNT(*) as QtdSinistro,LinhaProduto.Designacao as Produto  from Sinistro,Pessoa,LinhaProduto,PlanoProduto where Sinistro.ParticipanteSinistroID=Pessoa.IdPessoa and Sinistro.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto and Pessoa.IdPessoa='{id}' group by LinhaProduto.Designacao ";
                var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                return sinistrs.ToObservable();
            }
         }
          public IObservable<Sinistrographico> Sinistroproduto(ResolveEventStreamContext context)
          {
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
            using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"select COUNT(*) as QtdSinistro,LinhaProduto.Designacao as Produto from Sinistro,Pessoa,LinhaProduto,PlanoProduto where Sinistro.ParticipanteSinistroID=Pessoa.IdPessoa and Sinistro.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto Group by LinhaProduto.Designacao";
                var sinistrs = con.Query<Sinistrographico>(sqlQuery);
                var casted = new ObservableCollection<Sinistrographico>(sinistrs).ToObservable();
                return casted;
            }
         }
         public IObservable<ApoliceGraphico> Apolicepessoa(ResolveEventStreamContext context)
         {     
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
             string id = context.Arguments["id"] as string;
             
             using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"select COUNT(*) as QtdApolice,LinhaProduto.Designacao as Produto from  {nameof(Apolice)},{nameof(Pessoa)},{nameof(LinhaProduto)},{nameof(PlanoProduto)} where Apolice.ProdutorID=Pessoa.IdPessoa and Apolice.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto and Pessoa.IdPessoa='{id}' group by LinhaProduto.Designacao ";
                var apolic = con.Query<ApoliceGraphico>(sqlQuery);
                return apolic.ToObservable();
            }
         }
          public IObservable<ApoliceGraphico> Apoliceproduto(ResolveEventStreamContext context)
         {
           
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
             string id = context.Arguments["id"] as string;
             
             using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"select COUNT(*) as QtdApolice,LinhaProduto.Designacao as Produto from  {nameof(Apolice)},{nameof(Pessoa)},{nameof(LinhaProduto)},{nameof(PlanoProduto)} where Apolice.ProdutorID=Pessoa.IdPessoa and Apolice.PlanoProdutoId=PlanoProduto.IdPlano and PlanoProduto.LinhaProdutoID=LinhaProduto.IdLinhaProduto Group by LinhaProduto.Designacao";
                var apolic = con.Query<ApoliceGraphico>(sqlQuery);
                return apolic.ToObservable();
            }
         }
       
        /// <summary>
        /// TODO: Criar uma store procedure
        /// </summary>
        /// <param name="idLinha"></param>
        /// <returns></returns>
        private LinhaProduto GetLinhaProduto(string idLinha)
        {
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
            using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"SELECT * FROM {nameof(LinhaProduto)} WHERE IdLinhaProduto = @LinhaId;";
                var linha = con.QueryFirst<LinhaProduto>(sqlQuery,new {LinhaId = idLinha});
                
                return linha;
            }
        }

        /// <summary>
        /// TODO: Criar uma store procedure.
        /// </summary>
        /// <param name="idPlano"></param>
        /// <returns></returns>
        private PlanoProduto GetPlano(string idPlano)
        {
#if !DEBUG
            var conString = _configuration["ConnectionStrings:Connection"];
#else
            var conString = _configuration["ConnectionStrings:DefaultConnection"];
#endif
            using(var con = new SqlConnection(conString))
            {
                var sqlQuery = $"SELECT * FROM {nameof(PlanoProduto)} WHERE IdPlano = @PlanoId";
                var plano = con.QueryFirst<PlanoProduto>(sqlQuery,new {PlanoId = idPlano});
                
                return plano;
            }
        }


        // public IObservable<TModel> GetAll<TModel>() where TModel : class
        // {
        //     var value = _stream.GetValueOrDefault(typeof(TModel).Name);

        //     if (value == null)
        //     {
        //         value = new ReplaySubject<object>(1);
        //         _stream.TryAdd(typeof(TModel).Name, value);
        //     }

        //     return value.AsObservable().Cast<TModel>();
        // }

        // public IObservable<TReturn> GetAll<TKey, TReturn>() where TKey : class
        // {
        //     var value = _stream.GetValueOrDefault(typeof(TKey).Name);

        //     if (value == null)
        //     {
        //         value = new ReplaySubject<object>(1);
        //         _stream.TryAdd(typeof(TKey).Name, value);
        //     }

        //     return value.AsObservable().Cast<TReturn>();
        // }
    }
}
