using FavourPal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavourPal.Domain.Interfaces
{
    public interface IAccountService : IBaseService
    {
        Task<Balance> GetBalance();
    }
}
