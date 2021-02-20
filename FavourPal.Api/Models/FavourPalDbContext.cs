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
    public class FavourPalDbContext : IdentityDbContext<User>, IFavourPalDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        public FavourPalDbContext(DbContextOptions<FavourPalDbContext> options)
    : base(options)
        {
        }

        //public FavourPalDbContext()
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localDB)\MSSQLLocalDb;Initial Catalog=Favour_Pal;Integrated Security=True", b => b.MigrationsAssembly("FavourPal"));
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(user => user.Transfers)
                .WithOne(x => x.SenderUser)
                .HasForeignKey(x => x.SenderUserId);

            modelBuilder.Entity<User>().HasOne(user => user.Balance)
                .WithOne(balance => balance.User)
                .HasForeignKey<Balance>(balance => balance.UserId);

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().HasMany(user => user.Transfers)
            //    .WithOne(x => x.RecipientUser)
            //    .HasForeignKey(x => x.RecipientUserId);
        }


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
