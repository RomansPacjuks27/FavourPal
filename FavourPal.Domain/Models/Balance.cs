using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourPal.Domain.Models
{
    public class Balance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public string UserId { get; set;}

        public virtual User User { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Owed { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Lent { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public Balance()
        {

        }

        public Balance(decimal _Amount)
        {
            this.Amount = _Amount;
            this.Owed = 0;
            this.Lent = 0;
        }
    }
}
