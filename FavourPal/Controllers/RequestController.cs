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
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SendRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendRequest(RequestViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var requestTarget = dbContext.Users.Where(x => x.UserName == model.Email).FirstOrDefault();
            //    var requestSource = dbContext.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            //    if (requestTarget != null)
            //    {
            //        if(requestSource == requestTarget)
            //        {
            //            TempData["RequestCreate"] = "You cannot request money from yourself!";
            //            return RedirectToAction("SendRequest");
            //        }

            //        Request request = new Request
            //        {
            //            RequestFromUser = User.Identity.Name,
            //            RequestToUser = model.Email,
            //            Amount = (decimal)model.Amount,
            //            Accepted = false
            //        };

            //        dbContext.Requests.Attach(request);
            //        request.FK_RequestFrom = requestSource;
            //        request.FK_RequestTo = requestTarget;

            //        requestSource.RequestsFrom = new List<Request>
            //        {
            //            request
            //        };

            //        requestTarget.RequestsTo = new List<Request>
            //        {
            //            request
            //        };

            //        dbContext.SaveChanges();
            //        TempData["RequestCreate"] = "Request was successfully sent!";
            //        return RedirectToAction("SendRequest");
            //    }
            //    TempData["RequestCreate"] = "Recipient email does not exist!";
            //    return RedirectToAction("SendRequest");
            //}
            //TempData["RequestCreate"] = "Model encountered an error!";
            return RedirectToAction("SendRequest");
        }

        public IActionResult ViewRequests()
        {
            //List<RequestViewModel> requestList = new List<RequestViewModel>();
            //string userId = dbContext.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).First();
            //string email = "";

            //var result = dbContext.Requests.Where(x => x.RequestToUser == userId && x.Accepted == false).ToList();
            //foreach(var element in result)
            //{
            //    email = dbContext.Users.Where(x => x.Id == element.RequestFromUser).Select(x => x.UserName).First();
            //    requestList.Add(new RequestViewModel
            //    {
            //        Amount = (double)element.Amount,
            //        Email = email,
            //        RequestId = element.RequestId
            //    });
            //}
            //return View(requestList);
            return View();
        }

        public IActionResult AcceptRequest(RequestViewModel model)
        {
            //var result = dbContext.Requests.Where(x => x.RequestId == model.RequestId).First();
            //var currentUser = dbContext.Users.Where(x => x.UserName == User.Identity.Name).First();
            //var requestFrom = dbContext.Users.Where(x => x.UserName == model.Email).First();
            
            //if (model.Amount <= (double)currentUser.Balance)
            //{
            //    result.Accepted = true;
            //    dbContext.Update(result);
            //    currentUser.Balance -= (decimal)model.Amount;
            //    dbContext.Update(currentUser);
            //    requestFrom.Balance += (decimal)model.Amount;
            //    dbContext.Update(requestFrom);

            //    dbContext.SaveChanges();
            //    return RedirectToAction("CreateDebt", "DebtTake", result);
            //}
            //TempData.Add("RequestOperation", "Can not accept the request: You are short of available money!");
            return RedirectToAction("ViewRequests");
        }

        public IActionResult DeclineRequest(RequestViewModel model)
        {
            //var result = dbContext.Requests.Where(x => x.RequestId == model.RequestId).First();

            //dbContext.Remove(result);
            //dbContext.SaveChanges();

            return RedirectToAction("ViewRequests");
        }
    }
}