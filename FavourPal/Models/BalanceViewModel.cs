using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FavourPal.Models
{
    public class BalanceViewModel
    {
        [Display(Name = "Currently owed")]
        [DataType(DataType.Currency)]
        public decimal Owed { get; set; }

        [Display(Name = "Currently lent")]
        [DataType(DataType.Currency)]
        public decimal Lent { get; set; }

        [Display(Name = "Balance Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}
