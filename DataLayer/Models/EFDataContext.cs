using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataLayer.Models
{
    public class EFDataContext : IdentityDbContext
    {
        public DbSet<Users> _Users { get; set; }
        public DbSet<Requests> _Requests { get; set; }
        public DbSet<DebtTaken> _TakenDebts { get; set; }
        public DbSet<DebtReturned> _ReturnedDebts { get; set; }

        public EFDataContext(DbContextOptions<EFDataContext> options)
    : base(options)
        {
        }

        public EFDataContext()
        {

        }

        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localDB)\MSSQLLocalDb;Initial Catalog=Favour_Pal;Integrated Security=True");
        }
    }
}
