using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using FavourPal.Models;
using FavourPal.Api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FavourPal.Api.Interfaces;
using AutoMapper;

namespace FavourPal.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        //public readonly EFDataContext dbContext = new EFDataContext();

        private SignInManager<User> signInManager { get; set; }
        private UserManager<User> userInManager { get; set; }
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public AccountController (SignInManager<User> _signInManager, UserManager<User> _userManager, IAccountService _accountService, IMapper _mapper) : base(_accountService)
        {
            this.signInManager = _signInManager;
            this.userInManager = _userManager;
            this.accountService = _accountService;
            this.mapper = _mapper;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    ClaimsIdentity claimid = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Email)});
                    new ClaimsPrincipal(claimid);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid email or password.");
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(UsersViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new User { FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    PasswordHash = model.Password,
                    Balance = new Balance(400)
                };

                var result = await userInManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(IdentityError err in result.Errors)
                    {
                        ModelState.AddModelError("Model error", err.Description);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public ActionResult ViewBalance()
        {
            var balance = mapper.Map<BalanceViewModel>(accountService.GetBalance().Result);
            return View(balance);
        }
    }
}