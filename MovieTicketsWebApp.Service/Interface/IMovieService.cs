using MovieTicketsWebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketsWebApp.Service.Interface
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(Guid id);
        Task CreateMovie(Movie movie);
        Task UpdateMovie(Guid id, Movie movie);
        Task DeleteMovie(Guid id);
    }
}
