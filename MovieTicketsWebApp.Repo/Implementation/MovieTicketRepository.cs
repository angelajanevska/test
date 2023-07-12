using Microsoft.EntityFrameworkCore;
using MovieTicketsWebApp.Domain;
using MovieTicketsWebApp.Domain.Models;
using MovieTicketsWebApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Repository.Implementation
{
    public class MovieTicketRepository : IMovieTicketRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieTicketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MovieTicket>> GetAllMovieTickets()
        {
            return await _dbContext.MovieTickets.ToListAsync();
        }

        public async Task<MovieTicket> GetMovieTicketById(Guid id)
        {
            return await _dbContext.MovieTickets.FindAsync(id);
        }

        public async Task CreateMovieTicket(MovieTicket movieTicket)
        {
            await _dbContext.MovieTickets.AddAsync(movieTicket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMovieTicket(MovieTicket movieTicket)
        {
            _dbContext.Entry(movieTicket).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovieTicket(MovieTicket movieTicket)
        {
            _dbContext.MovieTickets.Remove(movieTicket);
            await _dbContext.SaveChangesAsync();
        }
    }
}
