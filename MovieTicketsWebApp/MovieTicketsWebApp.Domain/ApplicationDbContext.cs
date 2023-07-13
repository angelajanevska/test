using EShop.Domain.DomainModels;
using EShop.Domain.Identity;
using EShop.Domain.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieTicket> MovieTickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCards { get; set; }
        public virtual DbSet<MovieTicketInShoppingCart> MovieTicketInShoppingCarts { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MovieTicket>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieTicketInShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieTicketInShoppingCart>()
                .HasOne(z => z.CurrentTicket)
                .WithMany(z => z.MovieTicketInShoppingCarts)
                .HasForeignKey(z => z.MovieTicketId);

            builder.Entity<MovieTicketInShoppingCart>()
                .HasOne(z => z.UserCart)
                .WithMany(z => z.MovieTicketInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<ShoppingCart>()
                .HasOne<ApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);

            builder.Entity<MovieTicketInOrder>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieTicketInOrder>()
                .HasOne(z => z.MovieTicket)
                .WithMany(z => z.MovieTicketInOrders)
                .HasForeignKey(z => z.MovieTicketId);

            builder.Entity<MovieTicketInOrder>()
                .HasOne(z => z.Order)
                .WithMany(z => z.MovieTicketInOrders)
                .HasForeignKey(z => z.OrderId);
        }
    }
}
