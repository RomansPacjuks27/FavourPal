using FavourPal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourPal.Domain.Interfaces
{
    public interface IFavourPalDbContext : IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Request> Requests { get; set; }
        DbSet<Balance> Balances { get; set; }
        DbSet<Transfer> Transfers { get; set; }

        void DetachAllEntities();
    }
}
