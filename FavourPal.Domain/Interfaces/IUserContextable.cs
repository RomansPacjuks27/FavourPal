using FavourPal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourPal.Domain.Interfaces
{
    public interface IUserContextable
    {
        User AuthorizedUser { get; set; }
    }
}
