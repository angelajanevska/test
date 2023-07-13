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
    public class MovieTicketService : IMovieTicketService
    {
        private readonly IRepository<MovieTicket> _movieTicketRepository;
        private readonly IRepository<MovieTicketInShoppingCart> _movieTicketInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public MovieTicketService(IRepository<MovieTicket> movieTicketRepository, IRepository<MovieTicketInShoppingCart> movieTicketInShoppingCartRepository, IUserRepository userRepository)
        {
            _movieTicketRepository = movieTicketRepository;
            _userRepository = userRepository;
            _movieTicketInShoppingCartRepository = movieTicketInShoppingCartRepository;
        }


        public bool AddToShoppingCart(AddToShoppingCardDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.SelectedMovieTicketId != null && userShoppingCard != null)
            {
                var ticket = this.GetDetailsForMovieTicket(item.SelectedMovieTicketId);

                if (ticket != null)
                {
                    MovieTicketInShoppingCart itemToAdd = new MovieTicketInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        CurrentTicket = ticket,
                        MovieTicketId = ticket.Id,
                        UserCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    var existing = userShoppingCard.MovieTicketInShoppingCarts.Where(z => z.ShoppingCartId == userShoppingCard.Id && z.MovieTicketId == itemToAdd.MovieTicketId).FirstOrDefault();

                    if(existing != null)
                    {
                        existing.Quantity += itemToAdd.Quantity;
                        this._movieTicketInShoppingCartRepository.Update(existing);

                    }
                    else
                    {
                        this._movieTicketInShoppingCartRepository.Insert(itemToAdd);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewMovieTicket(MovieTicket p)
        {
            this._movieTicketRepository.Insert(p);
        }

        public void DeleteMovieTicket(Guid id)
        {
            var ticket = this.GetDetailsForMovieTicket(id);
            this._movieTicketRepository.Delete(ticket);
        }

        public List<MovieTicket> GetAllMovieTickets()
        {
            return this._movieTicketRepository.GetAll().Where(x => x.MovieDateTime >= DateTime.UtcNow).ToList();
        }

        public MovieTicket GetDetailsForMovieTicket(Guid? id)
        {
            return this._movieTicketRepository.Get(id);
        }

        public AddToShoppingCardDto GetShoppingCartInfo(Guid? id)
        {
            var ticket = this.GetDetailsForMovieTicket(id);
            AddToShoppingCardDto model = new AddToShoppingCardDto
            {
                SelectedMovieTicket = ticket,
                SelectedMovieTicketId = ticket.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdateExistingMovieTicket(MovieTicket p)
        {
            this._movieTicketRepository.Update(p);
        }
    }
}
