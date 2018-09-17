using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcMovie.Models;
using Repositories.Interfaces;

namespace Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
    }
}
