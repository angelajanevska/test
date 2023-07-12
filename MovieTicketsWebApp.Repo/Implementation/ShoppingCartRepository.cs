using Microsoft.EntityFrameworkCore;
using MovieTicketsWebApp.Domain;
using MovieTicketsWebApp.Domain.Models;
using MovieTicketsWebApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Repository.Implementation
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShoppingCartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCarts()
        {
            return await _dbContext.ShoppingCarts.ToListAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartById(Guid id)
        {
            return await _dbContext.ShoppingCarts.FindAsync(id);
        }

        public async Task CreateShoppingCart(ShoppingCart shoppingCart)
        {
            await _dbContext.ShoppingCarts.AddAsync(shoppingCart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            _dbContext.Entry(shoppingCart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteShoppingCart(ShoppingCart shoppingCart)
        {
            _dbContext.ShoppingCarts.Remove(shoppingCart);
            await _dbContext.SaveChangesAsync();
        }
    }
}
