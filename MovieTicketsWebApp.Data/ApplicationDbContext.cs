using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTicketsWebApp.Domain.Identity;

namespace MovieTicketsWebApp.Domain
{
    public class ApplicationDbContext : IdentityDbContext<StandardUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
    }
}
