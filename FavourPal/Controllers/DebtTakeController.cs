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
    public class DebtTakeController : Controller
    {
        public readonly EFDataContext dbContext = new EFDataContext();
        
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDebt(Requests model)
        {
            DebtTaken debt = new DebtTaken
            {
                Amount = model.Amount
            };

            dbContext._TakenDebts.Attach(debt);

            debt.FK_RequestId = model;
            model.DebtTakenId = debt;

            dbContext._TakenDebts.Add(debt);
            dbContext.SaveChanges();

            TempData.Add("RequestOperation", String.Format("Request has been accepted: You lent {0:C}!", model.Amount));
            return RedirectToAction("ViewRequests", "Request");
        }
    }
}