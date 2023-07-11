namespace MovieTicketsWebApp.Domain.Models
{
    public class MovieTicketShoppingCart
    {
        public Guid MovieTicketId { get; set; }
        public MovieTicket MovieTicket { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
