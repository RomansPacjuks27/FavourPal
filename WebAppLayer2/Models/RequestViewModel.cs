using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppLayer2.Models
{
    public class RequestViewModel
    {
        [Display(Name = "Request ID")]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Amount is required!")]
        [DataType(DataType.Currency)]
        [Range(0.01, 10000000)]
        public double Amount { get; set; }
    }
}
