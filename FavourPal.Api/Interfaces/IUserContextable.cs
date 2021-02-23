using FavourPal.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourPal.Api.Interfaces
{
    public interface IUserContextable
    {
        User AuthorizedUser { get; set; }
    }
}
