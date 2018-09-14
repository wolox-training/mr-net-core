using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using Repositories.Interfaces;

namespace MvcMovie.Controllers
{
    [Route("api/v1/Comments")]
    public class CommentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork { get { return this._unitOfWork; } }
        public CommentsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult AddComment(string text, string rating)
        {
            var Comment = new Comment { Text = text, Rating = rating };
            return View();
        }
    }
}