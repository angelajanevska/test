using MovieTicketsWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Service.Interface
{
    public interface IMovieTicketService
    {
        Task<IEnumerable<MovieTicket>> GetAllMovieTickets();
        Task<MovieTicket> GetMovieTicketById(Guid id);
        Task CreateMovieTicket(MovieTicket movieTicket);
        Task UpdateMovieTicket(Guid id, MovieTicket movieTicket);
        Task DeleteMovieTicket(Guid id);
    }
}
