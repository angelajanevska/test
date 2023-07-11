using MovieTicketsWebApp.Domain.Identity;

namespace MovieTicketsWebApp.Domain.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public StandardUser Owner { get; set; }
        public virtual ICollection<MovieTicketShoppingCart> MovieTicketShoppingCart { get; set; }
    }
}
