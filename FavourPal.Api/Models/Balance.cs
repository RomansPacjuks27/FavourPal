using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourPal.Api.Models
{
    public class Balance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; }

        public Guid? UserId { get; set;}

        public virtual User User { get; set; }

        public decimal Owed { get; set; }

        public decimal Lent { get; set; }

        public decimal Amount { get; set; }

        public Balance(decimal _Amount)
        {
            Amount = _Amount;
            Owed = 0;
            Lent = 0;
        }
    }
}
