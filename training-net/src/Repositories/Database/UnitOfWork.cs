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
            MovieRepository = new MovieRepository(_context);
            CommentRepository = new CommentRepository(_context);
        }
        public IMovieRepository MovieRepository { get; private set;}
        public ICommentRepository CommentRepository { get; private set;}
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
