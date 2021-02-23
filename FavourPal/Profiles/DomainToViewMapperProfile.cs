using AutoMapper;
using FavourPal.Api.Models;
using FavourPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourPal.Profiles
{
    public class DomainToViewMapperProfile : Profile
    {
        public DomainToViewMapperProfile()
        {
            CreateMap<Balance, BalanceViewModel>();
        }
    }
}
