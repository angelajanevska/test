using EShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.DTO
{
    public class AddToShoppingCardDto
    {
        public MovieTicket SelectedMovieTicket { get; set; }
        public Guid SelectedMovieTicketId { get; set; }
        public int Quantity { get; set; }
    }
}
