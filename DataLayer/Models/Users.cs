using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    [Table("Users", Schema = "dbo")]
    public class Users : IdentityUser
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Balance { get; set; } = 400;
        
        public virtual ICollection<Requests> RequestsFrom { get; set; }
        public virtual ICollection<Requests> RequestsTo { get; set; }

        public virtual ICollection<DebtReturned> ReturnFrom { get; set; }
        public virtual ICollection<DebtReturned> ReturnTo { get; set; }
    }
}
