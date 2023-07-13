using EShop.Domain.Relations;
using MovieTicketsWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Domain.DomainModels
{
    public class MovieTicket : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public DateTime MovieDateTime { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double MovieRating { get; set; }


        public virtual ICollection<MovieTicketInShoppingCart> MovieTicketInShoppingCarts { get; set; }
        public virtual ICollection<MovieTicketInOrder> MovieTicketInOrders { get; set; }

    }
}
