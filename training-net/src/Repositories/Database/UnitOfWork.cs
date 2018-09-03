using MvcMovie.Repositories.Database;
using Repositories;
using Repositories.Interfaces;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
        }
        public IMovieRepository Movies { get; private set;}
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
