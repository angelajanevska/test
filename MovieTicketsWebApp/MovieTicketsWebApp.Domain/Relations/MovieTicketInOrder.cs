using EShop.Domain.DomainModels;
using System;

namespace EShop.Domain.Relations
{
    public class MovieTicketInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid MovieTicketId { get; set; }
        public MovieTicket MovieTicket { get; set; }
        public int Quantity { get; set; }
    }
}
