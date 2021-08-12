using FavourPal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourPal.Domain.Interfaces
{
    public interface IBaseService
    {
        User AuthorizedUser { get; }
        Func<User> GetAuthorizedUser { get; set; }
    }
}
