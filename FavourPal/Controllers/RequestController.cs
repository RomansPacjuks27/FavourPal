using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FavourPal.Models;
using FavourPal.Api.Models;

namespace FavourPal.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        public readonly EFDataContext dbContext = new EFDataContext();

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LoanMoney()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoanMoney(RequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var requestTarget = dbContext._Users.Where(x => x.UserName == model.Email).FirstOrDefault();
                var requestSource = dbContext._Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                if (requestTarget != null)
                {
                    if(requestSource == requestTarget)
                    {
                        TempData["RequestCreate"] = "You cannot request money from yourself!";
                        return RedirectToAction("LoanMoney");
                    }

                    Request request = new Request
                    {
                        RequestFromUser = User.Identity.Name,
                        RequestToUser = model.Email,
                        Amount = (decimal)model.Amount,
                        Accepted = false
                    };

                    dbContext._Requests.Attach(request);
                    request.FK_RequestFrom = requestSource;
                    request.FK_RequestTo = requestTarget;

                    requestSource.RequestsFrom = new List<Request>
                    {
                        request
                    };

                    requestTarget.RequestsTo = new List<Request>
                    {
                        request
                    };

                    dbContext.SaveChanges();
                    TempData["RequestCreate"] = "Request was successfully sent!";
                    return RedirectToAction("LoanMoney");
                }
                TempData["RequestCreate"] = "Recipient email does not exist!";
                return RedirectToAction("LoanMoney");
            }
            TempData["RequestCreate"] = "Model encountered an error!";
            return RedirectToAction("LoanMoney");
        }

        public IActionResult ViewRequests()
        {
            List<RequestViewModel> requestList = new List<RequestViewModel>();
            string userId = dbContext._Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).First();
            string email = "";
            
            var result = dbContext._Requests.Where(x => x.RequestToUser == userId && x.Accepted == false).ToList();
            foreach(var element in result)
            {
                email = dbContext._Users.Where(x => x.Id == element.RequestFromUser).Select(x => x.UserName).First();
                requestList.Add(new RequestViewModel
                {
                    Amount = (double)element.Amount,
                    Email = email,
                    RequestId = element.RequestId
                });
            }
            return View(requestList);
        }

        public IActionResult AcceptRequest(RequestViewModel model)
        {
            var result = dbContext._Requests.Where(x => x.RequestId == model.RequestId).First();
            var currentUser = dbContext._Users.Where(x => x.UserName == User.Identity.Name).First();
            var requestFrom = dbContext._Users.Where(x => x.UserName == model.Email).First();
            
            if (model.Amount <= (double)currentUser.Balance)
            {
                result.Accepted = true;
                dbContext.Update(result);
                currentUser.Balance -= (decimal)model.Amount;
                dbContext.Update(currentUser);
                requestFrom.Balance += (decimal)model.Amount;
                dbContext.Update(requestFrom);

                dbContext.SaveChanges();
                return RedirectToAction("CreateDebt", "DebtTake", result);
            }
            TempData.Add("RequestOperation", "Can not accept the request: You are short of available money!");
            return RedirectToAction("ViewRequests");
        }

        public IActionResult DeclineRequest(RequestViewModel model)
        {
            var result = dbContext._Requests.Where(x => x.RequestId == model.RequestId).First();

            dbContext.Remove(result);
            dbContext.SaveChanges();

            return RedirectToAction("ViewRequests");
        }
    }
}