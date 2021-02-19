using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FavourPal.Api.Interfaces;
using System.Linq;

namespace FavourPal.Api.Models
{
    public class FavourPalDbContext : DbContext, IFavourPalDbContext
    {
        public DbSet<User> _Users { get; set; }
        public DbSet<Request> _Requests { get; set; }
        public DbSet<DebtTaken> _TakenDebts { get; set; }
        public DbSet<DebtReturned> _ReturnedDebts { get; set; }
        public DbSet<Balance> _Balances { get; set; }

        public FavourPalDbContext(DbContextOptions<FavourPalDbContext> options)
    : base(options)
        {
        }

        //public FavourPalDbContext()
        //{

        //}

        //protected override void OnConfiguring (DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Data Source=(localDB)\MSSQLLocalDb;Initial Catalog=Favour_Pal;Integrated Security=True");
        //}


        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();
            foreach (var entity in changedEntriesCopy)
            {
                this.Entry(entity.Entity).State = EntityState.Detached;
            }
        }

        public int SaveContext()
        {
            return SaveChanges();
        }

        void IDbContext.OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.OnConfiguring(optionsBuilder);
        }

        void IDbContext.OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnModelCreating(modelBuilder);
        }
    }
}
