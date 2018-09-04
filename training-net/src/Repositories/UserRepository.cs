using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Repositories.Database;
using NetCoreBootstrap.Models.Database;

namespace NetCoreBootstrap.Repositories
{
    public class UserRepository
    {
        private readonly DbContextOptions<DataBaseContext> _options;
        private readonly UserManager<User> _userManager;

        public UserRepository(DbContextOptions<DataBaseContext> options, UserManager<User> userManager)
        {
            this._options = options;
            this._userManager = userManager;
        }

        public UserManager<User> UserManager
        {
            get { return this._userManager; }
        }


        public DataBaseContext Context
        {
            get { return new DataBaseContext(this._options); }
        }

        public async Task<User> GetUserById(string id)
        {
            return await UserManager.FindByIdAsync(id);
        }

        public List<User> GetAllUsers()
        {
            return UserManager.Users.ToList();
        }
        
        public List<SelectListItem> GetUsersListItem()
        {
            return (from user in UserManager.Users.OrderBy(u => u.Email) select new SelectListItem { Text = user.Email, Value = user.Id }).ToList();
        }
    }
}