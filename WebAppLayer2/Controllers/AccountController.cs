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
using WebAppLayer2.Models;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAppLayer2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public readonly EFDataContext dbContext = new EFDataContext();

        private SignInManager<Users> signInManager { get; set; }
        private UserManager<Users> userInManager { get; set; }

        public AccountController (SignInManager<Users> _signInManager, UserManager<Users> _userManager)
        {
            this.signInManager = _signInManager;
            this.userInManager = _userManager;
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
                var user = new Users { FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    PasswordHash = model.Password,
                    Balance = 400  
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
            Users currentUser = dbContext._Users.Where(x => x.UserName == User.Identity.Name).First();
            
            var userOwed = (from x in dbContext._TakenDebts join
                            y in dbContext._Requests on
                            x.RequestId equals y.RequestId where 
                            y.RequestFromUser == currentUser.Id && 
                            y.Accepted == true &&
                            !dbContext._ReturnedDebts.Any(a => a.RequestId == y.RequestId)
                            select new
                            {
                                x.Amount
                            }).ToList().Sum(x => (double)x.Amount);

            var userlent = (from x in dbContext._TakenDebts join
                            y in dbContext._Requests on
                            x.RequestId equals y.RequestId where
                            y.RequestToUser == currentUser.Id && 
                            y.Accepted == true &&
                            !dbContext._ReturnedDebts.Any(a => a.RequestId == y.RequestId)
                            select new
                            {
                                x.Amount
                            }).ToList().Sum(z => (double)z.Amount);

            BalanceViewModel model = new BalanceViewModel()
            {
                Owed = userOwed,
                Lent = userlent,
                Balance = (double)currentUser.Balance 
            };

            return View(model);
        }
    }
}