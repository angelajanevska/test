using EShop.Domain.DomainModels;
using System;

namespace EShop.Domain.Relations
{
    public class MovieTicketInShoppingCart : BaseEntity
    {
        public Guid MovieTicketId { get; set; }
        public virtual MovieTicket CurrentTicket { get; set; }

        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart UserCart { get; set; }

        public int Quantity { get; set; }
    }
}
