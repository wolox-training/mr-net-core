using System;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {   
        IMovieRepository Movies{ get; }
        int Complete();
    }
}
