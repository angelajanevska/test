using MovieTicketsWebApp.Domain.Models;
using MovieTicketsWebApp.Repository.Interface;
using MovieTicketsWebApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Service.Implementation
{
    public class MovieTicketService : IMovieTicketService
    {
        private readonly IMovieTicketRepository _movieTicketRepository;

        public MovieTicketService(IMovieTicketRepository movieTicketRepository)
        {
            _movieTicketRepository = movieTicketRepository;
        }

        public async Task<IEnumerable<MovieTicket>> GetAllMovieTickets()
        {
            return await _movieTicketRepository.GetAllMovieTickets();
        }

        public async Task<MovieTicket> GetMovieTicketById(Guid id)
        {
            return await _movieTicketRepository.GetMovieTicketById(id);
        }

        public async Task CreateMovieTicket(MovieTicket movieTicket)
        {
            await _movieTicketRepository.CreateMovieTicket(movieTicket);
        }

        public async Task UpdateMovieTicket(Guid id, MovieTicket movieTicket)
        {
            var existingMovieTicket = await _movieTicketRepository.GetMovieTicketById(id);
            if (existingMovieTicket == null)
            {
                throw new Exception("Movie ticket not found");
            }

            existingMovieTicket.Movie = movieTicket.Movie;
            existingMovieTicket.MovieTicketShoppingCart = movieTicket.MovieTicketShoppingCart;

            await _movieTicketRepository.UpdateMovieTicket(existingMovieTicket);
        }

        public async Task DeleteMovieTicket(Guid id)
        {
            var movieTicket = await _movieTicketRepository.GetMovieTicketById(id);
            if (movieTicket == null)
            {
                throw new Exception("Movie ticket not found");
            }

            await _movieTicketRepository.DeleteMovieTicket(movieTicket);
        }
    }
}
