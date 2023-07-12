using MovieTicketsWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Repository.Interface
{
    public interface IShoppingCartRepository
    {
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCarts();
        Task<ShoppingCart> GetShoppingCartById(Guid id);
        Task CreateShoppingCart(ShoppingCart shoppingCart);
        Task UpdateShoppingCart(ShoppingCart shoppingCart);
        Task DeleteShoppingCart(ShoppingCart shoppingCart);
    }
}
