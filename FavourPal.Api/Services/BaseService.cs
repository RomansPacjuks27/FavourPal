using System;
using System.Collections.Generic;
using System.Text;
using FavourPal.Api.Interfaces;
using FavourPal.Api.Models;

namespace FavourPal.Api.Services
{
    public abstract class BaseService : IBaseService
    {
        protected BaseService(IDbContext db)
        {
            this.db = db;
        }

        protected IDbContext db { get; }

        public Func<User> GetAuthorizedUser { get; set; }

        public User AuthorizedUser => GetAuthorizedUser();

        public string GetCurrentUserEmail()
        {
            return AuthorizedUser.Email;
        }
    }
}
