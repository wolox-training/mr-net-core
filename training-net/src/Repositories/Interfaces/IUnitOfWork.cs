using System;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {   
        IMoviesRepository Movies{ get; }
        int Complete();
    }
}
