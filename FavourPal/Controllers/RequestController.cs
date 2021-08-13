using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FavourPal.Models;
using FavourPal.Domain.Models;
using FavourPal.Domain.Interfaces;
using AutoMapper;

namespace FavourPal.Controllers
{
    [Authorize]
    public class RequestController : BaseController
    {
        protected readonly IMapper mapper;
        protected readonly IRequestService requestService;
        public RequestController(IRequestService _requestService, IMapper _mapper) : base(_requestService)
        {
            requestService = _requestService;
            mapper = _mapper;
        }

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
            if (ModelState.IsValid)
            {
                requestService.SendRequest(mapper.Map<Request>(model));
            }
            else
            {
                //var errors = ModelState.Select(x => x.Value.Errors).ToList();
                //foreach(var err in errors)
                //{
                //    //fill collection to tempdata
                //}
                return RedirectToAction("SendRequest");
            }

            //    TempData["RequestCreate"] = "Recipient email does not exist!";
            //    return RedirectToAction("SendRequest");
            //}
            //TempData["RequestCreate"] = "Model encountered an error!";
            return RedirectToAction("SendRequest");
        }

        public IActionResult RequestList()
        {
            List<RequestViewModel> requestList = mapper.Map<List<RequestViewModel>>(requestService.GetAll().Result);
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
            return View(requestList);
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