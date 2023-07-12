using MovieTicketsWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Repository.Interface
{
    public interface IMovieTicketRepository
    {
        Task<IEnumerable<MovieTicket>> GetAllMovieTickets();
        Task<MovieTicket> GetMovieTicketById(Guid id);
        Task CreateMovieTicket(MovieTicket movieTicket);
        Task UpdateMovieTicket(MovieTicket movieTicket);
        Task DeleteMovieTicket(MovieTicket movieTicket);
    }
}
