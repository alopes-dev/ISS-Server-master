using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ISWebLib
{
    ///<summary>
    /// Definindo os metódos padrões para lidar com serviços de caching.
    ///</summary>
    public interface IDistributedCacheService
    {
        ///<summary>
        /// Enviar dados para a cache baseado em uma key.
        ///</summary>
        Task SetAsync<TModel>(string key, TModel model, double seconds = 60.0) where TModel : class;
        ///<summary>
        /// Pegar dos dados da cache baseado em uma key.
        ///</summary>
        Task<string> GetAsync(string key);
        Task<bool> ContainsKey(string key);
    }

    /// <summary>
    /// Implementação do serviço de caching.
    /// </summary>
    public class RedisDistributedCacheService : IDistributedCacheService
    {
        #region Private Members
        /// <summary>
        /// Serviço padrão de caching disponibilizado pela framework.
        /// </summary>
        private readonly IDistributedCache _distributedCache;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Padrão.
        /// </summary>
        public RedisDistributedCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        #endregion

        public async Task<string> GetAsync(string key)
        {
            try
            {
                var model = await _distributedCache.GetStringAsync(key);
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task SetAsync<TModel>(string key, TModel model, double seconds = 60.0) where TModel : class
        {
            var value = JsonConvert.SerializeObject(model);
            try
            {
                await _distributedCache.SetStringAsync(key, value, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(seconds)
                });
            }
            catch (Exception)
            {
            }
        }

        public async Task<bool> ContainsKey(string key)
        {
            try
            {
                var value = await _distributedCache.GetStringAsync(key);
                return !string.IsNullOrEmpty(value);
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
