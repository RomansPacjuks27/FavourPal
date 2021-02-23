using FavourPal.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavourPal.Api.Interfaces
{
    public interface IRequestService : IBaseService
    {
        Task<Request> SendRequest(Request request);
        Task<Request> CheckRequest(Guid requestId);
        Task<ICollection<Request>> GetAll();
    }
}
