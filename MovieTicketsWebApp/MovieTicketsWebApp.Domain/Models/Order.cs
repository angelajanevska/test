using EShop.Domain.Identity;
using EShop.Domain.Relations;
using System;
using System.Collections.Generic;

namespace EShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<MovieTicketInOrder> MovieTicketInOrders { get; set; }
    }
}
