using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.Permissions.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task Set<T>(this IDistributedCache distributedCache, string key, T obj)
        {
            var serializationSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All,
            };
            await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(obj, serializationSettings));
        }

        public static async Task<T> Get<T>(this IDistributedCache distributedCache, string key)
        {
            var content = await distributedCache.GetStringAsync(key);
            var serializationSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
            return JsonConvert.DeserializeObject<T>(content, serializationSettings);
        }
    }
}
