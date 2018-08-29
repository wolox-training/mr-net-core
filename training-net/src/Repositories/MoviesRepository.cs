using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Repositories;
using Repositories.Interfaces;

namespace Repositories
{
    public class MoviesRepository : Repository<Movie>, IMoviesRepository
    {
        public MoviesRepository(DbContext context) : base(context)
        {
        }
        public DbContext DbContext{ get { return Context as DbContext; } }
    }
}