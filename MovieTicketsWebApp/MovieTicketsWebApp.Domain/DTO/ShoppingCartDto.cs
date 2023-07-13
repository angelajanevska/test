using EShop.Domain.Relations;
using System.Collections.Generic;

namespace EShop.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<MovieTicketInShoppingCart> MovieTickets { get; set; }

        public double TotalPrice { get; set; }
    }
}
