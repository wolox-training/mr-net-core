using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Repositories;
using Repositories.Interfaces;

namespace Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

        public DbContext DbContext{ get { return Context as DbContext; } }

        // IEnumerable<Comment> ICommentRepository.GetMovieComments(int id)
        // {
        //     return Context.Set<Comment>().Where(m => m.mo).ToList();
        // }
    }
}
