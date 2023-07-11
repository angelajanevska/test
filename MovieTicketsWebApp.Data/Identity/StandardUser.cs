using Microsoft.AspNetCore.Identity;

namespace MovieTicketsWebApp.Domain.Identity
{
    public class StandardUser : IdentityUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
}
