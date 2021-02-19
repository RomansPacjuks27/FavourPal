using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FavourPal.Models;
using FavourPal.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace FavourPal.Controllers
{
    [Authorize]
    public class DebtController : Controller
    {
        public readonly EFDataContext dbContext = new EFDataContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewDebts()
        {
            List<RequestViewModel> debtList = new List<RequestViewModel>();
            User currentUser = dbContext._Users.Where(x => x.UserName == User.Identity.Name).First();
            User userTo;

            var result = (from x in dbContext._Requests  
                          where
                              x.Accepted == true &&
                              x.RequestFromUser == currentUser.Id &&
                              !dbContext._ReturnedDebts.Any(a => a.RequestId == x.RequestId)
                          select x).ToList();

            foreach (var element in result)
            {
                userTo = dbContext._Users.Where(x => x.Id == element.RequestToUser).First();
                debtList.Add(new RequestViewModel
                {
                    Amount = (double)element.Amount,
                    Email = userTo.UserName,
                    RequestId = element.RequestId
                });
            }
            return View(debtList);
        }

        public IActionResult PayDebt(RequestViewModel model)
        {
            User currentUser = dbContext._Users.Where(x => x.UserName == User.Identity.Name).First();
            User userTo = dbContext._Users.Where(x => x.UserName == model.Email).First();
            Request request = dbContext._Requests.Where(x => x.Id == model.RequestId).First();
            
            if (ModelState.IsValid)
            {
                if (model.Amount > (double)currentUser.Balance)
                {
                    TempData.Add("DebtReturn", "Cannot pay the debt: You are low on available money!");
                    return RedirectToAction("ViewDebts");
                }
                else
                {
                    DebtReturned debtReturned = new DebtReturned()
                    {
                        ReturnFromUser = currentUser.Id,
                        ReturnToUser = userTo.Id,
                        Amount = (decimal)model.Amount
                    };

                    dbContext._ReturnedDebts.Attach(debtReturned);
                    debtReturned.FK_ReturnFrom = currentUser;
                    debtReturned.FK_ReturnTo = userTo;
                    debtReturned.FK_Request = request;

                    currentUser.ReturnFrom = new List<DebtReturned>()
                    {
                        debtReturned
                    };

                    userTo.ReturnTo = new List<DebtReturned>()
                    {
                        debtReturned
                    };

                    request.DebtReturnedId = debtReturned;

                    dbContext._ReturnedDebts.Add(debtReturned);
                    currentUser.Balance -= debtReturned.Amount;
                    dbContext.Update(currentUser);
                    userTo.Balance += debtReturned.Amount;
                    dbContext.Update(userTo);

                    dbContext.SaveChanges();
                    TempData.Add("DebtReturn", "The debt was successfully paid!");
                    return RedirectToAction("ViewDebts");
                }
            }
            TempData.Add("DebtReturn", "Model encountered an error!");
            return RedirectToAction("ViewDebts");
        }
    }
}