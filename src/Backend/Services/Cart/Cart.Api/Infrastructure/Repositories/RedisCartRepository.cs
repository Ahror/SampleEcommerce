using Cart.Api.Abstractions.Repositories;
using Cart.Api.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Infrastructure.Repositories
{
    public class RedisCarttRepository : ICartRepository
    {
        private readonly ILogger<RedisCarttRepository> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisCarttRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<RedisCarttRepository>();
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteCartAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public IEnumerable<string> GetUsers()
        {
            var server = GetServer();
            var data = server.Keys();

            return data?.Select(k => k.ToString());
        }

        public async Task<CustomerCart> GetCartAsync(string customerId)
        {
            var data = await _database.StringGetAsync(customerId);

            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CustomerCart>(data);
        }

        public async Task<CustomerCart> UpdateCartAsync(CustomerCart cart)
        {
            var created = await _database.StringSetAsync(cart.BuyerId, JsonConvert.SerializeObject(cart));

            if (!created)
            {
                _logger.LogInformation("Problem occur persisting the item.");
                return null;
            }

            _logger.LogInformation("Cart item persisted succesfully.");

            return await GetCartAsync(cart.BuyerId);
        }

        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }
    }
}
