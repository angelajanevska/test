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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await _movieRepository.GetMovieById(id);
        }

        public async Task CreateMovie(Movie movie)
        {
            await _movieRepository.CreateMovie(movie);
        }

        public async Task UpdateMovie(Guid id, Movie movie)
        {
            var existingMovie = await _movieRepository.GetMovieById(id);
            if (existingMovie == null)
            {
                throw new Exception("Movie not found");
            }

            existingMovie.Title = movie.Title;
            existingMovie.StartDate = movie.StartDate;
            existingMovie.EndDate = movie.EndDate;
            existingMovie.Genre = movie.Genre;
            existingMovie.Price = movie.Price;

            await _movieRepository.UpdateMovie(existingMovie);
        }

        public async Task DeleteMovie(Guid id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            await _movieRepository.DeleteMovie(movie);
        }
    }
}
