using System;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IDistributedCache _redisCahe;

        public BasketRepository(IDistributedCache redisCahe)
        {
            this._redisCahe = redisCahe ?? throw new ArgumentNullException(nameof(redisCahe));
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCahe.GetStringAsync(userName);
            return basket == null ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCahe.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCahe.RemoveAsync(userName);
        }

        

       
    }
}

