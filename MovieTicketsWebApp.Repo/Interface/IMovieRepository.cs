using MovieTicketsWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Repository.Interface
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(Guid id);
        Task CreateMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(Movie movie);
    }
}
