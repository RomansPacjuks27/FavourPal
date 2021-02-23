using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FavourPal.Models
{
    public class RequestViewModel
    {
        [Display(Name = "Request ID")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Amount is required!")]
        public decimal AmountRequested { get; set; }

        public decimal AmountPaid { get; set; }

        public string Message { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
    }
}
