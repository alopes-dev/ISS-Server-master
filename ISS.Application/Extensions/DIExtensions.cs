using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ISS.Application.Extensions
{
    /// <summary>
    /// Extensions Methods para facilitar o processo de lidar com Service Provider
    /// </summary>
    public static class DIExtensions
    {
        /// <summary>
        /// Criar escopos temporários para executar pequenas tarefas.
        /// </summary>
        /// <typeparam name="TReturnType"> O tipo do resultado a ser retornado pela tarefa. </typeparam>
        /// <param name="factory"> O <see cref="IServiceScopeFactory"/> para criação de escopos e acesso ao <see cref="IServiceProvider"/> </param>
        /// <param name="func"> A tarefa a ser executada dentro do escopo. </param>
        /// <returns></returns>
        public static async Task<TReturnType> ExecuteInScopeAsync<TReturnType>(this IServiceScopeFactory factory,
                                                                               Func<IServiceProvider, Task<TReturnType>> func)
        {
            using (var scope = factory.CreateScope())
            {
                return await func(scope.ServiceProvider);
            }
        }

        public static TReturnType ExecuteInScope<TReturnType>(this IServiceScopeFactory factory,
                                                                               Func<IServiceProvider, TReturnType> func)
        {
            using (var scope = factory.CreateScope())
            {
                return func(scope.ServiceProvider);
            }
        }

        public static async Task ExecuteInScopeAsync(this IServiceScopeFactory factory,
                                                                               Func<IServiceProvider, Task> func)
        {
            using (var scope = factory.CreateScope())
            {
                await func(scope.ServiceProvider);
            }
        }
    }
}
