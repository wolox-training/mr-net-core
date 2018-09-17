using MvcMovie.Models;
using Repositories.Interfaces;

namespace Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieWithComments(int id);
    }
}
