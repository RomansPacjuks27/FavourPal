using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FavourPal.Api.Controllers
{
    [ApiController]
    class AccountController : Controller
    {
        public AccountController()
        {

        }

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
