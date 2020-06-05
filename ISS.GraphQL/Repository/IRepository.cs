using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ISS.Application.LinqToDb;
using LinqToDB;

namespace ISS.GraphQL.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Criar um determinado registro do objecto passado na base de dados.
        /// </summary>
        /// <typeparam name="T">O tipo de objecto, que geralmente refere-se ao nome da tabela.</typeparam>
        Task AddAsync<T>(T model) where T : class;
        
        /// <summary>
        /// Buscar por vários objectos de um determinado tipo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        Task<RepoResponse<IEnumerable<T>>> GetAsync<T>(Func<IEnumerable<T>, IEnumerable<T>> func = null) where T : class;

        Task<RepoResponse<IEnumerable<TReturn>>> GetAsync<TRelation, TReturn>(string prop1, string prop2)
            where TRelation : class
            where TReturn : class;

        /// <summary>
        /// Buscar por um objecto baseado no seu Id.
        /// </summary>
        /// <param name="id">Nome da propriedade usado como filtro.</param>
        /// <param name="consts">A condição a ser aplicada sobre uma determinada propriedade.</param>
        /// <returns>Objecto baseado nas condições passadas.</returns>
        Task<T> GetAsync<T>(string id, string consts = null) where T : class;

        /// <summary>
        /// Buscar por vários objectos baseando-se em uma determinada condição.
        /// </summary>
        /// <param name="consts">A restrição a ser aplicada sobre a propriedade.</param>
        /// <param name="id">A propriedade a ser filtrada.</param>
        /// <param name="search"></param>
        /// <param name="orderby"></param>
        /// <param name="asc"></param>
        /// /// </summary>
        /// <typeparam name="T"></typeparam>
        Task<RepoResponse<IEnumerable<T>>> GetWhereAsync<T>(string consts, string id, bool? search, string orderby, bool asc) where T : class;

        /// <summary>
        /// Remove one object
        /// </summary>
        /// <param name="id">the Id of the object</param>
        /// <returns>the removed object</returns>
        Task RemoveAsync<T>(string id) where T : class;

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateAsync<T>(string id, T model) where T : class;

        Task<TResult> ExecuteQueryAsync<TResult>(Func<LinqDbContext,Task<TResult>> func);
        TResult ExecuteQuery<TResult>(Func<LinqDbContext,TResult> func) where TResult : class;
        Task<TResult> ExecuteAsync<TResult>(Func<IServiceProvider, Task<TResult>> func) where TResult : class;
    }
}
