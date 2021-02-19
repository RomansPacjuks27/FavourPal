using FavourPal.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourPal.Api.Interfaces
{
    public interface IFavourPalDbContext : IDbContext
    {
        DbSet<User> _Users { get; set; }
        DbSet<Request> _Requests { get; set; }
        DbSet<DebtTaken> _TakenDebts { get; set; }
        DbSet<DebtReturned> _ReturnedDebts { get; set; }
        DbSet<Balance> _Balances { get; set; }

        void DetachAllEntities();
    }
}
