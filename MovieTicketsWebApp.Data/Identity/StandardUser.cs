using Microsoft.AspNetCore.Identity;
using MovieTicketsWebApp.Domain.Models;

namespace MovieTicketsWebApp.Domain.Identity
{
    public class StandardUser : IdentityUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ShoppingCart UserShoppingCart { get; set; }

    }
}
