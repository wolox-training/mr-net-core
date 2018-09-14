using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using Repositories.Interfaces;

namespace MvcMovie.Controllers
{
    [Route("api/v1/[controller]")]
    public class CommentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork { get { return this._unitOfWork; } }
        public CommentsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("AddComment")]        
        public IActionResult AddComment(int id, string text, string rating)
        {
            var movie = UnitOfWork.MovieRepository.Get(id);
            var comment = new Comment { Text = text, Date = DateTime.Today, Rating = rating, Movie = movie };
            UnitOfWork.CommentRepository.Add(comment);
            UnitOfWork.Complete();
            return Json(new { Message = "New comment added", Date = DateTime.Now.ToString("MM/dd/yyyy")});
        }
    }
}