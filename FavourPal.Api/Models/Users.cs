using FavourPal.Api.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourPal.Api.Models
{
    [Table("Users", Schema = "dbo")]
    public class User : IdentityUser
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Balance { get; set; }
        
        public List<Transfer> Transfers { get; set; }

        public virtual ICollection<Request> RequestsFrom { get; set; }
        public virtual ICollection<Request> RequestsTo { get; set; }

        public virtual ICollection<DebtReturned> ReturnFrom { get; set; }
        public virtual ICollection<DebtReturned> ReturnTo { get; set; }
    }
}
