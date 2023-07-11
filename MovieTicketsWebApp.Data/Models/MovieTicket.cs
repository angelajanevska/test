using System.ComponentModel.DataAnnotations;

namespace MovieTicketsWebApp.Domain.Models
{
    public class MovieTicket
    {
        public Guid Id { get; set; }
        [Required]
        public Movie Movie { get; set; }
        public virtual ICollection<MovieTicketShoppingCart> MovieTicketShoppingCart { get; set; }
    }
}
