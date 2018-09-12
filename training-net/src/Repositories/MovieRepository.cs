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

        public Movie GetMovieWithComments(int id)
        {
             var movie = Context.Set<Movie>().Find(id);
             Context.Entry(movie).Collection(m => m.Comments).Load();
             return movie;
        }
    }
}
