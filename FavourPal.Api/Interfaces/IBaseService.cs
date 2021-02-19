using FavourPal.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourPal.Api.Interfaces
{
    public interface IBaseService
    {
        User AuthorizedUser { get; }
        Func<User> GetAuthorizedUser { get; set; }
    }
}
