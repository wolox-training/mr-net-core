using System;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {   
        IMovieRepository MovieRepository{ get; }
        int Complete();
    }
}
