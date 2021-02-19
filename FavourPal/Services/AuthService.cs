using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FavourPal.Services
{
    public class AuthService
    {
        protected HttpClient httpClient;

        public AuthService(HttpClient _HttpClient)
        {
            _HttpClient.BaseAddress = new Uri("https://localhost:65009/");
            _HttpClient.DefaultRequestHeaders.Clear();
            _HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient = _HttpClient;
        }

        //public HttpResponseMessage Login()
        //{

        //}

        //public HttpResponseMessage Logout()
        //{

        //}

        //public HttpResponseMessage Signup()
        //{

        //}
    }
}
