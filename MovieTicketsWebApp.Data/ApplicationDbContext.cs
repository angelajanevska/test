using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTicketsWebApp.Domain.Identity;
using MovieTicketsWebApp.Domain.Models;

namespace MovieTicketsWebApp.Domain
{
    public class ApplicationDbContext : IdentityDbContext<StandardUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieTicket> MovieTickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<MovieTicketShoppingCart> MovieTicketShoppingCarts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StandardUser>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Movie>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieTicket>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieTicketShoppingCart>()
                .HasKey(x => new { x.MovieTicketId, x.ShoppingCartId });

            builder.Entity<MovieTicketShoppingCart>()
                .HasOne(x => x.MovieTicket)
                .WithMany(x => x.MovieTicketShoppingCart)
                .HasForeignKey(x => x.ShoppingCartId);

            builder.Entity<MovieTicketShoppingCart>()
                .HasOne(x => x.ShoppingCart)
                .WithMany(x => x.MovieTicketShoppingCart)
                .HasForeignKey(x => x.MovieTicketId);

            builder.Entity<ShoppingCart>()
                .HasOne<StandardUser>(x => x.Owner)
                .WithOne(x => x.UserShoppingCart)
                .HasForeignKey<ShoppingCart>(x => x.OwnerId);
        }
    }
}
