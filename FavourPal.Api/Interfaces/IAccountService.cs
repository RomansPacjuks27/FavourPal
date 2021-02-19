using FavourPal.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavourPal.Api.Interfaces
{
    public interface IAccountService : IBaseService
    {
        Task<Balance> GetBalance();
    }
}
