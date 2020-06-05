using Dapper;
using ISS.Application;
using ISS.Application.Extensions;
using ISS.Application.Helpers;
using ISS.Application.LinqToDb;
using ISS.Application.Models;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace ISS.GraphQL.Repository
{
    // TODO: Add the logs
    public class Repository : IRepository
    {
        #region Private Fields
        private readonly ISubscriptionRepository _subsRepo;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<Repository> _logger;
        #endregion
        
        #region Constructor
        public Repository(ISubscriptionRepository subsRepo,
                          IServiceScopeFactory scopeFactory,
                          ILogger<Repository> logger)   
        {
            _subsRepo = subsRepo;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        #endregion

        /// <summary>
        /// Auxilia na captura de erros.
        /// </summary>
        /// <param name="ex">Excepções a serem geradas.</param>
        /// <param name="globalErrors">Erros globais capturados.</param>
        /// <returns>Uma lista de erros em formato de string.</returns>
        private IEnumerable<string> Catch(Exception ex, IEnumerable<string> globalErrors = null)
        {
            // An aux list to store the error
            var errors = new List<string>
            {
                // Adding the main error details
                ex.Message
            };

            // Checking if we got some globalErrors
            if (globalErrors != null)
                // Adding them
                errors.AddRange(globalErrors);

            // Checking if the inner exception is not null
            if (ex.InnerException != null)
                // Adding the inner exception details
                errors.Add(ex.InnerException.Message);

            // Returning the value
            return errors;
        }

        #region Try and Catch structure for all

        public async Task<RepoResponse<T>> TryCatch<T>(Func<Task<RepoResponse<T>>> func, IEnumerable<string> globalErrors = null) where T : class
        {
            try
            {
                return await func.Invoke();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                await Task.Delay(0);
                // Returning the value
                return new RepoResponse<T>
                {
                    Errors = Catch(ex, globalErrors)
                };
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await Task.Delay(0);
                // Returning the value
                return new RepoResponse<T>
                {
                    Errors = Catch(ex, globalErrors)
                };
            }
            catch (Exception ex)
            {
                await Task.Delay(0);
                // Returning the value
                return new RepoResponse<T>
                {
                    Errors = Catch(ex, globalErrors)
                };
            }
        }
        #endregion

        public async Task AddAsync<T>(T model) where T : class
        {
            // Gerar excepção em caso de Model nulo.
            if (model == null)
                throw new ArgumentNullException("The model object is not defined");
            
            // Trying and calling the main function
            await TryCatch(async () =>
            {
                // TODO: Verificar sucesso do Insert.
                //await linqDbContext.ExecuteAsync(SqlQueries.Insert(model));
                // await Db.InsertAsync(model);
                await _scopeFactory.ExecuteInScopeAsync<T>(async provider =>
                {
                    var con = provider.GetService<SqlConnection>();
                    await con.InsertAsync(model);
                    return model;
                });

                _subsRepo.Push(model);

                // inserting the object the object and Returning the value
                return new RepoResponse<T>
                {
                    Data = model
                };
            });
        }

        public async Task<RepoResponse<IEnumerable<T>>> GetAsync<T>(Func<IEnumerable<T>, IEnumerable<T>> func = null) where T : class
        {
            // Trying and calling the main function
            return await TryCatch(async () =>
            {
                func ??= (func = f => f);
                
                var result = await _scopeFactory.ExecuteInScopeAsync<IEnumerable<T>>(async provider => 
                {
                    var con = provider.GetService<SqlConnection>();
                    return await con.GetAsync<T>();
                });
                // Returning the value
                return new RepoResponse<IEnumerable<T>>
                {
                    // Getting all the objects and Returning the value
                    Data = func(result)
                };
            });
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador do valor a ser pego.</param>
        /// <param name="consts">Atributo usado como identificador.</param>
        /// <typeparam name="T"></typeparam>
        public async Task<T> GetAsync<T>(string id, string consts = null) where T : class
        {
            // Verificar se o argumento passado é nulo, se sim lançar
            // uma execpção.
            if(id == null)
                return null;
            
            var result = await _scopeFactory.ExecuteInScopeAsync<IEnumerable<T>>( async provider =>
            {
                var connection = provider.GetService<SqlConnection>();
                return await connection.GetAsync<T>();
            });

            // Returning the value
            return result.FirstOrDefault(x => x.HasValue(id, consts));
        }

        public async Task<RepoResponse<IEnumerable<T>>> GetWhereAsync<T>(string consts, string id, bool? search = null, string orderby = null, bool asc = true) where T : class
        {
            // Trying and calling the main function
            return await TryCatch(async () =>
            {
                // Getting the data
                var result = await _scopeFactory.ExecuteInScopeAsync(async provider =>
                {
                    var connection = provider.GetService<SqlConnection>();
                    return await connection.GetAsync<T>();
                });
                
                // Retornando o valor.
                return new RepoResponse<IEnumerable<T>>
                {
                    // Buscar por todos os objectos que vão de acordo as condições passadas.
                    Data = result.Where(x => id == null ? true : ((search ?? false) ? x.ContainValue(id, consts) : x.HasValue(id, consts)))?.OrderBy(orderby, asc).ToList()
                };

            });

        }

        public async Task RemoveAsync<T>(string id) where T : class
        {
            // Checking the id
            _ = id ?? throw new ArgumentNullException(nameof(id));

            // Getting the model
            var model = await GetAsync<T>(id);

            // Checking if we got some errors
            _ = model ?? throw new Exception($"Something happened while getting the object '{typeof(T).Name}' with id '{id}'.");

            // Removing  and Returning the value
            await _scopeFactory.ExecuteInScopeAsync(async provider => 
            {
                var connection = provider.GetService<SqlConnection>();
                return await connection.RemoveAsync(model, id);
            });
        }

        public async Task UpdateAsync<T>(string id, T model) where T : class
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            // Getting the model
            var dbModel = await GetAsync<T>(id);

            // Verificando o model vindo da BD é válido.
            _ = dbModel ?? throw new Exception($"Something happened while getting the object '{typeof(T).Name}' with id '{id}'.");

            // Setting up the diferences
            dbModel.UpdateFrom(model);

            await _scopeFactory.ExecuteInScopeAsync(async provider => 
            {
                var connection = provider.GetService<SqlConnection>();
                await connection.UpdateAsync(dbModel,id);
            });
        }

        public TResult ExecuteQuery<TResult>(Func<LinqDbContext, TResult> func) where TResult : class
        {
            return _scopeFactory.ExecuteInScope<TResult>( provider => 
            {
                return func(provider.GetService<LinqDbContext>());
            });
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(Func<LinqDbContext, Task<TResult>> func)
        {
            return await _scopeFactory.ExecuteInScopeAsync<TResult>( provider => 
            {
                return func(provider.GetService<LinqDbContext>());
            });
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<IServiceProvider, Task<TResult>> func) where TResult : class
        {
            return await _scopeFactory.ExecuteInScopeAsync<TResult>( provider => 
            {
                return func(provider);
            });
        }

        // TODO: Reanalisar este metódo.
        public async Task<RepoResponse<IEnumerable<TReturn>>> GetAsync<TRelation, TReturn>(string prop1,string prop2)
            where TRelation : class
            where TReturn : class
        {
            return await _scopeFactory.ExecuteInScopeAsync(async provider =>
            {
                var ctx = provider.GetService<DapperContext>();

                var res = await ctx.Connection.QueryAsync<TReturn>(@$"SELECT F2.* FROM {typeof(TRelation).Name} F1 INNER JOIN {typeof(TReturn).Name} F2
                                                  ON F1.{prop1} = F2.{prop2}");


                return new RepoResponse<IEnumerable<TReturn>> { Data = res };
            });
        }
    }
}