using MovieTicketsWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Service.Interface
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCarts();
        Task<ShoppingCart> GetShoppingCartById(Guid id);
        Task CreateShoppingCart(ShoppingCart shoppingCart);
        Task UpdateShoppingCart(Guid id, ShoppingCart shoppingCart);
        Task DeleteShoppingCart(Guid id);
    }
}
