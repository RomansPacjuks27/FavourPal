using FavourPal.Api.Interfaces;
using FavourPal.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavourPal.Api.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IFavourPalDbContext dbContext;
        AccountService(IFavourPalDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Balance> GetBalance()
        {
            User currentUser = dbContext._Users.Where(x => x.UserName == AuthorizedUser.UserName).First();

            //var userOwed = (from x in dbContext._TakenDebts join
            //                y in dbContext._Requests on
            //                x.RequestId equals y.RequestId where 
            //                y.RequestFromUser == currentUser.Id && 
            //                y.Accepted == true &&
            //                !dbContext._ReturnedDebts.Any(a => a.RequestId == y.RequestId)
            //                select new
            //                {
            //                    x.Amount
            //                }).ToList().Sum(x => (double)x.Amount);

            //var userlent = (from x in dbContext._TakenDebts join
            //                y in dbContext._Requests on
            //                x.RequestId equals y.RequestId where
            //                y.RequestToUser == currentUser.Id && 
            //                y.Accepted == true &&
            //                !dbContext._ReturnedDebts.Any(a => a.RequestId == y.RequestId)
            //                select new
            //                {
            //                    x.Amount
            //                }).ToList().Sum(z => (double)z.Amount);

            //BalanceViewModel model = new BalanceViewModel()
            //{
            //    Owed = userOwed,
            //    Lent = userlent,
            //    Balance = (double)currentUser.Balance 
            //};

            var res = await dbContext._Balances.FirstOrDefaultAsync(x => x.UserId == new Guid(AuthorizedUser.Id));
            return res;
        }

    }
}
