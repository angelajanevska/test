using MovieTicketsWebApp.Domain.Models;
using MovieTicketsWebApp.Repository.Interface;
using MovieTicketsWebApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCarts()
        {
            return await _shoppingCartRepository.GetAllShoppingCarts();
        }

        public async Task<ShoppingCart> GetShoppingCartById(Guid id)
        {
            return await _shoppingCartRepository.GetShoppingCartById(id);
        }

        public async Task CreateShoppingCart(ShoppingCart shoppingCart)
        {
            await _shoppingCartRepository.CreateShoppingCart(shoppingCart);
        }

        public async Task UpdateShoppingCart(Guid id, ShoppingCart shoppingCart)
        {
            var existingShoppingCart = await _shoppingCartRepository.GetShoppingCartById(id);
            if (existingShoppingCart == null)
            {
                throw new Exception("ShoppingCart not found");
            }

            existingShoppingCart.OwnerId = shoppingCart.OwnerId;
            existingShoppingCart.Owner = shoppingCart.Owner;

            await _shoppingCartRepository.UpdateShoppingCart(existingShoppingCart);
        }

        public async Task DeleteShoppingCart(Guid id)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartById(id);
            if (shoppingCart == null)
            {
                throw new Exception("ShoppingCart not found");
            }

            await _shoppingCartRepository.DeleteShoppingCart(shoppingCart);
        }
    }
}
