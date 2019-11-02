using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppLayer2.Models
{
    public class BalanceViewModel
    {
        [Display(Name = "Currently owed")]
        [DataType(DataType.Currency)]
        public double Owed { get; set; } = 0.0;

        [Display(Name = "Currently lent")]
        [DataType(DataType.Currency)]
        public double Lent { get; set; } = 0.0;

        [Display(Name = "Balance")]
        [DataType(DataType.Currency)]
        public double Balance { get; set; }
    }
}
