using FavourPal.Domain.Interfaces;
using FavourPal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavourPal.Api.Services
{
    public class RequestService : BaseService, IRequestService
    {
        protected readonly IFavourPalDbContext dbContext;

        public RequestService(IFavourPalDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Request> SendRequest(Request request)
        {
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
            return null;
        }

        public async Task<Request> CheckRequest(Guid requestId)
        {
            return null;
        }

        public async Task<ICollection<Request>> GetAll()
        {
            var result = await dbContext.Requests.Where(x => x.RecipientUser == AuthorizedUser).ToListAsync();
            return result;
        }
    }
}
