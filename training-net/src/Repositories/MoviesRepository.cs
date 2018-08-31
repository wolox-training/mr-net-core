using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Repositories;
using Repositories.Interfaces;

namespace Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DbContext context) : base(context)
        {
        }

        public DbContext DbContext{ get { return Context as DbContext; } }
    }
}
