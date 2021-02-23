using FavourPal.ActionFilter;
using FavourPal.Api.Interfaces;
using FavourPal.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourPal.Controllers
{
    [Authorize]
    [AuthorizeFilter]
    //[PermissionFilter]
    //[AccessExceptionFilter]
    //[ModelValidationFilter]
    [ApiExplorerSettings(IgnoreApi = true)]
    public abstract class BaseController : Controller, IUserContextable
    {
        protected BaseController(params IBaseService[] repositories)
        {
            foreach (var repository in repositories)
            {
                repository.GetAuthorizedUser = GetAuthorizedUser;
            }
        }
        public User AuthorizedUser { get; set; }

        private User GetAuthorizedUser() => AuthorizedUser;
    }
}
