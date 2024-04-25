
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository basketRepository, IDistributedCache cache)
        : IBasketRepository 
    { 
        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            var cachedBasket = await cache.GetStringAsync(username, cancellationToken);

            if(!string.IsNullOrEmpty(cachedBasket)) return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;
            var basket = await basketRepository.GetBasket(username, cancellationToken);
            await cache.SetStringAsync(username, JsonSerializer.Serialize(basket), cancellationToken);
            return basket;  
        }
        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            await basketRepository.StoreBasket(basket, cancellationToken);
            await cache.SetStringAsync(basket.Username, JsonSerializer.Serialize<ShoppingCart>(basket), cancellationToken);
            return basket;
        }
        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            var deletedBasket = await basketRepository.DeleteBasket(username, cancellationToken);
            await cache.RemoveAsync(username, cancellationToken);
            return deletedBasket;
        }           
    }
}
