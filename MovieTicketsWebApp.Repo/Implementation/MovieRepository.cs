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
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }

        public async Task CreateMovie(Movie movie)
        {
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMovie(Movie movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
