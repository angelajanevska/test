using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Domain.Relations;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<EmailMessage> _mailRepository;
        private readonly IRepository<MovieTicketInOrder> _movieTicketInOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<EmailMessage> mailRepository, IRepository<Order> orderRepository, IRepository<MovieTicketInOrder> movieTicketInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _movieTicketInOrderRepository = movieTicketInOrderRepository;
            _mailRepository = mailRepository;
        }


        public bool deleteMovieTicketFromShoppingCart(string userId, Guid movieTicketId)
        {
            if(!string.IsNullOrEmpty(userId) && movieTicketId != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.MovieTicketInShoppingCarts.Where(z => z.MovieTicketId.Equals(movieTicketId)).FirstOrDefault();

                userShoppingCart.MovieTicketInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            if(!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userCard = loggedInUser.UserCart;

                var allMovieTickets = userCard.MovieTicketInShoppingCarts.ToList();

                var allMovieTicketPrices = allMovieTickets.Select(z => new
                {
                    Price = z.CurrentTicket.Price,
                    Quantity = z.Quantity
                }).ToList();

                double totalPrice = 0.0;

                foreach (var item in allMovieTicketPrices)
                {
                    totalPrice += item.Quantity * item.Price;
                }

                var reuslt = new ShoppingCartDto
                {
                    MovieTickets = allMovieTickets,
                    TotalPrice = totalPrice
                };

                return reuslt;
            }
            return new ShoppingCartDto();
        }

        public bool order(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);
                var userCard = loggedInUser.UserCart;

                EmailMessage mail = new EmailMessage();
                mail.MailTo = loggedInUser.Email;
                mail.Subject = "Sucessfuly created order!";
                mail.Status = false;


                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(order);

                List<MovieTicketInOrder> movieTicketsInOrders = new List<MovieTicketInOrder>();

                var result = userCard.MovieTicketInShoppingCarts.Select(z => new MovieTicketInOrder
                {
                    Id = Guid.NewGuid(),
                    MovieTicketId = z.CurrentTicket.Id,
                    MovieTicket = z.CurrentTicket,
                    OrderId = order.Id,
                    Order = order, 
                    Quantity = z.Quantity
                }).ToList();

                StringBuilder sb = new StringBuilder();

                var totalPrice = 0.0;

                sb.AppendLine("Your order is completed. The order conatins: ");

                for (int i = 1; i <= result.Count(); i++)
                {
                    var currentItem = result[i - 1];
                    totalPrice += currentItem.Quantity * currentItem.MovieTicket.Price;
                    sb.AppendLine(i.ToString() + ". " + currentItem.MovieTicket.MovieName + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.MovieTicket.Price);
                }

                sb.AppendLine("Total price for your order: " + totalPrice.ToString());

                mail.Content = sb.ToString();


                movieTicketsInOrders.AddRange(result);

                foreach (var item in movieTicketsInOrders)
                {
                    this._movieTicketInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.MovieTicketInShoppingCarts.Clear();

                this._userRepository.Update(loggedInUser);
                this._mailRepository.Insert(mail);

                return true;
            }

            return false;
        }
    }
}
