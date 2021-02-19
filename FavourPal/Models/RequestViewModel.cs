﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FavourPal.Models
{
    public class RequestViewModel
    {
        [Display(Name = "Request ID")]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Amount is required!")]
        public decimal Amount { get; set; }
    }
}
